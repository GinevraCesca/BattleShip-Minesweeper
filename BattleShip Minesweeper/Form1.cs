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
using System.IO;

namespace BattleShip_Minesweeper
{
    public partial class Form1 : Form
    {
        List<int> mineList = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});
        List<Button> buttons = new List<Button>();
        Random randGen = new Random();
        int time = 5000;
        int bombs = 0;
        int win1 = 0;
        int win2 = 0;

        SoundPlayer explosion = new SoundPlayer(Properties.Resources.Bomb_2_SoundBible_com_953367492);
        SoundPlayer applause = new SoundPlayer(Properties.Resources.Audience_Applause_Matthiew11_1206899159);
        System.Windows.Media.MediaPlayer backgroundMedia = new System.Windows.Media.MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            //backgroundMedia.Open(new Uri(Application.StartupPath + "/Resouces/______"));
            //backgroundMedia.Play();
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

            if (mineList[button.TabIndex] < 99)
            {
                win1++;
            }
        }

        public void ButtonCheck(Button b)
        {
            // show numbers or bombs
            if (flagButton.BackColor == Color.Goldenrod)
            {
                b.Text = $"{mineList[b.TabIndex]}";

                if (b.Text == "99" || b.Text == "100" || b.Text == "101" || b.Text == "102" || b.Text == "103" || b.Text == "104" || b.Text == "105" || b.Text == "106")
                {
                    b.Text = "";
                    b.BackgroundImage = Properties.Resources.bomb_icon;
                    titleLabel.Text = "You Lost";
                    explosion.Play();
                    GameOver();
                }
            }

            //show flags
            else if (flagButton.BackColor == Color.Green)
            {
                if (b.BackgroundImage == null)
                {
                    b.BackgroundImage = Properties.Resources.flag_folded_icon;
                    bombs--;
                    bombsLabel.Text = $"({bombs}) bombs left";

                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (mineList[i] >= 99 && buttons[i].BackgroundImage == Properties.Resources.Flag_2_icon && bombs == 0)
                        {
                            win2++;
                        }
                    }
                }

                else
                {
                    b.BackgroundImage = null;
                    bombs++;
                    bombsLabel.Text = $"({bombs}) bombs left";
                }
            }

            //easy game win statement
            if (win1 == 30 && easyButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }

            if (win2 == 5 && easyButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }

            //medium game win
            if (win1 == 25 && mediumButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }

            if (win2 == 10 && mediumButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }

            //hard game win
            if (win1 == 20 && hardButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }

            if (win2 == 15 && hardButton.BackColor == Color.Green)
            {
                titleLabel.Text = "Congratulation. You Won";
                applause.Play();
                GameOver();
            }
        }

        public void GameOver()
        {
            gameEngine.Stop();

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Enabled = false;
            }

            for (int i = 0; i < mineList.Count; i++)
            {
                if (mineList[i] >= 99)
                {
                    buttons[i].BackgroundImage = Properties.Resources.bomb_icon;
                }
            }

            PlayButton.Text = "PLAY AGAIN";
            easyButton.Enabled = true;
            mediumButton.Enabled = true;
            hardButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            mineList = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            PlayButton.Text = "PLAY";
            titleLabel.Text = "MINESWEEPER";
            flagButton.BackColor = Color.Goldenrod;
            gameEngine.Start();
            applause.Stop();
            explosion.Stop();
            win1 = 0;
            win2 = 0;

            //win if flags = bombs
            if (easyButton.BackColor == Color.Green)
            {
                bombsLabel.Text = "(5) bombs left";
                time = 6000;
                bombs = 5;

                for (int i = 0; i < 5; i++)
                {
                    int randValue = 0;
                    randValue = randGen.Next(0, 35);

                    while (mineList[randValue] == 99)
                    {
                        randValue = randGen.Next(0, 35);
                    }

                    mineList[randValue] = 99;
                }
            }

            if (mediumButton.BackColor == Color.Green)
            {
                bombsLabel.Text = "(10) bombs left";
                time = 5000;
                bombs = 10;

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
            }

            else if (hardButton.BackColor == Color.Green)
            {
                bombsLabel.Text = "(15) bombs left";
                time = 4000;
                bombs = 15;

                for (int i = 0; i < 15; i++)
                {
                    int randValue = 0;
                    randValue = randGen.Next(0, 35);

                    while (mineList[randValue] == 99)
                    {
                        randValue = randGen.Next(0, 35);
                    }

                    mineList[randValue] = 99;
                }
            }

            //add numbers to each button
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
                buttons[i].Enabled = true;
                buttons[i].Text = "";
                buttons[i].BackgroundImage = null;
            }
            
            easyButton.Enabled = false;
            mediumButton.Enabled = false;
            hardButton.Enabled = false;
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
                titleLabel.Text = "You Lost";
                GameOver();
            }
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Green;
            mediumButton.BackColor = Color.Goldenrod;
            hardButton.BackColor = Color.Goldenrod;

            PlayButton.Enabled = true;

            //var easySound = new System.Windows.Media.MediaPlayer();
            //easySound.Open(new Uri(Application.StartupPath + "_____");
            //easySound.Play();
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Goldenrod;
            mediumButton.BackColor = Color.Green;
            hardButton.BackColor = Color.Goldenrod;

            PlayButton.Enabled = true;
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Goldenrod;
            mediumButton.BackColor = Color.Goldenrod;
            hardButton.BackColor = Color.Green;

            PlayButton.Enabled = true;
        }
    }
}
