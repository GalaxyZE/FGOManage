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
    public partial class FormCommandCard : Form
    {
        public FormCommandCard()
        {
            InitializeComponent();
        }
        private Control _MainForm;
        public FormCommandCard(Control ctrl)
        {
            InitializeComponent();
            _MainForm = ctrl;
        }

        private void FormCommandCard_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Convert.ToInt32(((MainForm)_MainForm).Location.X.ToString()), 0);
            pic_CommandBuster.Image = Properties.Resources.card_buster;
            pic_CommandArts.Image = Properties.Resources.card_arts;
            pic_CommandQuick.Image = Properties.Resources.card_quicks;

        }

        private void pic_CommandBuster_Click(object sender, EventArgs e)
        {
            int int_Cardposition_ID = 0;
            int_Cardposition_ID = ((MainForm)_MainForm).IDselect;
            String str_cardcolor = "0";
            if (int_Cardposition_ID!=0)
            {
                switch(int_Cardposition_ID)
                {
                    case 8:                        
                        ((MainForm)_MainForm).ReceiveCommand01(str_cardcolor);
                        break;
                    case 9:
                        ((MainForm)_MainForm).ReceiveCommand02(str_cardcolor);
                        break;
                    case 10:
                        ((MainForm)_MainForm).ReceiveCommand03(str_cardcolor);
                        break;
                    case 11:
                        ((MainForm)_MainForm).ReceiveCommand04(str_cardcolor);
                        break;
                    case 12:
                        ((MainForm)_MainForm).ReceiveCommand05(str_cardcolor);
                        break;
                    case 66:
                        ((MainForm)_MainForm).ReceiveNPCard01(str_cardcolor);
                        break;
                    case 67:
                        ((MainForm)_MainForm).ReceiveNPCard02(str_cardcolor);
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }

        private void pic_CommandArts_Click(object sender, EventArgs e)
        {
            int int_Cardposition_ID = 0;
            int_Cardposition_ID = ((MainForm)_MainForm).IDselect;
            String str_cardcolor = "1";
            if (int_Cardposition_ID != 0)
            {
                switch (int_Cardposition_ID)
                {
                    case 8:
                        ((MainForm)_MainForm).ReceiveCommand01(str_cardcolor);
                        break;
                    case 9:
                        ((MainForm)_MainForm).ReceiveCommand02(str_cardcolor);
                        break;
                    case 10:
                        ((MainForm)_MainForm).ReceiveCommand03(str_cardcolor);
                        break;
                    case 11:
                        ((MainForm)_MainForm).ReceiveCommand04(str_cardcolor);
                        break;
                    case 12:
                        ((MainForm)_MainForm).ReceiveCommand05(str_cardcolor);
                        break;
                    case 66:
                        ((MainForm)_MainForm).ReceiveNPCard01(str_cardcolor);
                        break;
                    case 67:
                        ((MainForm)_MainForm).ReceiveNPCard02(str_cardcolor);
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }

        private void pic_CommandQuick_Click(object sender, EventArgs e)
        {
            int int_Cardposition_ID = 0;
            int_Cardposition_ID = ((MainForm)_MainForm).IDselect;
            String str_cardcolor = "2";
            if (int_Cardposition_ID != 0)
            {
                switch (int_Cardposition_ID)
                {
                    case 8:
                        ((MainForm)_MainForm).ReceiveCommand01(str_cardcolor);
                        break;
                    case 9:
                        ((MainForm)_MainForm).ReceiveCommand02(str_cardcolor);
                        break;
                    case 10:
                        ((MainForm)_MainForm).ReceiveCommand03(str_cardcolor);
                        break;
                    case 11:
                        ((MainForm)_MainForm).ReceiveCommand04(str_cardcolor);
                        break;
                    case 12:
                        ((MainForm)_MainForm).ReceiveCommand05(str_cardcolor);
                        break;
                    case 66:
                        ((MainForm)_MainForm).ReceiveNPCard01(str_cardcolor);
                        break;
                    case 67:
                        ((MainForm)_MainForm).ReceiveNPCard02(str_cardcolor);
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }
    }
}
