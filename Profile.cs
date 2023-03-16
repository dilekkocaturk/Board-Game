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

namespace BoardGame
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        public string Username, Password, bestScore;    

        XmlNode xnode1, xnode2, xnode3, xnode4, xnode5, xnode6;

        private void Profile_Load(object sender, EventArgs e)
        {
            XmlDocument xdosya3 = new XmlDocument();
            xdosya3.Load(@"../../userinfo.xml");

            //find the user datas from xml file
            foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
            {
                string uname = node.SelectSingleNode("Username").InnerText; // get value of Username Value.
                string pw = node.SelectSingleNode("Password").InnerText;
                xnode1 = node.SelectSingleNode("NameSurname");
                xnode2 = node.SelectSingleNode("PhoneNumber");
                xnode3 = node.SelectSingleNode("Address");
                xnode4 = node.SelectSingleNode("City");
                xnode5 = node.SelectSingleNode("Country");
                xnode6 = node.SelectSingleNode("Email");

                //if the username matches the username in xml, then write the relevant user's info
                if (Username == uname)
                {
                    txtUsername.Text = Username;
                    txtPassword.Text = SHA2.sha256(Password);
                    lblBS.Text = bestScore;
                    txtNameSname.Text = xnode1.InnerText;
                    txtPhoneNo.Text = xnode2.InnerText;
                    txtAddress.Text = xnode3.InnerText;
                    txtCity.Text = xnode4.InnerText;
                    txtCountry.Text = xnode5.InnerText;
                    txtEmail.Text = xnode6.InnerText;

                }

            }

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //check the password to update
            if (txtCnfrmPw.Text == Password)
            {
                XDocument xdosya = XDocument.Load(@"../../userinfo.xml");
                XElement element = xdosya.Element("Users").Elements("User").FirstOrDefault(x => x.Element("Username").Value == txtUsername.Text);
                if (element != null)
                {
                    element.SetElementValue("Password", SHA2.sha256(txtPassword.Text));
                    element.SetElementValue("NameSurname", txtNameSname.Text);
                    element.SetElementValue("PhoneNumber", txtPhoneNo.Text);
                    element.SetElementValue("Address", txtAddress.Text);
                    element.SetElementValue("City", txtCity.Text);
                    element.SetElementValue("Country", txtCountry.Text);
                    element.SetElementValue("Email", txtEmail.Text);

                    xdosya.Save(@"../../userinfo.xml");
                    MessageBox.Show("User's info updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Invalid Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //see the entered password as clear text and vice versa
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCnfrmPw.UseSystemPasswordChar == true)
            {
                //show the password
                txtCnfrmPw.UseSystemPasswordChar = false;
            }
            else
            {
                //hide the password
                txtCnfrmPw.UseSystemPasswordChar = true;
            }
        }

        //hide the profile screen to back the main game window
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}