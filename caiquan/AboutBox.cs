using System;
using System.Windows.Forms;
using jiandaoshitoubu;

namespace caiquan
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            okButton.Focus(); //优化用户体验
        }

        private void logoPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Game gm = new caiquan.Game();
            gm.Show();
            this.Hide();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            Modifier mfTool = new caiquan.Modifier();
            mfTool.Show();
            Hide();
        }
    }
}
