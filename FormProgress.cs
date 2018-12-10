using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FateGrandOrder_Data_Helper
{
    public partial class FormProgress : Form
    {
        private Control _MainForm;
        public FormProgress()
        {
            InitializeComponent();
        }
        public FormProgress(Control ctrl)
        {
            InitializeComponent();
            _MainForm = ctrl;
        }

        private void FormProgress_Load(object sender, EventArgs e)
        {
            Form fr = (MainForm)this.Tag;
            int X = (int)fr.Location.X;
            this.Location = new Point(X+450,600);
            this.Text = "Progress";
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;                   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
