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
    public partial class SkillForm : Form
    {
        /*
        private Bitmap[] icon_skill = {
            Properties.Resources.icon_skill_001,
            Properties.Resources.icon_skill_002,
            Properties.Resources.icon_skill_003,
            Properties.Resources.icon_skill_004,
            Properties.Resources.icon_skill_005,
            Properties.Resources.icon_skill_006,
            Properties.Resources.icon_skill_007,
            Properties.Resources.icon_skill_008,
            Properties.Resources.icon_skill_009,
            Properties.Resources.icon_skill_010,
            Properties.Resources.icon_skill_011,
            Properties.Resources.icon_skill_012,
            Properties.Resources.icon_skill_013,
            Properties.Resources.icon_skill_014,
            Properties.Resources.icon_skill_015,
            Properties.Resources.icon_skill_016,
            Properties.Resources.icon_skill_017,
            Properties.Resources.icon_skill_018,
            Properties.Resources.icon_skill_019,
            Properties.Resources.icon_skill_020,
            Properties.Resources.icon_skill_021,
            Properties.Resources.icon_skill_022,
            Properties.Resources.icon_skill_023,
            Properties.Resources.icon_skill_024,
            Properties.Resources.icon_skill_025,
            Properties.Resources.icon_skill_026,
            Properties.Resources.icon_skill_027,
            Properties.Resources.icon_skill_028,
            Properties.Resources.icon_skill_029,
            Properties.Resources.icon_skill_030,
            Properties.Resources.icon_skill_031,
            Properties.Resources.icon_skill_032,
            Properties.Resources.icon_skill_033,
            Properties.Resources.icon_skill_034,
            Properties.Resources.icon_skill_035,
            Properties.Resources.icon_skill_036,
            Properties.Resources.icon_skill_037,
            Properties.Resources.icon_skill_038,
            Properties.Resources.icon_skill_039,
            Properties.Resources.icon_skill_040,
            Properties.Resources.icon_skill_041,
            Properties.Resources.icon_skill_042,
            Properties.Resources.icon_skill_043,
            Properties.Resources.icon_skill_044,
            Properties.Resources.icon_skill_045,
            Properties.Resources.icon_skill_046,
            Properties.Resources.icon_skill_047,
            Properties.Resources.icon_skill_048,
            Properties.Resources.icon_skill_049,
            Properties.Resources.icon_skill_050,
            Properties.Resources.icon_skill_051,
            Properties.Resources.icon_skill_052,
            Properties.Resources.icon_skill_053,
            Properties.Resources.icon_skill_054,
            Properties.Resources.icon_skill_055,
            Properties.Resources.icon_skill_056,
            Properties.Resources.icon_skill_057,
            Properties.Resources.icon_skill_058,
            Properties.Resources.icon_skill_059,
            Properties.Resources.icon_skill_060,
            Properties.Resources.icon_skill_061,
            Properties.Resources.icon_skill_062,
            Properties.Resources.icon_skill_063,
            Properties.Resources.icon_skill_064,
            Properties.Resources.icon_skill_065,
            Properties.Resources.icon_skill_066,
            Properties.Resources.icon_skill_067,
            Properties.Resources.icon_skill_068,
            Properties.Resources.icon_skill_069,
            Properties.Resources.icon_skill_070,
            Properties.Resources.icon_skill_071,
            Properties.Resources.icon_skill_072,
            Properties.Resources.icon_skill_073,
            Properties.Resources.icon_skill_074,
            Properties.Resources.icon_skill_075,
            Properties.Resources.icon_skill_076,
            Properties.Resources.icon_skill_077,
            Properties.Resources.icon_skill_078,
            Properties.Resources.icon_skill_079,
            Properties.Resources.icon_skill_080,
            Properties.Resources.icon_skill_081,
            Properties.Resources.icon_skill_082,
            Properties.Resources.icon_skill_083,
            Properties.Resources.icon_skill_084,
            Properties.Resources.icon_skill_085,
            Properties.Resources.icon_skill_086,
            Properties.Resources.icon_skill_087,
            Properties.Resources.icon_skill_088,
            Properties.Resources.icon_skill_089,
            Properties.Resources.icon_skill_090,
            Properties.Resources.icon_skill_091,
            Properties.Resources.icon_skill_092,
            Properties.Resources.icon_skill_093,
            Properties.Resources.icon_skill_094,
            Properties.Resources.icon_skill_095,
            Properties.Resources.icon_skill_096,
            Properties.Resources.icon_skill_097,
            Properties.Resources.icon_skill_098,
            Properties.Resources.icon_skill_099,
            Properties.Resources.icon_skill_100,
            Properties.Resources.icon_skill_101,
            Properties.Resources.icon_skill_102,
            Properties.Resources.icon_skill_103,
            Properties.Resources.icon_skill_104,
            Properties.Resources.icon_skill_105,
            Properties.Resources.icon_skill_106,
            Properties.Resources.icon_skill_107,
            Properties.Resources.icon_skill_108,
            Properties.Resources.icon_skill_109,
            Properties.Resources.icon_skill_110,
            Properties.Resources.icon_skill_111,
            Properties.Resources.icon_skill_112,
        };*/
        private int int_pic_skill_ID = 0;//initial value
        public SkillForm()
        {
            InitializeComponent();
        }
        private String Sendimgkeyvalue=null;
        private Control _MainForm = new Control(); //宣告Control用以接收MainForm本體


        public SkillForm(Control ctrl)
        {
            InitializeComponent();
            _MainForm = ctrl;
        }

        public void Receive_picbox_SkillID(Int32 ID)
        {
            int_pic_skill_ID = ID;
        }

        private void SkillForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Convert.ToInt32(((MainForm)_MainForm).Location.X.ToString()), 0);
            ImageList imageList = new ImageList { ImageSize = new Size(50, 50) };
            //Image img = new Bitmap(Properties.Resources.class_alterego);
            this.listView1.View = View.LargeIcon;
            Bitmap[] icon_skill = ((MainForm)_MainForm).icon_skill;
            for (int i = 0; i < icon_skill.Length; i++)
            {
                imageList.Images.Add(icon_skill[i]);

                this.listView1.Items.Add(new ListViewItem { ImageIndex = i });
            }
            this.listView1.LargeImageList = imageList;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int lcount = 0; lcount <= listView1.Items.Count - 1; lcount++)
                {
                    if (listView1.Items[lcount].Selected == true)
                    {
                        label1.Text = (lcount + 1).ToString();
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sendimgkeyvalue = label1.Text;
                //send value
                if (Sendimgkeyvalue != null && Convert.ToInt32(Sendimgkeyvalue) >= 0)
                {
                    Form fr = (MainForm)this.Tag;
                    int_pic_skill_ID = ((MainForm)fr).IDselect;
                    if (int_pic_skill_ID==1)
                        ((MainForm)_MainForm).ReceiveSkillData01(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 2)
                        ((MainForm)_MainForm).ReceiveSkillData02(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 3)
                        ((MainForm)_MainForm).ReceiveSkillData03(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 4)
                        ((MainForm)_MainForm).ReceiveClassSkillData04(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 5)
                        ((MainForm)_MainForm).ReceiveClassSkillData05(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 6)
                        ((MainForm)_MainForm).ReceiveClassSkillData06(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 7)
                        ((MainForm)_MainForm).ReceiveClassSkillData07(Sendimgkeyvalue);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Select Icon", "Hint", MessageBoxButtons.OK);
                }
            }
            catch (Exception eClassSendValue)
            {
                MessageBox.Show("Class Form Error:" + eClassSendValue.ToString(), "Hint", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sendimgkeyvalue = null;
            Form fr = (MainForm)this.Tag;
            int_pic_skill_ID = ((MainForm)fr).IDselect;
            if (int_pic_skill_ID == 1)
                ((MainForm)_MainForm).ReceiveSkillData01(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 2)
                ((MainForm)_MainForm).ReceiveSkillData02(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 3)
                ((MainForm)_MainForm).ReceiveSkillData03(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 4)
                ((MainForm)_MainForm).ReceiveClassSkillData04(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 5)
                ((MainForm)_MainForm).ReceiveClassSkillData05(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 6)
                ((MainForm)_MainForm).ReceiveClassSkillData06(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 7)
                ((MainForm)_MainForm).ReceiveClassSkillData07(Sendimgkeyvalue);
            this.Close();
        }
    }
}
