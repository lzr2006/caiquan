using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

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
        int boss; //地主索引
        int user_material;
        int computer1_material;
        int computer2_material; //属性
        bool user_is_die = false; //用户是否挂掉
        bool end = false; //是否终止线程
        bool whowin = false; //是否判断输赢情况
        bool do_windo = false; //是否判断输赢
        bool is_switch = false; //已经判断过一次
        bool alllife = true; //电脑全部存活
        bool user_truth_blood_sum = false; //用户加血
        bool user_truth_count_sum = false; //用户加攻击
        bool computer1_truth_blood_sum = false; //Victor加血
        bool computer1_truth_count_sum = false; //Victor加攻击
        bool computer2_truth_blood_sum = false; //Utanus加血
        bool computer2_truth_count_sum = false; //Utanus加攻击
        int[] islife; //生存玩家
        int[] results; //转换后的输赢情况
        List<int> islifeing = new List<int>(); //生存玩家
        #endregion

        public game()
        {
            InitializeComponent();
        }


        private void game_Load(object sender, EventArgs e) {
            string local = Application.StartupPath;

            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = local + @"\\accets\\song.wav";
            //sp.PlayLooping();

            //Thread th = new Thread(timer1_Tick);
            RanName rn = new RanName();

            #region 判断地主
            Random rd = new Random();
            boss = rd.Next(1, 4);

            //解析地主 c1 -> label21 c2 -> label23 user -> label25
            if (boss == 1)
            {
                //玩家为地主
                label25.Text = "地主";
                label23.Text = "农民";
                label21.Text = "农民";
            }
            if (boss == 2)
            {
                //Victor为地主
                label21.Text = "地主";
                label23.Text = "农民";
                label25.Text = "农民";
            }
            if (boss == 3)
            {
                //Utanus为地主
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
                string path1 = rn.gets(local,rm);
                rm = rd.Next(1, 11);
                string path2 = rn.gets(local,rm);
                rm = rd.Next(1, 11);
                string path3 = rn.gets(local,rm);


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
            //优先终止线程


            game gm = new game();
            //电脑随机选择

            Random cm = new Random();

            int p1 = cm.Next(1, 4); //第一个电脑用户选择
            int p2 = cm.Next(1, 4); //第二个电脑用户选择
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
                MessageBox.Show("平局");
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
                    MessageBox.Show("Utanus单独胜利");
                    user_blood = user_blood - computer2_count;
                    computer1_blood = computer1_blood - computer2_count;
                    label27.Text = label29.Text = "烈火灼伤";
                    int c2 = ma.fire(computer2_count);
                    user_blood = user_blood - c2;
                    computer1_blood = computer1_blood - c2;
                    label17.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    label16.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();

                }
                else
                {
                    MessageBox.Show("Utanus单独胜利");
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    user_blood = user_blood - computer2_count;
                    computer1_blood = computer1_blood - computer2_count;
                    label17.Text = "-" + computer2_count.ToString();
                    label16.Text = "-" + computer2_count.ToString();
                    label18.Text = "-0";
                }
            }
            if (winner == 2)
            {
                if (computer2_material == 1)
                {

                        MessageBox.Show("Victor单独胜利");
                        //火属性
                        user_blood = user_blood - computer1_count;
                        computer2_blood = computer2_blood - computer1_count;
                        label28.Text = label29.Text = "烈火灼伤";
                        int c2 = ma.fire(computer2_count);
                        user_blood = user_blood - c2;
                        computer2_blood = computer2_blood - c2;
                        label18.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                        label16.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();

                    }
                

                else{
                    MessageBox.Show("Victor单独胜利");
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    computer2_blood = computer2_blood - computer1_count;
                    user_blood = user_blood - computer1_count;
                    label16.Text = "-" + computer1_count.ToString();
                    label18.Text = "-" + computer1_count.ToString();
                    label17.Text = "-0"; }
            }
            if (winner == 3)
            {
                MessageBox.Show("Utanus与user同时胜利");
                label27.Text = label28.Text = label29.Text = "普通攻击";
                computer1_blood = computer1_blood - computer2_count - user_count;
                int test = computer2_count + user_count;
                label17.Text = "-" + test.ToString();
                label16.Text = "-0";
                label18.Text = "-0";
            }
            if (winner == 4)
            {
                MessageBox.Show("Victor与user同时胜利");
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
                MessageBox.Show("Victor与Utanus同时胜利");
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

                    MessageBox.Show("user单独胜利");
                    //火属性
                    computer1_blood = computer1_blood - user_count;
                    computer2_blood = computer2_blood - user_count;
                    label28.Text = label27.Text = "烈火灼伤";
                    int c2 = ma.fire(user_count);
                    computer1_blood = computer1_blood - c2;
                    computer2_blood = computer2_blood - c2;
                    label18.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();
                    label17.Text = "-" + c2.ToString() + "-" + computer2_count.ToString();

                }
                else
                {
                    MessageBox.Show("user单独胜利");
                    label27.Text = label28.Text = label29.Text = "普通攻击";
                    //gm.LessBlood(2, user_count);
                    //gm.LessBlood(3, user_count);
                    computer2_blood = computer2_blood - user_count;
                    computer1_blood = computer1_blood - user_count;
                    label17.Text = "-" + user_count.ToString();
                    label18.Text = "-" + user_count.ToString();
                    label16.Text = "-0";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void auto()
        {
            if (alllife)
            {
                //用户挂掉后，电脑1和电脑3互相攻击的函数
                Core cr = new Core();
                Random cm = new Random();
                int p1 = cm.Next(); //第一个电脑用户选择
                int p2 = cm.Next(); //第二个电脑用户选择
                int win = cr.cwinner(p1, p2);


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
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //user_blood = 1;
            MessageBox.Show(computer2_material.ToString());
            MessageBox.Show(computer1_material.ToString());
            MessageBox.Show(user_material.ToString());
        }

        public void getwhowin()
        {
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
        }

        #region 胜利解析算法(新)
        //喜报:算法于2020.2.9 11:23 测试成功
        public void windo()
        {
            if (do_windo)
            {
                Random rd = new Random();
                int summer = rd.Next(1, 3);
                if (results.Length == 1 && !is_switch)
                {
                    if (results[0] == 404)
                    {
                        //谁都没赢
                        whowin = false;
                        is_switch = true;
                        
                    }

                    //l9

                    //错误处理记录:数组越界:数组索引从0开始
                    else
                    {
                        if (results[0] == 1 && !is_switch)
                        {
                            //玩家胜利
                            label19.Text = "恭喜玩家胜利!";
                            if (summer == 1)
                            {
                                user_truth_count_sum = true;
                            }
                            if (summer == 2)
                            {
                                user_truth_blood_sum = true;
                            }

                            is_switch = false;

                        }
                    }

                    if (results[0] == 2 && !is_switch)
                    {
                        //Victor胜利
                        label19.Text = "恭喜Victor胜利!";
                        if (summer == 1)
                        {
                            computer1_truth_count_sum = true;
                        }
                        if (summer == 5)
                        {
                            computer1_truth_blood_sum = true;
                        }
                        is_switch = false;
                    }
                    if (results[0] == 3 && !is_switch)
                    {
                        //Utanus胜利
                        label19.Text = "恭喜Utanus胜利!";

                        if (summer == 1)
                        {
                            computer2_truth_blood_sum = true;
                        }
                        if (summer == 2)
                        {
                            computer2_truth_count_sum = true;
                        }
                        is_switch = true;
                    }
                }

                if (results.Length == 2 && !is_switch)
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
                        if(summer == 1)
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
                    is_switch = true;
                }
            }
            //关闭执行命令 等待下一次执行
            do_windo = false;
            //开启未判断
            is_switch = false;
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
            is_switch = false;
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
                label25.Text = "地主";
                label23.Text = "农民";
                label21.Text = "农民";
            }
            if (boss == 2)
            {
                //Victor为地主
                label21.Text = "地主";
                label23.Text = "农民";
                label25.Text = "农民";
            }
            if (boss == 3)
            {
                //Utanus为地主
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
        }

        private void button12_Click(object sender, EventArgs e)
        {

            restart();
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
            
                #endregion
        

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            zengyi();
        }
    }
}