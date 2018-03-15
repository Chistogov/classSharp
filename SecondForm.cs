using Classificator.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classificator
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
            pics = db.Pictures.ToList();
            recognized_= db.Recognized_.ToList();
        }
        List<String> fileName_old = new List<String>();
        List<String> filesNames = new List<String>();
        ClassContext db = new ClassContext();
        List<Picture> pics = new List<Picture>();
        List<Recognized> recognized_ = new List<Recognized>();
        Picture current_picture;
        private void запросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueriesForm form = new QueriesForm();
            form.Show();
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {
            refreshTags();
        }
        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QueryMap.symptoms == null)
            {
                QueriesForm form = new QueriesForm();
                form.Show();
                return;
            }
            fileName_old = new List<String>();
            filesNames = new List<String>();
            List<User> user = db.Users.ToList();
            if (StaticInfo.root_folder == "")
                setRootFolder();
            var groups = recognized_.Where(p => QueryMap.symptoms.Contains(p.Symptom.Symptom_name));
            if (QueryMap.use_date)
                groups = groups.Where(p => p.Date == QueryMap.date);
            if (QueryMap.user != null)
                groups = groups.Where(p => p.User.User_name == QueryMap.user.User_name);
            var groupz = groups.GroupBy(p => p.Picture);
            foreach (var group in groupz)
            {
                foreach (var item in group)
                    if(!filesNames.Contains(item.Picture.Pic_name))
                        filesNames.Add(item.Picture.Pic_name);
            }
            if (groupz.Count() == 0)
            {
                MessageBox.Show("В результате поиска не было найдено ни одного снимка по заданному условию");
                return;
            }
            statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count();
            getNextPic();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (current_picture != null)
                fileName_old.Add(current_picture.Pic_name);
            statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count();
            getNextPic();
        }
        //**Functions**//
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
        string note = "";
        private void getNextPic()
        {
            string fileName = "";
            note = "";
            try
            {
                if (StaticInfo.root_folder == "")
                    setRootFolder();
               
                current_picture = pics.Where(p => !fileName_old.Contains(p.Pic_name) &&
                                            filesNames.Contains(p.Pic_name)).FirstOrDefault();
                var symptomsz = recognized_.Where(p => p.Picture == current_picture).GroupBy(p => p.Symptom).ToList();
                List<String> symptoms = new List<String>();
                foreach (var group in symptomsz)
                {
                    foreach (var item in group)
                    {
                        if (!symptoms.Contains(item.Symptom.Symptom_name))
                        {
                            symptoms.Add(item.Symptom.Symptom_name);
                        }
                        note += item.Symptom.Symptom_name + "("+item.User.User_name+ " - " + item.Date + ")" + "\n";
                    }
                }                
                var controls = groupBox1.Controls;
                foreach (var control in controls)
                {
                    if (control is CheckBox)
                    {                       
                        if (symptoms.Contains((control as CheckBox).Text))
                        {
                            (control as CheckBox).Checked = true;
                        }
                        else
                        {
                            (control as CheckBox).Checked = false;
                        }                       
                    }
                }
                if (checkBox1.Checked)
                    if (!QueryMap.symptoms.All(item => symptoms.Contains(item)))
                    {
                        fileName_old.Add(current_picture.Pic_name);
                        statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count() + " / Предыдущий файл пропущен";
                        getNextPic();
                    }
                fileName = current_picture.Pic_name;
                if (File.Exists(StaticInfo.root_folder + "/" + fileName))
                {
                    pictureBox1.Image = Image.FromFile(StaticInfo.root_folder + "/" + fileName);
                }
                else
                {
                    fileName_old.Add(current_picture.Pic_name);
                    statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count() + " / Предыдущий файл " + fileName + " не был найден!";
                    getNextPic();
                }
            }
            catch
            {
                if (current_picture != null && File.Exists(StaticInfo.root_folder + "/" + fileName))
                {
                    db.Pictures.Attach(current_picture);
                    db.SaveChanges();
                    current_picture = null;
                    MessageBox.Show("Файл " + fileName + " имел неверный формат и был исключен из индексации.");
                }
                else
                {
                    statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count() + " / Предыдущий файл " + fileName + " не был найден!";
                }
            }
        }
        private void setRootFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                StaticInfo.root_folder = FBD.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current_picture != null)
            {
                if (StaticInfo.user != null)
                {
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
                    db.SaveChanges();
                }
                else
                {
                    LoginForm form = new LoginForm();
                    form.Show();
                    return;
                }
            }
            if (current_picture != null)
                fileName_old.Add(current_picture.Pic_name);
            statusLabel.Text = fileName_old.Count() + "/" + filesNames.Count();
            getNextPic();

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

        private void подсказкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(note);
        }
    }
}
