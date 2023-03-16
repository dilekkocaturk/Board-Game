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
    public partial class SignUp : Form
    {

        public SignUp()
        {
            InitializeComponent();
        }
        
      
        bool isDuplicate = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string username;

            isDuplicate = false;

            XmlDocument xdosya3 = new XmlDocument();
            xdosya3.Load(@"../../userinfo.xml");

            foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
            {
                username = node.SelectSingleNode("Username").InnerText; // get value of Username Value.
  

                if (username == txtUsername.Text)
                {

                    isDuplicate = true;
                    MessageBox.Show("Entered username is already registered! Please try another username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }

            //if the username is unique then add user
            if (isDuplicate == false)
            {
                XDocument xdosya = XDocument.Load(@"../../userinfo.xml");
                XElement rootelement = xdosya.Root;
                XElement element = new XElement("User");
                XElement Username = new XElement("Username", txtUsername.Text);
                XElement Password = new XElement("Password", SHA2.sha256(txtPassword.Text));
                XElement BestScore = new XElement("BestScore", "0");
                XElement NameSurname = new XElement("NameSurname", txtNameSname.Text);
                XElement PhoneNumber = new XElement("PhoneNumber", txtPhoneNo.Text);
                XElement Address = new XElement("Address", txtAddress.Text);
                XElement City = new XElement("City", txtCity.Text);
                XElement Country = new XElement("Country", txtCountry.Text);
                XElement Email = new XElement("Email", txtEmail.Text);
                element.Add(Username, Password, BestScore, NameSurname, PhoneNumber, Address, City, Country, Email);
                rootelement.Add(element);

                xdosya.Save(@"../../userinfo.xml");
                MessageBox.Show("Signed up!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //switch the main game window after sign up
                MainGame mg = new MainGame();
                mg.Username = txtUsername.Text; //transfer to the MainGame window to control whether the manage button is visible
                mg.Password = txtPassword.Text; //transfer to the MainGame window to control whether the manage button is visible
                this.Hide();
                mg.Show();
            }
          
        }

        //back to log in
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }

        //exit with X
        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //see the entered password as clear text and vice versa
        private void btnHideShw_Click(object sender, EventArgs e)
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


        private void SignUp_Load(object sender, EventArgs e)
        {
        }
    }
}
