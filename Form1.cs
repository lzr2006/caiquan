using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jiandaoshitoubu

{
    public partial class Form1 : Form
    {
        int user_in;

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
                button6.BackColor = System.Drawing.Color.Blue;
                MessageBox.Show("电脑出了剪刀");
            }
            else
            {
                if(computer == 2)
                {
                    button5.BackColor = System.Drawing.Color.Red;
                    button4.BackColor = System.Drawing.Color.Blue;
                    button6.BackColor = System.Drawing.Color.Blue;
                    MessageBox.Show("电脑出了石头");
                }

                else
                {
                    if(computer == 3) {

                        button6.BackColor = System.Drawing.Color.Red;
                        button5.BackColor = System.Drawing.Color.Blue;
                        button4.BackColor = System.Drawing.Color.Blue;
                        MessageBox.Show("电脑出了布");
                    }
                }
            }
           
            if(computer == user_in)
            {
                button7.Text = "平局";

                
            }

            else
            {
                if(computer == 3 && user_in == 1)
                {
                    button7.Text = "您赢了";
                }

                else
                {
                    if(computer == 1 && user_in == 3)
                    {
                        button7.Text = "电脑赢了";
                    }

                    else
                    {

                        if (user_in > computer)
                        {

                            button7.Text = "您赢了";
                        }

                        else
                        {

                            if (computer > user_in)
                            {

                                button7.Text = "电脑赢了";
                            }
                        }
                    }
                }
            }
            
        }

        
    }
}
