using Classificator.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classificator
{
    public partial class LoadPics : Form
    {
        public LoadPics()
        {
            InitializeComponent();
        }
        ClassContext db = new ClassContext();
        private void LoadPics_Load(object sender, EventArgs e)
        {
            refreshTags();
            refreshComboBox();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Recognized_.ToList();
            db.Users.ToList();
            db.Pictures.ToList();
            DateTime date = DateTime.MinValue;
            String user_name = "";
            List<String> symptoms = new List<String>();
            List<String> pics_iskl = new List<String>();
            if (checkBox1.Checked)
                date = dateTimePicker1.Value;
            if (checkBox2.Checked)
                user_name = comboBox1.Text;
            //CheckBoxes
            var controls = groupBox1.Controls;
            foreach (var control in controls)
            {
                if (control is CheckBox)
                {
                    if ((control as CheckBox).Checked)
                    {
                        if (!(control as CheckBox).Name.Contains("iskl"))
                        {
                            symptoms.Add((control as CheckBox).Text);
                        }
                    }
                }
            }
            if (symptoms.Count() == 1)
            {
                foreach (var control in controls)
                {
                    if (control is CheckBox)
                    {
                        if ((control as CheckBox).Checked)
                        {
                            if ((control as CheckBox).Name.Contains("iskl"))
                            {
                                var pic_temp = db.Recognized_.ToList().Where(p => p.Symptom.Symptom_name.Equals((control as CheckBox).Name.Replace("iskl", "")));
                                foreach (Recognized picc in pic_temp)
                                {
                                    if (!pics_iskl.Contains(picc.Picture.Pic_name))
                                        pics_iskl.Add(picc.Picture.Pic_name);
                                }

                            }
                        }
                    }
                }
            }
            db.Users.ToList();
            var groups = db.Recognized_.ToList().Where(p => symptoms.Contains(p.Symptom.Symptom_name));
            //int t = groups.Count();
            if (pics_iskl.Count() != 0)
            {
                groups = groups.Where(p => !pics_iskl.Contains(p.Picture.Pic_name));
            }
            if (checkBox1.Checked)
                groups = groups.Where(p => p.Date == date.Date);
            if (checkBox2.Checked)
                groups = groups.Where(p => p.User.User_name == user_name);
            int n = groups.GroupBy(p => p.pic_id).Count();
            //Отчет
            String s = "Снимков распознано: " + n + "\n";
            if (!checkBox2.Checked)
            {
                s += "По пользователям:\n";
                foreach (User user in db.Users.ToList())
                {
                    int u = groups.Where(p => p.user_id == user.Id).GroupBy(p => p.pic_id).Count();
                    s += "    " + user.User_name + ": " + u + "\n";
                }
            }
            s += "По категориям:\n";
            foreach (Symptom symptom in db.Symptoms.ToList())
            {
                int u = groups.Where(p => p.symp_id == symptom.Id).Count();
                s += "    " + symptom.Symptom_name + ": " + u + "\n";
            }
            MessageBox.Show(s);
        }
        //**Functions**//
        private void refreshTags()
        {
            groupBox1.Controls.Clear();
            int x_iskl = 15;
            int x = 35;
            int y = 15;
            foreach (Symptom symp in db.Symptoms.ToList())
            {
                CheckBox checkBox_iskl = new CheckBox();
                checkBox_iskl.Name = "iskl" + symp.Symptom_name;
                checkBox_iskl.Parent = groupBox1;
                Point location = new Point(x_iskl, y);
                checkBox_iskl.Location = location;
                checkBox_iskl.Size = new Size(17, 17);

                CheckBox checkBoxNew = new CheckBox();
                checkBoxNew.Text = symp.Symptom_name;
                checkBoxNew.Name = symp.Symptom_name;
                checkBoxNew.Parent = groupBox1;
                location = new Point(x, y);
                checkBoxNew.Location = location;
                checkBoxNew.Size = new Size(symp.Symptom_name.Length * 6 + 50, 17);
                y += 20;
            }
        }

        private void refreshComboBox()
        {
            comboBox1.Items.Clear();
            foreach (User user in db.Users.ToList())
            {
                comboBox1.Items.Add(user.User_name);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Recognized_.ToList();
            db.Users.ToList();
            db.Pictures.ToList();
            DateTime date = DateTime.MinValue;
            String user_name = "";
            List<String> symptoms = new List<String>();
            List<String> pics_iskl = new List<String>();
            if (checkBox1.Checked)
                date = dateTimePicker1.Value;
            if (checkBox2.Checked)
                user_name = comboBox1.Text;
            //CheckBoxes
            string message = "";
            var controls = groupBox1.Controls;
            foreach (var control in controls)
            {
                if (control is CheckBox)
                {
                    if ((control as CheckBox).Checked)
                    {
                        if (!(control as CheckBox).Name.Contains("iskl"))
                        {
                            symptoms.Add((control as CheckBox).Text);
                            message += "\n" + (control as CheckBox).Text;
                        }
                    }
                }
            }
            if (symptoms.Count() == 1)
            {
                message += "\nИсключая:";
                foreach (var control in controls)
                {
                    if (control is CheckBox)
                    {
                        if ((control as CheckBox).Checked)
                        {
                            if ((control as CheckBox).Name.Contains("iskl"))
                            {
                                var pic_temp = db.Recognized_.ToList().Where(p => p.Symptom.Symptom_name.Equals((control as CheckBox).Name.Replace("iskl", "")));
                                foreach (Recognized picc in pic_temp)
                                {
                                    if(!pics_iskl.Contains(picc.Picture.Pic_name))
                                        pics_iskl.Add(picc.Picture.Pic_name);
                                }
                                
                                message += "\n" + (control as CheckBox).Name.Replace("iskl", "");
                            }
                        }
                    }
                }
                message = "Будут сохранены все снимки с признаком:" + message;
            }
            else
            {
                message = "Будут сохранены все снимки из категорий:" + message + "\nВозможны коллизии!";
            }
            MessageBox.Show(message + pics_iskl.Count());
            var groups = db.Recognized_.ToList().Where(p => symptoms.Contains(p.Symptom.Symptom_name));
            if (pics_iskl.Count() != 0)
            {
                groups = groups.Where(p => !pics_iskl.Contains(p.Picture.Pic_name));
            }
            int t = groups.Count();
            if (checkBox1.Checked)
                groups = groups.Where(p => p.Date == date.Date);
            if (checkBox2.Checked)
                groups = groups.Where(p => p.User.User_name == user_name);
            int n = groups.GroupBy(p => p.pic_id).Count();
            //Отчет            
            setRootFolder();
            setFolderTo();
            foreach (Symptom symptom in db.Symptoms.ToList())
            {
                if (!Directory.Exists(folder_to + "\\" + symptom.Symptom_name))
                    Directory.CreateDirectory(folder_to + "\\" + symptom.Symptom_name);
                var rec = groups.Where(p => p.symp_id == symptom.Id);
                foreach (Recognized recognized in rec)
                {
                    if (!File.Exists(folder_to + "\\" + symptom.Symptom_name + "\\" + recognized.Picture.Pic_name))
                        File.Copy(StaticInfo.root_folder + "\\" + recognized.Picture.Pic_name, folder_to + "\\" + symptom.Symptom_name + "\\" + recognized.Picture.Pic_name);
                }
            }
            MessageBox.Show("Готово");
        }
        String folder_to = "";
        private void setRootFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                StaticInfo.root_folder = FBD.SelectedPath;
            }
        }

        private void setFolderTo()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                folder_to = FBD.SelectedPath;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBoxes
            var controls = groupBox1.Controls;
            foreach (var control in controls)
            {
                if (control is CheckBox)
                {
                    if(checkBox3.Checked == true)
                        (control as CheckBox).Checked = true;
                    else
                        (control as CheckBox).Checked = false;
                }
            }
        }
    }
}
