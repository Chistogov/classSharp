using Classificator.database;
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
    public partial class QueriesForm : Form
    {
        public QueriesForm()
        {
            InitializeComponent();
            refreshComboBox();
        }
        ClassContext db = new ClassContext();
        Picture current_picture;

        private void QueriesForm_Load(object sender, EventArgs e)
        {
            refreshTags();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryMap.user = null;
            QueryMap.date = DateTime.MinValue;
            QueryMap.use_date = false;
            QueryMap.symptoms = new List<String>();
            //CheckBoxes
            var controls = groupBox1.Controls;
            foreach (var control in controls)
            {
                if (control is CheckBox)
                {
                    if ((control as CheckBox).Checked)
                    {
                        QueryMap.symptoms.Add((control as CheckBox).Text);
                    }
                }
            }
            //User
            if (checkBox1.Checked)
            {
                QueryMap.user = db.Users.ToList().Where(p => p.User_name == comboBox1.Text).FirstOrDefault();
            }
            //Date
            if (checkBox2.Checked)
            {
                QueryMap.date = dateTimePicker1.Value;
                QueryMap.use_date = true;
            }
            Close();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
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
                    if (checkBox3.Checked == true)
                        (control as CheckBox).Checked = true;
                    else
                        (control as CheckBox).Checked = false;
                }
            }
        }
    }
}
