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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add user to xml file
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
            MessageBox.Show("User added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //back to manager screen after add a new user
            Manager mngr = new Manager();
            this.Hide();
            mngr.Show();
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

        //back to manager screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            Manager mngr = new Manager();
            this.Hide();
            mngr.Show();
        }

        //prevent non-alphabetic chars from being entered
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar == 8))
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
    }
}
