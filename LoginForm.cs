using Classificator.database;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Classificator
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            refreshComboBox();
        }
        ClassContext db = new ClassContext();
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (!db.Users.ToList().Where(p => p.User_name == textBox1.Text).Any())
                {
                    User user = new User();
                    user.User_name = textBox1.Text;
                    db.Users.Add(user);
                    db.SaveChanges();
                    refreshComboBox();
                    groupBox1.Visible = false;
                }
                else
                {
                    MessageBox.Show("Пользователь с именем \"" + textBox1.Text + "\" уже существует");
                }
            }
            else
            {
                MessageBox.Show("Введите имя пользователя");
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

        private void button1_Click(object sender, EventArgs e)
        {
            StaticInfo.user = db.Users.ToList().Where(p => p.User_name == comboBox1.Text).FirstOrDefault();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
