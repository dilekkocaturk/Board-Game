using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace BoardGame
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        
        bool loginCheck = false;
        bool isDuplicate = false;
     
        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;

            XmlDocument xdosya3 = new XmlDocument();
            xdosya3.Load(@"../../userinfo.xml");

           //find the entered datas from xml file to verify login
            foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
            {
                username = node.SelectSingleNode("Username").InnerText; // get value of Username Value.
                password = node.SelectSingleNode("Password").InnerText; // get value of Password Value.

                if (username == txtUsername.Text && password == SHA2.sha256(txtPassword.Text))
                {
                    loginCheck = true;
     
                }
            }

            //check the username and password
            if ((txtUsername.Text == "admin" && txtPassword.Text == "admin")
                || (txtUsername.Text == "user" && txtPassword.Text == "user")
                || loginCheck)
            {
            
                //store the pre-registered users(admin,user) passwords as hash values
                if ((txtUsername.Text == "admin" && txtPassword.Text == "admin") || (txtUsername.Text == "user" && txtPassword.Text == "user")) //store only once
                {

                    xdosya3.Load(@"../../userinfo.xml");

                    foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
                    {
                        username = node.SelectSingleNode("Username").InnerText; // get value of Username Value.

                        if (username == txtUsername.Text)
                        {
                            isDuplicate = true;

                        }
                    }

                    //if the username is unique then add "admin" or "user"
                    if (isDuplicate == false)
                    {
  
                        XDocument xdosya = XDocument.Load(@"../../userinfo.xml");
                        XElement rootelement = xdosya.Root;
                        XElement element = new XElement("User");
                        XElement Username = new XElement("Username", txtUsername.Text);
                        XElement Password = new XElement("Password", SHA2.sha256(txtPassword.Text));
                        XElement BestScore = new XElement("BestScore", "-1");
                        XElement NameSurname = new XElement("NameSurname", "");
                        XElement PhoneNumber = new XElement("PhoneNumber", "");
                        XElement Address = new XElement("Address", "");
                        XElement City = new XElement("City", "");
                        XElement Country = new XElement("Country", "");
                        XElement Email = new XElement("Email", "");
                        element.Add(Username, Password, BestScore, NameSurname, PhoneNumber, Address, City, Country, Email);
                        rootelement.Add(element);

                        xdosya.Save(@"../../userinfo.xml");
                    }
                }

                //save the last successful login
                if (checkBoxRememberMe.Checked == true)
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Save();
                }

                //clear the username textbox when checkbox is not checked
                else
                {
                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.Save();
                }

                //switch to main game window
                MainGame mg = new MainGame();
                mg.Username = txtUsername.Text; //transfer to the MainGame window to control whether the manage button is visible
                mg.Password = txtPassword.Text; //transfer to the MainGame window to control whether the manage button is visible
                this.Hide();
                mg.Show();
 
            }//end-if
            else
            {
                MessageBox.Show("Incorrect username or password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//end-else
        }

        //exit with X
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create a xml file
            string path = @"../../userinfo.xml";
            if (!File.Exists(path))
            {
                XmlTextWriter dosya = new XmlTextWriter(@"../../userinfo.xml", Encoding.UTF8);
                dosya.Formatting = Formatting.Indented;
                dosya.WriteStartDocument();
                dosya.WriteStartElement("Users");

                dosya.WriteEndElement();
                dosya.Close();
            }

            //remember the last successful login
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
            }
        }

        //prevent non-alphabetic chars from being entered
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90 ) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar == 8))
            {
                //65-90 (A-Z), 97-122 (a-z), 8 backspace
                e.Handled = false; 
            }
          
            else
            {
                //all the other states (numbers, special chars, space...)
                e.Handled = true;
            }
        }

        //see the entered password as clear text and vice versa
        private void button2_Click(object sender, EventArgs e)
        {

            if (txtPassword.UseSystemPasswordChar == true)
            {
                //show the password
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                //hide the password
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        //switch the sign up screen
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            this.Hide();
            su.Show();
        }

    }
}
