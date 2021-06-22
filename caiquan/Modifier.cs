using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caiquan
{
    public partial class Modifier : Form
    {
        public Modifier()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //数据类型转换 检查是否合法
                int user_blood = Convert.ToInt32(textBox1.Text);
                int user_count = Convert.ToInt32(textBox2.Text);
                int user_money = Convert.ToInt32(textBox3.Text);
                //进度条
                timer1.Enabled = true;
                //打包数据
                StringBuilder valueSb = new StringBuilder();
                valueSb.Append(user_blood.ToString() + ";" + user_count.ToString() + ";" + user_money.ToString());
                MessageBox.Show("数据:" + valueSb.ToString() + "程序运行完成后会自动关闭窗口，属性值会在下一回合生效。","已启动",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                //写入文件
                StreamWriter valueWt = new StreamWriter(Application.StartupPath + "\\API\\value.txt");
                valueWt.Write(valueSb);
                valueWt.Flush();
                valueWt.Close();
            }
            catch
            {
                //数据类型不合法
                MessageBox.Show("有至少一个数据不合法！","转换失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = progressBar1.Value + 1;
            }
            catch
            {
                Hide();
                timer1.Enabled = false; //结束自己

            }
        }


    }
}
