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
            //取随机路径
            string will = rn.Iget();
            //完整路径
            string okay = local + "\\" + will + ".JPG";
            MessageBox.Show(okay);
            //给予PictureBox路径
            pictureBox2.ImageLocation = okay;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
