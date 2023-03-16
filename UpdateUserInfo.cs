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
    public partial class UpdateUserInfo : Form
    {
        public UpdateUserInfo()
        {
            InitializeComponent();
        }

        public string Username, Password, NameSurname, PhoneNumber, Address, City, Country, Email;
     
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            XDocument xdosya = XDocument.Load(@"../../userinfo.xml");
            //find the relevant user by using username
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
        
            //back to manager screen after update user's info
            Manager mngr = new Manager();
            this.Hide();
            mngr.Show();
        }
        

        private void UpdateUserInfo_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Username;
            txtPassword.Text = Password;
            txtNameSname.Text = NameSurname;
            txtPhoneNo.Text = PhoneNumber;
            txtAddress.Text = Address;
            txtCity.Text = City;
            txtCountry.Text = Country;
            txtEmail.Text = Email;

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
    }
}
