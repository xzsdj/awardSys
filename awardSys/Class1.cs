using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T=System.Windows.Forms;

namespace awardSys
{
    public delegate void CJDelegateHandler(string person, int curCJIndex);
    public class CJElapsedEventArgs : EventArgs
    {
        public List<Person> curcjpersons;
        public string _curCJCode { get; set; } //当前抽奖项目号：3，2，1

        public int curcjlc { get; set; }  //当前轮次：3：5轮，2：3轮，1：1轮

        
    }
    public class CJCore
    {
        //基础信息
        public event CJDelegateHandler CJEvent; //每500毫秒触发事件
        public event CJDelegateHandler CJEventCompleted; //本轮抽奖完成事件
        public event CJDelegateHandler CJEventStoped; //本次抽奖停止事件
        public  List<string> LstUcnum = new List<string>(); //参加抽奖人员信息（暂定100人，以后动态改变）
        public Random r = new Random();
        public T.Timer t = new T.Timer(); //抽奖时间
        public Dictionary<int, string> CJNames = new Dictionary<int, string>();
        //抽奖信息
        //public int[,] lc = new int[2,3]; //在XML里初始化每个奖项的轮次
        public List<string> CJNum = new List<string>(); //每次抽奖总人数:初始化化的时候已经是100人，以后每次抽奖后出去抽奖过的人

        public List<string> CURZJNum = new List<string>(); //当前中奖人员
        public List<string> ZJNum3 = new List<string>(); //3等奖中奖名单
        public List<string> ZJNum2 = new List<string>(); //2等奖中奖名单
        public List<string> ZJNum1 = new List<string>(); //1等奖中奖名单
        //public string _curCJCode = "";  //当前抽奖项目号，分为3,2，1
        public string _curCJName = "";  //当前抽奖项目名称 分为3：三等奖，2:二等奖，1:一等奖
        public int _curCJIndex = 0;  //当前抽奖项目索引号
        public int curlc = 0;   //当前抽奖项目正在进行轮次
        public int curtotallc = 0; //当前抽奖项目的总轮次

        public string curTitleName = ""; //当前总标题：例如：三等级：当前正在抽取第1轮奖项
        public string curperson;  //当前抽奖的人

        public bool isgiveup = true;   //是否放弃   不放弃：true   放弃：false
        public CJCore(Form_Main main)
        {
            //加载所有100个人员信息表

            //LstUcnum = new List<Person>
            //{
            //    new Person() {ID=1,Name = "邓杰"},
            //    new Person() {ID=2,Name = "强亚波"},
            //    new Person() {ID=3,Name = "韩俊峰"},
            //    new Person() {ID=4,Name = "区兴华"},
            //    new Person() {ID=5,Name = "杨文峰"},
            //    new Person() {ID=6,Name = "贾涛"},
            //    new Person() {ID=7,Name = "佟冰"}
            //};
          

            CJNames.Add(4, "鼓励奖");
            CJNames.Add(3,"三等奖");
            CJNames.Add(2, "二等奖");
            CJNames.Add(1, "一等奖");

            CJNum = LstUcnum;
            //初始化当前奖项信息
            curTitleName = "三等级:当前正在抽取第1轮奖项";
            _curCJName = CJNames[3];////  奖项名称
            _curCJIndex = 3; //奖项索引号
            curlc = 1;
            curtotallc = 5;

            main.stopevent += StopCompleted;
        }

        /// <summary>
        /// 抽奖重置 0：全部重置   3:三等奖重置  2:2等奖重置  1:1等奖重置
        /// </summary>
        /// <param name="index"></param>
        public void ReSet(int index)
        {
            switch (index)
            {
                case 0:
                case 3:
                    CJNum = LstUcnum;

                    curTitleName = "三等级:当前正在抽取第1轮奖项";
                    _curCJName = CJNames[3];////  奖项名称
                    _curCJIndex = 3; //奖项索引号
                    curlc = 1;
                    curtotallc = 5;

                    CURZJNum.Clear();
                    ZJNum3.Clear();
                    ZJNum2.Clear();
                    ZJNum1.Clear();

                    curperson = null;
                    break;
                case 2:
                    curTitleName = "二等级:当前正在抽取第1轮奖项";
                    _curCJName = CJNames[2];////  奖项名称
                    _curCJIndex = 2; //奖项索引号
                    curlc = 1;
                    curtotallc = 3;

                    CURZJNum.Clear();
                    if (ZJNum2.Count > 0)
                    {
                        foreach (string person in ZJNum2)
                        {
                            if (!CJNum.Contains(person))
                                CJNum.Add(person);
                        }
                        ZJNum2.Clear();
                    }
                    ZJNum1.Clear();
                    curperson = null;
                    break;
                case 1:
                    curTitleName = "一等级:当前正在抽取第1轮奖项";
                    _curCJName = CJNames[1];////  奖项名称
                    _curCJIndex = 1; //奖项索引号
                    curlc = 1;
                    curtotallc = 1;

                    CURZJNum.Clear();
                    if (ZJNum1.Count > 0)
                    {
                        foreach (string person in ZJNum1)
                        {
                            if (!CJNum.Contains(person))
                                CJNum.Add(person);
                        }
                        ZJNum1.Clear();
                    }
                    curperson = null;
                    break;
                
            } 
        }

        /// <summary>
        /// 抽奖开始
        /// </summary>
        public void CJStart()
        {
            t.Interval = 10;
            t.Tick += T_Elapsed;
            t.Start();

            isgiveup = true; 
        }

        

        private void T_Elapsed(object sender, EventArgs e)
        {
            int totalnum = CJNum.Count;
            if (totalnum <= 0) return ;
            int rannum = r.Next(0, totalnum);

            string p = CJNum[rannum];
            if (p != null)
            {
                if (CJEvent != null)
                    CJEvent(p, _curCJIndex);
            }
            curperson = p;
        }

        /// <summary>
        /// 抽奖结束
        /// </summary>
        public void CJStop()
        {
            t.Stop();

            
        }


        /// <summary>
        /// 停止完成事件
        /// </summary>
        public void StopCompleted(bool bl)
        {
            if (bl == true)  //如果不放弃
            {
                if (CJNum.Contains(curperson))
                {
                    CJNum.Remove(curperson);
                    switch (_curCJIndex) //添加到抽奖项目的获奖列表里
                    {
                        case 3:
                            if (!ZJNum3.Contains(curperson))
                            {
                                ZJNum3.Add(curperson);
                            }
                            break;
                        case 2:
                            if (!ZJNum2.Contains(curperson))
                            {
                                ZJNum2.Add(curperson);
                            }
                            break;
                        case 1:
                            if (!ZJNum1.Contains(curperson))
                            {
                                ZJNum1.Add(curperson);
                            }
                            break;

                    }
                    if (!CURZJNum.Contains(curperson)) //在当前的中奖增加记录
                    {
                        CURZJNum.Add(curperson);
                    }
                    //本次抽奖停止事件
                    if (CJEventStoped != null)
                        CJEventStoped(curperson, _curCJIndex);
                    //
                    if (curlc == curtotallc) //本轮抽奖结果事件
                    {
                        if (CJEventCompleted != null)
                            CJEventCompleted(curperson, _curCJIndex);
                    }
                    curlc = curlc + 1;
                }
            }
        }
        /// <summary>
        /// 弃权
        /// </summary>
        public void ReStart()
        {
            return; 
        }


        /// <summary>
        /// 切换抽奖模式
        /// </summary>
        /// <param name="index"></param>
        public void SwitchCjMode(int index,out string curTitleName)
        {
            curTitleName = "";
            switch (index)
            {
                case 3: //三等奖
                    curTitleName = "三等奖:当前正在抽取第1轮奖项";
                    _curCJName = CJNames[3];////  奖项名称
                    _curCJIndex = 3; //奖项索引号
                    curlc = 1;
                    curtotallc = 5;
                    break;
                case 2:
                    curTitleName = "二等奖:当前正在抽取第1轮奖项";
                    _curCJName = CJNames[2];////  奖项名称
                    _curCJIndex = 2; //奖项索引号
                    curlc = 1;
                    curtotallc = 3;
                    break;
                case 1:
                    curTitleName = "一等奖:当前正在抽取1等奖项";
                    _curCJName = CJNames[1];////  奖项名称
                    _curCJIndex = 1; //奖项索引号
                    curlc = 1;
                    curtotallc = 1;
                    break;
            }
        }
    }
}
