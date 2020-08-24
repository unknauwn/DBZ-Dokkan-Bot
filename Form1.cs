using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DBZ_DokkanBottle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            CSelectDifficulty.SelectedIndex = 3;
            CSelectDice.SelectedIndex = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("Key pressed: " + e.KeyCode.ToString());
                timer1.Stop();
            }
        }

        #region MouseClick
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        #endregion


        public Bitmap LiveDBZ;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (NbGame.Value == Story.GameDone && NbGame.Value != 0)
            { EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Bot Stopped"); button3.PerformClick(); }
            else
                BotUpdateEVent();
        }
        //Start Bot
        private void button1_Click(object sender, EventArgs e)
        {
            if (CSelectDifficulty.SelectedIndex >= 0)
            { timer1.Start(); EventBotLogs.AppendText(DateTime.Now.ToString() + " Bot Started"); }
            else
                button1.Text = "No Difficulty Selected";
        }
        //StopBot
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 150;
            button1.Text = "Start Botting";
        }
        //TakeScreenshot
        private void button2_Click(object sender, EventArgs e)
        {
            LiveDBZ = APIDetector.AppScreen.CaptureApplication("Nox");
            TextBoxInfo();
        }

        public void TextBoxInfo()
        {
            xTextBox.Text = APIDetector.AppScreen.GetPos.CursorX.ToString();
            yTextBox.Text = APIDetector.AppScreen.GetPos.CursorY.ToString();
            widthTextBox.Text = APIDetector.AppScreen.GetPos.AppLeftLoc.ToString();
            heightTextBox.Text = APIDetector.AppScreen.GetPos.AppTopLoc.ToString();
        }

        public void SetCursorPos(Int32 X = 0, Int32 Y = 0, Boolean Positive = true)
        {
            if (Positive)
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + APIDetector.AppScreen.GetPos.CursorX.X + X, APIDetector.AppScreen.GetPos.CursorY.Y + Y);
            else
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + APIDetector.AppScreen.GetPos.CursorX.X - X, APIDetector.AppScreen.GetPos.CursorY.Y - Y);


            xTextBox.Text = (APIDetector.AppScreen.GetPos.AppLeftLoc + APIDetector.AppScreen.GetPos.CursorX.X).ToString();
            yTextBox.Text = (APIDetector.AppScreen.GetPos.CursorY.Y + Y).ToString();
        }

        //Random Timer
        private Int32 RandomTimer(Int32 Min, Int32 Max)
        {
            Random rnd = new Random();
            return rnd.Next(Min, Max);
        }

        public void BotUpdateEVent()
        {
            LiveDBZ = APIDetector.AppScreen.CaptureApplication("Nox");

            if (checkBoxTB.Checked)
            {
                if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Item_Game))
                {
                    TBInGameEvents();
                }
                else
                {
                    TBGameEvents();
                    DSRefillLbl.Text = Story.DSToRefill.ToString();
                }
            }
            else
            {
                if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Item_Game))
                {
                    InGameEvents();
                }
                else
                {
                    GameEvents();
                    GameDoneLbl.Text = Story.GameDone.ToString();
                    DSRefillLbl.Text = Story.DSToRefill.ToString();
                }
                EventBotLogs.ScrollToCaret();
            }
        }

        private void InGameEvents()
        {
            if (APIDetector.CheckEventPos(LiveDBZ, LibImg.OK_Wrong_Way))
            {
                SetCursorPos((LibImg.OK_Wrong_Way.Width / 2), (LibImg.OK_Wrong_Way.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(150, 300);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Hard Way Unavailable");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Move))
            {
                if (CSelectDice.SelectedIndex == 0)
                    SetCursorPos(LibImg.Move.Width - 230, LibImg.Move.Height + 20);
                else if (CSelectDice.SelectedIndex == 1)
                    SetCursorPos((LibImg.Move.Width - 115), (LibImg.Move.Height + 10));
                else if (CSelectDice.SelectedIndex == 2)
                    SetCursorPos((LibImg.Move.Width / 2), (LibImg.Move.Height / 2));
                else
                {
                    CSelectDice.SelectedIndex = new Random().Next(0, 2);
                }

                DoMouseClick();
                timer1.Interval = RandomTimer(900, 1700);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Moving");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Select_Way))
            {
                if (CSelectDice.SelectedIndex == 0)
                {
                    if (CkWayL.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width + 10), (LibImg.Select_Way.Height - 285));
                        Thread.Sleep(250);
                        DoMouseClick();
                    }
                    if (CkWayR.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width + 150), (LibImg.Select_Way.Height - 220));
                        Thread.Sleep(250);
                        DoMouseClick();
                    }
                    if (CkWayT.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width + 150), (LibImg.Select_Way.Height - 285));
                        Thread.Sleep(250);
                        DoMouseClick();
                    }
                    if (CkWayD.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width + 20), (LibImg.Select_Way.Height - 220));
                        Thread.Sleep(250);
                        DoMouseClick();
                    }
                }
                else if (CSelectDice.SelectedIndex == 1)
                    SetCursorPos((LibImg.Move.Width / 2), (LibImg.Move.Height / 2));
                else
                {
                    if (CkWayL.Checked)
                        if (CkWayL.Checked)
                            if (CkWayL.Checked)
                            {
                                SetCursorPos((LibImg.Select_Way.Width - 75), (LibImg.Select_Way.Height - 200));
                                //DoMouseClick();
                            }
                    if (CkWayR.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width - 70), (LibImg.Select_Way.Height - 250));
                        DoMouseClick();
                    }
                    if (CkWayT.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width - 200), (LibImg.Select_Way.Height - 250));
                        DoMouseClick();
                    }
                    if (CkWayD.Checked)
                    {
                        SetCursorPos((LibImg.Select_Way.Width - 75), (LibImg.Select_Way.Height - 200));
                        DoMouseClick();
                    }
                }

                //DoMouseClick();
                timer1.Interval = RandomTimer(250, 1000);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Choosing Way");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Item_Game) && !APIDetector.CheckEventPos(LiveDBZ, LibImg.Move))
            {
                SetCursorPos((LibImg.Item_Game.Width / 2), (LibImg.Item_Game.Height - 320));
                DoMouseClick();
                timer1.Interval = RandomTimer(550, 1000);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Fighting");
            }
            else
            {
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 250, APIDetector.AppScreen.GetPos.AppTopLoc + 250);
                DoMouseClick();
                timer1.Interval = RandomTimer(1000, 2000);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Unknown Event");
            }
        }

        private void GameEvents()
        {
            if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Friend_Request))
            {
                SetCursorPos((LibImg.Friend_Request.Width / 2), (LibImg.Friend_Request.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(500, 1050);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Friend Request");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.RestoreACT))
            {
                if (AutoRestoreACTCheck.Checked)
                {
                    if (NbDS.Value > Story.DSToRefill && NbDS.Value != 0)
                    {
                        SetCursorPos((LibImg.RestoreACT.Width / 2), (LibImg.RestoreACT.Height / 2));
                        DoMouseClick();
                        timer1.Interval = RandomTimer(500, 1550);
                    }
                    else
                        AutoRestoreACTCheck.Checked = false;
                }
                else
                {
                    SetCursorPos((LibImg.RestoreACT.Width / 2) - 180, (LibImg.RestoreACT.Height / 2));
                    DoMouseClick();
                    timer1.Interval = RandomTimer(800000, 1500000);
                    EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Out of ACT, Next Check in " + TimeSpan.FromMilliseconds(timer1.Interval).ToString("mm':'ss")); EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Out of ACT, Next Check in " + TimeSpan.FromMilliseconds(timer1.Interval).ToString("mm':'ss"));
                }
            }
            //else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.ACTRestored))
            //{
            //    SetCursorPos((LibImg.ACTRestored.Width / 2), (LibImg.ACTRestored.Height / 2));
            //    DoMouseClick();
            //    timer1.Interval = RandomTimer(500, 1500);
            //    Story.DSToRefill = Story.DSToRefill + 1;
            //    EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " ACT Restored");
            //}
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Friend_Selection))
            {
                SetCursorPos((LibImg.Friend_Selection.Width - 150), (LibImg.Friend_Selection.Height - 240));
                DoMouseClick();
                timer1.Interval = RandomTimer(200, 550);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Friend Selected");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Start_Game))
            {
                SetCursorPos((LibImg.Start_Game.Width / 2), (LibImg.Start_Game.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(1200, 2550);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Game Started");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_N) || APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_H) || APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_ZH) || APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_SU) || APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_SU2))
            {
                if (CSelectDifficulty.SelectedIndex == 0)
                {
                    APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_N);
                    SetCursorPos((LibImg.Difficulty_N.Width / 2), (LibImg.Difficulty_N.Height / 2));
                }
                else if (CSelectDifficulty.SelectedIndex == 1)
                {
                    APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_H);
                    SetCursorPos((LibImg.Difficulty_H.Width / 2), (LibImg.Difficulty_H.Height / 2));
                }
                else if (CSelectDifficulty.SelectedIndex == 2)
                {
                    APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_ZH);
                    SetCursorPos((LibImg.Difficulty_ZH.Width / 2), (LibImg.Difficulty_ZH.Height / 2));
                }
                else if (CSelectDifficulty.SelectedIndex == 3)
                {
                    APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_SU);
                    SetCursorPos((LibImg.Difficulty_SU.Width / 2), (LibImg.Difficulty_SU.Height / 2));
                }
                else if (CSelectDifficulty.SelectedIndex == 4)
                {
                    APIDetector.CheckEventPos(LiveDBZ, LibImg.Difficulty_SU2);
                    SetCursorPos((LibImg.Difficulty_SU2.Width / 2), (LibImg.Difficulty_SU2.Height / 2));
                }
                DoMouseClick();
                timer1.Interval = RandomTimer(550, 1500);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Difficulty " + CSelectDifficulty.Text + " Selected");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.OK_End_Game))// || APIDetector.CheckEventPos(LiveDBZ, LibImg.OK_N21_L1))
            {
                SetCursorPos((LibImg.OK_End_Game.Width / 2), (LibImg.OK_End_Game.Height / 2));
                DoMouseClick();
                Thread.Sleep(250);
                //SetCursorPos((LibImg.OK_N21_L1.Width / 2), (LibImg.OK_N21_L1.Height / 2));
                //DoMouseClick();
                timer1.Interval = RandomTimer(1000, 1550);
                Story.GameDone = Story.GameDone + 1;
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Game Ended");
            }
            else
            {
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 250);
                DoMouseClick();
                Thread.Sleep(250);
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 500);
                DoMouseClick();
                timer1.Interval = RandomTimer(900, 1700);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Unknown Event");
            }
        }

        private void ResetInfoGame_Click(object sender, EventArgs e)
        {
            Story.GameDone = 0;
            Story.DSToRefill = 0;
            GameDoneLbl.Text = Story.GameDone.ToString();
            DSRefillLbl.Text = Story.DSToRefill.ToString();
        }

        private void AutoRestoreACTCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AutoRestoreACTCheck.Checked)
                NbDS.Enabled = true;
            else
                NbDS.Enabled = false;
        }

        private void checkBoxTB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTB.Checked)
            {
                CSelectDifficulty.Enabled = false;
                CSelectDice.Enabled = false;
                CkWayL.Enabled = false;
                CkWayR.Enabled = false;
                CkWayT.Enabled = false;
                CkWayD.Enabled = false;
                NbGame.Enabled = false;
            }
            else
            {
                CSelectDifficulty.Enabled = true;
                CSelectDice.Enabled = true;
                CkWayL.Enabled = true;
                CkWayR.Enabled = true;
                CkWayT.Enabled = true;
                CkWayD.Enabled = true;
                NbGame.Enabled = true;
            }
        }

        #region TB Events
        private void TBInGameEvents()
        {
            if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Move))
            {
                SetCursorPos((LibImg.Move.Width / 2), (LibImg.Move.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(900, 1700);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Moving");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Select_Way) && (APIDetector.CheckEventPos(LiveDBZ, LibImg.Way_Arrow) || APIDetector.CheckEventPos(LiveDBZ, LibImg.Way_ArrowD)))
            {
                for (int m = 0; m < 3; m += 1)
                {
                    SetCursorPos((LibImg.Way_Arrow.Width / 2) + 5, (LibImg.Way_Arrow.Height / 2) + 7 - m);
                    SetCursorPos((LibImg.Way_ArrowD.Width / 2) +7 - m, (LibImg.Way_ArrowD.Height / 2) +5);
                }
                    DoMouseClick();
                timer1.Interval = RandomTimer(250, 1000);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Choosing Way");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Item_Game) && !APIDetector.CheckEventPos(LiveDBZ, LibImg.Move))
            {
                SetCursorPos((LibImg.Item_Game.Width / 2), (LibImg.Item_Game.Height - 320));
                DoMouseClick();
                timer1.Interval = RandomTimer(550, 600);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Fighting");
            }
            else
            {
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 250);
                DoMouseClick();
                timer1.Interval = RandomTimer(1000, 2000);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Misc Event");
            }
        }

        private void TBGameEvents()
        {

            if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Participe_TB))
            {
                SetCursorPos((LibImg.Participe_TB.Width / 2) - 120, (LibImg.Participe_TB.Height / 2) - 50);
                DoMouseClick();
                timer1.Interval = RandomTimer(500, 1050);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Participating TB");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.DifficultyX2))
            {
                SetCursorPos((LibImg.DifficultyX2.Width / 2), (LibImg.DifficultyX2.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(500, 1050);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Difficulty Selected");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Next_TB))
            {
                SetCursorPos((LibImg.Next_TB.Width / 2), (LibImg.Next_TB.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(500, 1050);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Round Confirmed");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Friend_Request))
            {
                SetCursorPos((LibImg.Friend_Request.Width / 2), (LibImg.Friend_Request.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(500, 1050);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Friend Request");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Cancel_DS))
            {
                if (!AutoRestoreACTCheck.Checked)
                {
                    SetCursorPos((LibImg.Cancel_DS.Width / 2), (LibImg.Cancel_DS.Height / 2));
                    DoMouseClick();
                    timer1.Interval = RandomTimer(800000, 1500000);
                    EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Out of ACT, Next Check in " + TimeSpan.FromMilliseconds(timer1.Interval).ToString("mm':'ss")); EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Out of ACT, Next Check in " + TimeSpan.FromMilliseconds(timer1.Interval).ToString("mm':'ss"));
                }
                else
                {
                    if (Story.DSToRefill < NbDS.Value && NbDS.Value != 0)
                    {
                        SetCursorPos((LibImg.Cancel_DS.Width / 2) + 150, (LibImg.Cancel_DS.Height / 2));
                        DoMouseClick();
                        timer1.Interval = RandomTimer(500, 1500);
                        Story.DSToRefill = Story.DSToRefill + 1;
                        EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " ACT Restored");
                    }
                    else if (Story.DSToRefill >= NbDS.Value && NbDS.Value != 0)
                        AutoRestoreACTCheck.Checked = false;
                }
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Friend_Selection))
            {
                SetCursorPos((LibImg.Friend_Selection.Width - 150), (LibImg.Friend_Selection.Height - 240));
                DoMouseClick();
                timer1.Interval = RandomTimer(200, 550);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Friend Selected");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Start_Game))
            {
                SetCursorPos((LibImg.Start_Game.Width / 2), (LibImg.Start_Game.Height / 2));
                DoMouseClick();
                timer1.Interval = RandomTimer(1200, 2550);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Game Started");
            }
            else if (APIDetector.CheckEventPos(LiveDBZ, LibImg.OK_End_Game))
            {
                SetCursorPos((LibImg.OK_End_Game.Width / 2), (LibImg.OK_End_Game.Height / 2));
                DoMouseClick();
                Thread.Sleep(250);
                timer1.Interval = RandomTimer(1000, 1550);
                Story.GameDone = Story.GameDone + 1;
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " OK Button");
            }
            else
            {
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 250);
                DoMouseClick();
                Thread.Sleep(250);
                Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 495);
                DoMouseClick();
                timer1.Interval = RandomTimer(900, 1700);
                EventBotLogs.AppendText("\r\n" + DateTime.Now.ToString() + " Misc Event");
            }
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            LiveDBZ = APIDetector.AppScreen.CaptureApplication("Nox");
            //Cursor.Position = new Point(APIDetector.AppScreen.GetPos.AppLeftLoc + 200, APIDetector.AppScreen.GetPos.AppTopLoc + 250);
            if (APIDetector.CheckEventPos(LiveDBZ, LibImg.Select_Way) && APIDetector.CheckEventPos(LiveDBZ, LibImg.Way_Arrow))
                for (int m = 0; m < 3; m += 1)
                    SetCursorPos((LibImg.Way_Arrow.Width / 2) + 5, (LibImg.Way_Arrow.Height / 2) + 7 - m);
            //Thread.Sleep(250);
            //DoMouseClick();
        }
    }
}
