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

namespace caiquan
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }

        private void game_Load(object sender, EventArgs e) {

            RanName rn = new RanName();
            //获取程序运行路径
            string local = Application.StartupPath;
            ////取随机路径
            //string will = rn.Iget();
            ////完整路径
            //string okay = local + "\\" + will + ".JPG";
            //MessageBox.Show(okay);
            ////给予PictureBox路径
            //pictureBox2.ImageLocation = okay;

            //取3个随机路径

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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
