using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using caiqian;
using System.Text;
using System.Media;

namespace caiquan
{
    public partial class game : Form
    {
        #region 声明字段
        int user_choose = 0; //用户选择
        int user_blood = 5; //用户血量
        int computer1_blood = 5; //Voctor血量
        int computer2_blood = 5; //Utanus血量 
        int user_count = 1; //用户攻击力
        int computer1_count = 1; //Voctor攻击力
        int computer2_count = 1; //Utanus攻击力
        int user_truth_count = 1;
        int computer1_truth_count = 1;
        int computer2_truth_count = 1; //真实攻击力
        int user_truth_blood = 5;
        int computer1_truth_blood = 5;
        int computer2_truth_blood = 5; //真实血量
        int money_id = 0; //加钱的id
        public int user_money = 0; //用户金钱
        public int computer1_money = 0; //Victor金钱
        public int computer2_money = 0; //Utanus金钱 
        public int tool_expensive = 0; //道具增量金币 
        public int hpq = 0; //核平器价格
        public int exp_lightning = 0; //闪电价格
        int boss; //地主索引
        int user_material;
        int computer1_material;
        int computer2_material; //属性
        bool add_money = false; //已经加钱
        bool user_is_die = false; //用户是否挂掉
        bool end = false; //是否终止线程
        bool whowin = false; //是否判断输赢情况
        bool do_windo = false; //是否判断输赢
        bool alllife = true; //电脑全部存活
        bool user_truth_blood_sum = false; //用户加血
        bool user_truth_count_sum = false; //用户加攻击
        bool computer1_truth_blood_sum = false; //Victor加血
        bool computer1_truth_count_sum = false; //Victor加攻击
        bool computer2_truth_blood_sum = false; //Utanus加血
        bool computer2_truth_count_sum = false; //Utanus加攻击
        int[] islife; //生存玩家
        int[] results; //转换后的输赢情况
        List<string> result = new List<string>();
        List<string> backer = new List<string>(); //存档
        List<int> islifeing = new List<int>(); //生存玩家
        #endregion

        public game()
        {
            InitializeComponent();
        }     //构造函数


        private void game_Load(object sender, EventArgs e) {
            string local = Application.StartupPath;


            RanName rn = new RanName();

            #region 判断地主
            Random rd = new Random();
            boss = rd.Next(1, 4);

            //解析地主 c1 -> label21 c2 -> label23 user -> label25
            if (boss == 1)
            {
                //玩家为地主
                user_blood = user_blood + (computer1_truth_blood / 2);
                user_count = user_count + (user_truth_count / 2);
                label25.Text = "地主";
                label23.Text = "农民";
                label21.Text = "农民";
            }
            if (boss == 2)
            {
                //Victor为地主
                computer1_blood = computer1_blood + (computer2_truth_blood / 2);
                computer1_count = computer1_count + (computer1_truth_count / 2);
                label21.Text = "地主";
                label23.Text = "农民";
                label25.Text = "农民";
            }
            if (boss == 3)
            {
                //Utanus为地主
                computer2_blood = computer2_blood + (user_blood / 2);
                computer2_count = computer2_count + (computer2_truth_count / 2);
                label23.Text = "地主";
                label25.Text = "农民";
                label21.Text = "农民";
            }
            #endregion
            #region 判断属性
            int sx = rd.Next(1, 4);
            if (sx == 1)
            {
                user_material = 1;
                label30.BackColor = System.Drawing.Color.Red;
                label30.Text = "火";
                label32.BackColor = System.Drawing.Color.White;
                label34.BackColor = System.Drawing.Color.White;
                label32.Text = "普通";
                label34.Text = "普通";
            }
            if (sx == 2)
            {
                computer1_material = 1;
                label32.BackColor = System.Drawing.Color.Red;
                label32.Text = "火";
                label30.BackColor = System.Drawing.Color.White;
                label34.BackColor = System.Drawing.Color.White;
                label30.Text = "普通";
                label34.Text = "普通";
            }
            if (sx == 3)
            {
                computer2_material = 1;
                label34.BackColor = System.Drawing.Color.Red;
                label34.Text = "火";
                label32.BackColor = System.Drawing.Color.White;
                label30.BackColor = System.Drawing.Color.White;
                label30.Text = "普通";
                label32.Text = "普通";
            }
            #endregion
            #region 加载图片
            try
            {
                int rm = rd.Next(1, 11);
                string path1 = rn.gets(local, rm);
                rm = rd.Next(1, 11);
                string path2 = rn.gets(local, rm);
                rm = rd.Next(1, 11);
                string path3 = rn.gets(local, rm);


                //赋予pictureBox图片路径
                pictureBox1.ImageLocation = path1;
                pictureBox2.ImageLocation = path2;
                pictureBox3.ImageLocation = path3;

            }

            catch
            {

                //加载失败
                MessageBox.Show("缺失类或图片！");

            }
            #endregion
            #region 初始化用户
            islifeing.Clear();
            islifeing.Add(1);
            islifeing.Add(2);
            islifeing.Add(3);
            #endregion
        }

        #region 用户选择按钮点击事件

        private void button1_Click(object sender, EventArgs e)
        {
            //改变颜色
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Chartreuse;
            button3.BackColor = System.Drawing.Color.Chartreuse;
            user_choose = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //改变颜色
            button2.BackColor = System.Drawing.Color.Gold;
            button1.BackColor = System.Drawing.Color.Chartreuse;
            button3.BackColor = System.Drawing.Color.Chartreuse;
            user_choose = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //改变颜色
            button3.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Chartreuse;
            button1.BackColor = System.Drawing.Color.Chartreuse;
            user_choose = 3;
        }

        #endregion

 


        private void button10_Click(object sender, EventArgs e)
        {
            #region 预操作
            //先打开判断加钱通道
            add_money = false;

            game gm = new game();
            //电脑随机选择

            Random cm = new Random();

            int p1 = cm.Next(1, 4); //第一个电脑用户选择
            int p2 = cm.Next(1, 4); //第二个电脑用户选择
            #endregion
            #region 按钮上色

            //电脑用户1:Utanus

            if (p1 == 1)
            {
                button4.BackColor = System.Drawing.Color.Plum;
                button5.BackColor = System.Drawing.Color.Chartreuse;
                button6.BackColor = System.Drawing.Color.Chartreuse;
            }

            if (p1 == 2)
            {
                button5.BackColor = System.Drawing.Color.Plum;
                button4.BackColor = System.Drawing.Color.Chartreuse;
                button6.BackColor = System.Drawing.Color.Chartreuse;
            }
            if (p1 == 3)
            {
                button6.BackColor = System.Drawing.Color.Plum;
                button4.BackColor = System.Drawing.Color.Chartreuse;
                button5.BackColor = System.Drawing.Color.Chartreuse;
            }

            //电脑用户2:Victor

            if (p2 == 1)
            {
                button9.BackColor = System.Drawing.Color.Plum;
                button8.BackColor = System.Drawing.Color.Chartreuse;
                button7.BackColor = System.Drawing.Color.Chartreuse;
            }

            if (p2 == 2)
            {
                button8.BackColor = System.Drawing.Color.Plum;
                button9.BackColor = System.Drawing.Color.Chartreuse;
                button7.BackColor = System.Drawing.Color.Chartreuse;
            }

            if (p2 == 3)
            {
                button7.BackColor = System.Drawing.Color.Plum;
                button8.BackColor = System.Drawing.Color.Chartreuse;
                button9.BackColor = System.Drawing.Color.Chartreuse;
            }

            //button1.BackColor=button2.BackColor=button3.BackColor=System.Drawing.Color.Chartreuse; 影响观感
            #endregion
            Core cr = new Core();
            int winner = cr.winner(p1, p2, user_choose);
            #region 解析核心算法
            Material ma = new Material();
            if (winner == 0)
            {
                MessageBox.Show("平局","对战信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                label27.Text = label28.Text = label29.Text = "普通攻击";
                label16.Text = "-0";
                label17.Text = "-0";
                label18.Text = "-0";
            }
            if (winner == 1)
            {

                if (computer1_material == 1)
                {
                    //火属性
                    MessageBox.Show("Utanus单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    user_blood = user_blood - computer2_count;
                    computer1_blood = computer1_blood - computer2_count;
                    label27.Text = label29.Text = "烈火灼伤";
                    int c2 = ma.fire(computer2_count);
                    user_blood = user_blood - c2;
                    computer1_blood = computer1_blood - c2;
                    label17.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    label16.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    computer2_money = computer2_money + (computer2_count / 2);

                }
                else
                {
                    MessageBox.Show("Utanus单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    user_blood = user_blood - computer2_count;
                    computer1_blood = computer1_blood - computer2_count;
                    label17.Text = "-" + computer2_count.ToString();
                    label16.Text = "-" + computer2_count.ToString();
                    label18.Text = "-0";
                    computer2_money = computer2_money + (computer2_count / 2);
                }
            }
            if (winner == 2)
            {

                    if (computer2_material == 1)
                {

                        MessageBox.Show("Victor单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //火属性
                        user_blood = user_blood - computer1_count;
                        computer2_blood = computer2_blood - computer1_count;
                        label28.Text = label29.Text = "烈火灼伤";
                        int c2 = ma.fire(computer2_count);
                        user_blood = user_blood - c2;
                        computer2_blood = computer2_blood - c2;
                        label18.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                        label16.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                        computer1_money = computer1_money + (computer1_count / 2);

                }
                

                else{
                    MessageBox.Show("Victor单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    computer2_blood = computer2_blood - computer1_count;
                    user_blood = user_blood - computer1_count;
                    label16.Text = "-" + computer1_count.ToString();
                    label18.Text = "-" + computer1_count.ToString();
                    label17.Text = "-0";
                    computer1_money = computer1_money + (computer1_count / 2);
                }
            }
            if (winner == 3)
            {

                MessageBox.Show("Utanus与user同时胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label27.Text = label28.Text = label29.Text = "普通攻击";
                computer1_blood = computer1_blood - computer2_count - user_count;
                int test = computer2_count + user_count;
                label17.Text = "-" + test.ToString();
                label16.Text = "-0";
                label18.Text = "-0";
            }
            if (winner == 4)
            {

                MessageBox.Show("Victor与user同时胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label27.Text = label28.Text = label29.Text = "普通攻击";
                //gm.LessBlood(3, computer1_count + user_count);
                computer2_blood = computer2_blood - computer1_count - user_count;
                int test = user_count + computer1_count;
                label18.Text = "-" + test.ToString();
                label16.Text = "-0";
                label17.Text = "-0";

            }
            if (winner == 5)
            {

                MessageBox.Show("Victor与Utanus同时胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label27.Text = label28.Text = label29.Text = "普通攻击";
                //gm.LessBlood(1, computer1_count + computer2_count);
                user_blood = user_blood - computer1_count - computer2_count;
                int test = computer1_count + computer2_count;
                label16.Text = "-" + test.ToString();
                label17.Text = "-0";
                label18.Text = "-0";

            }
            if (winner == 6)
            {

                if (user_material == 1)
                {
                    
                    MessageBox.Show("user单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //火属性
                    computer1_blood = computer1_blood - user_count;
                    computer2_blood = computer2_blood - user_count;
                    label28.Text = label27.Text = "烈火灼伤";
                    int c2 = ma.fire(user_count);
                    computer1_blood = computer1_blood - c2;
                    computer2_blood = computer2_blood - c2;
                    label18.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    label17.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    user_money = user_money + (user_count / 2);

                }
                else
                {
                    MessageBox.Show("user单独胜利", "对战信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    //gm.LessBlood(2, user_count);
                    //gm.LessBlood(3, user_count);
                    computer2_blood = computer2_blood - user_count;
                    computer1_blood = computer1_blood - user_count;
                    label17.Text = "-" + user_count.ToString();
                    label18.Text = "-" + user_count.ToString();
                    label16.Text = "-0";
                    user_money = user_money + (user_count / 2);
                }
            }
            #endregion 
        }


        #region 暂时废弃:血量回显函数

        //public void getblood()
        //  {
        //      //回显血量
        //      //label5.Text = user_blood.ToString();
        //      //label6.Text = computer1_blood.ToString();
        //      //label8.Text = computer2_blood.ToString();
        //      //MessageBox.Show(user_blood.ToString());
        //  }
        #endregion

        public void timer1_Tick(object sender, EventArgs e)
        {
            #region 更新血量和攻击
            //实时更新血量
            //Blood bda = new Blood();
            label5.Text = user_blood.ToString();
            label6.Text = computer1_blood.ToString();
            label8.Text = computer2_blood.ToString();
            //MessageBox.Show(bda.User_blood.ToString()); //user_blood
            //实时更新攻击
            label12.Text = user_count.ToString();
            label14.Text = computer1_count.ToString();
            label11.Text = computer2_count.ToString();

            #endregion
            #region 更新金钱
            label42.Text = user_money.ToString();
            label41.Text = computer2_money.ToString();
            label40.Text = computer1_money.ToString();
            #endregion
            #region 判断是否挂掉
            if (user_blood <= 0)
            {
                // MessageBox.Show("你输了！" + user_count.ToString(), user_blood.ToString());
                //System.Environment.Exit(0);
                label1.Text = "已经没了";
                user_count = 0;
                user_is_die = true;
                islifeing.Remove(1);
                whowin = true;
            }

            if (computer1_blood <= 0)
            {
                label2.Text = "已经没了";
                computer1_count = 0;
                islifeing.Remove(2);
                whowin = true;

            }

            if (computer2_blood <= 0)
            {
                label3.Text = "已经没了";
                computer2_count = 0;
                islifeing.Remove(3);
                whowin = true;
            }

            //if (computer1_blood <= 0 && computer2_blood <= 0)
            //{
            //    label19.Text = "恭喜玩家胜利！";
            //    islifeing.Remove(2);
            //    islifeing.Remove(3);
            //    whowin = true;
            //}
            //if (computer1_blood <= 0 && user_blood <= 0)
            //{
            //    label19.Text = "恭喜Utanus胜利！";
            //    islifeing.Remove(1);
            //    islifeing.Remove(2);
            //    whowin = true;
            //}
            //if (computer2_blood <= 0 && user_blood <= 0)
            //{
            //    label19.Text = "恭喜Victor胜利！";
            //    islifeing.Remove(1);
            //    islifeing.Remove(3);
            //    whowin = true;
            //}
            if (user_is_die)
            {
                if (computer1_blood <= 0)
                {
                    label2.Text = "已经没了";
                    computer1_count = 0;
                    

                }

                if (computer2_blood <= 0)
                {
                    label3.Text = "已经没了";
                    computer2_count = 0;
                }
            }
            #endregion
        }

        #region 暂时废弃:减血函数
        //public void LessBlood(int user_id, int count) {

        //    //确认问题根本：函数问题或传入问题
        //    //问题描述：在外面使用时正常
        //    //尝试使用return

        //    if (user_id == 1)
        //    {
        //        //user
        //        user_blood = user_blood - count;
        //        if (user_blood <= 0) {
        //            MessageBox.Show("你输了！" + user_count.ToString(),user_blood.ToString());
        //            game gm = new game();
        //            gm.Close();
        //        }
        //    }
        //    if (user_id == 2)
        //    {
        //        //Victor
        //        computer1_blood = computer1_blood - count;
        //        if (computer1_blood <= 0)
        //        {
        //            MessageBox.Show("Victor挂掉了，攻击变为0.");
        //            //computer1.count = 0;
        //        }
        //    }
        //    if (user_id == 3)
        //    {
        //        //Utanus
        //        computer2_blood = computer2_blood - count;
        //        if (computer2_blood <= 0)
        //        {
        //            MessageBox.Show("Utanus挂掉了，攻击变为0.");
        //            //computer2.count = 0;
        //        }
        //}
        // }
        #endregion
        #region 输赢测试函数(已经测试完毕)
        //private void button11_Click(object sender, EventArgs e)
        //{
        //    SwitchWinner sw = new SwitchWinner();
        //    int[] islife = {2,3};
        //    List<int> result = new List<int>();
        //    result = sw.getwin(1, islife);
        //    foreach (var item in result)
        //    {
        //        MessageBox.Show(item.ToString());
        //    }
        // }
        #endregion


        public void auto()
        {
            if (alllife)
            {
                #region 电脑互打
                //用户挂掉后，电脑1和电脑3互相攻击的函数
                Core cr = new Core();
                Random cm = new Random();
                int p1 = cm.Next(); //第一个电脑用户选择
                int p2 = cm.Next(); //第二个电脑用户选择
                int win = cr.cwinner(p1, p2);
                #endregion
                #region 解析算法 减血回显
                if (win == 1)
                {
                    computer2_blood = computer2_blood - computer1_count;
                    label18.Text = "-" + computer1_count.ToString();
                }
                if (win == 2)
                {
                    computer1_blood = computer1_blood - computer2_count;
                    label17.Text = "-" + computer2_count.ToString();
                }
            }
                #endregion
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            #region 自动战斗
            if (user_blood <= 0)
            {

                if (computer1_blood != 0 && computer2_blood != 0)
                {
                    auto();

                }
            }

            if (computer1_blood <= 0 || computer2_blood <= 0)
            {
                alllife = false;
                //停止电脑互怼行为
            }

            #endregion

        }

        public void getwhowin()
        {
            #region 获取输赢情况
            if (whowin)
            {
                
                SwitchWinner sw = new SwitchWinner();
                //转换并传入参数
                islifeing.Sort();
                islife = islifeing.ToArray();
                List<int> result = new List<int>();
                result = sw.getwin(boss, islife); //接收数据
                result.Sort();
                results = result.ToArray();
                //自动结束调用 等待下一次调用
                whowin = false;
                //打开判断输赢的函数执行通道
                do_windo = true;
            }
            #endregion
        }

        #region 胜利解析算法(新)
        //喜报:算法于2021.2.9 11:23 测试成功
        //喜报:算法于2021.2.11 12:50 二次调试成功
        public void windo()
        {
            if (do_windo)
            {
                Random rd = new Random();
                int summer = rd.Next(1, 3);
                if (results.Length == 1)
                {
                    if (results[0] == 404)
                    {
                        //谁都没赢
                        whowin = false;
                        
                    }

                    //错误处理记录:数组越界:数组索引从0开始
                    else
                    {
                        if (results[0] == 1)
                        {
                            //玩家胜利
                            label19.Text = "恭喜玩家胜利!";
                            money_id = 1;
                            
                            if (summer == 1)
                            {
                                user_truth_count_sum = true;
                            }
                            if (summer == 2)
                            {
                                user_truth_blood_sum = true;
                            }

                            

                        }
                    }

                    if (results[0] == 2)
                    {
                        //Victor胜利
                        label19.Text = "恭喜Victor胜利!";
                        money_id = 2;

                        if (summer == 1)
                        {
                            computer1_truth_count_sum = true;
                        }
                        if (summer == 2)
                        {
                            computer1_truth_blood_sum = true;
                        }
                        
                    }
                    if (results[0] == 3)
                    {
                        //Utanus胜利
                        label19.Text = "恭喜Utanus胜利!";
                        money_id = 3;
                        
                        if (summer == 1)
                        {
                            computer2_truth_blood_sum = true;
                        }
                        if (summer == 2)
                        {
                            computer2_truth_count_sum = true;
                        }
                        
                    }
                }

                if (results.Length == 2 )
                {
                    //1,2 2,3 1,3 顺序不确定
                    int sum = 0;

                    foreach (int item in results)
                    {
                        sum = sum + item;
                    }

                    if (sum == 3)
                    {
                        label19.Text = "恭喜user和Victor同时胜利!";
                        money_id = 4;

                        if (summer == 1)
                        {
                            user_truth_count_sum = true;
                            computer1_truth_count_sum = true;
                        }
                        if (summer == 2)
                        {
                            user_truth_blood_sum = true;
                            computer1_truth_blood_sum = true;
                            
                        }
                    }
                    if (sum == 4)
                    {
                        label19.Text = "恭喜user和Utanus同时胜利!";
                        money_id = 5;

                        if (summer == 1)
                        {
                            user_truth_count_sum = true;
                            computer2_truth_count_sum = true; 
                        }
                        if (summer == 2)
                        {
                            user_truth_blood_sum = true;
                            computer2_truth_blood_sum = true;
                        }
                    }
                    if (sum == 5)
                    {

                        label19.Text = "恭喜Victor和Utanus同时胜利!";
                        money_id = 6;

                        if (summer == 1)
                        {
                            computer1_truth_count_sum = true;
                            computer2_truth_count_sum = true;
                        }
                        if (summer == 2)
                        {
                            computer1_truth_blood_sum = true;
                            computer2_truth_blood_sum = true;
                        }
                    }
                    
                }
            }
            //关闭执行命令 等待下一次执行
            do_windo = false;
        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)
        {
            getwhowin();
            windo();
        }
        public void restart()
        {
            #region 继续重开
            //一局结束 恢复参数
            alllife = true;
            label27.Text = label28.Text = label29.Text = "普通攻击";
            user_blood = user_truth_blood;
            computer1_blood = computer1_truth_blood;
            computer2_blood = computer2_truth_blood;
            user_count = user_truth_count;
            computer1_count = computer1_truth_count;
            computer2_count = computer2_truth_count; //补全血量和攻击
            label19.Text = string.Empty;
            label2.Text = "姓名：Victor";
            label3.Text = "姓名：Utanus";
            label1.Text = "姓名：我"; //基本标签
            #endregion
            #region 判断地主
            Random rd = new Random();
            boss = rd.Next(1, 4);

            //解析地主 c1 -> label21 c2 -> label23 user -> label25
            if (boss == 1)
            {
                //玩家为地主
                user_blood = user_blood + (computer1_truth_blood / 2);
                user_count = user_count + (user_truth_count / 2);
                label25.Text = "地主";
                label23.Text = "农民";
                label21.Text = "农民";
            }
            if (boss == 2)
            {
                //Victor为地主
                computer1_blood = computer1_blood + (computer2_truth_blood / 2);
                computer1_count = computer1_count + (computer1_truth_count / 2);
                label21.Text = "地主";
                label23.Text = "农民";
                label25.Text = "农民";
            }
            if (boss == 3)
            {
                //Utanus为地主
                computer2_blood = computer2_blood + (user_blood / 2);
                computer2_count = computer2_count + (computer2_truth_count / 2);
                label23.Text = "地主";
                label25.Text = "农民";
                label21.Text = "农民";
            }
            #endregion
            #region 初始化用户
            islifeing.Clear();
            islifeing.Add(1);
            islifeing.Add(2);
            islifeing.Add(3);
            #endregion
            #region 判断属性
            int sx = rd.Next(1, 4);
            if (sx == 1)
            {
                user_material = 1;
                computer1_material = 0;
                computer2_material = 0;
                label30.BackColor = System.Drawing.Color.Red;
                label30.Text = "火";
                label32.BackColor = System.Drawing.Color.White;
                label34.BackColor = System.Drawing.Color.White;
                label32.Text = "普通";
                label34.Text = "普通";
            }
            if (sx == 2)
            {
                computer1_material = 1;
                computer2_material = 0;
                user_material = 0;
                label32.BackColor = System.Drawing.Color.Red;
                label32.Text = "火";
                label30.BackColor = System.Drawing.Color.White;
                label34.BackColor = System.Drawing.Color.White;
                label30.Text = "普通";
                label34.Text = "普通";
            }
            if (sx == 3)
            {
                user_material = 0;
                computer1_material = 0;
                computer2_material = 1;
                label34.BackColor = System.Drawing.Color.Red;
                label34.Text = "火";
                label32.BackColor = System.Drawing.Color.White;
                label30.BackColor = System.Drawing.Color.White;
                label30.Text = "普通";
                label32.Text = "普通";
            }
            #endregion
            #region 道具金币增量
            Random rs = new Random();
            for (int i = 0; i < tool_expensive / 3; i++)
            {
                hpq = this.hpq + rs.Next(1, 3);
                label45.Text = hpq.ToString() + "金币";
            }
            for (int i = 0; i < tool_expensive / 2; i++)
            {
                exp_lightning = this.exp_lightning + rs.Next(1, 3);
                label48.Text = exp_lightning.ToString() + "金币";
            }

            #endregion
            #region 恢复道具
            button13.Enabled = true;
            #endregion
        }

        private void button12_Click(object sender, EventArgs e)
        {
            zengyi(); //强化属性
            restart();
            add_moneyes(money_id);
        }


        public void zengyi()
        {
            #region 增加属性函数

                if (user_truth_blood_sum)
                {
                    user_truth_blood++;
                    user_truth_blood_sum = false;
                }
                if (user_truth_count_sum)
                {
                    user_truth_count++;
                    user_truth_count_sum = false;
                }
                if (computer1_truth_blood_sum)
                {
                    computer1_truth_blood++;
                    computer1_truth_blood_sum = false;
                }
                if (computer1_truth_count_sum)
                {
                    computer1_truth_count++;
                    computer1_truth_count_sum = false;
                }
                if (computer2_truth_blood_sum)
                {
                    computer2_truth_blood++;
                    computer2_truth_blood_sum = false;
                }
                if (computer2_truth_count_sum)
                {
                    computer2_truth_count++;
                    computer2_truth_count_sum = false;
                }

            tool_expensive++;
            
                #endregion       

        }

        public void add_moneyes(int id) {
            #region 加钱函数
            //以不动应万动
            if (id == 1)
            {
                //user单独胜利
                user_money = user_money + computer1_truth_blood + computer2_truth_blood;
                id = 0; //重置 避免多次访问
            }
            if (id == 2)
            {
                //Victor单独胜利
                computer1_money = computer1_money + computer2_truth_blood + user_truth_blood;
                id = 0; //重置 避免多次访问
            }
            if (id == 3)
            {
                //Utanus单独胜利
                computer2_money = computer2_money + user_truth_blood + computer1_truth_blood;
                id = 0; //重置 避免多次访问
            }
            if (id == 4)
            {
                //user和Victor同时胜利
                user_money = user_money + computer2_truth_blood;
                computer1_money = computer1_money + computer2_truth_blood;
                id = 0; //重置 避免多次访问
            }
            if (id == 5)
            {
                //user与Utanus同时胜利
                user_money = user_money + computer1_truth_blood;
                computer2_money = computer2_money + computer1_truth_blood;
                id = 0; //重置 避免多次访问
            }
            if (id == 6)
            {
                //Victor和Utanus同时胜利
                computer1_money = computer1_money + user_truth_blood;
                computer2_money = computer2_money + user_truth_blood;
                id = 0; //重置 避免多次访问
            }
            #endregion        
        }


        private void button11_Click(object sender, EventArgs e)
        {
            #region 存档
            string local = Application.StartupPath;
            Save sv = new Save();
            sv.saved(user_truth_blood, computer1_truth_blood, computer2_truth_blood, user_money, computer1_money, computer2_money, user_truth_count, computer1_truth_count, computer2_truth_count, local);
            //string wiilsaved = local + "\\Save.exe"; //存储程序路径

            //System.Diagnostics.Process.Start(wiilsaved);
            #endregion
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            #region 读档
            string path2 = Application.StartupPath + "\\temp\\temp.txt";
            StreamReader sr = new StreamReader(path2, Encoding.GetEncoding("utf-8"));
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                
                result.Add(line.ToString());
            }

            foreach (var item in result)
            {
                backer.Add(item);
            }
            sr.Close();
            user_truth_blood = Convert.ToInt32(backer[0]);
            computer1_truth_blood = Convert.ToInt32(backer[1]);
            computer2_truth_blood = Convert.ToInt32(backer[2]);
            user_money = Convert.ToInt32(backer[3]);
            computer1_money = Convert.ToInt32(backer[4]);
            computer2_money = Convert.ToInt32(backer[5]);
            user_count = Convert.ToInt32(backer[6]);
            computer1_count = Convert.ToInt32(backer[7]);
            computer2_count = Convert.ToInt32(backer[8]);
            MessageBox.Show("读档成功!");
            #endregion
        }

        private void label36_Click(object sender, EventArgs e)
        {
            ReadTools rt = new ReadTools();
            rt.Get_tools(Application.StartupPath + "\\tools\\index.txt");
            
        }

        private void game_Load_1(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
        #region 道具系统 爆炸系
        private void button13_Click(object sender, EventArgs e)
        {
            
            if (user_money >= hpq)
            {
                MessageBox.Show("购买成功！","Tool System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                user_money = user_money - hpq;
                label27.Text = label28.Text = label29.Text = "世界核平";
                int damage = user_truth_count * 3; //核弹伤害为用户伤害的3倍
                double E = damage / 2;
                label16.Text = "-" + E.ToString();
                label17.Text = label18.Text = "-" +  damage.ToString();
                user_blood = user_blood - damage / 2;//加强一点儿可玩性 否则后期不敢用
                computer1_blood = computer1_blood - damage;
                computer2_blood = computer2_blood - damage;
                SoundPlayer boom = new SoundPlayer(Application.StartupPath +  "\\accets\\HD.wav"); //播放声音
                boom.Play();
                button13.Enabled = false;
            }
           else
            {
                MessageBox.Show("购买失败，金钱不足！", "Tool System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (user_money >= exp_lightning) 
            {
                MessageBox.Show("购买成功！", "Tool System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                user_money = user_money - exp_lightning;
                //对随机一名玩家造成致命打稽
                Random random = new Random();
                int hapless = random.Next(1, 4); //1->玩家 2->Victor 3->Utanus
                SoundPlayer splt = new SoundPlayer(Application.StartupPath + "\\accets\\LT.wav"); //未 雨 绸 缪
                splt.Play(); //漏了这个是最骚的
                if (hapless == 1)
                {
                    int damage = user_truth_blood;
                    label29.Text = "雷电打击";
                    user_blood = user_blood - damage;
                    label16.Text = "-" + damage.ToString();
                }
                else if (hapless == 2)
                {
                    int damage = computer1_truth_blood;
                    label27.Text = "雷电打击";
                    computer1_blood = computer1_blood - damage;
                    label17.Text = "-" + damage.ToString();
                }
                else if (hapless == 3)
                {
                    int damage = computer2_truth_blood;
                    label28.Text = "雷电打击";
                    computer2_blood = computer2_blood - damage;
                    label18.Text = "-" + damage.ToString();
                }
            }
            else
            {
                MessageBox.Show("购买失败，金钱不足！", "Tool System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }//path2, false, )
}