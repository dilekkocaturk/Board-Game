using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;


namespace BoardGame
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            //create dataset to read xml file
            DataSet dset = new DataSet();
            XmlReader reader = XmlReader.Create(@"../../userinfo.xml", new XmlReaderSettings());
            dset.ReadXml(reader);
            //transfer data from dataset to datagrid
            dataGridView1.DataSource = dset.Tables[0];
            //hide the password column in datagrid
            this.dataGridView1.Columns[1].Visible = false;
            reader.Close();
        }

        //switch the adduser screen
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            this.Hide();
            addUser.Show();
        }

        //switch the updateuserinfo screen
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //transfer user info
            UpdateUserInfo updateUserInfo = new UpdateUserInfo();
            updateUserInfo.Username = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateUserInfo.Password = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateUserInfo.NameSurname = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateUserInfo.PhoneNumber = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            updateUserInfo.Address = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateUserInfo.City = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            updateUserInfo.Country = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            updateUserInfo.Email = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            this.Hide();
            updateUserInfo.Show();
        } 

        //delete selected user
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Are You Sure?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                //do something
                XDocument xdosya = XDocument.Load(@"../../userinfo.xml");
                xdosya.Root.Elements().Where(x => x.Element("Username").Value == dataGridView1.CurrentRow.Cells[0].Value.ToString()).Remove();

                xdosya.Save(@"../../userinfo.xml");
                MessageBox.Show("User deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                DataSet dset = new DataSet();
                XmlReader reader = XmlReader.Create(@"../../userinfo.xml", new XmlReaderSettings());
                dset.ReadXml(reader);
                dataGridView1.DataSource = dset.Tables[0];
                reader.Close();
            }
            else if (dialog == DialogResult.No)
            {
                //do something else
                MessageBox.Show("The selected user was not deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
  

        //hide the manager screen to back the main game window
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Admin sorts users with their best scores them by ascending scores
        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["BestScore"], ListSortDirection.Ascending);
        }

        //Admin sorts users with their best scores them by descending scores
        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["BestScore"], ListSortDirection.Descending);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }

   
}
