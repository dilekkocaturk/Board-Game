using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.Xml.Linq;

namespace BoardGame
{
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
        }

        //open the settings screen
        private void btnStngs_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }


        //exit with exit button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //log out
        private void button3_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();

        }

        //exit with X
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //switch the manager screen
        private void btnManage_Click(object sender, EventArgs e)
        {
            Manager mngr = new Manager();
            mngr.Show();
        }

        public string Username, Password, bS;

        public Button[,] buttons;
        public int a = 9;
        public int b = 9;
        public int top, left;

        public bool[,] visited;


        private void Form2_Load(object sender, EventArgs e)
        {
            btnManage.Visible = false;
            btnStngs.Visible = false;
            btnProfile.Visible = false;
            btnAbout.Visible = false;
            btnHelp.Visible = false;
            btnLogOut.Visible = false;
            btnExit.Visible = false;

            lblScore.Visible = false;
            lblScr.Visible = false;
            lblBestScore.Visible = false;
            lblBstScr.Visible = false;

            visited = new bool[a, b];


        }

        //switch the profile screen
        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile pr = new Profile();
            pr.Username = Username;
            pr.Password = Password;
            pr.bestScore = bS;
            pr.Show();

        }

        //switch the about screen
        private void btnAbout_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }
        //switch the help screen
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

            btnStart.Visible = false;
            lblWelcome.Visible = false;

            btnStngs.Visible = true;
            btnProfile.Visible = true;
            btnAbout.Visible = true;
            btnHelp.Visible = true;
            btnLogOut.Visible = true;
            btnExit.Visible = true;

            lblScore.Visible = true;
            lblScr.Visible = true;
            lblBestScore.Visible = true;
            lblBstScr.Visible = true;

            XmlDocument xdosya3 = new XmlDocument();
            xdosya3.Load(@"../../userinfo.xml");
            foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
            {
                if (Username == node.SelectSingleNode("Username").InnerText)
                {
                    lblBstScr.Text = node.SelectSingleNode("BestScore").InnerText;
                    Profile p = new Profile();
                    bS = node.SelectSingleNode("BestScore").InnerText;//profile screen shows the user's best score
                }
            }


            //only admin users can see the manage button
            if (Username == "admin" && Password == "admin")
            {
                btnManage.Visible = true;
            }

            buttons = new Button[a, b];
            top = 0;
            left = 0;
            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 40;
                    buttons[i, j].Height = 40;
                    buttons[i, j].Left = left;
                    buttons[i, j].Top = top;
                    buttons[i, j].Click += new EventHandler(this.button_click);
                    left += 40;
                    this.Controls.Add(buttons[i, j]);


                }
                top += 40;
                left = 0;

            }


            rndShapeColor(3);


        }
        //---------------------------------
        public int sayac = 0;
        public int rowIndex, colIndex, newRowIndex, newColIndex, imgIndex;
        public List<Tuple<int, int>> path;

        public void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (sayac % 2 == 0)
            {
                //check the whether user selects an empty box
                if (btn.ImageList == null)
                {
                    MessageBox.Show("You selected an empty box!\n\nFirst, select a shape to move.\n\nSecond, select the target box.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sayac--;
                    btnExit.Focus();
                }

                rowIndex = btn.Top / 40;
                colIndex = btn.Left / 40;
                imgIndex = btn.ImageIndex;

            }
            else
            {

                newRowIndex = btn.Top / 40;
                newColIndex = btn.Left / 40;

                path = solve(rowIndex, colIndex, newRowIndex, newColIndex);
                timer1.Enabled = true;

            }
            sayac++;
        }
        //--------------------------------------

        ///-----------------------------------------------------------------------------------
        /// Run Breadth First Search (BFS) to find the shortest path from (sr, sc) to (tr, tc)
        ///
        public dynamic p;
        public List<Tuple<int, int>> solve(int sr, int sc, int tr, int tc)
        {
            int m = a;
            int n = b;

            List<List<bool>> visited = VectorHelper.NestedList(m, n, false);
            List<List<Tuple<int, int>>> pred = VectorHelper.NestedList<Tuple<int, int>>(m, n, Tuple.Create(-1, -1));
            Queue<Tuple<int, int>> Q = new Queue<Tuple<int, int>>();
            Q.Enqueue(new Tuple<int, int>(sr, sc));

            pred[sr][sc] = new Tuple<int, int>(-1, -1);

            visited[sr][sc] = true;
            int r, c;

            while (Q.Count != 0)
            {
                p = Q.Peek();
                Q.Dequeue();
                r = p.Item1;
                c = p.Item2;
                if (r == tr && c == tc)
                {
                    break;
                }

                // Neighbors
                List<Tuple<int, int>> neighs = new List<Tuple<int, int>>()
            {
                    Tuple.Create(r-1,c),
                    Tuple.Create(r+1,c),
                    Tuple.Create(r,c-1),
                    Tuple.Create(r,c+1)

            };
                foreach (var p in neighs)
                {
                    int nr = p.Item1;
                    int nc = p.Item2;
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                    {
                        continue;
                    }

                    if (buttons[nr, nc].ImageList == null && !visited[nr][nc])
                    {
                        visited[nr][nc] = true;
                        pred[nr][nc] = new Tuple<int, int>(r, c);
                        Q.Enqueue(new Tuple<int, int>(nr, nc));
                    } // end-if
                } // end-for
            } // end-while

            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            r = tr;
            c = tc;
            while (true)
            {
                path.Add(new Tuple<int, int>(r, c));
                if (pred[r][c].Item1 < 0)
                {
                    break;
                }
                int nr = pred[r][c].Item1;
                int nc = pred[r][c].Item2;
                r = nr;
                c = nc;
            } // end-while

            path.Reverse();
            i = 0;
            return new List<Tuple<int, int>>(path);
        } // end-solve


        ///--------------------------------------------------
        ///


        public int i;
        //to be able to give an error message when the user clicks on an illegal location
        public bool moveFlag = false;
        //In order not to make random assignments after trying to go to places where it is illegal to go
        public bool _flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (i < path.Count - 1)
            {
                playStepSound();
                //yukarıya
                if (path[i].Item1 > path[i + 1].Item1 && path[i].Item2 == path[i + 1].Item2)
                {
                    buttons[rowIndex, colIndex].ImageList = null;
                    rowIndex--;
                    buttons[rowIndex, colIndex].ImageList = ımageList1;
                    buttons[rowIndex, colIndex].ImageIndex = imgIndex;
                }
                //aşağıya
                else if (path[i].Item1 < path[i + 1].Item1 && path[i].Item2 == path[i + 1].Item2)
                {
                    buttons[rowIndex, colIndex].ImageList = null;
                    rowIndex++;
                    buttons[rowIndex, colIndex].ImageList = ımageList1;
                    buttons[rowIndex, colIndex].ImageIndex = imgIndex;
                }
                //sağa
                else if (path[i].Item1 == path[i + 1].Item1 && path[i].Item2 < path[i + 1].Item2)
                {

                    buttons[rowIndex, colIndex].ImageList = null;
                    colIndex++;
                    buttons[rowIndex, colIndex].ImageList = ımageList1;
                    buttons[rowIndex, colIndex].ImageIndex = imgIndex;
                }
                //sola
                else if (path[i].Item1 == path[i + 1].Item1 && path[i].Item2 > path[i + 1].Item2)
                {
                    buttons[rowIndex, colIndex].ImageList = null;
                    colIndex--;
                    buttons[rowIndex, colIndex].ImageList = ımageList1;
                    buttons[rowIndex, colIndex].ImageIndex = imgIndex;
                }
                i++;
                moveFlag = true;
            }
            else if (moveFlag == false)
            {
                timer1.Enabled = false;

                MessageBox.Show("You can not go there!\n\nFirst, select a shape to move.\n\nSecond, select the target box.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnExit.Focus();
                _flag = false;
            }
            else
            {
                timer1.Enabled = false;
                btnExit.Focus();
                moveFlag = false;
                _flag = true;

            }


            if (timer1.Enabled == false && _flag == true)
            {

                shapeMatching();
                empty = 0;

                if (flag == false) // if at least 5 same shapes with same color are not side by side
                {
                    for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                        {
                            if (buttons[i, j].ImageList == null)
                            {
                                empty++;
                            }
                        }
                    }
                    if (empty > 0)
                    {
                        if (empty < 3)
                        {
                            rndShapeColor(empty);
                            shapeMatching();
                            empty = 0;
                            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                            {
                                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                                {
                                    if (buttons[i, j].ImageList == null)
                                    {
                                        empty++;
                                    }
                                }
                            }
                            if (empty == 0) // if the board is full
                            {
                                if (MessageBox.Show("Game Over! Would you like to play again?", "GAME OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    lblScr.Text = (0.ToString());
                                    for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                                    {
                                        for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                                        {
                                            buttons[i, j].ImageList = null;
                                        }
                                    }
                                    rndShapeColor(3);
                                }
                                else
                                {
                                    MessageBox.Show("Your Score: " + lblScr.Text + "\n\nYour Best Score: " + lblBstScr.Text, "GAME OVER", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            rndShapeColor(3);
                            shapeMatching();
                            empty = 0;
                            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                            {
                                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                                {
                                    if (buttons[i, j].ImageList == null)
                                    {
                                        empty++;
                                    }
                                }
                            }
                            if (empty == 0)
                            {
                                if (MessageBox.Show("Game Over! Would you like to play again?", "GAME OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    score = 0;
                                    lblScr.Text = (0.ToString());
                                    for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                                    {
                                        for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                                        {
                                            buttons[i, j].ImageList = null;
                                        }
                                    }

                                    rndShapeColor(3);

                                }//end-if
                                else
                                {
                                    MessageBox.Show("Your Score: " + lblScr.Text + "\n\nYour Best Score: " + lblBstScr.Text, "GAME OVER", MessageBoxButtons.OK);
                                }
                            }//end-if
                        }//end-else

                    }//end-if

                }//end-if

            }//end-if

        }

        //When the user makes a move, play a sound for each step
        public void playStepSound()
        {
            SoundPlayer _soundplayer = new SoundPlayer(@"../../step.wav");
            _soundplayer.Play();
        }

        //At the end of the steps, if the user takes a score point, play a different sound
        public void playScoreSound()
        {
            SoundPlayer _soundplayer = new SoundPlayer(@"../../score.wav");
            _soundplayer.Play();
        }


        public int empty = 0;
        public int cCount = 2;
        public int rCount = 2;
        public int imIndex;
        public int cIndex = 0;
        public int rIndex = 0;
        public int score = 0;
        public bool flag = false;


        public void shapeMatching()
        {
            flag = false;

            //horizontal same color and shape control
            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 1; j < buttons.GetUpperBound(1); j++)
                {
                    if (buttons[i, j].ImageList == ımageList1 &&
                        buttons[i, j - 1].ImageList == ımageList1 &&
                        buttons[i, j + 1].ImageList == ımageList1 &&
                        buttons[i, j].ImageIndex == buttons[i, j - 1].ImageIndex &&
                        buttons[i, j].ImageIndex == buttons[i, j + 1].ImageIndex)
                    {
                        cIndex = j + 1; //cIndex-->column index of the last of the adjacent shapes
                        imIndex = buttons[i, j].ImageIndex;
                        cCount++; //cCount-->shows how many shapes are side by side
                    }

                }
                if (cCount >= 5)
                {
                    flag = true;
                    if (a == 15 & b == 15)
                    {
                        score += (cCount * 1);

                    }
                    else if (a == 9 && b == 9)
                    {
                        score += (cCount * 3);
                    }
                    else if (a == 6 && b == 6)
                    {
                        score += (cCount * 5);

                    }
                    else //custom
                    {
                        score += (cCount * 2);
                    }

                    lblScr.Text = score.ToString();

                    XmlDocument xdosya3 = new XmlDocument();
                    xdosya3.Load(@"../../userinfo.xml");
                    foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
                    {

                        if (Username == node.SelectSingleNode("Username").InnerText)
                        {
                            if (score > Convert.ToInt32(node.SelectSingleNode("BestScore").InnerText))
                            {
                                node.SelectSingleNode("BestScore").InnerText = score.ToString(); //write user's best score to xml file 
                                lblBstScr.Text = score.ToString();
                            }
                            
                            xdosya3.Save(@"../../userinfo.xml");
                        }
                    }


                    for (int k = cCount; k > 0; k--)
                    {
                        buttons[i, cIndex].ImageList = null;
                        cIndex--;
                    }
                    playScoreSound();
                }

                cCount = 2;
            }//end-for

            //vertical control
            for (int j = 0; j <= buttons.GetUpperBound(0); j++)
            {
                for (int i = 1; i < buttons.GetUpperBound(1); i++)
                {
                    if (buttons[i, j].ImageList == ımageList1 &&
                        buttons[i - 1, j].ImageList == ımageList1 &&
                        buttons[i + 1, j].ImageList == ımageList1 &&
                        buttons[i, j].ImageIndex == buttons[i - 1, j].ImageIndex &&
                        buttons[i, j].ImageIndex == buttons[i + 1, j].ImageIndex)
                    {
                        rIndex = i + 1;
                        imIndex = buttons[i, j].ImageIndex;
                        rCount++;
                    }

                }
                if (rCount >= 5)
                {
                    flag = true;
                    if (a == 15 & b == 15)
                    {
                        score += (rCount * 1);

                    }
                    else if (a == 9 && b == 9)
                    {
                        score += (rCount * 3);
                    }
                    else if (a == 6 && b == 6)
                    {
                        score += (rCount * 5);

                    }
                    else //custom
                    {
                        score += (rCount * 2);
                    }
                    lblScr.Text = score.ToString();

                    XmlDocument xdosya3 = new XmlDocument();
                    xdosya3.Load(@"../../userinfo.xml");
                    foreach (XmlNode node in xdosya3.SelectNodes("/Users/User")) //xpath to /Users/User
                    {

                        if (Username == node.SelectSingleNode("Username").InnerText)
                        {

                            if (score > Convert.ToInt32(node.SelectSingleNode("BestScore").InnerText))
                            {
                                node.SelectSingleNode("BestScore").InnerText = score.ToString(); //write user's best score to xml file 
                                lblBstScr.Text = score.ToString();
                            }
                           
                            xdosya3.Save(@"../../userinfo.xml");
                        }
                    }


                    for (int k = rCount; k > 0; k--)
                    {
                        buttons[rIndex, j].ImageList = null;
                        rIndex--;
                    }
                    playScoreSound();
                }

                rCount = 2;
            }//end-for

        }

        private void rndShapeColor(int num)
        {
            Random rnd = new Random();
            int rowIndex, colIndex, imageIndex;

            for (int i = 0; i < num; i++)
            {
                rowIndex = rnd.Next(0, buttons.GetUpperBound(0) + 1);
                colIndex = rnd.Next(0, buttons.GetUpperBound(1) + 1);
                if (buttons[rowIndex, colIndex].ImageList == ımageList1)
                {
                    i--;
                    continue;
                }
                buttons[rowIndex, colIndex].ImageList = ımageList1;
                //-----------------------
                //red
                if (Properties.Settings.Default.check4 == true && Properties.Settings.Default.check5 == false && Properties.Settings.Default.check6 == false)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        //0 or 1
                        imageIndex = rnd.Next(0, 2);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //0 or 2

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 3);
                            if (imageIndex != 1)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //1 or 2
                        imageIndex = rnd.Next(1, 3);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //0, 1 or 2
                        imageIndex = rnd.Next(0, 3);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //green
                else if (Properties.Settings.Default.check4 == false && Properties.Settings.Default.check5 == true && Properties.Settings.Default.check6 == false)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        //3 or 4
                        imageIndex = rnd.Next(3, 5);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //3 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 6);
                            if (imageIndex != 4)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //4 or 5
                        imageIndex = rnd.Next(4, 6);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //3, 4 or 5
                        imageIndex = rnd.Next(3, 6);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //blue
                else if (Properties.Settings.Default.check4 == false && Properties.Settings.Default.check5 == false && Properties.Settings.Default.check6 == true)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        //6 or 7
                        imageIndex = rnd.Next(6, 8);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(6, 9);
                            if (imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //7 or 8
                        imageIndex = rnd.Next(7, 9);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //6, 7 or 8
                        imageIndex = rnd.Next(6, 9);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //red,green
                else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check5 == true && Properties.Settings.Default.check6 == false)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //0 or 3

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 4);
                            if (imageIndex != 1 && imageIndex != 2)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //1 or 4

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 5);
                            if (imageIndex != 2 && imageIndex != 3)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //2 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 6);
                            if (imageIndex != 3 && imageIndex != 4)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {

                        bool state = false;
                        //0, 1, 3 or 4

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 5);
                            if (imageIndex != 2)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //0, 2, 3 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 6);
                            if (imageIndex != 1 && imageIndex != 4)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //1, 2, 4 or 5

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 6);
                            if (imageIndex != 3)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        //0, 1, 2, 3, 4 or 5
                        imageIndex = rnd.Next(0, 6);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                    }
                }
                //red,blue
                else if (Properties.Settings.Default.check4 == true && Properties.Settings.Default.check5 == false && Properties.Settings.Default.check6 == true)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //0 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 7);
                            if (imageIndex != 1 && imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //1 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //2 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {

                        bool state = false;
                        //0, 1, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //0, 2, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 1 && imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //1, 2, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }


                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //0, 1, 2, 6, 7 or 8
                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                }
                //green,blue
                else if (Properties.Settings.Default.check4 == false && Properties.Settings.Default.check5 == true && Properties.Settings.Default.check6 == true)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //3 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 7);
                            if (imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //4 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(4, 8);
                            if (imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //5 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(5, 9);
                            if (imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {

                        bool state = false;
                        //3, 4, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 8);
                            if (imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //3, 5, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(3, 9);
                            if (imageIndex != 4 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //4, 5, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(4, 9);
                            if (imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {

                        //3, 4, 5, 6, 7 or 8                         
                        imageIndex = rnd.Next(3, 9);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;

                    }
                }
                //red,green,blue
                else if (Properties.Settings.Default.check4 == true && Properties.Settings.Default.check5 == true && Properties.Settings.Default.check6 == true)
                {
                    if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //0, 3 or 6

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 7);
                            if (imageIndex != 1 && imageIndex != 2 && imageIndex != 4 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {
                        bool state = false;
                        //1, 4 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 8);
                            if (imageIndex != 2 && imageIndex != 3 && imageIndex != 5 && imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //2, 5 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(2, 9);
                            if (imageIndex != 3 && imageIndex != 4 && imageIndex != 6 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }
                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == false)
                    {

                        bool state = false;
                        //0, 1, 3, 4, 6 or 7

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 8);
                            if (imageIndex != 2 && imageIndex != 5)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == false && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //0, 2, 3, 5, 6 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(0, 9);
                            if (imageIndex != 1 && imageIndex != 4 && imageIndex != 7)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == false && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {
                        bool state = false;
                        //1, 2, 4, 5, 7 or 8

                        while (state == false)
                        {
                            imageIndex = rnd.Next(1, 9);
                            if (imageIndex != 3 && imageIndex != 6)
                            {
                                state = true;
                                buttons[rowIndex, colIndex].ImageIndex = imageIndex;
                            }
                        }

                    }
                    else if (Properties.Settings.Default.check1 == true && Properties.Settings.Default.check2 == true && Properties.Settings.Default.check3 == true)
                    {

                        //0, 1, 2, 3, 4, 5, 6, 7 or 8                         
                        imageIndex = rnd.Next(0, 9);
                        buttons[rowIndex, colIndex].ImageIndex = imageIndex;

                    }
                }//end

            }//end-for

        }

    }
}