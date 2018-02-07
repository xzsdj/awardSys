using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CCWin;
using CCWin.SkinControl;

using System.IO;

namespace awardSys
{
    public delegate void stophandler(bool bl);
    public partial class Form_Main : Form
    {
        public event stophandler stopevent;

        int _timer_count = 0;
        int _cur_mode = 0;

        string _sta_mode = "";
        string _sta_cur = "";

        CJCore cjcore;



        public clsMCI cm = new clsMCI();
        string config_filename = AppDomain.CurrentDomain.BaseDirectory  + "list.csv";
        


        public Form_Main()
        {
            InitializeComponent();
            //base.Opacity = 0;
            Control.CheckForIllegalCrossThreadCalls = false;

            cjcore = new CJCore(this);

            //初始化背景音乐
            //cm.FileName = "alarm.mp3";
            //cm.play();
        }
           

        #region 通用
        public void SetBackgroundImage(string Imagestr, string Mrk)
        {
            //if (Mrk == "主页")
            //{
            //    this.BackgroundImage = Image.FromFile(Imagestr);
            //}
            //else if (Mrk == "开始")
            //{
            //    btnStart.Image = Image.FromFile(Imagestr);
            //    imgStr = Image.FromFile(Imagestr);
            //}
            //else
            //{
            //    imgEnd = Image.FromFile(Imagestr);
            //}
        }

        #region =========================================全屏设置================================================  
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern Int32 ShowWindow(Int32 hwnd, Int32 nCmdShow);
        public const Int32 SW_SHOW = 5; public const Int32 SW_HIDE = 0;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, ref Rectangle lpvParam, Int32 fuWinIni);
        public const Int32 SPIF_UPDATEINIFILE = 0x1;
        public const Int32 SPI_SETWORKAREA = 47;
        public const Int32 SPI_GETWORKAREA = 48;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern Int32 FindWindow(string lpClassName, string lpWindowName);

        /// <summary>  
        /// 设置全屏或这取消全屏  
        /// </summary>  
        /// <param name="fullscreen">true:全屏 false:恢复</param>  
        /// <param name="rectOld">设置的时候，此参数返回原始尺寸，恢复时用此参数设置恢复</param>  
        /// <returns>设置结果</returns>  
        public Boolean SetFormFullScreen(Boolean fullscreen)//, ref Rectangle rectOld
        {
            Rectangle rectOld = Rectangle.Empty;
            Int32 hwnd = 0;
            hwnd = FindWindow("Shell_TrayWnd", null);//获取任务栏的句柄

            if (hwnd == 0) return false;

            if (fullscreen)//全屏
            {
                ShowWindow(hwnd, SW_HIDE);//隐藏任务栏

                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get  屏幕范围
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;//全屏范围
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//窗体全屏幕显示
            }
            else//还原 
            {
                ShowWindow(hwnd, SW_SHOW);//显示任务栏

                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//窗体还原
            }
            return true;
        }
        #endregion =========================================全屏设置================================================  

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            lab_name_2.Location = new Point(935 * SW / 1920, 225 * SH / 1080);
            lab_name_1.Location = new Point(803 * SW / 1920, 225 * SH / 1080);

            lab_name_3.Location = new Point(1054 * SW / 1920, 225 * SH / 1080);
            //
            listBox_2.Location = new Point(710 * SW / 1920, 540 * SH / 1080);
            listBox_1.Location = new Point(880 * SW / 1920, 540 * SH / 1080);
            listBox_3.Location = new Point(1110 * SW / 1920, 500 * SH / 1080);

            cjcore.CJEvent += Cjcore_CJEvent;
            cjcore.CJEventCompleted += Cjcore_CJEventCompleted;
            cjcore.CJEventStoped += Cjcore_CJEventStoped;


            lab_Title.Visible = true;
            lab_Statue.Visible = true;
            gBox_1.Visible = true;
            btnStart.Visible = true;
            btn_Exit.Visible = true;



            #region ==================================加载所有员工======================================
            ExcelToList(config_filename, cjcore.LstUcnum);
            radioButton_3.Text = cjcore.LstUcnum.Count.ToString() + "人中抽取5个三等奖";
            radioButton_2.Text = (cjcore.LstUcnum.Count - 5).ToString() + "人中抽取3个二等奖";
            radioButton_1.Text = (cjcore.LstUcnum.Count - 5 - 3).ToString() + "人中抽取1个一等奖";
            #endregion ==================================加载所有员工======================================
            BackgroundImageLoad();//背景图片加载
            #region =====================================全屏设置============================================
            //SetFormFullScreen(true);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            #endregion=====================================全屏设置============================================

            this.Opacity = 1;
        }

        private void Cjcore_CJEventStoped(string person, int curCJIndex)
        {
            listBox_1.Items.Clear(); listBox_2.Items.Clear(); listBox_3.Items.Clear();
            foreach (string item in cjcore.ZJNum1)
            {
                listBox_1.Items.Add(item);
            }
            foreach (string item in cjcore.ZJNum2)
            {
                listBox_2.Items.Add(item);
            }
            foreach (string item in cjcore.ZJNum3)
            {
                listBox_3.Items.Add(item);
            }
            string[] names = new string[] { "", "", "" };
            string name = person;


            for (int i = 0; i < name.Length; i++)
            {
                names[i] = name.Substring(i, 1);
            }

            lab_name_1.Text = names[0];
            lab_name_2.Text = names[1];

            if (name.Length >= 3)
            {
                if (names[2] == null || names[2] == "")
                    lab_name_3.Text = "  ";
                else
                    lab_name_3.Text = names[2];
            }
            else
            {
                lab_name_3.Text = "  ";
            }

            //写本轮抽奖状态信息
            lab_Statue.Text = cjcore.CJNames[curCJIndex] + ":" + "当前正在抽取第"+ (cjcore.curlc +1).ToString() + "轮奖项";

        }

        private void Cjcore_CJEventCompleted(string person, int curCJIndex)
        {
            
            switch (curCJIndex)
            {
                case 3:
                    lab_Statue.Text = "三等奖：本轮抽奖结束";
                    break;
                case 2:
                    lab_Statue.Text = "二等奖：本轮抽奖结束";
                    break;

                case 1:
                    lab_Statue.Text = "一等奖：本轮抽奖结束";
                    break;     
            }

            
        }

        /// <summary>
        /// 抽奖时，person的显示
        /// </summary>
        /// <param name="person"></param>
        private void Cjcore_CJEvent(string person, int curCJIndex)
        {
            try
            {
                string[] names = new string[] { "", "", "" };
                string name = person;


                for (int i = 0; i < name.Length; i++)
                {
                    names[i] = name.Substring(i, 1);
                }

                lab_name_1.Text = names[0];
                lab_name_2.Text = names[1];

                if (name.Length >= 3)
                {
                    if (names[2] == null || names[2] == "")
                        lab_name_3.Text =   "  ";
                    else
                        lab_name_3.Text = names[2];
                }
                else
                {
                    lab_name_3.Text = "  ";
                }
            }
            catch (Exception e)
            {
                return;
            } 
            
            


        }

        void tbOtherCJNum_TextChanged(object sender, EventArgs e)
        {

        }
        void tbOtherCJNumName_TextChanged(object sender, EventArgs e)
        {

            //lbPrizeTile.Text = tbOtherCJNumName.Text;
        }
        void tbOtherCJNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        public void BackgroundImageLoad()
        {
           // SetBackgroundImage(imageList1.Images[0].ToString(), "主页");
        }

        private void timer_01_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (this.Opacity >= 1)
            {
                //lab_Title.Visible = true;
                //lab_Statue.Visible = true;
                //gBox_1.Visible = true;
                //btnStart.Visible = true;
                //btn_Exit.Visible = true;
                //timer_01.Interval = 500;
            }
            else
            {
                //base.Opacity += 0.1;
            }
            
            //timer_01.Interval = 500;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _cur_mode = int.Parse((string)rb.Tag);
            switch (_cur_mode)
            {
                case 1:
                    _sta_mode = "一等奖：";
                    break;
                case 2:
                    _sta_mode = "二等奖：";
                    break;
                case 3:
                    _sta_mode = "三等奖：";
                    break;
            }
            string tempstr = "";
            cjcore.SwitchCjMode(_cur_mode,out tempstr);
            //lab_Statue.Text = _sta_mode + _sta_cur;
            lab_Statue.Text = tempstr; //_sta_mode + ":" + "当前正在抽取第1轮奖项";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void rcv_endChose(bool status)
        {
            cjcore.isgiveup = status;
            if (stopevent != null)
                stopevent(status);
        }

        public int count = 5; //滚动次数
        public Random r0= new Random();
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //首先判断是否在本组已经抽奖完毕
            if (radioButton_3.Checked == true)
            {
                if (cjcore.ZJNum3.Count == 5)
                {
                    MessageBox.Show("三等奖已经抽奖完毕,请选择抽奖选项！");return;
                }
            }
            else if (radioButton_2.Checked == true)
            {
                if (cjcore.ZJNum2.Count == 3)
                {
                    MessageBox.Show("二等奖已经抽奖完毕,请选择抽奖选项！"); return;
                }
            }
            else if (radioButton_1.Checked == true)
            {
                if (cjcore.ZJNum1.Count == 1)
                {
                    MessageBox.Show("一等奖已经抽奖完毕,抽奖结束！"); return;
                }
            }

            switch ((string)btnStart.Tag)
            {
                case "1":
                    
                    cjcore.CJStart();
                    btnStart.Text = "停止";
                    btnStart.Tag = "2";
                    break;
                case "2": //点击停止后，在滚动100毫秒5次后停止
                    timer1.Enabled = true;
                    btnStart.Enabled = false;
                    count = r0.Next(2,5);
                    break;
            }
            
        }

        public int ExcelToList(string filename, List<string> sList)
        {
            int rtn = 0;
            int temp = 0;
            Person person = new Person();
            FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.GetEncoding(936));

            string str = "";
            string[] content;

            str = SR.ReadLine();

            sList.Clear();

            while (str != null)
            {
                content = str.Split(',');

                if (content.Length == 2)
                {
                    person = new Person();
                    if (int.TryParse(content[0], out temp))
                    {
                        person.ID = temp;
                    }
                    else
                    {
                        rtn = 1001;
                        break;
                    }
                    person.Name = content[1];

                    sList.Add(person.Name);
                }
                else
                {
                    rtn = 1000;
                    break;
                }

                str = SR.ReadLine();
            }

            SR.Close();
            SR.Dispose();
            SR = null;
            FS.Close();
            FS.Dispose();
            FS = null;

            return rtn;
        }

        private void lab_name_3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public int indexnum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (indexnum == count)
            {
                indexnum = 0;
                btnStart.Enabled = true;
                this.timer1.Enabled = false;
                cjcore.CJStop();
                btnStart.Text = "开始抽奖";
                btnStart.Tag = "1";
                Form_Prompt frm = new awardSys.Form_Prompt();
                frm._endChose = rcv_endChose;
                frm.Show(this);
                //btnStart.Focus();
            }
            else
            {
                indexnum = indexnum + 1;
            }
        }

        /// <summary>
        /// 按任意键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            //switch ((string)btnStart.Tag)
            //{
            //    case "1":

            //        cjcore.CJStart();
            //        btnStart.Text = "停止";
            //        btnStart.Tag = "2";
            //        break;
            //    case "2": //点击停止后，在滚动100毫秒5次后停止
            //        timer1.Enabled = true;
            //        btnStart.Enabled = false;
            //        count = r0.Next(2, 10);
            //        break;
            //}
        }

        public int init = 1;
        private void Form_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                //系统初始化，重三等奖重新开始
                if (init == 5)
                {
                    this.cjcore.ReSet(0);
                    this.radioButton_3.Checked = true;
                    this.radioButton_2.Checked = false;
                    this.radioButton_1.Checked = false;

                    lab_Statue.Text = "三等级:当前正在抽取第1轮奖项";
                    lab_name_1.Text = "";
                    lab_name_2.Text = "";
                    lab_name_3.Text = "";

                    listBox_1.Items.Clear();
                    listBox_2.Items.Clear();
                    listBox_3.Items.Clear();
                    init = 1;
                    return;
                }

                init = init + 1;

            }
            

        }
    }

    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

}
