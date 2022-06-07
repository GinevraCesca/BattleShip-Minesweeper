using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Minesweeper
{
    public partial class Form1 : Form
    {
        List<int> mineList = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});
        List<Button> buttons = new List<Button>();
        Random randGen = new Random();
        int time = 10000;
        int bombs = 10;

        public Form1()
        {
            InitializeComponent();
            buttons.Add(A1);
            buttons.Add(A2);
            buttons.Add(A3);
            buttons.Add(A4);
            buttons.Add(A5);
            buttons.Add(A6);
            buttons.Add(A7);
            buttons.Add(B1);
            buttons.Add(B2);
            buttons.Add(B3);
            buttons.Add(B4);
            buttons.Add(B5);
            buttons.Add(B6);
            buttons.Add(B7);
            buttons.Add(C1);
            buttons.Add(C2);
            buttons.Add(C3);
            buttons.Add(C4);
            buttons.Add(C5);
            buttons.Add(C6);
            buttons.Add(C7);
            buttons.Add(D1);
            buttons.Add(D2);
            buttons.Add(D3);
            buttons.Add(D4);
            buttons.Add(D5);
            buttons.Add(D6);
            buttons.Add(D7);
            buttons.Add(E1);
            buttons.Add(E2);
            buttons.Add(E3);
            buttons.Add(E4);
            buttons.Add(E5);
            buttons.Add(E6);
            buttons.Add(E7);
        }

        private void E7_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonCheck(button);
        }

        public void ButtonCheck(Button b)
        {
            if (flagButton.BackColor == Color.Goldenrod)
            {
                b.Text = $"{mineList[b.TabIndex]}";

                if (b.Text == "99" || b.Text == "100" || b.Text == "101" || b.Text == "102" || b.Text == "103")
                {
                    b.Text = "";
                    b.BackgroundImage = Properties.Resources.bomb_icon;
                    titleLabel.Text = "You Lost";
                    GameOver();
                }
            }

            else if (flagButton.BackColor == Color.Green)
            {
                if (b.BackgroundImage == Properties.Resources.flag_folded_icon)
                {
                    b.BackgroundImage = null;
                    bombs++;
                    bombsLabel.Text = $"({bombs}) bombs left";
                }
                else if (b.BackgroundImage == null)
                {
                    b.BackgroundImage = Properties.Resources.flag_folded_icon;
                    bombs--;
                    bombsLabel.Text = $"({bombs}) bombs left";
                }
            }
        }

        public void GameOver()
        {
            gameEngine.Stop();

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Enabled = false;
            }

            PlayButton.Text = "PLAY AGAIN";
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            mineList = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            PlayButton.Text = "PLAY";
            titleLabel.Text = "MINESWEEPER";
            bombsLabel.Text = "(10) bombs left";
            bombs = 10;
            gameEngine.Start();
            time = 10000;

            for (int i = 0; i < 10; i++)
            {
                int randValue = 0;
                randValue = randGen.Next(0, 35);

                while (mineList[randValue] == 99)
                {
                    randValue = randGen.Next(0, 35);
                }

                mineList[randValue] = 99;
            }

            for (int i = 0; i < mineList.Count; i++)
            {
                if (i == 0 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }

                else if (i == 7 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }

                else if (i == 14 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }

                else if (i == 21 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }

                else if (i == 28 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }
                }

                else if (i == 6 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }

                else if (i == 13 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 8]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }
                }

                else if (i == 20 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 8]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch 
                    { }
                }

                else if (i == 27 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 8]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }
                }

                else if (i == 34 && mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 8]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }
                }

                else if (mineList[i] >= 99)
                {
                    try
                    {
                        mineList[i - 8]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i - 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 1]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 6]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 7]++;
                    }
                    catch
                    { }

                    try
                    {
                        mineList[i + 8]++;
                    }
                    catch
                    { }
                }
            }

            for (int i = 0; i < buttons.Count; i++)
            { 
                buttons[i].Enabled = false;
                buttons[i].Text = "";
                buttons[i].BackgroundImage = null;
            }
           

            //A1.BackgroundImage = null;
            //A2.BackgroundImage = null;
            //A3.BackgroundImage = null;
            //A4.BackgroundImage = null;
            //A5.BackgroundImage = null;
            //A6.BackgroundImage = null;
            //A7.BackgroundImage = null;
            //B1.BackgroundImage = null;
            //B2.BackgroundImage = null;
            //B3.BackgroundImage = null;
            //B4.BackgroundImage = null;
            //B5.BackgroundImage = null;
            //B6.BackgroundImage = null;
            //B7.BackgroundImage = null;
            //C1.BackgroundImage = null;
            //C2.BackgroundImage = null;
            //C3.BackgroundImage = null;
            //C4.BackgroundImage = null;
            //C5.BackgroundImage = null;
            //C6.BackgroundImage = null;
            //C7.BackgroundImage = null;
            //D1.BackgroundImage = null;
            //D2.BackgroundImage = null;
            //D3.BackgroundImage = null;
            //D4.BackgroundImage = null;
            //D5.BackgroundImage = null;
            //D6.BackgroundImage = null;
            //D7.BackgroundImage = null;
            //E1.BackgroundImage = null;
            //E2.BackgroundImage = null;
            //E3.BackgroundImage = null;
            //E4.BackgroundImage = null;
            //E5.BackgroundImage = null;
            //E6.BackgroundImage = null;
            //E7.BackgroundImage = null;
        }

        private void flagButton_Click(object sender, EventArgs e)
        {
            if (flagButton.BackColor == Color.Goldenrod)
            {
                flagButton.BackColor = Color.Green;
            }
            else
            {
                flagButton.BackColor = Color.Goldenrod;
            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            time--;
            timeLabel.Text = $"time left: {time}";

            if (time == 0)
            {
                gameEngine.Stop();
                GameOver();
            }
        }
    }
}
