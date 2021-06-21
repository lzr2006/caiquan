using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caiquan
{
    public partial class SelectTarget : Form
    {
        public SelectTarget()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string target = textBox1.Text; //CLFPT
            StreamWriter choice = new StreamWriter(Application.StartupPath + "\\temp\\target.txt");
            choice.Write(target);
            choice.Flush();
            choice.Close();
            this.Dispose();
        }

    }
}
