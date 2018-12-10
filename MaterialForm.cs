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
    public partial class MaterialForm : Form
    {
        private String Sendimgkeyvalue = null;
        private int int_pic_skill_ID = 0;
        public MaterialForm()
        {
            InitializeComponent();
        }

        Control _MainForm;
        public MaterialForm(Control ctrl)
        {
            InitializeComponent();
            _MainForm = ctrl;
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            
            this.Location = new Point(Convert.ToInt32(((MainForm)_MainForm).Location.X.ToString()),0 );
            label1.Text = "----";
            Bitmap[] Bitmap_Material = ((MainForm)_MainForm).img_Material;
            ImageList imageList = new ImageList { ImageSize = new Size(50, 50) };
            //Image img = new Bitmap(Properties.Resources.class_alterego);
            this.listView1.View = View.LargeIcon;
            for (int i = 0; i < Bitmap_Material.Length; i++)
            {
                imageList.Images.Add(Bitmap_Material[i]);

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
                    if (int_pic_skill_ID == 14)
                        ((MainForm)_MainForm).ReceiveLevelMaterial11(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 15)
                        ((MainForm)_MainForm).ReceiveLevelMaterial12(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 16)
                        ((MainForm)_MainForm).ReceiveLevelMaterial13(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 17)
                        ((MainForm)_MainForm).ReceiveLevelMaterial14(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 18)
                        ((MainForm)_MainForm).ReceiveLevelMaterial21(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 19)
                        ((MainForm)_MainForm).ReceiveLevelMaterial22(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 20)
                        ((MainForm)_MainForm).ReceiveLevelMaterial23(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 21)
                        ((MainForm)_MainForm).ReceiveLevelMaterial24(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 22)
                        ((MainForm)_MainForm).ReceiveLevelMaterial31(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 23)
                        ((MainForm)_MainForm).ReceiveLevelMaterial32(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 24)
                        ((MainForm)_MainForm).ReceiveLevelMaterial33(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 25)
                        ((MainForm)_MainForm).ReceiveLevelMaterial34(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 26)
                        ((MainForm)_MainForm).ReceiveLevelMaterial41(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 27)
                        ((MainForm)_MainForm).ReceiveLevelMaterial42(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 28)
                        ((MainForm)_MainForm).ReceiveLevelMaterial43(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 29)
                        ((MainForm)_MainForm).ReceiveLevelMaterial44(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 30)
                        ((MainForm)_MainForm).ReceiveSkillMaterial21(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 31)
                        ((MainForm)_MainForm).ReceiveSkillMaterial22(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 32)
                        ((MainForm)_MainForm).ReceiveSkillMaterial23(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 33)
                        ((MainForm)_MainForm).ReceiveSkillMaterial24(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 34)
                        ((MainForm)_MainForm).ReceiveSkillMaterial31(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 35)
                        ((MainForm)_MainForm).ReceiveSkillMaterial32(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 36)
                        ((MainForm)_MainForm).ReceiveSkillMaterial33(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 37)
                        ((MainForm)_MainForm).ReceiveSkillMaterial34(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 38)
                        ((MainForm)_MainForm).ReceiveSkillMaterial41(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 39)
                        ((MainForm)_MainForm).ReceiveSkillMaterial42(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 40)
                        ((MainForm)_MainForm).ReceiveSkillMaterial43(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 41)
                        ((MainForm)_MainForm).ReceiveSkillMaterial44(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 42)
                        ((MainForm)_MainForm).ReceiveSkillMaterial51(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 43)
                        ((MainForm)_MainForm).ReceiveSkillMaterial52(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 44)
                        ((MainForm)_MainForm).ReceiveSkillMaterial53(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 45)
                        ((MainForm)_MainForm).ReceiveSkillMaterial54(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 46)
                        ((MainForm)_MainForm).ReceiveSkillMaterial61(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 47)
                        ((MainForm)_MainForm).ReceiveSkillMaterial62(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 48)
                        ((MainForm)_MainForm).ReceiveSkillMaterial63(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 49)
                        ((MainForm)_MainForm).ReceiveSkillMaterial64(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 50)
                        ((MainForm)_MainForm).ReceiveSkillMaterial71(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 51)
                        ((MainForm)_MainForm).ReceiveSkillMaterial72(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 52)
                        ((MainForm)_MainForm).ReceiveSkillMaterial73(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 53)
                        ((MainForm)_MainForm).ReceiveSkillMaterial74(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 54)
                        ((MainForm)_MainForm).ReceiveSkillMaterial81(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 55)
                        ((MainForm)_MainForm).ReceiveSkillMaterial82(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 56)
                        ((MainForm)_MainForm).ReceiveSkillMaterial83(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 57)
                        ((MainForm)_MainForm).ReceiveSkillMaterial84(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 58)
                        ((MainForm)_MainForm).ReceiveSkillMaterial91(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 59)
                        ((MainForm)_MainForm).ReceiveSkillMaterial92(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 60)
                        ((MainForm)_MainForm).ReceiveSkillMaterial93(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 61)
                        ((MainForm)_MainForm).ReceiveSkillMaterial94(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 62)
                        ((MainForm)_MainForm).ReceiveSkillMaterial101(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 63)
                        ((MainForm)_MainForm).ReceiveSkillMaterial102(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 64)
                        ((MainForm)_MainForm).ReceiveSkillMaterial103(Sendimgkeyvalue);
                    else if (int_pic_skill_ID == 65)
                        ((MainForm)_MainForm).ReceiveSkillMaterial104(Sendimgkeyvalue);
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
            Form fr = (MainForm)this.Tag;
            Sendimgkeyvalue = null;
            int_pic_skill_ID = ((MainForm)fr).IDselect;
            if (int_pic_skill_ID == 14)
                ((MainForm)_MainForm).ReceiveLevelMaterial11(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 15)
                ((MainForm)_MainForm).ReceiveLevelMaterial12(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 16)
                ((MainForm)_MainForm).ReceiveLevelMaterial13(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 17)
                ((MainForm)_MainForm).ReceiveLevelMaterial14(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 18)
                ((MainForm)_MainForm).ReceiveLevelMaterial21(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 19)
                ((MainForm)_MainForm).ReceiveLevelMaterial22(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 20)
                ((MainForm)_MainForm).ReceiveLevelMaterial23(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 21)
                ((MainForm)_MainForm).ReceiveLevelMaterial24(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 22)
                ((MainForm)_MainForm).ReceiveLevelMaterial31(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 23)
                ((MainForm)_MainForm).ReceiveLevelMaterial32(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 24)
                ((MainForm)_MainForm).ReceiveLevelMaterial33(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 25)
                ((MainForm)_MainForm).ReceiveLevelMaterial34(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 26)
                ((MainForm)_MainForm).ReceiveLevelMaterial41(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 27)
                ((MainForm)_MainForm).ReceiveLevelMaterial42(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 28)
                ((MainForm)_MainForm).ReceiveLevelMaterial43(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 29)
                ((MainForm)_MainForm).ReceiveLevelMaterial44(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 30)
                ((MainForm)_MainForm).ReceiveSkillMaterial21(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 31)
                ((MainForm)_MainForm).ReceiveSkillMaterial22(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 32)
                ((MainForm)_MainForm).ReceiveSkillMaterial23(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 33)
                ((MainForm)_MainForm).ReceiveSkillMaterial24(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 34)
                ((MainForm)_MainForm).ReceiveSkillMaterial31(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 35)
                ((MainForm)_MainForm).ReceiveSkillMaterial32(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 36)
                ((MainForm)_MainForm).ReceiveSkillMaterial33(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 37)
                ((MainForm)_MainForm).ReceiveSkillMaterial34(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 38)
                ((MainForm)_MainForm).ReceiveSkillMaterial41(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 39)
                ((MainForm)_MainForm).ReceiveSkillMaterial42(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 40)
                ((MainForm)_MainForm).ReceiveSkillMaterial43(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 41)
                ((MainForm)_MainForm).ReceiveSkillMaterial44(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 42)
                ((MainForm)_MainForm).ReceiveSkillMaterial51(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 43)
                ((MainForm)_MainForm).ReceiveSkillMaterial52(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 44)
                ((MainForm)_MainForm).ReceiveSkillMaterial53(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 45)
                ((MainForm)_MainForm).ReceiveSkillMaterial54(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 46)
                ((MainForm)_MainForm).ReceiveSkillMaterial61(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 47)
                ((MainForm)_MainForm).ReceiveSkillMaterial62(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 48)
                ((MainForm)_MainForm).ReceiveSkillMaterial63(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 49)
                ((MainForm)_MainForm).ReceiveSkillMaterial64(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 50)
                ((MainForm)_MainForm).ReceiveSkillMaterial71(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 51)
                ((MainForm)_MainForm).ReceiveSkillMaterial72(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 52)
                ((MainForm)_MainForm).ReceiveSkillMaterial73(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 53)
                ((MainForm)_MainForm).ReceiveSkillMaterial74(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 54)
                ((MainForm)_MainForm).ReceiveSkillMaterial81(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 55)
                ((MainForm)_MainForm).ReceiveSkillMaterial82(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 56)
                ((MainForm)_MainForm).ReceiveSkillMaterial83(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 57)
                ((MainForm)_MainForm).ReceiveSkillMaterial84(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 58)
                ((MainForm)_MainForm).ReceiveSkillMaterial91(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 59)
                ((MainForm)_MainForm).ReceiveSkillMaterial92(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 60)
                ((MainForm)_MainForm).ReceiveSkillMaterial93(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 61)
                ((MainForm)_MainForm).ReceiveSkillMaterial94(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 62)
                ((MainForm)_MainForm).ReceiveSkillMaterial101(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 63)
                ((MainForm)_MainForm).ReceiveSkillMaterial102(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 64)
                ((MainForm)_MainForm).ReceiveSkillMaterial103(Sendimgkeyvalue);
            else if (int_pic_skill_ID == 65)
                ((MainForm)_MainForm).ReceiveSkillMaterial104(Sendimgkeyvalue);
            this.Close();
        }
    }
}

        


