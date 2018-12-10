using FirebaseNet.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FateGrandOrder_Data_Helper;
using System.Threading;

namespace FateGrandOrder_Data_Helper
{
    public partial class Form_Add_NoServents : Form
    {
        public static FirebaseDB FirebaseServant = new FirebaseDB("https://fgohelper.firebaseio.com/Servant");

        public Form_Add_NoServents()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread Task = new Thread(Data_Add);
            Task.Start();
        }

        private void Data_Add()
        {
            if (Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox2.Text) >= 0)
            {
                int int_processvalue = 100/(Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox1.Text));
                try
                {
                    for (int i = Convert.ToInt32(textBox1.Text); i <= Convert.ToInt32(textBox2.Text); i++)
                    {
                        FirebaseDB Firebase_ServantDelete = new FirebaseDB("https://fgohelper.firebaseio.com/Servant/" + "NO_" + i.ToString());
                        FirebaseResponse patchResponse = FirebaseServant.Node("NO_" + i.ToString()).Patch("{" +
                        "\"" + "nameCH" + "\":\"" + "Servant" + "\""
                            + "}");
                        progressBar1.Value += (int_processvalue);
                    }
                    progressBar1.Value = 100;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error", exc.ToString());
                }
            }
        }
    }
}
