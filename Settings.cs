using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        public int rowIndex, colIndex, imageIndex;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Custom")
            {
                lblRow.Visible = true;
                lblClmn.Visible = true;
                txtRow.Visible = true;
                txtCol.Visible = true;

            }

            //if the custom is not selected then row and column options must be hidden
            if(comboBox1.Text!="Custom")
            {
                lblRow.Visible = false;
                lblClmn.Visible = false;
                txtRow.Visible = false;
                txtCol.Visible = false;
                txtRow.Clear();
                txtCol.Clear();
            }
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            //if at least one shape and color is not selected
            if ((!((checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true) &&
               (checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true))) ||
                //or
                //if only 1 shape is selected
                ((checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false) ||
                (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false) ||
                (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)) &&
                //and 1 color
                ((checkBox4.Checked == true && checkBox5.Checked == false && checkBox6.Checked == false) ||
                (checkBox4.Checked == false && checkBox5.Checked == true && checkBox6.Checked == false) ||
                (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == true)))
            {
                //check the at least one shape and one color selection
                if (!((checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true) &&
                    (checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true)))
                {
                    MessageBox.Show("You must select at least one shape and one color!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //check the only one shape and color selection
                else
                {
                    MessageBox.Show("You must choose one more color or shape!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }



            else
            {
                //check the min and max sizes if the level is custom
                if (comboBox1.Text == "Custom" && (Convert.ToInt32(txtRow.Text) < 6 || Convert.ToInt32(txtRow.Text) > 20 || Convert.ToInt32(txtCol.Text) < 6 || Convert.ToInt32(txtCol.Text) > 20))
                {

                    MessageBox.Show("You cannot enter a size smaller than 6 or larger than 20!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                //check the dimensions of the custom level
                else if ((comboBox1.Text == "Custom" && Convert.ToInt32(txtRow.Text) == 6 && Convert.ToInt32(txtCol.Text) == 6) ||
                         (comboBox1.Text == "Custom" && Convert.ToInt32(txtRow.Text) == 9 && Convert.ToInt32(txtCol.Text) == 9) ||
                         (comboBox1.Text == "Custom" && Convert.ToInt32(txtRow.Text) == 15 && Convert.ToInt32(txtCol.Text) == 15))
                {
                    MessageBox.Show("The dimensions​​you entered are already available in the the difficulty levels." +
                        "\n\nPlease enter values ​​excluding 6x6 (Hard), 9x9 (Intermediate), 15x15 (Easy).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    //save settings
                    Properties.Settings.Default.combo1 = comboBox1.Text; //difficulty level
                    Properties.Settings.Default.text1 = txtRow.Text; 
                    Properties.Settings.Default.text2 = txtCol.Text;
                    //shapes
                    Properties.Settings.Default.check1 = checkBox1.Checked;
                    Properties.Settings.Default.check2 = checkBox2.Checked;
                    Properties.Settings.Default.check3 = checkBox3.Checked;
                    //colors
                    Properties.Settings.Default.check4 = checkBox4.Checked;
                    Properties.Settings.Default.check5 = checkBox5.Checked;
                    Properties.Settings.Default.check6 = checkBox6.Checked;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Your settings have been saved succesfully!");

                    MainGame mg = (MainGame)Application.OpenForms["MainGame"];
                    mg.top = 0;
                    mg.left = 0;
                    for (int i = 0; i <= mg.buttons.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= mg.buttons.GetUpperBound(1); j++)
                        {
                            mg.Controls.Remove(mg.buttons[i, j]);
                            mg.left += 40;
                        }
                        mg.top += 40;
                        mg.left = 0;

                    }

                    if (Properties.Settings.Default.combo1 == "Easy")
                    {
                        mg.a = 15;
                        mg.b = 15;
                    }
                    else if (Properties.Settings.Default.combo1 == "Intermediate")
                    {
                        mg.a = 9;
                        mg.b = 9;
                    }
                    else if (Properties.Settings.Default.combo1 == "Hard")
                    {
                        mg.a = 6;
                        mg.b = 6;
                    }
                    else if (Properties.Settings.Default.combo1 == "Custom")
                    {
                        mg.a = Convert.ToInt32(Properties.Settings.Default.text1);
                        mg.b = Convert.ToInt32(Properties.Settings.Default.text2);
                    }
                    mg.buttons = new Button[mg.a, mg.b];
                    mg.top = 0;
                    mg.left = 0;
                    for (int i = 0; i <= mg.buttons.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= mg.buttons.GetUpperBound(1); j++)
                        {
                            mg.buttons[i, j] = new Button();
                            mg.buttons[i, j].Width = 40;
                            mg.buttons[i, j].Height = 40;
                            mg.buttons[i, j].Left = mg.left;
                            mg.buttons[i, j].Top = mg.top;
                            mg.buttons[i, j].Click += new EventHandler(mg.button_click);
                            mg.left += 40;
                            mg.Controls.Add(mg.buttons[i, j]);
                        }

                        mg.top += 40;
                        mg.left = 0;
                    }

                    rndShapeColor(3);
                }
            }
        }

        //exit with X
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        //hide the setting screen to back the main game window
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

          
        }

        //remember settings
        private void Form3_Load(object sender, EventArgs e)
        {

            comboBox1.Text = Properties.Settings.Default.combo1;
            txtRow.Text = Properties.Settings.Default.text1;
            txtCol.Text = Properties.Settings.Default.text2;
            checkBox1.Checked = Properties.Settings.Default.check1;
            checkBox2.Checked = Properties.Settings.Default.check2;
            checkBox3.Checked = Properties.Settings.Default.check3;
            checkBox4.Checked = Properties.Settings.Default.check4;
            checkBox5.Checked = Properties.Settings.Default.check5;
            checkBox6.Checked = Properties.Settings.Default.check6;

        }
       
        private void rndShapeColor(int num)
        {
            MainGame mg = (MainGame)Application.OpenForms["MainGame"];

            for (int i = 0; i < num; i++)
            {
                rowIndex = rnd.Next(0, mg.buttons.GetUpperBound(0) + 1);
                colIndex = rnd.Next(0, mg.buttons.GetUpperBound(1) + 1);
                if (mg.buttons[rowIndex, colIndex].ImageList == mg.ımageList1)
                {
                    i--;
                    continue;
                }
                mg.buttons[rowIndex, colIndex].ImageList = mg.ımageList1;
                //-----------------------
                //red
                if (checkBox4.Checked == true && checkBox5.Checked == false && checkBox6.Checked == false)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        //0 or 1
                        imageIndex = rnd.Next(0, 2);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //0 or 2

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 3);
                            if (imageIndex != 1)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //1 or 2
                        imageIndex = rnd.Next(1, 3);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //0, 1 or 2
                        imageIndex = rnd.Next(0, 3);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //green
                else if (checkBox4.Checked == false && checkBox5.Checked == true && checkBox6.Checked == false)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        //3 or 4
                        imageIndex = rnd.Next(3, 5);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //3 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 6);
                            if (imageIndex != 4)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //4 or 5
                        imageIndex = rnd.Next(4, 6);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //3, 4 or 5
                        imageIndex = rnd.Next(3, 6);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //blue
                else if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == true)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        //6 or 7
                        imageIndex = rnd.Next(6, 8);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(6, 9);
                            if (imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //7 or 8
                        imageIndex = rnd.Next(7, 9);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //6, 7 or 8
                        imageIndex = rnd.Next(6, 9);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //red,green
                else if (checkBox4.Checked == true && checkBox5.Checked == true && checkBox6.Checked == false)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //0 or 3

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 4);
                            if (imageIndex != 1 && imageIndex != 2)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //1 or 4

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 5);
                            if (imageIndex != 2 && imageIndex != 3)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //2 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 6);
                            if (imageIndex != 3 && imageIndex != 4)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {

                        bool state = false;
                        //0, 1, 3 or 4

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 5);
                            if (imageIndex != 2)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //0, 2, 3 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 6);
                            if (imageIndex != 1 && imageIndex != 4)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //1, 2, 4 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 6);
                            if (imageIndex != 3)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        //0, 1, 2, 3, 4 or 5
                        imageIndex = rnd.Next(0, 6);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //red,blue
                else if (checkBox4.Checked == true && checkBox5.Checked == false && checkBox6.Checked == true)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //0 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 7);
                            if (imageIndex != 1 && imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //1 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //2 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {

                        bool state = false;
                        //0, 1, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //0, 2, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 1 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //1, 2, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //0, 1, 2, 6, 7 or 8
                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                }
                //green,blue
                else if (checkBox4.Checked == false && checkBox5.Checked == true && checkBox6.Checked == true)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //3 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 7);
                            if (imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //4 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(4, 8);
                            if (imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //5 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(5, 9);
                            if (imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {

                        bool state = false;
                        //3, 4, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 8);
                            if (imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //3, 5, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 9);
                            if (imageIndex != 4 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //4, 5, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(4, 9);
                            if (imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {

                        //3, 4, 5, 6, 7 or 8                         
                        imageIndex = rnd.Next(3, 9);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;

                    }
                }
                //red,green,blue
                else if (checkBox4.Checked == true && checkBox5.Checked == true && checkBox6.Checked == true)
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //0, 3 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 7);
                            if (imageIndex != 1 && imageIndex != 2 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
                    {
                        bool state = false;
                        //1, 4 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //2, 5 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                    {

                        bool state = false;
                        //0, 1, 3, 4, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 8);
                            if (imageIndex != 2 && imageIndex != 5)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //0, 2, 3, 5, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 1 && imageIndex != 4 && imageIndex != 7)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        bool state = false;
                        //1, 2, 4, 5, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 9);
                            if (imageIndex != 3 && imageIndex != 6)
                            {
                                state = true;
                                mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {

                        //0, 1, 2, 3, 4, 5, 6, 7 or 8                         
                        imageIndex = rnd.Next(0, 9);
                        mg.buttons[rowIndex, colIndex].ImageIndex = imageIndex;

                    }
                }//end

            }//end-for

        }

    }
}
