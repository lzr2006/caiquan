using System;
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
        bool user_is_die = false; //用户是否挂掉
        //bool started = false; //电脑自动攻击线程是否开启
        bool end = false; //是否终止线程
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
            Random rda = new Random();
            int boss = rda.Next(1, 4);
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
            #region 加载图片
            try
            {
                Random rd = new Random();
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

            
        }
        #endregion
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
            if (winner == 0)
            {
                MessageBox.Show("平局");
                label16.Text = "-0";
                label17.Text = "-0";
                label18.Text = "-0";
            }
            if (winner == 1)
            {
                MessageBox.Show("Utanus单独胜利");
                user_blood = user_blood - computer2_count;
                computer1_blood = computer1_blood - computer2_count;
                label17.Text = "-" + computer2_count.ToString();
                label16.Text = "-" + computer2_count.ToString();
                label18.Text = "-0";
            }
            if (winner == 2)
            {
                MessageBox.Show("Victor单独胜利");
                computer2_blood = computer2_blood - computer1_count;
                user_blood = user_blood - computer1_count;
                label16.Text = "-" + computer1_count.ToString();
                label18.Text = "-" + computer1_count.ToString();
                label17.Text = "-0";
            }
            if (winner == 3)
            {
                MessageBox.Show("Utanus与user同时胜利");
                computer1_blood = computer1_blood - computer2_count - user_count;
                int test = computer2_count + user_count;
                label17.Text = "-" + test.ToString();
                label16.Text = "-0";
                label18.Text = "-0";
            }
            if (winner == 4)
            {
                MessageBox.Show("Victor与user同时胜利");
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
                //gm.LessBlood(1, computer1_count + computer2_count);
                user_blood = user_blood - computer1_count - computer2_count;
                int test = computer1_count + computer2_count;
                label16.Text = "-" + test.ToString();
                label17.Text = "-0";
                label18.Text = "-0";

            }
            if (winner == 6)
            {
                MessageBox.Show("user单独胜利");
                //gm.LessBlood(2, user_count);
                //gm.LessBlood(3, user_count);
                computer2_blood = computer2_blood - user_count;
                computer1_blood = computer1_blood - user_count;
                label17.Text = "-" + user_count.ToString();
                label18.Text = "-" + user_count.ToString();
                label16.Text = "-0";

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
            }

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

            if (computer1_blood <= 0 && computer2_blood <= 0)
            {
                label19.Text = "恭喜玩家胜利！";
            }
            if (computer1_blood <= 0 && user_blood <= 0)
            {
                label19.Text = "恭喜Utanus胜利！";
            }
            if (computer2_blood <= 0 && user_blood <= 0)
            {
                label19.Text = "恭喜Victor胜利！";
            }
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

                //用户挂掉后，电脑1和电脑3互相攻击的函数
                Core cr = new Core();
                Random cm = new Random();
                int p1 = cm.Next(); //第一个电脑用户选择
                int p2 = cm.Next(); //第二个电脑用户选择
                int win = cr.cwinner(p1, p2);
                #region 解析算法
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
        }

        private void button11_Click(object sender, EventArgs e)
        {
            user_blood = 1;
        }
    }
}