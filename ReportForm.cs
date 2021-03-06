﻿using Classificator.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classificator
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        ClassContext db = new ClassContext();
        private void ReportForm_Load(object sender, EventArgs e)
        {
            refreshTags();
            refreshComboBox();
        }
        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Recognized_.ToList();
            DateTime date = DateTime.MinValue;
            String user_name = "";
            List<String> symptoms = new List<String>();
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
                        symptoms.Add((control as CheckBox).Text);
                    }
                }
            }
            db.Users.ToList();
            var groups = db.Recognized_.ToList().Where(p => symptoms.Contains(p.Symptom.Symptom_name));
            int t = groups.Count();            
            if (checkBox1.Checked)
                groups = groups.Where(p => p.Date == date.Date);
            if (checkBox2.Checked)
                groups = groups.Where(p => p.User.User_name == user_name);
            int n = groups.GroupBy(p => p.pic_id).Count();
            //Отчет
            String s  = "Снимков распознано: " + n + "\n";            
            if (!checkBox2.Checked)
            {
                s += "По пользователям:\n";
                foreach (User user in db.Users.ToList())
                {
                    int u = groups.Where(p => p.user_id  == user.Id).GroupBy(p => p.pic_id).Count();
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

        private void refreshComboBox()
        {
            comboBox1.Items.Clear();
            foreach (User user in db.Users.ToList())
            {
                comboBox1.Items.Add(user.User_name);
            }
        }
    }
}
