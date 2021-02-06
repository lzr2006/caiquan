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

namespace jiandaoshitoubu

{
    public partial class Form1 : Form
    {
        int user_in;

        //记录计算机和玩家赢的次数
        int user_win = 0;
        int nl=0;

    public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user_in = 1;
            button1.BackColor = System.Drawing.Color.Red;
            button2.BackColor = System.Drawing.Color.Blue;
            button3.BackColor = System.Drawing.Color.Blue;
            button7.Text = "确认";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user_in = 2;
            button2.BackColor = System.Drawing.Color.Red;
            button1.BackColor = System.Drawing.Color.Blue;
            button3.BackColor = System.Drawing.Color.Blue;
            button7.Text = "确认";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = user_win.ToString();
            if (user_win >= 2)
            {
                button8.BackColor = System.Drawing.Color.AliceBlue;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            user_in = 3;
            button3.BackColor = System.Drawing.Color.Red;
            button1.BackColor = System.Drawing.Color.Blue;
            button2.BackColor = System.Drawing.Color.Blue;
            button7.Text = "确认";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random com = new Random();
            int computer = com.Next(1,4);

            if(computer == 1)
            {
                button4.BackColor = System.Drawing.Color.Red;
                button5.BackColor = System.Drawing.Color.Blue;
                button9.BackColor = System.Drawing.Color.Blue;
                MessageBox.Show("电脑出了剪刀");
            }
            else
            {
                if(computer == 2)
                {
                    button5.BackColor = System.Drawing.Color.Red;
                    button4.BackColor = System.Drawing.Color.Blue;
                    button9.BackColor = System.Drawing.Color.Blue;
                    MessageBox.Show("电脑出了石头");
                }

                else
                {
                    if(computer == 3) {

                        button9.BackColor = System.Drawing.Color.Red;
                        button5.BackColor = System.Drawing.Color.Blue;
                        button4.BackColor = System.Drawing.Color.Blue;
                        MessageBox.Show("电脑出了布");
                    }
                }
            }
            #region 核心算法
            if (computer == user_in)
            {
                button7.Text = "平局";

                
            }

            else
            {
                if(computer == 3 && user_in == 1)
                {
                    button7.Text = "您赢了";
                    user_win = user_win + 1;
                }

                else
                {
                    if(computer == 1 && user_in == 3)
                    {
                        button7.Text = "电脑赢了";
                        user_win = user_win - 1;
                    }

                    else
                    {

                        if (user_in > computer)
                        {

                            button7.Text = "您赢了";
                            user_win = user_win + 1;
                        }

                        else
                        {

                            if (computer > user_in)
                            {

                                button7.Text = "电脑赢了";
                                user_win = user_win - 1;
                            }
                        }
                    }
                }
            }
            
        }
        #endregion


        private void button8_Click(object sender, EventArgs e)
        {
            if (user_win >= 2)
            {
                //启动窗口
                MessageBox.Show("可以启动");
                game gm = new game();
                gm.Show();
            }

            else
            {
                //拒绝启动
                MessageBox.Show("不可以启动");
            }

        }



        private void button10_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }


    }
}
