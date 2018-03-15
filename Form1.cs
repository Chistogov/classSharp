using Classificator.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Classificator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClassContext db = new ClassContext();
        Picture current_picture;
        string root_folder = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshTags();
        }        
        private void button1_Click_1(object sender, EventArgs e)
        {            
            if (current_picture != null)
            {
                if (StaticInfo.user != null)
                {
                    Text = "Классификатор. Клинка \"Ухо, Горло, Нос\" / " + StaticInfo.user.User_name;
                    List<Symptom> symptom = db.Symptoms.ToList();
                    var controls = groupBox1.Controls;
                    foreach (var control in controls)
                    {
                        if (control is CheckBox)
                            if ((control as CheckBox).Checked)
                            {
                                Recognized rec = new Recognized();
                                rec.Picture = current_picture;
                                rec.Date = DateTime.Now;
                                rec.Symptom = symptom.Where(p => p.Symptom_name == (control as CheckBox).Text).FirstOrDefault();
                                rec.User = db.Users.ToList().Where(p => p.User_name == StaticInfo.user.User_name).FirstOrDefault();
                                db.Recognized_.Add(rec);
                                db.SaveChanges();
                            }
                    }

                    current_picture.Recognized = true;
                    current_picture.Skipped = false;
                    db.SaveChanges();
                }
                else
                {
                    LoginForm form = new LoginForm();
                    form.Show();
                    return;
                }
            }
            refreshTags();
            getNextPic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current_picture != null)
            {
                current_picture.Skipped = true;
                db.SaveChanges();
            }
            refreshTags();
            getNextPic();
        }

        private void refreshTags()
        {
            groupBox1.Controls.Clear();
            int x = 15;
            int y = 15;
            foreach (Symptom symp in db.Symptoms.ToList())
            {
                CheckBox checkBoxNew = new CheckBox();
                checkBoxNew.Text = symp.Symptom_name;
                checkBoxNew.Name = symp.Symptom_name;
                checkBoxNew.Parent = groupBox1;
                Point location = new Point(x, y);
                checkBoxNew.Location = location;
                checkBoxNew.Size = new Size(symp.Symptom_name.Length * 6 + 50, 17);
                y += 20;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Symptom symp = new Symptom();
            symp.Symptom_name = textBox1.Text;
            db.Symptoms.Add(symp);
            db.SaveChanges();
            refreshTags();
            textBox1.Text = "";
        }

        private void начатьИндексациюСнимковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setRootFolder();
            indexing();
            getNextPic();
        }

        private void приступитьКРазметкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setRootFolder();
            getNextPic();
        }

        private void indexing()
        {
            if (root_folder == "")
                setRootFolder();
            DirectoryInfo d = new DirectoryInfo(root_folder);
            FileInfo[] Files = d.GetFiles("*.jpg"); 
            string str = "";
            List<Picture> pics = db.Pictures.ToList();
            foreach (FileInfo file in Files)
            {
                if (!pics.Where(p => p.Pic_name == file.Name).Any())
                {
                    Picture pic = new Picture();
                    pic.Pic_name = file.Name;
                    pic.Date = DateTime.Now;
                    pic.Recognized = false;
                    //pic.Hash = getMD5(root_folder + "/" + file.Name);
                    db.Pictures.Add(pic);
                    db.SaveChanges();
                }                
            }           
        }

        private void getNextPic()
        {
            string fileName = "";
            try
            {
                if (root_folder == "")
                    setRootFolder();
                List<Picture> pics = db.Pictures.ToList();
                if(checkBoxSkipped.Checked)
                    current_picture = pics.Where(p => p.Recognized == false).FirstOrDefault();
                else
                    current_picture = pics.Where(p => p.Recognized == false && p.Skipped == false).FirstOrDefault();
                fileName = current_picture.Pic_name;
                if (File.Exists(root_folder + "/" + fileName))
                {
                    pictureBox1.Image = Image.FromFile(root_folder + "/" + fileName);
                    updateStatus("");
                }
                else
                {
                    //fileName_old.Add(current_picture.Pic_name);
                    //statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count() + " / Предыдущий файл " + fileName + " не был найден!";
                    updateStatus(" / Предыдущий файл " + fileName + " не был найден!");
                    getNextPic();
                }
            }
            catch
            {
                if (current_picture != null && File.Exists(root_folder + "/" + fileName))
                {
                    db.Pictures.Attach(current_picture);
                    db.SaveChanges();
                    current_picture = null;
                    MessageBox.Show("Файл " + fileName + " имел неверный формат и был исключен из индексации.");
                }
                else
                {
                    MessageBox.Show("Файл " + fileName + " не найден. \nВозможно в папке " + root_folder + " нет индексированных снимков");
                    root_folder = "";
                }
            }
        }

        private void setRootFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                root_folder = FBD.SelectedPath;
            }
        }

        public string getMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void повторнаяРазметкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecondForm form = new SecondForm();
            form.Show();
        }

        private void updateStatus(String s)
        {
            int all = db.Pictures.Count();
            int ready = 0;
            if (checkBoxSkipped.Checked)
                ready = db.Pictures.ToList().Where(p => p.Recognized == false).Count();
            else
                ready = db.Pictures.ToList().Where(p => p.Recognized == false && p.Skipped == false).Count();
            ready = all - ready;
            statusLabel.Text = ready + "/" + all + s;
        }

        private void checkBoxSkipped_CheckedChanged(object sender, EventArgs e)
        {
            updateStatus("");
        }

        private void количествоСнимковПоКатегориямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm form = new ReportForm();
            form.Show();
        }
    }
}
