using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using caiquan;
using System.Threading;

namespace caiquan
{
    public partial class game : Form
    {
        #region 声明变量
        int user_choose = 0; //用户选择
        int user_blood = 5; //用户血量
        int computer1_blood = 5; //Voctor血量
        int computer2_blood = 5; //Utanus血量 
        int user_count = 1; //用户攻击力
        int computer1_count = 1; //Voctor攻击力
        int computer2_count = 1; //Utanus攻击力
        #endregion

        public game()
        {
            InitializeComponent();
        }



        private void game_Load(object sender, EventArgs e) {
            //Thread th = new Thread(timer1_Tick);
            RanName rn = new RanName();
            //获取程序运行路径
            string local = Application.StartupPath;


            //user_blood = 5;
            //computer1_blood = 5;
            //computer2_blood = 5;
            //user_count = 1;
            //computer1_count = 1;
            //computer2_count = 1;

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

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

            


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
        #region 废函数
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        #endregion

 
        private void button10_Click(object sender, EventArgs e)
        {
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
            int winner = cr.winner(p1,p2,user_choose);

            #region 解析核心算法
            if (winner == 0) {
                MessageBox.Show("平局");
            }
            if (winner == 1) {
                MessageBox.Show("Utanus单独胜利");
                gm.LessBlood(2, computer2_count);
                gm.LessBlood(1, computer2_count);

            }
            if (winner == 2) {
                MessageBox.Show("Victor单独胜利");
                gm.LessBlood(1, computer1_count);
                gm.LessBlood(3, computer1_count);
            }
            if (winner == 3) {
                MessageBox.Show("Utanus与user同时胜利");
                gm.LessBlood(2, computer2_count + user_count);
            }
            if (winner == 4) {
                MessageBox.Show("Victor与user同时胜利");
                gm.LessBlood(3, computer1_count + user_count);
            }
            if (winner == 5)
            {
                MessageBox.Show("Victor与Utanus同时胜利");
                gm.LessBlood(1, computer1_count + computer2_count);
            }
            if (winner == 6)
            {
                MessageBox.Show("user单独胜利");
                gm.LessBlood(2, user_count);
                gm.LessBlood(3, user_count);
            }
            #endregion

        }



      //public void getblood()
      //  {
      //      //回显血量
      //      //label5.Text = user_blood.ToString();
      //      //label6.Text = computer1_blood.ToString();
      //      //label8.Text = computer2_blood.ToString();
      //      //MessageBox.Show(user_blood.ToString());
      //  }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user_blood.ToString(),"UB");
            MessageBox.Show(user_count.ToString(),"UC");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //实时更新血量
            //Blood bda = new Blood();
            label5.Text = user_blood.ToString();
            label6.Text = computer1_blood.ToString();
            label8.Text = computer2_blood.ToString();
            //MessageBox.Show(bda.User_blood.ToString()); //user_blood
            
        }

        public void LessBlood(int user_id, int count) {

            if (user_id == 1)
            {
                //user
                user_blood = user_blood - count;
                if (user_blood <= 0) {
                    MessageBox.Show("你输了！" + user_count.ToString(),user_blood.ToString());
                    game gm = new game();
                    gm.Close();
                }
            }
            if (user_id == 2)
            {
                //Victor
                computer1_blood = computer1_blood - count;
                if (computer1_blood <= 0)
                {
                    MessageBox.Show("Victor挂掉了，攻击变为0.");
                    //computer1.count = 0;
                }
            }
            if (user_id == 3)
            {
                //Utanus
                computer2_blood = computer2_blood - count;
                if (computer2_blood <= 0)
                {
                    MessageBox.Show("Utanus挂掉了，攻击变为0.");
                    //computer2.count = 0;
                }
            }
        }

    }
}
