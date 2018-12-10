using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FateGrandOrder_Data_Helper
{
       
    public partial class ClassForm : Form
    {
        public string Sendimgkeyvalue = null;
        private Bitmap[] imgclass = { Properties.Resources.class_saber, Properties.Resources.class_archer,
            Properties.Resources.class_lancer,Properties.Resources.class_rider,Properties.Resources.class_caster,
            Properties.Resources.class_assassin,Properties.Resources.class_berserker,Properties.Resources.class_shielder,
            Properties.Resources.class_ruler,Properties.Resources.class_avenger,Properties.Resources.class_alterego,
            Properties.Resources.class_mooncancer,Properties.Resources.class_foreinger,Properties.Resources.class_beast
        };
        private Control _MainForm = new Control(); //宣告Control用以接收MainForm本體

        public ClassForm(Control ctrl)
        {
            InitializeComponent();
            _MainForm = ctrl;
        }

        public ClassForm()
        {
            InitializeComponent();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label1.Text = listView1.SelectedItems.IndexOf(listView1.SelectedItems[0]).ToString();
            if(listView1.SelectedItems.Count>0)
            {
                for (int lcount = 0; lcount <= listView1.Items.Count - 1; lcount++)
                {
                    if (listView1.Items[lcount].Selected == true)
                    {
                        label1.Text = (lcount+1).ToString();


                        break;
                    }
                }
            }
            

        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Convert.ToInt32(((MainForm)_MainForm).Location.X.ToString()), 0);
            ImageList imageList = new ImageList { ImageSize = new Size(30, 30) };
            //Image img = new Bitmap(Properties.Resources.class_alterego);
            this.listView1.View = View.LargeIcon;
            for (int i=0;i<imgclass.Length;i++)
            {
                imageList.Images.Add(imgclass[i]);

                this.listView1.Items.Add(new ListViewItem { ImageIndex = i });
            }                        
            this.listView1.LargeImageList = imageList;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sendimgkeyvalue = label1.Text;
                //send value
                if (Sendimgkeyvalue != null && Convert.ToInt32(Sendimgkeyvalue) >= 0)
                {

                    ((MainForm)_MainForm).ReceiveClassFormData(Sendimgkeyvalue);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Select Icon", "Hint", MessageBoxButtons.OK);
                }
            }
            catch(Exception eClassSendValue)
            {
                MessageBox.Show("Class Form Error:" + eClassSendValue.ToString(), "Hint", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }        
    }
}
