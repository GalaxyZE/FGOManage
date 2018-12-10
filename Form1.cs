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
using FirebaseNet.Database;
using Newtonsoft.Json;
using System.Web;
using System.Web.Script;

namespace FateGrandOrder_Data_Helper
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        #region Array
        private Bitmap[] imgclass = { Properties.Resources.class_saber, Properties.Resources.class_archer,
            Properties.Resources.class_lancer,Properties.Resources.class_rider,Properties.Resources.class_caster,
            Properties.Resources.class_assassin,Properties.Resources.class_berserker,Properties.Resources.class_shielder,
            Properties.Resources.class_ruler,Properties.Resources.class_avenger,Properties.Resources.class_alterego,
            Properties.Resources.class_mooncancer,Properties.Resources.class_foreinger,Properties.Resources.class_beast
        };
        public Bitmap[] icon_skill = {
            Properties.Resources.icon_skill_001,Properties.Resources.icon_skill_002, Properties.Resources.icon_skill_003,Properties.Resources.icon_skill_004,
            Properties.Resources.icon_skill_005, Properties.Resources.icon_skill_006,Properties.Resources.icon_skill_007, Properties.Resources.icon_skill_008,
            Properties.Resources.icon_skill_009, Properties.Resources.icon_skill_010, Properties.Resources.icon_skill_011,Properties.Resources.icon_skill_012,
            Properties.Resources.icon_skill_013,Properties.Resources.icon_skill_014,Properties.Resources.icon_skill_015,Properties.Resources.icon_skill_016,Properties.Resources.icon_skill_017,
            Properties.Resources.icon_skill_018,Properties.Resources.icon_skill_019,Properties.Resources.icon_skill_020,Properties.Resources.icon_skill_021,Properties.Resources.icon_skill_022,
            Properties.Resources.icon_skill_023,Properties.Resources.icon_skill_024,Properties.Resources.icon_skill_025,Properties.Resources.icon_skill_026,Properties.Resources.icon_skill_027,
            Properties.Resources.icon_skill_028,Properties.Resources.icon_skill_029,Properties.Resources.icon_skill_030,Properties.Resources.icon_skill_031,Properties.Resources.icon_skill_032,
            Properties.Resources.icon_skill_033,Properties.Resources.icon_skill_034,Properties.Resources.icon_skill_035,Properties.Resources.icon_skill_036,Properties.Resources.icon_skill_037,
            Properties.Resources.icon_skill_038,Properties.Resources.icon_skill_039,Properties.Resources.icon_skill_040,Properties.Resources.icon_skill_041,Properties.Resources.icon_skill_042,
            Properties.Resources.icon_skill_043,Properties.Resources.icon_skill_044,Properties.Resources.icon_skill_045,Properties.Resources.icon_skill_046,Properties.Resources.icon_skill_047,
            Properties.Resources.icon_skill_048,Properties.Resources.icon_skill_049,Properties.Resources.icon_skill_050,Properties.Resources.icon_skill_051,Properties.Resources.icon_skill_052,
            Properties.Resources.icon_skill_053,Properties.Resources.icon_skill_054,Properties.Resources.icon_skill_055,Properties.Resources.icon_skill_056,
            Properties.Resources.icon_skill_057,Properties.Resources.icon_skill_058,Properties.Resources.icon_skill_059,Properties.Resources.icon_skill_060,
            Properties.Resources.icon_skill_061,Properties.Resources.icon_skill_062,Properties.Resources.icon_skill_063,Properties.Resources.icon_skill_064,
            Properties.Resources.icon_skill_065,Properties.Resources.icon_skill_066, Properties.Resources.icon_skill_067,
            Properties.Resources.icon_skill_068,Properties.Resources.icon_skill_069,Properties.Resources.icon_skill_070,Properties.Resources.icon_skill_071,Properties.Resources.icon_skill_072,Properties.Resources.icon_skill_073,
            Properties.Resources.icon_skill_074,Properties.Resources.icon_skill_075,Properties.Resources.icon_skill_076,Properties.Resources.icon_skill_077,
            Properties.Resources.icon_skill_078,Properties.Resources.icon_skill_079,Properties.Resources.icon_skill_080,Properties.Resources.icon_skill_081,
            Properties.Resources.icon_skill_082,Properties.Resources.icon_skill_083,Properties.Resources.icon_skill_084,Properties.Resources.icon_skill_085,
            Properties.Resources.icon_skill_086,Properties.Resources.icon_skill_087,Properties.Resources.icon_skill_088,Properties.Resources.icon_skill_089,
            Properties.Resources.icon_skill_090,Properties.Resources.icon_skill_091,Properties.Resources.icon_skill_092,Properties.Resources.icon_skill_093,
            Properties.Resources.icon_skill_094,Properties.Resources.icon_skill_095,Properties.Resources.icon_skill_096,Properties.Resources.icon_skill_097,Properties.Resources.icon_skill_098,
            Properties.Resources.icon_skill_099,Properties.Resources.icon_skill_100,Properties.Resources.icon_skill_101,Properties.Resources.icon_skill_102,Properties.Resources.icon_skill_103,            Properties.Resources.icon_skill_104,            Properties.Resources.icon_skill_105,            Properties.Resources.icon_skill_106,
            Properties.Resources.icon_skill_107,Properties.Resources.icon_skill_108,Properties.Resources.icon_skill_109,Properties.Resources.icon_skill_110,
            Properties.Resources.icon_skill_111,Properties.Resources.icon_skill_112,Properties.Resources.icon_skill_113,Properties.Resources.icon_skill_114
        };
        private Bitmap[] _Card = { Properties.Resources.card_buster, Properties.Resources.card_arts, Properties.Resources.card_quicks };
        private String[] str_class = {
            "Saber","Archer","Lancer","Rider","Caster","Assassin","Berserker","Shielder","Ruler","Avenger","Altergo",
            "Mooncancer","Foreinger","Beast"
        };
        public String[] str_Material=
        {       "傳承結晶","QP",
                "劍兵銀棋","弓兵銀棋","槍兵銀棋","騎兵銀棋","法師銀棋","暗殺者銀棋","狂戰士銀棋",
                "劍兵金棋","弓兵金棋","槍兵金棋","騎兵金棋","法師金棋","暗殺者金棋","狂戰士金棋",
                "劍的輝石","弓的輝石","槍的輝石","騎的輝石","術的輝石","殺的輝石","狂的輝石",
                "劍的魔石","弓的魔石","槍的魔石","騎的魔石","術的魔石","殺的魔石","狂的魔石",
                "劍的秘石","弓的秘石","槍的秘石","騎的秘石","術的秘石","殺的秘石","狂的秘石",
                "鳳凰之羽","世界樹種子","英雄之證","虛影之塵","龍的逆鱗","渾沌之爪","鬼魂提燈",
                "蛇眼寶玉","無間的齒輪","禁斷書頁","龍牙","隕蹄鐵","人造生命","八連雙晶",
                "兇骨","蠻神心臟","精靈根","戰馬幼角","血之淚石","黑獸油脂","愚者之鎖",
                "封魔神燈","騎士勳章","智慧聖甲蟲","回憶的貝殼","萬死毒針","原初產毛","咒獸膽石",
                "魔術髓液","奇奇神酒","枯鎖勾玉","宵哭的鐵釘","結冰","火藥","極光鋼","巨人的戒指","閑古鈴","曉光爐心"
        };
        public String[] str_EventMaterial =
        {
                "棒棒糖","黃金骷髏","炸雞桶","小刀","水晶球","打火機","樹枝","項鍊","龍珠","娃娃","盒子","緞帶","蘆葦",
                "方塊","鬍子","樹葉","海盜旗","漆黑的羽毛","護法"
        };

        public Bitmap[] img_Material =
        {
            Properties.Resources.item_skill_00,Properties.Resources.item_qp,
            Properties.Resources.item_class_01,Properties.Resources.item_class_02,Properties.Resources.item_class_03,Properties.Resources.item_class_04,Properties.Resources.item_class_05,Properties.Resources.item_class_06,Properties.Resources.item_class_07,
            Properties.Resources.item_class_08,Properties.Resources.item_class_09,Properties.Resources.item_class_10,Properties.Resources.item_class_11,Properties.Resources.item_class_12,Properties.Resources.item_class_13,Properties.Resources.item_class_14,
            Properties.Resources.item_skill_01,Properties.Resources.item_skill_02,Properties.Resources.item_skill_03,Properties.Resources.item_skill_04,Properties.Resources.item_skill_05,Properties.Resources.item_skill_06,Properties.Resources.item_skill_07,
            Properties.Resources.item_skill_08,Properties.Resources.item_skill_09,Properties.Resources.item_skill_10,Properties.Resources.item_skill_11,Properties.Resources.item_skill_12,Properties.Resources.item_skill_13,Properties.Resources.item_skill_14,
            Properties.Resources.item_skill_15,Properties.Resources.item_skill_16,Properties.Resources.item_skill_17,Properties.Resources.item_skill_18,Properties.Resources.item_skill_19,Properties.Resources.item_skill_20,Properties.Resources.item_skill_21,
            Properties.Resources.item_material_01,Properties.Resources.item_material_02,Properties.Resources.item_material_03,Properties.Resources.item_material_04,Properties.Resources.item_material_05,Properties.Resources.item_material_06,Properties.Resources.item_material_07,
            Properties.Resources.item_material_08,Properties.Resources.item_material_09,Properties.Resources.item_material_10,Properties.Resources.item_material_11,Properties.Resources.item_material_12,Properties.Resources.item_material_13,Properties.Resources.item_material_14,
            Properties.Resources.item_material_15,Properties.Resources.item_material_16,Properties.Resources.item_material_17,Properties.Resources.item_material_18,Properties.Resources.item_material_19,Properties.Resources.item_material_20,Properties.Resources.item_material_21,
            Properties.Resources.item_material_22,Properties.Resources.item_material_23,Properties.Resources.item_material_24,Properties.Resources.item_material_25,Properties.Resources.item_material_26,Properties.Resources.item_material_27,Properties.Resources.item_material_28,
            Properties.Resources.item_material_29,Properties.Resources.item_material_30,Properties.Resources.item_material_31,Properties.Resources.item_material_32,Properties.Resources.item_material_33,Properties.Resources.item_material_34,Properties.Resources.item_material_35,
            Properties.Resources.item_material_36,Properties.Resources.item_material_37,Properties.Resources.item_material_38
        };
        public Bitmap[] img_EventMaterial =
        {
            Properties.Resources.item_eventmaterial_001,Properties.Resources.item_eventmaterial_002,Properties.Resources.item_eventmaterial_003,Properties.Resources.item_eventmaterial_004,
            Properties.Resources.item_eventmaterial_005,Properties.Resources.item_eventmaterial_006,Properties.Resources.item_eventmaterial_007,Properties.Resources.item_eventmaterial_008,
            Properties.Resources.item_eventmaterial_009,Properties.Resources.item_eventmaterial_010,Properties.Resources.item_eventmaterial_011,Properties.Resources.item_eventmaterial_012,
            Properties.Resources.item_eventmaterial_013,Properties.Resources.item_eventmaterial_014,Properties.Resources.item_eventmaterial_015,Properties.Resources.item_eventmaterial_016,
            Properties.Resources.item_other_302
        };
        #endregion
        FateGrandOrder_Data_Helper.Properties.Settings MySetting = new FateGrandOrder_Data_Helper.Properties.Settings();
        private bool bool_switch_textClass = false;
        private String [] str_Receive_imgskill = new string[3];
        private Control _SkillForm = new Control(); //宣告Control用以接收MainForm本體
        public int IDselect = 0;
        public static FirebaseDB FirebaseQuest = new FirebaseDB("https://fgohelper.firebaseio.com/QuestWeek");
        public static FirebaseDB FirebaseServant = new FirebaseDB("https://fgohelper.firebaseio.com/Servant");
        private Thread t2 ;


        public MainForm(Control ctrl)
        {
            InitializeComponent();
            _SkillForm = ctrl;
        }
        public MainForm()
        {
            InitializeComponent();            
        }

        #region Receive 
        public void ReceiveClassFormData(String Data)
        {
            if(Data!=null)
             textClass_int.Text = Data;
            
            
        }

        public void ReceiveSkillData01(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_Skill01.Image = icon_skill[Convert.ToInt32(Data) - 1];
                str_Receive_imgskill[0] = Data;
            }
            else
            {
                pic_Skill01.Image = null;
                str_Receive_imgskill[0] = null;
            }
        }

        public void ReceiveSkillData02(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_Skill02.Image = icon_skill[Convert.ToInt32(Data) - 1];
                str_Receive_imgskill[1] = Data;
            }
            else
            {
                pic_Skill02.Image = null;
                str_Receive_imgskill[1] = null;
            }
        }

        public void ReceiveSkillData03(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_Skill03.Image = icon_skill[Convert.ToInt32(Data) - 1];
                str_Receive_imgskill[2] = Data;
            }
            else
            {
                pic_Skill01.Image = null;
                str_Receive_imgskill[2] = null;
            }
        }

        public void ReceiveClassSkillData04(String Data)
        {
            if(Data!=null && Data!="")
            {
                pic_ClassSkill01.Image = icon_skill[Convert.ToInt32(Data) - 1];
            }
            else
            {
                pic_ClassSkill01.Image = null;
            }
            
        }

        public void ReceiveClassSkillData05(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_ClassSkill02.Image = icon_skill[Convert.ToInt32(Data) - 1];
            }
            else
            {
                pic_ClassSkill02.Image = null;
            }
        }

        public void ReceiveClassSkillData06(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_ClassSkill03.Image = icon_skill[Convert.ToInt32(Data) - 1];
            }
            else
            {
                pic_ClassSkill03.Image = null;
            }
        }
        public void ReceiveClassSkillData07(String Data)
        {
            if (Data != null && Data != "")
            {
                pic_ClassSkill04.Image = icon_skill[Convert.ToInt32(Data) - 1];
            }
            else
            {
                pic_ClassSkill04.Image = null;
            }
        }

        public void ReceiveCommand01(String Data)
        {
            if(Data != null && Data !="999999")
            {
                pic_Commandcard01.Image = _Card[Convert.ToInt32(Data)];
            }
            else
            {
                pic_Commandcard01.Image = null;
            }
            
        }

        public void ReceiveCommand02(String Data)
        {
            if (Data != null && Data != "999999")
                pic_Commandcard02.Image = _Card[Convert.ToInt32(Data)];
            else
                pic_Commandcard02.Image = null;
        }

        public void ReceiveCommand03(String Data)
        {
            if (Data != null && Data != "999999")
                pic_Commandcard03.Image = _Card[Convert.ToInt32(Data)];
            else
                pic_Commandcard03.Image = null;
        }

        public void ReceiveCommand04(String Data)
        {
            if (Data != null && Data != "999999")
                pic_Commandcard04.Image = _Card[Convert.ToInt32(Data)];
            else
                pic_Commandcard04.Image = null;
        }

        public void ReceiveCommand05(String Data)
        {
            if (Data != null && Data != "999999")
                pic_Commandcard05.Image = _Card[Convert.ToInt32(Data)];
            else
                pic_Commandcard05.Image = null;
        }

        public void ReceiveLevelMaterial11(String Data)
        {
            if(Data !=null)
                pic_levelmaterial_11.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_11.Image = null;
        }

        public void ReceiveLevelMaterial12(String Data)
        {
            if (Data != null)
                pic_levelmaterial_12.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_12.Image = null;
        }

        public void ReceiveLevelMaterial13(String Data)
        {
            if (Data != null)
                pic_levelmaterial_13.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_13.Image = null;
        }

        public void ReceiveLevelMaterial14(String Data)
        {
            if (Data != null)
                pic_levelmaterial_14.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_14.Image = null;
        }

        public void ReceiveLevelMaterial21(String Data)
        {
            if (Data != null)
                pic_levelmaterial_21.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_21.Image = null;
        }
        public void ReceiveLevelMaterial22(String Data)
        {
            if (Data != null)
                pic_levelmaterial_22.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_22.Image = null;
        }
        public void ReceiveLevelMaterial23(String Data)
        {
            if (Data != null)
                pic_levelmaterial_23.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_23.Image = null;
        }
        public void ReceiveLevelMaterial24(String Data)
        {
            if (Data != null)
                pic_levelmaterial_24.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_24.Image = null;
        }
        public void ReceiveLevelMaterial31(String Data)
        {
            if (Data != null)
                pic_levelmaterial_31.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_31.Image = null;
        }
        public void ReceiveLevelMaterial32(String Data)
        {
            if (Data != null)
                pic_levelmaterial_32.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_32.Image = null;
        }
        public void ReceiveLevelMaterial33(String Data)
        {
            if (Data != null)
                pic_levelmaterial_33.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_33.Image = null;
        }
        public void ReceiveLevelMaterial34(String Data)
        {
            if (Data != null)
                pic_levelmaterial_34.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_34.Image = null;
        }
        public void ReceiveLevelMaterial41(String Data)
        {
            if (Data != null)
                pic_levelmaterial_41.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_41.Image = null;
        }
        public void ReceiveLevelMaterial42(String Data)
        {
            if (Data != null)
                pic_levelmaterial_42.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_42.Image = null;
        }
        public void ReceiveLevelMaterial43(String Data)
        {
            if (Data != null)
                pic_levelmaterial_43.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_43.Image = null;
        }
        public void ReceiveLevelMaterial44(String Data)
        {
            if (Data != null)
                pic_levelmaterial_44.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_levelmaterial_44.Image = null;
        }
        //------------------------------------------------------------------------
        public void ReceiveSkillMaterial21(String Data)
        {
            if (Data != null)
                pic_Skill_Material21.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material21.Image = null;
        }
        public void ReceiveSkillMaterial22(String Data)
        {
            if (Data != null)
                pic_Skill_Material22.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material22.Image = null;
        }
        public void ReceiveSkillMaterial23(String Data)
        {
            if (Data != null)
                pic_Skill_Material23.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material23.Image = null;
        }
        public void ReceiveSkillMaterial24(String Data)
        {
            if (Data != null)
                pic_Skill_Material24.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material24.Image = null;
        }

        public void ReceiveSkillMaterial31(String Data)
        {
            if (Data != null)
                pic_Skill_Material31.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material31.Image = null;
        }
        public void ReceiveSkillMaterial32(String Data)
        {
            if (Data != null)
                pic_Skill_Material32.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material32.Image = null;
        }
        public void ReceiveSkillMaterial33(String Data)
        {
            if (Data != null)
                pic_Skill_Material33.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material33.Image = null;
        }
        public void ReceiveSkillMaterial34(String Data)
        {
            if (Data != null)
                pic_Skill_Material34.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material34.Image = null;
        }

        public void ReceiveSkillMaterial41(String Data)
        {
            if (Data != null)
                pic_Skill_Material41.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material41.Image = null;
        }
        public void ReceiveSkillMaterial42(String Data)
        {
            if (Data != null)
                pic_Skill_Material42.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material42.Image = null;
        }
        public void ReceiveSkillMaterial43(String Data)
        {
            if (Data != null)
                pic_Skill_Material43.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material43.Image = null;
        }
        public void ReceiveSkillMaterial44(String Data)
        {
            if (Data != null)
                pic_Skill_Material44.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material44.Image = null;
        }

        public void ReceiveSkillMaterial51(String Data)
        {
            if (Data != null)
                pic_Skill_Material51.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material51.Image = null;
        }
        public void ReceiveSkillMaterial52(String Data)
        {
            if (Data != null)
                pic_Skill_Material52.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material52.Image = null;
        }
        public void ReceiveSkillMaterial53(String Data)
        {
            if (Data != null)
                pic_Skill_Material53.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material53.Image = null;
        }
        public void ReceiveSkillMaterial54(String Data)
        {
            if (Data != null)
                pic_Skill_Material54.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material54.Image = null;
        }

        public void ReceiveSkillMaterial61(String Data)
        {
            if (Data != null)
                pic_Skill_Material61.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material61.Image = null;
        }
        public void ReceiveSkillMaterial62(String Data)
        {
            if (Data != null)
                pic_Skill_Material62.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material62.Image = null;
        }
        public void ReceiveSkillMaterial63(String Data)
        {
            if (Data != null)
                pic_Skill_Material63.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material63.Image = null;
        }
        public void ReceiveSkillMaterial64(String Data)
        {
            if (Data != null)
                pic_Skill_Material64.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material64.Image = null;
        }

        public void ReceiveSkillMaterial71(String Data)
        {
            if (Data != null)
                pic_Skill_Material71.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material71.Image = null;
        }
        public void ReceiveSkillMaterial72(String Data)
        {
            if (Data != null)
                pic_Skill_Material72.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material72.Image = null;
        }
        public void ReceiveSkillMaterial73(String Data)
        {
            if (Data != null)
                pic_Skill_Material73.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material73.Image = null;
        }
        public void ReceiveSkillMaterial74(String Data)
        {
            if (Data != null)
                pic_Skill_Material74.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material74.Image = null;
        }

        public void ReceiveSkillMaterial81(String Data)
        {
            if (Data != null)
                pic_Skill_Material81.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material81.Image = null;
        }
        public void ReceiveSkillMaterial82(String Data)
        {
            if (Data != null)
                pic_Skill_Material82.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material82.Image = null;
        }
        public void ReceiveSkillMaterial83(String Data)
        {
            if (Data != null)
                pic_Skill_Material83.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material83.Image = null;
        }
        public void ReceiveSkillMaterial84(String Data)
        {
            if (Data != null)
                pic_Skill_Material84.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material84.Image = null;
        }

        public void ReceiveSkillMaterial91(String Data)
        {
            if (Data != null)
                pic_Skill_Material91.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material91.Image = null;
        }
        public void ReceiveSkillMaterial92(String Data)
        {
            if (Data != null)
                pic_Skill_Material92.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material92.Image = null;
        }
        public void ReceiveSkillMaterial93(String Data)
        {
            if (Data != null)
                pic_Skill_Material93.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material93.Image = null;
        }
        public void ReceiveSkillMaterial94(String Data)
        {
            if (Data != null)
                pic_Skill_Material94.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material94.Image = null;
        }

        public void ReceiveSkillMaterial101(String Data)
        {
            if(Data!=null)
                pic_Skill_Material101.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material101.Image = null;
        }
        public void ReceiveSkillMaterial102(String Data)
        {
            if (Data != null)
                pic_Skill_Material102.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material102.Image = null;
        }
        public void ReceiveSkillMaterial103(String Data)
        {
            if (Data != null)
                pic_Skill_Material103.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material103.Image = null;
        }
        public void ReceiveSkillMaterial104(String Data)
        {
            if (Data != null)
                pic_Skill_Material104.Image = img_Material[Convert.ToInt32(Data) - 1];
            else
                pic_Skill_Material104.Image = null;
        }
        public void ReceiveNPCard01(String Data)
        {
            
            pic_NPCard01.Image = _Card[Convert.ToInt32(Data)];
        }
        public void ReceiveNPCard02(String Data)
        {
            pic_NPCard02.Image = _Card[Convert.ToInt32(Data)];
        }

        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            #region Initial object
            this.Text = "Fate/GrandOder-Helper";
            tabServantPage.Text = "Servant";
            tabCraftEssencePage.Text = "CraftEssence";
            tabWeekQuestPage.Text = "Week-Quset";
            this.Size = new Size(950, 1040);
            combo_WeekQuest.Items.Add("Chinese");
            combo_WeekQuest.Items.Add("English");
            combo_WeekQuest.Items.Add("China");

            #region Initial picturebox sizemode
            pic_levelmaterial_11.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_12.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_13.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_14.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_21.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_22.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_23.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_24.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_31.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_32.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_33.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_34.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_41.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_42.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_43.SizeMode = PictureBoxSizeMode.Zoom;
            pic_levelmaterial_44.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material21.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material22.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material23.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material24.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material21.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material22.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material23.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material24.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material31.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material32.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material33.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material34.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material41.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material42.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material43.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material44.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material51.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material52.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material53.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material54.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material61.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material62.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material63.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material64.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material71.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material72.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material73.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material74.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material81.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material82.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material83.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material84.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material91.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material92.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material93.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material94.SizeMode = PictureBoxSizeMode.Zoom;

            pic_Skill_Material101.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material102.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material103.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Skill_Material104.SizeMode = PictureBoxSizeMode.Zoom;


            #endregion

            #endregion
            //*********************************************************
            int k = 208;
            FirebaseDB firebaseDB;
            FirebaseResponse getResponse;
            FGOHelper.FGOHelperS fgo = new FGOHelper.FGOHelperS();
            if (MySetting.Load_ServantNO==-1)
            {
                try
                {                    
                    while(true)
                    {
                        firebaseDB = FirebaseServant.Node("NO_" + k.ToString());
                        getResponse = firebaseDB.Get();
                        fgo=JsonConvert.DeserializeObject<FGOHelper.FGOHelperS>(getResponse.JSONContent.ToString());
                        comboBox1.Items.Add("NO_" + (k).ToString());
                        k++;
                    }                                         
                }
                catch(Exception excformload)
                {
                    MySetting.Load_ServantNO = k;
                    MySetting.Save();
                    Application.Restart();
                    //excformload.ToString();                    
                }              
            }
            for (int i = 0; i < MySetting.Load_ServantNO; i++)
            {
                comboBox1.Items.Add("NO_" + (i).ToString());
            }
            comboBox1.SelectedIndex = 0;
            
            /*
            FirebaseDB firebaseDB = new FirebaseDB("https://csharp-9f233.firebaseio.com/Servant");
            FirebaseDB firebaseDBTeams = firebaseDB.Node(comboBox1.Text); 
            textServantNO.Text += "GET Request\n";
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            if (getResponse.Success)
                textServantNO.Text+= getResponse.JSONContent.ToString()+"\n";
            FGOHelper.FGOHelperS fgo = new FGOHelper.FGOHelperS();
            fgo = JsonConvert.DeserializeObject<FGOHelper.FGOHelperS>(getResponse.JSONContent.ToString());
            textServantNO.Text = fgo.GetNameEN()+"/"+fgo.GetNameCH();
            */
            
            



            //textBox1.Text+="PUT Request\n";
            //FirebaseResponse putResponse = firebaseDBTeams.Put(data);

                //WriteLine(putResponse.Success);
                //WriteLine();

                //WriteLine("POST Request");
                //FirebaseResponse postResponse = firebaseDBTeams.Post(data);
                //WriteLine(postResponse.Success);
                //WriteLine();
                /*
                 * 
                //WriteLine("PATCH Request");
                FirebaseResponse patchResponse = firebaseDBTeams
                    // Use of NodePath to refer path lnager than a single Node
                    .NodePath("Team-Awesome/Members/M1")
                    .Patch("{\"Designation\":\"CRM Consultant\"}");
                //WriteLine(patchResponse.Success);
                //WriteLine();

                //WriteLine("DELETE Request");
                //FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
                //WriteLine(deleteResponse.Success);
                //WriteLine();
                */
                //WriteLine(firebaseDBTeams.ToString());
                //ReadLine();
        }

        private void textServantNO_TextChanged(object sender, EventArgs e)
        {
            
        }

      
        /// <summary>
        /// 選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread t1 = new Thread(Read_Data_Servant_Function);
            progressBar2.Visible = true;
            t1.Start();
            
            /*                      
            #region Reading Data From Firebase by Get apporach
            textServantNO.Text = (comboBox1.SelectedIndex+1).ToString();
            //FirebaseDB firebaseDB = new FirebaseDB("https://csharp-9f233.firebaseio.com/Servant");
            
                FirebaseDB firebaseDB = FirebaseServant.Node(comboBox1.Text);
            //GET Request
            if (!checkBox_Editmode.Checked)
            {
                
                FirebaseResponse getResponse = firebaseDB.Get();

                //if (getResponse.Success)
                //    textBox1.Text += getResponse.JSONContent.ToString();
                FGOHelper.FGOHelperS fgo = new FGOHelper.FGOHelperS();
                try
                {
                    fgo = JsonConvert.DeserializeObject<FGOHelper.FGOHelperS>(getResponse.JSONContent.ToString());
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error:" + er.ToString(), "Hint", MessageBoxButtons.OK);
                    comboBox1.SelectedIndex = 1;
                }

                #endregion

                #region Image initial
                pic_ClassSkill01.Image = null;
                pic_ClassSkill02.Image = null;
                pic_ClassSkill03.Image = null;
                pic_ClassSkill04.Image = null;
                pic_Skill01.Image = null;
                pic_Skill02.Image = null;
                pic_Skill03.Image = null;
                pic_Commandcard01.Image = null;
                pic_Commandcard02.Image = null;
                pic_Commandcard03.Image = null;
                pic_Commandcard04.Image = null;
                pic_Commandcard05.Image = null;
                pic_NPCard01.Image = pic_NPCard02.Image = null;
                pic_levelmaterial_11.Image = null;
                pic_levelmaterial_12.Image = null;
                pic_levelmaterial_13.Image = null;
                pic_levelmaterial_14.Image = null;
                pic_levelmaterial_21.Image = null;
                pic_levelmaterial_22.Image = null;
                pic_levelmaterial_23.Image = null;
                pic_levelmaterial_24.Image = null;
                pic_levelmaterial_31.Image = null;
                pic_levelmaterial_32.Image = null;
                pic_levelmaterial_33.Image = null;
                pic_levelmaterial_34.Image = null;
                pic_levelmaterial_41.Image = null;
                pic_levelmaterial_42.Image = null;
                pic_levelmaterial_43.Image = null;
                pic_levelmaterial_44.Image = null;
                pic_Skill_Material101.Image = null;
                pic_Skill_Material102.Image = null;
                pic_Skill_Material103.Image = null;
                pic_Skill_Material104.Image = null;
                pic_Skill_Material21.Image = null;
                pic_Skill_Material22.Image = null;
                pic_Skill_Material23.Image = null;
                pic_Skill_Material24.Image = null;
                pic_Skill_Material31.Image = null;
                pic_Skill_Material32.Image = null;
                pic_Skill_Material33.Image = null;
                pic_Skill_Material34.Image = null;
                pic_Skill_Material41.Image = null;
                pic_Skill_Material42.Image = null;
                pic_Skill_Material43.Image = null;
                pic_Skill_Material44.Image = null;
                pic_Skill_Material51.Image = null;
                pic_Skill_Material52.Image = null;
                pic_Skill_Material53.Image = null;
                pic_Skill_Material54.Image = null;
                pic_Skill_Material61.Image = null;
                pic_Skill_Material62.Image = null;
                pic_Skill_Material63.Image = null;
                pic_Skill_Material64.Image = null;
                pic_Skill_Material71.Image = null;
                pic_Skill_Material72.Image = null;
                pic_Skill_Material73.Image = null;
                pic_Skill_Material74.Image = null;
                pic_Skill_Material81.Image = null;
                pic_Skill_Material82.Image = null;
                pic_Skill_Material83.Image = null;
                pic_Skill_Material84.Image = null;
                pic_Skill_Material91.Image = null;
                pic_Skill_Material92.Image = null;
                pic_Skill_Material93.Image = null;
                pic_Skill_Material94.Image = null;

                #endregion

                try
                {
                    #region Status Info
                    ServantNameChinese.Text = fgo.NameCH;
                    ServantNameEN.Text = fgo.NameEN;
                    ServantNameJP.Text = fgo.NameJP;
                    ServantNameChina.Text = fgo.NameChina;
                    textRarity.Text = fgo.Rarity.ToString();
                    textCost.Text = fgo.COST.ToString();
                    textMaxLv.Text = fgo.MAX_LV.ToString();
                    textClass_int.Text = fgo.servantClass.ToString();
                    if (fgo.servantClass != 999999)
                    {
                        textClass_str.Text = str_class[fgo.servantClass - 1];
                    }
                    else
                    {
                        textClass_str.Text = fgo.servantClass.ToString();
                    }

                    if (fgo.servantClass != 999999 && fgo.servantClass > 0)
                    {
                        picimgclass.Image = imgclass[fgo.servantClass - 1];
                    }
                    textATK01.Text = fgo.StatusATKLV1.ToString();
                    textHP01.Text = fgo.Status_HPLV1.ToString();
                    textATKMax.Text = fgo.StatusATKFinal.ToString();
                    textHPMax.Text = fgo.Status_HPFinal.ToString();
                    textATK100.Text = fgo.StatusATKLV100.ToString();
                    textHP100.Text = fgo.Status_HPLV100.ToString();
                    #endregion

                    #region Skill Describe
                    pic_Skill01.Image = icon_skill[fgo.img_Skill01 - 1];
                    pic_Skill02.Image = icon_skill[fgo.img_Skill02 - 1];
                    pic_Skill03.Image = icon_skill[fgo.img_Skill03 - 1];

                    text_Skill_Describe1.Text = fgo.Skill_Describe1;
                    text_Skill_Describe2.Text = fgo.Skill_Describe2;
                    text_Skill_Describe3.Text = fgo.Skill_Describe3;
                    text_Skill_Describe4.Text = fgo.Skill_Describe4;
                    text_Skill_Describe5.Text = fgo.Skill_Describe5;
                    text_Skill_Describe6.Text = fgo.Skill_Describe6;

                    textSkillEffect11.Text = fgo.Skill_1_Effect1;
                    textSkillEffect12.Text = fgo.Skill_1_Effect2;
                    textSkillEffect13.Text = fgo.Skill_1_Effect3;
                    textSkillEffect14.Text = fgo.Skill_1_Effect4;
                    textSkillEffect15.Text = fgo.Skill_1_Effect5;
                    textSkillEffect16.Text = fgo.Skill_1_Effect6;
                    textSkillEffect17.Text = fgo.Skill_1_Effect7;
                    textSkillEffect18.Text = fgo.Skill_1_Effect8;
                    textSkillEffect19.Text = fgo.Skill_1_Effect9;
                    textSkillEffect110.Text = fgo.Skill_1_Effect10;

                    textSkillEffect21.Text = fgo.Skill_2_Effect1;
                    textSkillEffect22.Text = fgo.Skill_2_Effect2;
                    textSkillEffect23.Text = fgo.Skill_2_Effect3;
                    textSkillEffect24.Text = fgo.Skill_2_Effect4;
                    textSkillEffect25.Text = fgo.Skill_2_Effect5;
                    textSkillEffect26.Text = fgo.Skill_2_Effect6;
                    textSkillEffect27.Text = fgo.Skill_2_Effect7;
                    textSkillEffect28.Text = fgo.Skill_2_Effect8;
                    textSkillEffect29.Text = fgo.Skill_2_Effect9;
                    textSkillEffect210.Text = fgo.Skill_2_Effect10;

                    textSkillEffect31.Text = fgo.Skill_3_Effect1;
                    textSkillEffect32.Text = fgo.Skill_3_Effect2;
                    textSkillEffect33.Text = fgo.Skill_3_Effect3;
                    textSkillEffect34.Text = fgo.Skill_3_Effect4;
                    textSkillEffect35.Text = fgo.Skill_3_Effect5;
                    textSkillEffect36.Text = fgo.Skill_3_Effect6;
                    textSkillEffect37.Text = fgo.Skill_3_Effect7;
                    textSkillEffect38.Text = fgo.Skill_3_Effect8;
                    textSkillEffect39.Text = fgo.Skill_3_Effect9;
                    textSkillEffect310.Text = fgo.Skill_3_Effect10;
                    #endregion

                    #region Class Skill Describe


                    if (fgo.img_ClassSkill01 != 999999)
                    {
                        pic_ClassSkill01.Image = icon_skill[fgo.img_ClassSkill01 - 1];
                    }

                    if (fgo.img_ClassSkill02 != 999999)
                    {
                        pic_ClassSkill02.Image = icon_skill[fgo.img_ClassSkill02 - 1];
                    }

                    if (fgo.img_ClassSkill03 != 999999)
                    {
                        pic_ClassSkill03.Image = icon_skill[fgo.img_ClassSkill03 - 1];
                    }

                    if (fgo.img_ClassSkill04 != 999999)
                    {
                        pic_ClassSkill04.Image = icon_skill[fgo.img_ClassSkill04 - 1];
                    }

                    textClassSkillDescribe01.Text = fgo.Class_Describe1;
                    textClassSkillDescribe02.Text = fgo.Class_Describe2;
                    textClassSkillDescribe03.Text = fgo.Class_Describe3;
                    textClassSkillDescribe04.Text = fgo.Class_Describe4;
                    #endregion

                    #region Command Card 
                    int Buster = fgo.Command_Buster;
                    int Arts = fgo.Command_Arts;
                    int Quick = fgo.Command_Quick;

                    for (int c = 0; c < 5; c++)
                    {
                        if (Buster != 0)
                        {
                            Buster--;
                            switch (c)
                            {
                                case 0:
                                    pic_Commandcard01.Image = _Card[0];
                                    break;
                                case 1:
                                    pic_Commandcard02.Image = _Card[0];
                                    break;
                                case 2:
                                    pic_Commandcard03.Image = _Card[0];
                                    break;
                                case 3:
                                    pic_Commandcard04.Image = _Card[0];
                                    break;
                                case 4:
                                    pic_Commandcard05.Image = _Card[0];
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (Arts != 0)
                            {
                                Arts--;
                                switch (c)
                                {
                                    case 0:
                                        pic_Commandcard01.Image = _Card[1];
                                        break;
                                    case 1:
                                        pic_Commandcard02.Image = _Card[1];
                                        break;
                                    case 2:
                                        pic_Commandcard03.Image = _Card[1];
                                        break;
                                    case 3:
                                        pic_Commandcard04.Image = _Card[1];
                                        break;
                                    case 4:
                                        pic_Commandcard05.Image = _Card[1];
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                if (Quick != 0)
                                {
                                    Quick--;
                                    switch (c)
                                    {
                                        case 0:
                                            pic_Commandcard01.Image = _Card[2];
                                            break;
                                        case 1:
                                            pic_Commandcard02.Image = _Card[2];
                                            break;
                                        case 2:
                                            pic_Commandcard03.Image = _Card[2];
                                            break;
                                        case 3:
                                            pic_Commandcard04.Image = _Card[2];
                                            break;
                                        case 4:
                                            pic_Commandcard05.Image = _Card[2];
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region NP
                    textNPname1.Text = fgo.NP_Name1;
                    textNPname2.Text = fgo.NP_Name2;
                    textNPdescribe.Text = fgo.NP_Describe;
                    textNPrank1.Text = fgo.NP_Describe_Rank1;
                    textNPrank2.Text = fgo.NP_Rank2;
                    textNPtarget.Text = fgo.NP_Describe_Target;

                    textNP_Effect11.Text = fgo.NP_1_Effect1;
                    textNP_Effect12.Text = fgo.NP_1_Effect2;
                    textNP_Effect13.Text = fgo.NP_1_Effect3;
                    textNP_Effect14.Text = fgo.NP_1_Effect4;
                    textNP_Effect15.Text = fgo.NP_1_Effect5;

                    textNP_Effect21.Text = fgo.NP_2_Effect1;
                    textNP_Effect22.Text = fgo.NP_2_Effect2;
                    textNP_Effect23.Text = fgo.NP_2_Effect3;
                    textNP_Effect24.Text = fgo.NP_2_Effect4;
                    textNP_Effect25.Text = fgo.NP_2_Effect5;

                    if (fgo.NP_CardColor != 4 || fgo.NP_CardColor != 999999)
                    {
                        switch (fgo.NP_CardColor)
                        {
                            case 0:
                                pic_NPCard01.Image = _Card[0];
                                break;
                            case 1:
                                pic_NPCard01.Image = _Card[1];
                                break;
                            case 2:
                                pic_NPCard01.Image = _Card[2];
                                break;
                            default:
                                break;
                        }
                    }
                    if (fgo.NP_Rank2 != null)
                    {
                        switch (fgo.NP_CardColor)
                        {
                            case 0:
                                pic_NPCard02.Image = _Card[0];
                                break;
                            case 1:
                                pic_NPCard02.Image = _Card[1];
                                break;
                            case 2:
                                pic_NPCard02.Image = _Card[2];
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion

                    #region  Material
                    String[] str_levelmaterial =
                    {
                fgo.LevelMaterial_11,fgo.LevelMaterial_12,fgo.LevelMaterial_13,fgo.LevelMaterial_14,
                fgo.LevelMaterial_21,fgo.LevelMaterial_22,fgo.LevelMaterial_23,fgo.LevelMaterial_24,
                fgo.LevelMaterial_31,fgo.LevelMaterial_32,fgo.LevelMaterial_33,fgo.LevelMaterial_34,
                fgo.LevelMaterial_41,fgo.LevelMaterial_42,fgo.LevelMaterial_43,fgo.LevelMaterial_44
            };
                    String[] str_skillmaterial = {
                fgo.Skill_Material21,fgo.Skill_Material22,fgo.Skill_Material23,fgo.Skill_Material24,
                fgo.Skill_Material31,fgo.Skill_Material32,fgo.Skill_Material33,fgo.Skill_Material34,
                fgo.Skill_Material41,fgo.Skill_Material42,fgo.Skill_Material43,fgo.Skill_Material44,
                fgo.Skill_Material51,fgo.Skill_Material52,fgo.Skill_Material53,fgo.Skill_Material54,
                fgo.Skill_Material61,fgo.Skill_Material62,fgo.Skill_Material63,fgo.Skill_Material64,
                fgo.Skill_Material71,fgo.Skill_Material72,fgo.Skill_Material73,fgo.Skill_Material74,
                fgo.Skill_Material81,fgo.Skill_Material82,fgo.Skill_Material83,fgo.Skill_Material84,
                fgo.Skill_Material91,fgo.Skill_Material92,fgo.Skill_Material93,fgo.Skill_Material94,
                fgo.Skill_Material101,fgo.Skill_Material102,fgo.Skill_Material103,fgo.Skill_Material104,

            };

                    bool bool_find = false;

                    #region Level Material

                    #region text
                    text_levelmaterialQP1.Text = fgo.LevelMaterialQP_1;
                    text_levelmaterialQP2.Text = fgo.LevelMaterialQP_2;
                    text_levelmaterialQP3.Text = fgo.LevelMaterialQP_3;
                    text_levelmaterialQP4.Text = fgo.LevelMaterialQP_4;

                    text_RequireQuantity11.Text = fgo.RequireQuantity11;
                    text_RequireQuantity12.Text = fgo.RequireQuantity12;
                    text_RequireQuantity13.Text = fgo.RequireQuantity13;
                    text_RequireQuantity14.Text = fgo.RequireQuantity14;

                    text_RequireQuantity21.Text = fgo.RequireQuantity21;
                    text_RequireQuantity22.Text = fgo.RequireQuantity22;
                    text_RequireQuantity23.Text = fgo.RequireQuantity23;
                    text_RequireQuantity24.Text = fgo.RequireQuantity24;

                    text_RequireQuantity31.Text = fgo.RequireQuantity31;
                    text_RequireQuantity32.Text = fgo.RequireQuantity32;
                    text_RequireQuantity33.Text = fgo.RequireQuantity33;
                    text_RequireQuantity34.Text = fgo.RequireQuantity34;

                    text_RequireQuantity41.Text = fgo.RequireQuantity41;
                    text_RequireQuantity42.Text = fgo.RequireQuantity42;
                    text_RequireQuantity43.Text = fgo.RequireQuantity43;
                    text_RequireQuantity44.Text = fgo.RequireQuantity44;
                    #endregion

                    for (int i = 0; i < 16; i++)
                    {
                        if (str_levelmaterial[i] != null)
                        {
                            #region Switch
                            switch (i)
                            {
                                case 0:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_11.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    if (!bool_find)
                                    {
                                        for (int j = 0; j < str_EventMaterial.Length; j++)
                                        {
                                            if (fgo.LevelMaterial_11.Equals(str_EventMaterial[j]))
                                            {
                                                pic_levelmaterial_11.Image = img_EventMaterial[j];
                                                pic_levelmaterial_21.Image = img_EventMaterial[j];
                                                pic_levelmaterial_31.Image = img_EventMaterial[j];
                                                pic_levelmaterial_41.Image = img_EventMaterial[j];
                                                bool_find = true;
                                                i = 16;//break loop
                                                break;
                                            }
                                        }
                                    }
                                    #endregion
                                    break;
                                case 1:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_12.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_13.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_14.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 4:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_21.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 5:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_22.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 6:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_23.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 7:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_24.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 8:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_31.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 9:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_32.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 10:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_33.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 11:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_34.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 12:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_41.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 13:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_42.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 14:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_43.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 15:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_44.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Skill Material

                    #region text
                    text_Skill_RequireQuantity21.Text = fgo.Skill_RequireQuantity21;
                    text_Skill_RequireQuantity22.Text = fgo.Skill_RequireQuantity22;
                    text_Skill_RequireQuantity23.Text = fgo.Skill_RequireQuantity23;
                    text_Skill_RequireQuantity24.Text = fgo.Skill_RequireQuantity24;

                    text_Skill_RequireQuantity31.Text = fgo.Skill_RequireQuantity31;
                    text_Skill_RequireQuantity32.Text = fgo.Skill_RequireQuantity32;
                    text_Skill_RequireQuantity33.Text = fgo.Skill_RequireQuantity33;
                    text_Skill_RequireQuantity34.Text = fgo.Skill_RequireQuantity34;

                    text_Skill_RequireQuantity41.Text = fgo.Skill_RequireQuantity41;
                    text_Skill_RequireQuantity42.Text = fgo.Skill_RequireQuantity42;
                    text_Skill_RequireQuantity43.Text = fgo.Skill_RequireQuantity43;
                    text_Skill_RequireQuantity44.Text = fgo.Skill_RequireQuantity44;

                    text_Skill_RequireQuantity51.Text = fgo.Skill_RequireQuantity51;
                    text_Skill_RequireQuantity52.Text = fgo.Skill_RequireQuantity52;
                    text_Skill_RequireQuantity53.Text = fgo.Skill_RequireQuantity53;
                    text_Skill_RequireQuantity54.Text = fgo.Skill_RequireQuantity54;

                    text_Skill_RequireQuantity61.Text = fgo.Skill_RequireQuantity61;
                    text_Skill_RequireQuantity62.Text = fgo.Skill_RequireQuantity62;
                    text_Skill_RequireQuantity63.Text = fgo.Skill_RequireQuantity63;
                    text_Skill_RequireQuantity64.Text = fgo.Skill_RequireQuantity64;

                    text_Skill_RequireQuantity71.Text = fgo.Skill_RequireQuantity71;
                    text_Skill_RequireQuantity72.Text = fgo.Skill_RequireQuantity72;
                    text_Skill_RequireQuantity73.Text = fgo.Skill_RequireQuantity73;
                    text_Skill_RequireQuantity74.Text = fgo.Skill_RequireQuantity74;

                    text_Skill_RequireQuantity81.Text = fgo.Skill_RequireQuantity81;
                    text_Skill_RequireQuantity82.Text = fgo.Skill_RequireQuantity82;
                    text_Skill_RequireQuantity83.Text = fgo.Skill_RequireQuantity83;
                    text_Skill_RequireQuantity84.Text = fgo.Skill_RequireQuantity84;

                    text_Skill_RequireQuantity91.Text = fgo.Skill_RequireQuantity91;
                    text_Skill_RequireQuantity92.Text = fgo.Skill_RequireQuantity92;
                    text_Skill_RequireQuantity93.Text = fgo.Skill_RequireQuantity93;
                    text_Skill_RequireQuantity94.Text = fgo.Skill_RequireQuantity94;

                    text_Skill_RequireQuantity101.Text = fgo.Skill_RequireQuantity101;
                    text_Skill_RequireQuantity102.Text = fgo.Skill_RequireQuantity102;
                    text_Skill_RequireQuantity103.Text = fgo.Skill_RequireQuantity103;
                    text_Skill_RequireQuantity104.Text = fgo.Skill_RequireQuantity104;

                    text_Skill_QP2.Text = fgo.Skill_QP2;
                    text_Skill_QP3.Text = fgo.Skill_QP3;
                    text_Skill_QP4.Text = fgo.Skill_QP4;
                    text_Skill_QP5.Text = fgo.Skill_QP5;
                    text_Skill_QP6.Text = fgo.Skill_QP6;
                    text_Skill_QP7.Text = fgo.Skill_QP7;
                    text_Skill_QP8.Text = fgo.Skill_QP8;
                    text_Skill_QP9.Text = fgo.Skill_QP9;
                    text_Skill_QP10.Text = fgo.Skill_QP10;

                    #endregion

                    #region image
                    for (int i = 0; i < 36; i++)
                    {
                        if (str_skillmaterial[i] != null)
                        {
                            #region Switch
                            switch (i)
                            {
                                case 0:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material21.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 1:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material22.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material23.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material24.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 4:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material31.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 5:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material32.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 6:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material33.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 7:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material34.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 8:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material41.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 9:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material42.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 10:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material43.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 11:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material44.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 12:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material51.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 13:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material52.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 14:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material53.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 15:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material54.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 16:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material61.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 17:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material62.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 18:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material63.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 19:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material64.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 20:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material71.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 21:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material72.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 22:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material73.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 23:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material74.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 24:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material81.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 25:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material82.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 26:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material83.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 27:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material84.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 28:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material91.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 29:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material92.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 30:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material93.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 31:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material94.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 32:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material101.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 33:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material102.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 34:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material103.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 35:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material104.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;

                                default:
                                    break;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #endregion




                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Error:" + ex.ToString(), "Hint");
                }
            }
            */
            
            
        }

        private void textServantNO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && !checkBox_Editmode.Checked)
            {
                try
                {
                    comboBox1.SelectedIndex = Convert.ToInt32(textServantNO.Text) - 1;
                }            
                catch(Exception exc)
                {                    
                    MessageBox.Show("textServantNO_KeyDown Error:\n" + exc.ToString(), "Message", MessageBoxButtons.OK);
                    comboBox1.SelectedIndex = 1;   
                }
            }
            if (e.KeyCode == Keys.Enter && checkBox_Editmode.Checked)
            {
                try
                {
                    comboBox1.SelectedIndex = Convert.ToInt32(textServantNO.Text) - 1;
                }
                catch (Exception exc)
                {
                    //MessageBox.Show("textServantNO_KeyDown Error:\n" + exc.ToString(), "Message", MessageBoxButtons.OK);
                    //comboBox1.SelectedIndex = comboBox1.SelectionLength;
                    if(Convert.ToInt64(textServantNO.Text)-MySetting.Load_ServantNO>0)
                    {
                        comboBox1.Items.Add("NO_" + (Convert.ToInt32(textServantNO.Text) - 1).ToString());
                        comboBox1.SelectedIndex = Convert.ToInt32(textServantNO.Text) - 1;
                        MySetting.Load_ServantNO = (int)Convert.ToInt64(textServantNO.Text);
                        MySetting.Save();
                    }
                    


                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool_switch_textClass = true;
            Form classForm = new ClassForm(this);
            classForm.Show();
            
        }

        private void textClass_int_TextChanged(object sender, EventArgs e)
        {
            if (bool_switch_textClass)
            {
                try
                {
                    picimgclass.Image = imgclass[Convert.ToInt32(textClass_int.Text)-1];
                    textClass_int.Text = textClass_int.Text;
                    textClass_str.Text = str_class[Convert.ToInt32(textClass_int.Text)-1];

                    bool_switch_textClass = false;
                }
                catch (Exception eClasstext)
                {
                    MessageBox.Show("Error:" + eClasstext.ToString(), "Hint", MessageBoxButtons.OK);
                }
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        # region PictureBox Click
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            IDselect = 1;
            Form skill01 = new SkillForm(this);            
            skill01.Show();
            skill01.Tag = this;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            IDselect = 2;
            Form skill02 = new SkillForm(this);            
            skill02.Show();
            skill02.Tag = this;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            IDselect = 3;            
            Form skill03 = new SkillForm(this);
            skill03.Show();
            skill03.Tag = this;

        }


        //--------------Class Skill picturebox-------------------------
        private void picClassSkill01_Click(object sender, EventArgs e)
        {
            IDselect = 4;
            Form _ClassSkill = new SkillForm(this);
            _ClassSkill.Show();
            _ClassSkill.Tag = this;
        }

        private void picClassSkill02_Click(object sender, EventArgs e)
        {
            IDselect = 5;
            Form _ClassSkill = new SkillForm(this);
            _ClassSkill.Show();
            _ClassSkill.Tag = this;
        }

        private void picClassSkill03_Click(object sender, EventArgs e)
        {
            IDselect = 6;
            Form _ClassSkill = new SkillForm(this);
            _ClassSkill.Show();
            _ClassSkill.Tag = this;
        }

        private void picClassSkill04_Click(object sender, EventArgs e)
        {
            IDselect = 7;
            Form _ClassSkill = new SkillForm(this);
            _ClassSkill.Show();
            _ClassSkill.Tag = this;
        }
        //--------------------------------------------------------------

        private void pic_Commandcard01_Click(object sender, EventArgs e)
        {
            IDselect = 8;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        private void pic_Commandcard02_Click(object sender, EventArgs e)
        {
            IDselect = 9;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        private void pic_Commandcard03_Click(object sender, EventArgs e)
        {
            IDselect = 10;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        private void pic_Commandcard04_Click(object sender, EventArgs e)
        {
            IDselect = 11;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        private void pic_Commandcard05_Click(object sender, EventArgs e)
        {
            IDselect = 12;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        #region material

        private void pic_levelmaterial_11_Click(object sender, EventArgs e)
        {
            IDselect = 14;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_12_Click(object sender, EventArgs e)
        {
            IDselect = 15;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_13_Click(object sender, EventArgs e)
        {
            IDselect = 16;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_14_Click(object sender, EventArgs e)
        {
            IDselect = 17;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_21_Click(object sender, EventArgs e)
        {
            IDselect = 18;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_22_Click(object sender, EventArgs e)
        {
            IDselect = 19;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_23_Click(object sender, EventArgs e)
        {
            IDselect = 20;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_24_Click(object sender, EventArgs e)
        {
            IDselect = 21;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_31_Click(object sender, EventArgs e)
        {
            IDselect = 22;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_32_Click(object sender, EventArgs e)
        {
            IDselect = 23;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_33_Click(object sender, EventArgs e)
        {
            IDselect = 24;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_34_Click(object sender, EventArgs e)
        {
            IDselect = 25;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_41_Click(object sender, EventArgs e)
        {
            IDselect = 26;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_42_Click(object sender, EventArgs e)
        {
            IDselect = 27;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_43_Click(object sender, EventArgs e)
        {
            IDselect = 28;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_levelmaterial_44_Click(object sender, EventArgs e)
        {
            IDselect = 29;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }
        

        private void pic_Skill_Material21_Click(object sender, EventArgs e)
        {
            IDselect = 30;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material22_Click(object sender, EventArgs e)
        {
            IDselect = 31;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material23_Click(object sender, EventArgs e)
        {
            IDselect = 32;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material24_Click(object sender, EventArgs e)
        {
            IDselect = 33;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material31_Click(object sender, EventArgs e)
        {
            IDselect = 34;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material32_Click(object sender, EventArgs e)
        {
            IDselect = 35;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material33_Click(object sender, EventArgs e)
        {
            IDselect = 36;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material34_Click(object sender, EventArgs e)
        {
            IDselect = 37;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material41_Click(object sender, EventArgs e)
        {
            IDselect = 38;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material42_Click(object sender, EventArgs e)
        {
            IDselect = 39;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material43_Click(object sender, EventArgs e)
        {
            IDselect = 40;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material44_Click(object sender, EventArgs e)
        {
            IDselect = 41;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material51_Click(object sender, EventArgs e)
        {
            IDselect = 42;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material52_Click(object sender, EventArgs e)
        {
            IDselect = 43;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material53_Click(object sender, EventArgs e)
        {
            IDselect = 44;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material54_Click(object sender, EventArgs e)
        {
            IDselect = 45;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material61_Click(object sender, EventArgs e)
        {
            IDselect = 46;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material62_Click(object sender, EventArgs e)
        {
            IDselect = 47;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material63_Click(object sender, EventArgs e)
        {
            IDselect = 48;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material64_Click(object sender, EventArgs e)
        {
            IDselect = 49;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material71_Click(object sender, EventArgs e)
        {
            IDselect = 50;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material72_Click(object sender, EventArgs e)
        {
            IDselect = 51;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material73_Click(object sender, EventArgs e)
        {
            IDselect =52;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material74_Click(object sender, EventArgs e)
        {
            IDselect = 53;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material81_Click(object sender, EventArgs e)
        {
            IDselect = 54;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material82_Click(object sender, EventArgs e)
        {
            IDselect = 55;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material83_Click(object sender, EventArgs e)
        {
            IDselect = 56;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material84_Click(object sender, EventArgs e)
        {
            IDselect = 57;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material91_Click(object sender, EventArgs e)
        {
            IDselect = 58;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material92_Click(object sender, EventArgs e)
        {
            IDselect = 59;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material93_Click(object sender, EventArgs e)
        {
            IDselect = 60;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material94_Click(object sender, EventArgs e)
        {
            IDselect = 61;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material101_Click(object sender, EventArgs e)
        {
            IDselect = 62;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material102_Click(object sender, EventArgs e)
        {
            IDselect = 63;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material103_Click(object sender, EventArgs e)
        {
            IDselect = 64;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }

        private void pic_Skill_Material104_Click(object sender, EventArgs e)
        {
            IDselect = 65;
            Form material = new MaterialForm(this);
            material.Show();
            material.Tag = this;
        }
        #endregion
        private void pic_NPCard01_Click(object sender, EventArgs e)
        {
            IDselect = 66;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }

        private void pic_NPCard02_Click(object sender, EventArgs e)
        {
            IDselect = 67;
            Form Ccard = new FormCommandCard(this);
            Ccard.Show();
            Ccard.Tag = this;
        }



        #endregion

        private void combo_WeekQuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool getdata = false;
            FirebaseDB firebaseDB = new FirebaseDB("https://csharp-9f233.firebaseio.com/QuestWeek");
            FirebaseDB firebaseDBTeams = firebaseDB.Node(combo_WeekQuest.Text);
            //GET Request
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            //FGOHelper.FGOHelperS fgo = new FGOHelper.FGOHelperS();
            FGOWeekQuest quest = new FGOWeekQuest();
            try
            {                
                quest = JsonConvert.DeserializeObject<FGOWeekQuest>(getResponse.JSONContent.ToString());
                getdata = true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Error---Quest :" + er.ToString(), "Hint", MessageBoxButtons.OK);                
            }

            if(getdata)
            {
                textQuest1.Text = quest.NO_1;
                textQuest2.Text = quest.NO_2;
                textQuest3.Text = quest.NO_3;
                textQuest4.Text = quest.NO_4;
                textQuest5.Text = quest.NO_5;
                textQuest6.Text = quest.NO_6;
                textQuest7.Text = quest.NO_7;
            }
        }

        private void button_Update_Quest_Click(object sender, EventArgs e)
        {

            

            if (combo_WeekQuest.SelectedIndex != -1)
            {
                /*
                FirebaseResponse patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_1\":\"" + textQuest1.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_2\":\"" + textQuest2.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_3\":\"" + textQuest3.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_4\":\"" + textQuest4.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_5\":\"" + textQuest5.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_6\":\"" + textQuest6.Text + "\"}");
                patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_7\":\"" + textQuest7.Text + "\"}");
                MessageBox.Show(patchResponse.Success.ToString(), "Hint", MessageBoxButtons.OK);
                */
                FirebaseResponse patchResponse = FirebaseQuest.Node(combo_WeekQuest.Text).Patch("{\"NO_1\":\"" + textQuest1.Text + "\"" +
                    ","+ "\"NO_2\":\"" + textQuest2.Text+"\","+
                    "\"NO_3\":\"" + textQuest3.Text+"\","+
                    "\"NO_4\":\"" + textQuest4.Text + "\","+
                    "\"NO_5\":\"" + textQuest5.Text + "\","+
                    "\"NO_6\":\"" + textQuest6.Text + "\","+
                    "\"NO_7\":\"" + textQuest7.Text + "\""
                    + "}");

            }                     
        }

        private void updateDataToolStripMenuItem_Click(object sender, EventArgs e)// \" =  "
        {
            Thread T_update = new Thread(Update_function);
            T_update.Start();
            /*
            FirebaseDB Firebase_ServantDelete = new FirebaseDB("https://fgohelper.firebaseio.com/Servant/"+comboBox1.Text);
            Firebase_ServantDelete.Delete();
            
           
            DialogResult result =
                MessageBox.Show("Will you upadte servant series is \n NO."+textServantNO.Text+" ?", "Message", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                #region Data Processing

                #region text Processing

                if (textClass_int.Equals(null)||textClass_int.Equals(""))
                {
                    textClass_int.Text = "999999";
                }
                else if(textCost.Text.Equals(null)|| textCost.Text.Equals(""))
                {
                    textCost.Text = "999999";
                }
                else if(textMaxLv.Text.Equals(null)|| textMaxLv.Text.Equals(""))
                {
                    textMaxLv.Text = "999999";
                }
                else if(textRarity.Text.Equals(null)|| textRarity.Text.Equals(""))
                {
                    textRarity.Text = "999999";
                }

                else if (textATK01.Text.Equals(null) || textATK01.Text.Equals(""))
                {
                    textATK01.Text = "999999";
                }
                else if (textHP01.Text.Equals(null) || textHP01.Text.Equals(""))
                {
                    textHP01.Text = "999999";
                }
                else if (textATKMax.Text.Equals(null) || textATKMax.Text.Equals(""))
                {
                    textATKMax.Text = "999999";
                }
                else if (textHPMax.Text.Equals(null) || textHPMax.Text.Equals(""))
                {
                    textHPMax.Text = "999999";
                }
                else if (textATK100.Text.Equals(null) || textATK100.Text.Equals(""))
                {
                    textATK100.Text = "999999";
                }
                else if (textHP100.Text.Equals(null) || textHP100.Text.Equals(""))
                {
                    textHP100.Text = "999999";
                }
                #endregion

                #region picturebox image processing
                   
                    #region Skill Image
                    int[] _imgSKill = new int[3];
                    for(int i=0;i<icon_skill.Length;i++)
                    {
                        if(pic_Skill01.Image!=null)
                        {
                            if(pic_Skill01.Image==icon_skill[i])
                            {
                                _imgSKill[0] = i+1;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < icon_skill.Length; i++)
                    {
                        if (pic_Skill02.Image != null)
                        {
                            if (pic_Skill02.Image == icon_skill[i])
                            {
                                _imgSKill[1] = i+1;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < icon_skill.Length; i++)
                    {
                        if (pic_Skill03.Image != null)
                        {
                            if (pic_Skill03.Image == icon_skill[i])
                            {
                                _imgSKill[2] = i+1;
                                break;
                            }
                        }
                    }
                #endregion

                    #region ClassSkill Image
                int[] _img_ClassSkill = new int[4];

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill01.Image != null)
                    {
                        if (pic_ClassSkill01.Image == icon_skill[i])
                        {
                            _img_ClassSkill[0] = i + 1;
                            break;
                        }
                    }else
                    {
                        _img_ClassSkill[0] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill02.Image != null)
                    {
                        if (pic_ClassSkill02.Image == icon_skill[i])
                        {
                            _img_ClassSkill[1] = i + 1;
                            break;
                        }
                    }else
                    {
                        _img_ClassSkill[1] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill03.Image != null)
                    {
                        if (pic_ClassSkill03.Image == icon_skill[i])
                        {
                            _img_ClassSkill[2] = i + 1;
                            break;
                        }
                    }else
                    {
                        _img_ClassSkill[2] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill04.Image != null)
                    {
                        if (pic_ClassSkill04.Image == icon_skill[i])
                        {
                            _img_ClassSkill[3] = i + 1;
                            break;
                        }
                    }
                    else
                    {
                        _img_ClassSkill[3] = 999999;
                    }
                }
                #endregion

                    #region CommandCard Image
                int Buster =0,Arts = 0,Quick = 0;
                Bitmap a = (Bitmap)pic_Commandcard01.Image;
                Bitmap[] _ActionCard = {
                    a,(Bitmap)pic_Commandcard02.Image,(Bitmap)pic_Commandcard03.Image,(Bitmap)pic_Commandcard04.Image,(Bitmap)pic_Commandcard05.Image
                };                                              

                for (int i = 0; i <= 5; i++)
                {
                    for(int j=0;j<_Card.Length;j++)
                    {
                        switch(i)
                        {
                            case 0:
                                if(_ActionCard[i]==_Card[j])
                                {
                                    switch(j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 1:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 4:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
                #endregion

                    #region NP Card
                int [] _NPcard =new int [2];

                for(int i=0;i<_Card.Length;i++)
                {
                    if(pic_NPCard01.Image==_Card[i])
                    {
                        _NPcard[0] = i;
                        break;
                    }
                }

                for (int i = 0; i < _Card.Length; i++)
                {
                    if (pic_NPCard02.Image == _Card[i])
                    {
                        _NPcard[1] = i;
                        break;
                    }
                }
                #endregion

                #region Material Image
                
                #region Bitmap Array
                Bitmap[] bitmap_material = {
                    (Bitmap)pic_levelmaterial_11.Image,(Bitmap)pic_levelmaterial_12.Image,(Bitmap)pic_levelmaterial_13.Image,(Bitmap)pic_levelmaterial_14.Image,
                    (Bitmap)pic_levelmaterial_21.Image,(Bitmap)pic_levelmaterial_22.Image,(Bitmap)pic_levelmaterial_23.Image,(Bitmap)pic_levelmaterial_24.Image,
                    (Bitmap)pic_levelmaterial_31.Image,(Bitmap)pic_levelmaterial_32.Image,(Bitmap)pic_levelmaterial_33.Image,(Bitmap)pic_levelmaterial_34.Image,
                    (Bitmap)pic_levelmaterial_41.Image,(Bitmap)pic_levelmaterial_42.Image,(Bitmap)pic_levelmaterial_43.Image,(Bitmap)pic_levelmaterial_44.Image,
                    (Bitmap)pic_Skill_Material21.Image,(Bitmap)pic_Skill_Material22.Image,(Bitmap)pic_Skill_Material23.Image,(Bitmap)pic_Skill_Material24.Image,
                    (Bitmap)pic_Skill_Material31.Image,(Bitmap)pic_Skill_Material32.Image,(Bitmap)pic_Skill_Material33.Image,(Bitmap)pic_Skill_Material34.Image,
                    (Bitmap)pic_Skill_Material41.Image,(Bitmap)pic_Skill_Material42.Image,(Bitmap)pic_Skill_Material43.Image,(Bitmap)pic_Skill_Material44.Image,
                    (Bitmap)pic_Skill_Material51.Image,(Bitmap)pic_Skill_Material52.Image,(Bitmap)pic_Skill_Material53.Image,(Bitmap)pic_Skill_Material54.Image,
                    (Bitmap)pic_Skill_Material61.Image,(Bitmap)pic_Skill_Material62.Image,(Bitmap)pic_Skill_Material63.Image,(Bitmap)pic_Skill_Material64.Image,
                    (Bitmap)pic_Skill_Material71.Image,(Bitmap)pic_Skill_Material72.Image,(Bitmap)pic_Skill_Material73.Image,(Bitmap)pic_Skill_Material74.Image,
                    (Bitmap)pic_Skill_Material81.Image,(Bitmap)pic_Skill_Material82.Image,(Bitmap)pic_Skill_Material83.Image,(Bitmap)pic_Skill_Material84.Image,
                    (Bitmap)pic_Skill_Material91.Image,(Bitmap)pic_Skill_Material92.Image,(Bitmap)pic_Skill_Material93.Image,(Bitmap)pic_Skill_Material94.Image,
                    (Bitmap)pic_Skill_Material101.Image,(Bitmap)pic_Skill_Material102.Image,(Bitmap)pic_Skill_Material103.Image,(Bitmap)pic_Skill_Material104.Image
                };
                String[] _str_material = new String[52];

                String[] str_Firebase_material =
                {
                    "levelMaterial_11","levelMaterial_12","levelMaterial_13","levelMaterial_14",
                    "levelMaterial_21","levelMaterial_22","levelMaterial_23","levelMaterial_24",
                    "levelMaterial_31","levelMaterial_32","levelMaterial_33","levelMaterial_34",
                    "levelMaterial_41","levelMaterial_42","levelMaterial_43","levelMaterial_44",
                    "skill_Material21","skill_Material22","skill_Material23","skill_Material24",
                    "skill_Material31","skill_Material32","skill_Material33","skill_Material34",
                    "skill_Material41","skill_Material42","skill_Material43","skill_Material44",
                    "skill_Material51","skill_Material52","skill_Material53","skill_Material54",
                    "skill_Material61","skill_Material62","skill_Material63","skill_Material64",
                    "skill_Material71","skill_Material72","skill_Material73","skill_Material74",
                    "skill_Material81","skill_Material82","skill_Material83","skill_Material84",
                    "skill_Material91","skill_Material92","skill_Material93","skill_Material94",
                    "skill_Material101","skill_Material102","skill_Material103","skill_Material104",
                };

                String[] _str_Firebase_Quantity = {
                    "requireQuantity11","requireQuantity12","requireQuantity13","requireQuantity14",
                    "requireQuantity21","requireQuantity22","requireQuantity23","requireQuantity24",
                    "requireQuantity31","requireQuantity32","requireQuantity33","requireQuantity34",
                    "requireQuantity41","requireQuantity42","requireQuantity43","requireQuantity44",
                    "skill_RequireQuantity21","skill_RequireQuantity22","skill_RequireQuantity23","skill_RequireQuantity24",
                    "skill_RequireQuantity31","skill_RequireQuantity32","skill_RequireQuantity33","skill_RequireQuantity34",
                    "skill_RequireQuantity41","skill_RequireQuantity42","skill_RequireQuantity43","skill_RequireQuantity44",
                    "skill_RequireQuantity51","skill_RequireQuantity52","skill_RequireQuantity53","skill_RequireQuantity54",
                    "skill_RequireQuantity61","skill_RequireQuantity62","skill_RequireQuantity63","skill_RequireQuantity64",
                    "skill_RequireQuantity71","skill_RequireQuantity72","skill_RequireQuantity73","skill_RequireQuantity74",
                    "skill_RequireQuantity81","skill_RequireQuantity82","skill_RequireQuantity83","skill_RequireQuantity84",
                    "skill_RequireQuantity91","skill_RequireQuantity92","skill_RequireQuantity93","skill_RequireQuantity94",
                    "skill_RequireQuantity101","skill_RequireQuantity102","skill_RequireQuantity103","skill_RequireQuantity104",
                };
                String[] _textQuantity =
                {
                    text_RequireQuantity11.Text,text_RequireQuantity12.Text,text_RequireQuantity13.Text,text_RequireQuantity14.Text,
                    text_RequireQuantity21.Text,text_RequireQuantity22.Text,text_RequireQuantity23.Text,text_RequireQuantity24.Text,
                    text_RequireQuantity31.Text,text_RequireQuantity32.Text,text_RequireQuantity33.Text,text_RequireQuantity34.Text,
                    text_RequireQuantity41.Text,text_RequireQuantity42.Text,text_RequireQuantity43.Text,text_RequireQuantity44.Text,
                    text_Skill_RequireQuantity21.Text,text_Skill_RequireQuantity22.Text,text_Skill_RequireQuantity23.Text,text_Skill_RequireQuantity24.Text,
                    text_Skill_RequireQuantity31.Text,text_Skill_RequireQuantity32.Text,text_Skill_RequireQuantity33.Text,text_Skill_RequireQuantity34.Text,                                       
                    text_Skill_RequireQuantity41.Text,text_Skill_RequireQuantity42.Text,text_Skill_RequireQuantity43.Text,text_Skill_RequireQuantity44.Text,
                    text_Skill_RequireQuantity51.Text,text_Skill_RequireQuantity52.Text,text_Skill_RequireQuantity53.Text,text_Skill_RequireQuantity54.Text,
                    text_Skill_RequireQuantity61.Text,text_Skill_RequireQuantity62.Text,text_Skill_RequireQuantity63.Text,text_Skill_RequireQuantity64.Text,
                    text_Skill_RequireQuantity71.Text,text_Skill_RequireQuantity72.Text,text_Skill_RequireQuantity73.Text,text_Skill_RequireQuantity74.Text,
                    text_Skill_RequireQuantity81.Text,text_Skill_RequireQuantity82.Text,text_Skill_RequireQuantity83.Text,text_Skill_RequireQuantity84.Text,
                    text_Skill_RequireQuantity91.Text,text_Skill_RequireQuantity92.Text,text_Skill_RequireQuantity93.Text,text_Skill_RequireQuantity94.Text,
                    text_Skill_RequireQuantity101.Text,text_Skill_RequireQuantity102.Text,text_Skill_RequireQuantity103.Text,text_Skill_RequireQuantity104.Text
                };
                for(int k=0;k< _textQuantity.Length;k++)
                {
                    if(_textQuantity[k].Equals("")|| _textQuantity[k].Equals(null))
                    {
                        _textQuantity[k] = null;
                    }
                }
                #endregion

                for (int i = 0; i < 52; i++)
                {
                    for (int j = 0; j < img_Material.Length; j++)
                    {
                        if (bitmap_material[i] != null)
                        {
                            if (bitmap_material[i] == img_Material[j])
                            {
                                _str_material[i] = str_Material[j];
                                break;
                            }
                        }
                        else
                        {
                            _str_material[i] = null;
                        }
                    }
                }


                #endregion

                #endregion

                #endregion

                #region Updata 
                #region Progress Bar
                progressBar1.Maximum = 173;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                #endregion
                #region Status
                FirebaseResponse patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                    "\""+"nameCH"+"\":\"" + ServantNameChinese .Text+ "\""+","+
                    "\"" + "nameEN" + "\":\"" + ServantNameEN.Text + "\"" + "," +
                    "\"" + "nameJP" + "\":\"" + ServantNameJP.Text + "\"" + "," +
                    "\"" + "nameChina" + "\":\"" + ServantNameChina.Text+ "\"" + "," +
                    "\"" + "rarity" + "\":" + textRarity.Text + "" + "," +
                    "\"" + "cost" + "\":" + textCost.Text + "" + "," +
                    "\"" + "max_LV" + "\":" + textMaxLv.Text + "" + "," +
                    "\"" + "servantClass" + "\":" + textClass_int.Text + "" + "," +                    
                    "\"" + "statusATKLV1" + "\":" + textATK01.Text + "" + "," +
                    "\"" + "status_HPLV1" + "\":" + textHP01.Text + "" + "," +
                    "\"" + "statusATKFinal" + "\":" + textATKMax.Text + "" + "," +
                    "\"" + "status_HPFinal" + "\":" + textHPMax.Text + "" + "," +
                    "\"" + "statusATKLV100" + "\":" + textATK100.Text + "" + "," +
                    "\"" + "status_HPLV100" + "\":" + textHP100.Text + "" + "," +
                    "\"" + "skill_Describe1" + "\":\"" + text_Skill_Describe1.Text + "\"" + "," +
                    "\"" + "skill_Describe2" + "\":\"" + text_Skill_Describe2.Text + "\"" + "," +
                    "\"" + "skill_Describe3" + "\":\"" + text_Skill_Describe3.Text + "\"" + "," +
                    "\"" + "skill_Describe4" + "\":\"" + text_Skill_Describe4.Text + "\"" + "," +
                    "\"" + "skill_Describe5" + "\":\"" + text_Skill_Describe5.Text + "\"" + "," +
                    "\"" + "skill_Describe6" + "\":\"" + text_Skill_Describe6.Text + "\"" + "," +                    
                    "\"" + "img_Skill01" + "\":" + _imgSKill[0].ToString() + "" + "," +
                    "\"" + "img_Skill02" + "\":" + _imgSKill[1].ToString() + "" + "," +
                    "\"" + "img_Skill03" + "\":" + _imgSKill[2].ToString() + "" + "," +
                    "\"" + "skill_1_Effect1" + "\":\"" + textSkillEffect11.Text + "\"" + "," +
                    "\"" + "skill_1_Effect2" + "\":\"" + textSkillEffect12.Text + "\"" + "," +
                    "\"" + "skill_1_Effect3" + "\":\"" + textSkillEffect13.Text + "\"" + "," +
                    "\"" + "skill_1_Effect4" + "\":\"" + textSkillEffect14.Text + "\"" + "," +
                    "\"" + "skill_1_Effect5" + "\":\"" + textSkillEffect15.Text + "\"" + "," +
                    "\"" + "skill_1_Effect6" + "\":\"" + textSkillEffect16.Text + "\"" + "," +
                    "\"" + "skill_1_Effect7" + "\":\"" + textSkillEffect17.Text + "\"" + "," +
                    "\"" + "skill_1_Effect8" + "\":\"" + textSkillEffect18.Text + "\"" + "," +
                    "\"" + "skill_1_Effect9" + "\":\"" + textSkillEffect19.Text + "\"" + "," +
                    "\"" + "skill_1_Effect10" + "\":\"" + textSkillEffect110.Text + "\"" + "," +
                    "\"" + "skill_2_Effect1" + "\":\"" + textSkillEffect21.Text + "\"" + "," +
                    "\"" + "skill_2_Effect2" + "\":\"" + textSkillEffect22.Text + "\"" + "," +
                    "\"" + "skill_2_Effect3" + "\":\"" + textSkillEffect23.Text + "\"" + "," +
                    "\"" + "skill_2_Effect4" + "\":\"" + textSkillEffect24.Text + "\"" + "," +
                    "\"" + "skill_2_Effect5" + "\":\"" + textSkillEffect25.Text + "\"" + "," +
                    "\"" + "skill_2_Effect6" + "\":\"" + textSkillEffect26.Text + "\"" + "," +
                    "\"" + "skill_2_Effect7" + "\":\"" + textSkillEffect27.Text + "\"" + "," +
                    "\"" + "skill_2_Effect8" + "\":\"" + textSkillEffect28.Text + "\"" + "," +
                    "\"" + "skill_2_Effect9" + "\":\"" + textSkillEffect29.Text + "\"" + "," +
                    "\"" + "skill_2_Effect10" + "\":\"" + textSkillEffect210.Text + "\"" + "," +
                    "\"" + "skill_3_Effect1" + "\":\"" + textSkillEffect31.Text + "\"" + "," +
                    "\"" + "skill_3_Effect2" + "\":\"" + textSkillEffect32.Text + "\"" + "," +
                    "\"" + "skill_3_Effect3" + "\":\"" + textSkillEffect33.Text + "\"" + "," +
                    "\"" + "skill_3_Effect4" + "\":\"" + textSkillEffect34.Text + "\"" + "," +
                    "\"" + "skill_3_Effect5" + "\":\"" + textSkillEffect35.Text + "\"" + "," +
                    "\"" + "skill_3_Effect6" + "\":\"" + textSkillEffect36.Text + "\"" + "," +
                    "\"" + "skill_3_Effect7" + "\":\"" + textSkillEffect37.Text + "\"" + "," +
                    "\"" + "skill_3_Effect8" + "\":\"" + textSkillEffect38.Text + "\"" + "," +
                    "\"" + "skill_3_Effect9" + "\":\"" + textSkillEffect39.Text + "\"" + "," +
                    "\"" + "skill_3_Effect10" + "\":\"" + textSkillEffect310.Text + "\"" + "," +                                        
                    "\"" + "command_Buster" + "\":" + Buster.ToString() + "" + "," +
                    "\"" + "command_Arts" + "\":" + Arts.ToString() + "" + "," +
                    "\"" + "command_Quick" + "\":" + Quick.ToString() + "" + "," +                    
                    "\"" + "np_CardColor" + "\":" + _NPcard[0].ToString() + "" + "," +                    
                    "\"" + "np_Name1" + "\":\"" + textNPname1.Text + "\"" + "," +                    
                    "\"" + "np_Describe" + "\":\"" + textNPdescribe.Text + "\"" + "," +
                    "\"" + "np_Describe_Rank1" + "\":\"" + textNPrank1.Text + "\"" + "," +
                    "\"" + "np_Describe_Target" + "\":\"" + textNPtarget.Text + "\"" + "," +                                   
                    "\"" + "skill_QP2" + "\":\"" + text_Skill_QP2.Text + "\"" + "," +
                    "\"" + "skill_QP3" + "\":\"" + text_Skill_QP3.Text + "\"" + "," +
                    "\"" + "skill_QP4" + "\":\"" + text_Skill_QP4.Text + "\"" + "," +
                    "\"" + "skill_QP5" + "\":\"" + text_Skill_QP5.Text + "\"" + "," +
                    "\"" + "skill_QP6" + "\":\"" + text_Skill_QP6.Text + "\"" + "," +
                    "\"" + "skill_QP7" + "\":\"" + text_Skill_QP7.Text + "\"" + "," +
                    "\"" + "skill_QP8" + "\":\"" + text_Skill_QP8.Text + "\"" + "," +
                    "\"" + "skill_QP9" + "\":\"" + text_Skill_QP9.Text + "\"" + "," +
                    "\"" + "skill_QP10" + "\":\"" + text_Skill_QP10.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_1" + "\":\"" + text_levelmaterialQP1.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_2" + "\":\"" + text_levelmaterialQP2.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_3" + "\":\"" + text_levelmaterialQP3.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_4" + "\":\"" + text_levelmaterialQP4.Text + "\""                   
                    + "}");
                progressBar1.Value = 50;
                #endregion
                #region NP
                String [,] _strfibase =
                {
                    {"np_Rank2",textNPrank2.Text },
                    { "np_1_Effect1",textNP_Effect11.Text},
                    { "np_1_Effect2",textNP_Effect12.Text},
                    { "np_1_Effect3",textNP_Effect13.Text},
                    { "np_1_Effect4",textNP_Effect14.Text},
                    { "np_1_Effect5",textNP_Effect15.Text},
                    { "np_2_Effect1",textNP_Effect21.Text },
                    { "np_2_Effect2",textNP_Effect22.Text },
                    { "np_2_Effect3",textNP_Effect23.Text },
                    { "np_2_Effect4",textNP_Effect24.Text },
                    { "np_2_Effect5",textNP_Effect25.Text },
                };
                for(int i=0;i<11;i++)
                {
                    if(_strfibase[i,1]!=null && _strfibase[i,1]!="")
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + _strfibase[i, 0] + "\":\"" + _strfibase[i, 1] + "\""
                        + "}");
                    }
                    progressBar1.Value++;
                }

                String[,] _firbaseclassskill = {
                    {"class_Describe1" ,textClassSkillDescribe01.Text},
                    {"class_Describe2" ,textClassSkillDescribe02.Text},
                    {"class_Describe3" ,textClassSkillDescribe03.Text},
                    {"class_Describe4" ,textClassSkillDescribe04.Text},
                    { "img_ClassSkill01", _img_ClassSkill[0].ToString()},
                    { "img_ClassSkill02", _img_ClassSkill[1].ToString()},
                    { "img_ClassSkill03", _img_ClassSkill[2].ToString()},
                    { "img_ClassSkill04", _img_ClassSkill[3].ToString()},
                };
                for(int i=0;i<8;i++)
                {
                    if (_firbaseclassskill[i, 1] != null && _firbaseclassskill[i, 1] != "" && i<4)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + _firbaseclassskill[i,0] + "\":\"" + _firbaseclassskill[i, 1] + "\""
                        + "}");
                    }

                    if (_firbaseclassskill[i, 1] != "999999" && _firbaseclassskill[i, 1] != ""&& _firbaseclassskill[i, 1] != null && i>=4)
                        {
                            patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                            "\"" + _firbaseclassskill[i, 0] + "\":" + _firbaseclassskill[i, 1] + ""
                            + "}");
                        }
                    else
                    {
                        if (i>=4)
                        { patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                            "\"" + _firbaseclassskill[i, 0] + "\":" +"999999" + ""
                            + "}");
                        }
                    }
                    progressBar1.Value++;
                }
                    
                
                #endregion

                #region Material
                for (int i = 0; i < 52; i++)
                {
                    if (_str_material[i]!="" && _str_material[i]!=null)
                    { 
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + str_Firebase_material[i] + "\":\"" + _str_material[i] + "\"" 
                        + "}");
                    }
                    progressBar1.Value++;
                }
                

                for(int i=0;i<52;i++)
                {
                    if (_textQuantity[i]!="" && _textQuantity[i]!=null)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                       "\"" + _str_Firebase_Quantity[i] + "\":\"" + _textQuantity[i] + "\"" + "}");
                    }
                    progressBar1.Value++;
                }
                
                MessageBox.Show("Update Sucessfuly", "Message", MessageBoxButtons.OK);
                progressBar1.Value = 0;


                #endregion
                #endregion
            }
            */
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Do you want to clean all text & picture ? ", "Message",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                CleanAllData();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void reloadSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result= 
                MessageBox.Show("It will Restart Application.Are you sure to Do it?","Message",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                MySetting.Load_ServantNO = -1;
                MySetting.Save();
                Application.Restart();
            }            
        }
        private void CleanAllData()
        {
            ServantNameChinese.Text = null;
            ServantNameEN.Text = null;
            ServantNameJP.Text = null;
            ServantNameChina.Text = null;
            textRarity.Text = null;
            textCost.Text = null;
            textMaxLv.Text = null;
            textClass_int.Text = null;
            textClass_str.Text = null;
            textATK01.Text = null;
            textATKMax.Text = null;
            textATK100.Text = null;
            textHP01.Text = null;
            textHPMax.Text = null;
            textHP100.Text = null;
            textClassSkillDescribe01.Text = null;
            textClassSkillDescribe02.Text = null;
            textClassSkillDescribe03.Text = null;
            textClassSkillDescribe04.Text = null;
            text_Skill_Describe1.Text = null;
            text_Skill_Describe2.Text = null;
            text_Skill_Describe3.Text = null;
            text_Skill_Describe4.Text = null;
            text_Skill_Describe5.Text = null;
            text_Skill_Describe6.Text = null;
            textSkillEffect11.Text = null;
            textSkillEffect12.Text = null;
            textSkillEffect13.Text = null;
            textSkillEffect14.Text = null;
            textSkillEffect15.Text = null;
            textSkillEffect16.Text = null;
            textSkillEffect17.Text = null;
            textSkillEffect18.Text = null;
            textSkillEffect19.Text = null;
            textSkillEffect110.Text = null;
            textSkillEffect21.Text = null;
            textSkillEffect22.Text = null;
            textSkillEffect23.Text = null;
            textSkillEffect24.Text = null;
            textSkillEffect25.Text = null;
            textSkillEffect26.Text = null;
            textSkillEffect27.Text = null;
            textSkillEffect28.Text = null;
            textSkillEffect29.Text = null;
            textSkillEffect210.Text = null;
            textSkillEffect31.Text = null;
            textSkillEffect32.Text = null;
            textSkillEffect33.Text = null;
            textSkillEffect34.Text = null;
            textSkillEffect35.Text = null;
            textSkillEffect36.Text = null;
            textSkillEffect37.Text = null;
            textSkillEffect38.Text = null;
            textSkillEffect39.Text = null;
            textSkillEffect310.Text = null;
            pic_Skill01.Image = null;
            pic_Skill02.Image = null;
            pic_Skill03.Image = null;
            pic_ClassSkill01.Image = null;
            pic_ClassSkill02.Image = null;
            pic_ClassSkill03.Image = null;
            pic_ClassSkill04.Image = null;
            pic_Commandcard01.Image = null;
            pic_Commandcard02.Image = null;
            pic_Commandcard03.Image = null;
            pic_Commandcard04.Image = null;
            pic_Commandcard05.Image = null;
            pic_NPCard01.Image = null;
            pic_NPCard02.Image = null;
            textNPdescribe.Text = null;
            textNPname1.Text = null;
            textNPname2.Text = null;
            textNPrank1.Text = null;
            textNPrank2.Text = null;
            textNPtarget.Text = null;
            textNP_Effect11.Text = null;
            textNP_Effect12.Text = null;
            textNP_Effect13.Text = null;
            textNP_Effect14.Text = null;
            textNP_Effect15.Text = null;
            textNP_Effect21.Text = null;
            textNP_Effect22.Text = null;
            textNP_Effect23.Text = null;
            textNP_Effect24.Text = null;
            textNP_Effect25.Text = null;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Update_function()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            


            DialogResult result =
                MessageBox.Show("Will you upadte servant series is \n NO." + textServantNO.Text + " ?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                #region Firbase Delete 
                FirebaseDB Firebase_ServantDelete = new FirebaseDB("https://fgohelper.firebaseio.com/Servant/" + comboBox1.Text);
                Firebase_ServantDelete.Delete();
                #endregion

                #region Data Processing

                #region text Processing

                if (textClass_int.Equals(null) || textClass_int.Equals(""))
                {
                    textClass_int.Text = "999999";
                }
                else if (textCost.Text.Equals(null) || textCost.Text.Equals(""))
                {
                    textCost.Text = "999999";
                }
                else if (textMaxLv.Text.Equals(null) || textMaxLv.Text.Equals(""))
                {
                    textMaxLv.Text = "999999";
                }
                else if (textRarity.Text.Equals(null) || textRarity.Text.Equals(""))
                {
                    textRarity.Text = "999999";
                }

                else if (textATK01.Text.Equals(null) || textATK01.Text.Equals(""))
                {
                    textATK01.Text = "999999";
                }
                else if (textHP01.Text.Equals(null) || textHP01.Text.Equals(""))
                {
                    textHP01.Text = "999999";
                }
                else if (textATKMax.Text.Equals(null) || textATKMax.Text.Equals(""))
                {
                    textATKMax.Text = "999999";
                }
                else if (textHPMax.Text.Equals(null) || textHPMax.Text.Equals(""))
                {
                    textHPMax.Text = "999999";
                }
                else if (textATK100.Text.Equals(null) || textATK100.Text.Equals(""))
                {
                    textATK100.Text = "999999";
                }
                else if (textHP100.Text.Equals(null) || textHP100.Text.Equals(""))
                {
                    textHP100.Text = "999999";
                }
                #endregion

                #region picturebox image processing

                #region Skill Image
                int[] _imgSKill = new int[3];
                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_Skill01.Image != null)
                    {
                        if (pic_Skill01.Image == icon_skill[i])
                        {
                            _imgSKill[0] = i + 1;
                            break;
                        }
                    }
                }
                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_Skill02.Image != null)
                    {
                        if (pic_Skill02.Image == icon_skill[i])
                        {
                            _imgSKill[1] = i + 1;
                            break;
                        }
                    }
                }
                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_Skill03.Image != null)
                    {
                        if (pic_Skill03.Image == icon_skill[i])
                        {
                            _imgSKill[2] = i + 1;
                            break;
                        }
                    }
                }
                #endregion

                #region ClassSkill Image
                int[] _img_ClassSkill = new int[4];

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill01.Image != null)
                    {
                        if (pic_ClassSkill01.Image == icon_skill[i])
                        {
                            _img_ClassSkill[0] = i + 1;
                            break;
                        }
                    }
                    else
                    {
                        _img_ClassSkill[0] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill02.Image != null)
                    {
                        if (pic_ClassSkill02.Image == icon_skill[i])
                        {
                            _img_ClassSkill[1] = i + 1;
                            break;
                        }
                    }
                    else
                    {
                        _img_ClassSkill[1] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill03.Image != null)
                    {
                        if (pic_ClassSkill03.Image == icon_skill[i])
                        {
                            _img_ClassSkill[2] = i + 1;
                            break;
                        }
                    }
                    else
                    {
                        _img_ClassSkill[2] = 999999;
                    }
                }

                for (int i = 0; i < icon_skill.Length; i++)
                {
                    if (pic_ClassSkill04.Image != null)
                    {
                        if (pic_ClassSkill04.Image == icon_skill[i])
                        {
                            _img_ClassSkill[3] = i + 1;
                            break;
                        }
                    }
                    else
                    {
                        _img_ClassSkill[3] = 999999;
                    }
                }
                #endregion

                #region CommandCard Image
                int Buster = 0, Arts = 0, Quick = 0;
                Bitmap a = (Bitmap)pic_Commandcard01.Image;
                Bitmap[] _ActionCard = {
                    a,(Bitmap)pic_Commandcard02.Image,(Bitmap)pic_Commandcard03.Image,(Bitmap)pic_Commandcard04.Image,(Bitmap)pic_Commandcard05.Image
                };

                for (int i = 0; i <= 5; i++)
                {
                    for (int j = 0; j < _Card.Length; j++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 1:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 4:
                                if (_ActionCard[i] == _Card[j])
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Buster++;
                                            break;
                                        case 1:
                                            Arts++;
                                            break;
                                        case 2:
                                            Quick++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
                #endregion

                #region NP Card
                int[] _NPcard = new int[2];

                for (int i = 0; i < _Card.Length; i++)
                {
                    if (pic_NPCard01.Image == _Card[i])
                    {
                        _NPcard[0] = i;
                        break;
                    }
                }

                for (int i = 0; i < _Card.Length; i++)
                {
                    if (pic_NPCard02.Image == _Card[i])
                    {
                        _NPcard[1] = i;
                        break;
                    }
                }
                #endregion

                #region Material Image

                #region Bitmap Array
                Bitmap[] bitmap_material = {
                    (Bitmap)pic_levelmaterial_11.Image,(Bitmap)pic_levelmaterial_12.Image,(Bitmap)pic_levelmaterial_13.Image,(Bitmap)pic_levelmaterial_14.Image,
                    (Bitmap)pic_levelmaterial_21.Image,(Bitmap)pic_levelmaterial_22.Image,(Bitmap)pic_levelmaterial_23.Image,(Bitmap)pic_levelmaterial_24.Image,
                    (Bitmap)pic_levelmaterial_31.Image,(Bitmap)pic_levelmaterial_32.Image,(Bitmap)pic_levelmaterial_33.Image,(Bitmap)pic_levelmaterial_34.Image,
                    (Bitmap)pic_levelmaterial_41.Image,(Bitmap)pic_levelmaterial_42.Image,(Bitmap)pic_levelmaterial_43.Image,(Bitmap)pic_levelmaterial_44.Image,
                    (Bitmap)pic_Skill_Material21.Image,(Bitmap)pic_Skill_Material22.Image,(Bitmap)pic_Skill_Material23.Image,(Bitmap)pic_Skill_Material24.Image,
                    (Bitmap)pic_Skill_Material31.Image,(Bitmap)pic_Skill_Material32.Image,(Bitmap)pic_Skill_Material33.Image,(Bitmap)pic_Skill_Material34.Image,
                    (Bitmap)pic_Skill_Material41.Image,(Bitmap)pic_Skill_Material42.Image,(Bitmap)pic_Skill_Material43.Image,(Bitmap)pic_Skill_Material44.Image,
                    (Bitmap)pic_Skill_Material51.Image,(Bitmap)pic_Skill_Material52.Image,(Bitmap)pic_Skill_Material53.Image,(Bitmap)pic_Skill_Material54.Image,
                    (Bitmap)pic_Skill_Material61.Image,(Bitmap)pic_Skill_Material62.Image,(Bitmap)pic_Skill_Material63.Image,(Bitmap)pic_Skill_Material64.Image,
                    (Bitmap)pic_Skill_Material71.Image,(Bitmap)pic_Skill_Material72.Image,(Bitmap)pic_Skill_Material73.Image,(Bitmap)pic_Skill_Material74.Image,
                    (Bitmap)pic_Skill_Material81.Image,(Bitmap)pic_Skill_Material82.Image,(Bitmap)pic_Skill_Material83.Image,(Bitmap)pic_Skill_Material84.Image,
                    (Bitmap)pic_Skill_Material91.Image,(Bitmap)pic_Skill_Material92.Image,(Bitmap)pic_Skill_Material93.Image,(Bitmap)pic_Skill_Material94.Image,
                    (Bitmap)pic_Skill_Material101.Image,(Bitmap)pic_Skill_Material102.Image,(Bitmap)pic_Skill_Material103.Image,(Bitmap)pic_Skill_Material104.Image
                };
                String[] _str_material = new String[52];

                String[] str_Firebase_material =
                {
                    "levelMaterial_11","levelMaterial_12","levelMaterial_13","levelMaterial_14",
                    "levelMaterial_21","levelMaterial_22","levelMaterial_23","levelMaterial_24",
                    "levelMaterial_31","levelMaterial_32","levelMaterial_33","levelMaterial_34",
                    "levelMaterial_41","levelMaterial_42","levelMaterial_43","levelMaterial_44",
                    "skill_Material21","skill_Material22","skill_Material23","skill_Material24",
                    "skill_Material31","skill_Material32","skill_Material33","skill_Material34",
                    "skill_Material41","skill_Material42","skill_Material43","skill_Material44",
                    "skill_Material51","skill_Material52","skill_Material53","skill_Material54",
                    "skill_Material61","skill_Material62","skill_Material63","skill_Material64",
                    "skill_Material71","skill_Material72","skill_Material73","skill_Material74",
                    "skill_Material81","skill_Material82","skill_Material83","skill_Material84",
                    "skill_Material91","skill_Material92","skill_Material93","skill_Material94",
                    "skill_Material101","skill_Material102","skill_Material103","skill_Material104",
                };

                String[] _str_Firebase_Quantity = {
                    "requireQuantity11","requireQuantity12","requireQuantity13","requireQuantity14",
                    "requireQuantity21","requireQuantity22","requireQuantity23","requireQuantity24",
                    "requireQuantity31","requireQuantity32","requireQuantity33","requireQuantity34",
                    "requireQuantity41","requireQuantity42","requireQuantity43","requireQuantity44",
                    "skill_RequireQuantity21","skill_RequireQuantity22","skill_RequireQuantity23","skill_RequireQuantity24",
                    "skill_RequireQuantity31","skill_RequireQuantity32","skill_RequireQuantity33","skill_RequireQuantity34",
                    "skill_RequireQuantity41","skill_RequireQuantity42","skill_RequireQuantity43","skill_RequireQuantity44",
                    "skill_RequireQuantity51","skill_RequireQuantity52","skill_RequireQuantity53","skill_RequireQuantity54",
                    "skill_RequireQuantity61","skill_RequireQuantity62","skill_RequireQuantity63","skill_RequireQuantity64",
                    "skill_RequireQuantity71","skill_RequireQuantity72","skill_RequireQuantity73","skill_RequireQuantity74",
                    "skill_RequireQuantity81","skill_RequireQuantity82","skill_RequireQuantity83","skill_RequireQuantity84",
                    "skill_RequireQuantity91","skill_RequireQuantity92","skill_RequireQuantity93","skill_RequireQuantity94",
                    "skill_RequireQuantity101","skill_RequireQuantity102","skill_RequireQuantity103","skill_RequireQuantity104",
                };
                String[] _textQuantity =
                {
                    text_RequireQuantity11.Text,text_RequireQuantity12.Text,text_RequireQuantity13.Text,text_RequireQuantity14.Text,
                    text_RequireQuantity21.Text,text_RequireQuantity22.Text,text_RequireQuantity23.Text,text_RequireQuantity24.Text,
                    text_RequireQuantity31.Text,text_RequireQuantity32.Text,text_RequireQuantity33.Text,text_RequireQuantity34.Text,
                    text_RequireQuantity41.Text,text_RequireQuantity42.Text,text_RequireQuantity43.Text,text_RequireQuantity44.Text,
                    text_Skill_RequireQuantity21.Text,text_Skill_RequireQuantity22.Text,text_Skill_RequireQuantity23.Text,text_Skill_RequireQuantity24.Text,
                    text_Skill_RequireQuantity31.Text,text_Skill_RequireQuantity32.Text,text_Skill_RequireQuantity33.Text,text_Skill_RequireQuantity34.Text,
                    text_Skill_RequireQuantity41.Text,text_Skill_RequireQuantity42.Text,text_Skill_RequireQuantity43.Text,text_Skill_RequireQuantity44.Text,
                    text_Skill_RequireQuantity51.Text,text_Skill_RequireQuantity52.Text,text_Skill_RequireQuantity53.Text,text_Skill_RequireQuantity54.Text,
                    text_Skill_RequireQuantity61.Text,text_Skill_RequireQuantity62.Text,text_Skill_RequireQuantity63.Text,text_Skill_RequireQuantity64.Text,
                    text_Skill_RequireQuantity71.Text,text_Skill_RequireQuantity72.Text,text_Skill_RequireQuantity73.Text,text_Skill_RequireQuantity74.Text,
                    text_Skill_RequireQuantity81.Text,text_Skill_RequireQuantity82.Text,text_Skill_RequireQuantity83.Text,text_Skill_RequireQuantity84.Text,
                    text_Skill_RequireQuantity91.Text,text_Skill_RequireQuantity92.Text,text_Skill_RequireQuantity93.Text,text_Skill_RequireQuantity94.Text,
                    text_Skill_RequireQuantity101.Text,text_Skill_RequireQuantity102.Text,text_Skill_RequireQuantity103.Text,text_Skill_RequireQuantity104.Text
                };
                for (int k = 0; k < _textQuantity.Length; k++)
                {
                    if (_textQuantity[k].Equals("") || _textQuantity[k].Equals(null))
                    {
                        _textQuantity[k] = null;
                    }
                }
                #endregion

                for (int i = 0; i < 52; i++)
                {
                    for (int j = 0; j < img_Material.Length; j++)
                    {
                        if (bitmap_material[i] != null)
                        {
                            if (bitmap_material[i] == img_Material[j])
                            {
                                _str_material[i] = str_Material[j];
                                break;
                            }
                        }
                        else
                        {
                            _str_material[i] = null;
                        }
                    }
                }


                #endregion

                #endregion

                #endregion

                #region Updata 
                #region Progress Bar
                progressBar1.Maximum = 173;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                #endregion
                #region Status
                FirebaseResponse patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                    "\"" + "nameCH" + "\":\"" + ServantNameChinese.Text + "\"" + "," +
                    "\"" + "nameEN" + "\":\"" + ServantNameEN.Text + "\"" + "," +
                    "\"" + "nameJP" + "\":\"" + ServantNameJP.Text + "\"" + "," +
                    "\"" + "nameChina" + "\":\"" + ServantNameChina.Text + "\"" + "," +
                    "\"" + "rarity" + "\":" + textRarity.Text + "" + "," +
                    "\"" + "cost" + "\":" + textCost.Text + "" + "," +
                    "\"" + "max_LV" + "\":" + textMaxLv.Text + "" + "," +
                    "\"" + "servantClass" + "\":" + textClass_int.Text + "" + "," +
                    "\"" + "statusATKLV1" + "\":" + textATK01.Text + "" + "," +
                    "\"" + "status_HPLV1" + "\":" + textHP01.Text + "" + "," +
                    "\"" + "statusATKFinal" + "\":" + textATKMax.Text + "" + "," +
                    "\"" + "status_HPFinal" + "\":" + textHPMax.Text + "" + "," +
                    "\"" + "statusATKLV100" + "\":" + textATK100.Text + "" + "," +
                    "\"" + "status_HPLV100" + "\":" + textHP100.Text + "" + "," +
                    "\"" + "skill_Describe1" + "\":\"" + text_Skill_Describe1.Text + "\"" + "," +
                    "\"" + "skill_Describe2" + "\":\"" + text_Skill_Describe2.Text + "\"" + "," +
                    "\"" + "skill_Describe3" + "\":\"" + text_Skill_Describe3.Text + "\"" + "," +
                    "\"" + "skill_Describe4" + "\":\"" + text_Skill_Describe4.Text + "\"" + "," +
                    "\"" + "skill_Describe5" + "\":\"" + text_Skill_Describe5.Text + "\"" + "," +
                    "\"" + "skill_Describe6" + "\":\"" + text_Skill_Describe6.Text + "\"" + "," +
                    "\"" + "img_Skill01" + "\":" + _imgSKill[0].ToString() + "" + "," +
                    "\"" + "img_Skill02" + "\":" + _imgSKill[1].ToString() + "" + "," +
                    "\"" + "img_Skill03" + "\":" + _imgSKill[2].ToString() + "" + "," +
                    "\"" + "skill_1_Effect1" + "\":\"" + textSkillEffect11.Text + "\"" + "," +
                    "\"" + "skill_1_Effect2" + "\":\"" + textSkillEffect12.Text + "\"" + "," +
                    "\"" + "skill_1_Effect3" + "\":\"" + textSkillEffect13.Text + "\"" + "," +
                    "\"" + "skill_1_Effect4" + "\":\"" + textSkillEffect14.Text + "\"" + "," +
                    "\"" + "skill_1_Effect5" + "\":\"" + textSkillEffect15.Text + "\"" + "," +
                    "\"" + "skill_1_Effect6" + "\":\"" + textSkillEffect16.Text + "\"" + "," +
                    "\"" + "skill_1_Effect7" + "\":\"" + textSkillEffect17.Text + "\"" + "," +
                    "\"" + "skill_1_Effect8" + "\":\"" + textSkillEffect18.Text + "\"" + "," +
                    "\"" + "skill_1_Effect9" + "\":\"" + textSkillEffect19.Text + "\"" + "," +
                    "\"" + "skill_1_Effect10" + "\":\"" + textSkillEffect110.Text + "\"" + "," +
                    "\"" + "skill_2_Effect1" + "\":\"" + textSkillEffect21.Text + "\"" + "," +
                    "\"" + "skill_2_Effect2" + "\":\"" + textSkillEffect22.Text + "\"" + "," +
                    "\"" + "skill_2_Effect3" + "\":\"" + textSkillEffect23.Text + "\"" + "," +
                    "\"" + "skill_2_Effect4" + "\":\"" + textSkillEffect24.Text + "\"" + "," +
                    "\"" + "skill_2_Effect5" + "\":\"" + textSkillEffect25.Text + "\"" + "," +
                    "\"" + "skill_2_Effect6" + "\":\"" + textSkillEffect26.Text + "\"" + "," +
                    "\"" + "skill_2_Effect7" + "\":\"" + textSkillEffect27.Text + "\"" + "," +
                    "\"" + "skill_2_Effect8" + "\":\"" + textSkillEffect28.Text + "\"" + "," +
                    "\"" + "skill_2_Effect9" + "\":\"" + textSkillEffect29.Text + "\"" + "," +
                    "\"" + "skill_2_Effect10" + "\":\"" + textSkillEffect210.Text + "\"" + "," +
                    "\"" + "skill_3_Effect1" + "\":\"" + textSkillEffect31.Text + "\"" + "," +
                    "\"" + "skill_3_Effect2" + "\":\"" + textSkillEffect32.Text + "\"" + "," +
                    "\"" + "skill_3_Effect3" + "\":\"" + textSkillEffect33.Text + "\"" + "," +
                    "\"" + "skill_3_Effect4" + "\":\"" + textSkillEffect34.Text + "\"" + "," +
                    "\"" + "skill_3_Effect5" + "\":\"" + textSkillEffect35.Text + "\"" + "," +
                    "\"" + "skill_3_Effect6" + "\":\"" + textSkillEffect36.Text + "\"" + "," +
                    "\"" + "skill_3_Effect7" + "\":\"" + textSkillEffect37.Text + "\"" + "," +
                    "\"" + "skill_3_Effect8" + "\":\"" + textSkillEffect38.Text + "\"" + "," +
                    "\"" + "skill_3_Effect9" + "\":\"" + textSkillEffect39.Text + "\"" + "," +
                    "\"" + "skill_3_Effect10" + "\":\"" + textSkillEffect310.Text + "\"" + "," +
                    "\"" + "command_Buster" + "\":" + Buster.ToString() + "" + "," +
                    "\"" + "command_Arts" + "\":" + Arts.ToString() + "" + "," +
                    "\"" + "command_Quick" + "\":" + Quick.ToString() + "" + "," +
                    "\"" + "np_CardColor" + "\":" + _NPcard[0].ToString() + "" + "," +
                    "\"" + "np_Name1" + "\":\"" + textNPname1.Text + "\"" + "," +
                    "\"" + "np_Describe" + "\":\"" + textNPdescribe.Text + "\"" + "," +
                    "\"" + "np_Describe_Rank1" + "\":\"" + textNPrank1.Text + "\"" + "," +
                    "\"" + "np_Describe_Target" + "\":\"" + textNPtarget.Text + "\"" + "," +
                    "\"" + "skill_QP2" + "\":\"" + text_Skill_QP2.Text + "\"" + "," +
                    "\"" + "skill_QP3" + "\":\"" + text_Skill_QP3.Text + "\"" + "," +
                    "\"" + "skill_QP4" + "\":\"" + text_Skill_QP4.Text + "\"" + "," +
                    "\"" + "skill_QP5" + "\":\"" + text_Skill_QP5.Text + "\"" + "," +
                    "\"" + "skill_QP6" + "\":\"" + text_Skill_QP6.Text + "\"" + "," +
                    "\"" + "skill_QP7" + "\":\"" + text_Skill_QP7.Text + "\"" + "," +
                    "\"" + "skill_QP8" + "\":\"" + text_Skill_QP8.Text + "\"" + "," +
                    "\"" + "skill_QP9" + "\":\"" + text_Skill_QP9.Text + "\"" + "," +
                    "\"" + "skill_QP10" + "\":\"" + text_Skill_QP10.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_1" + "\":\"" + text_levelmaterialQP1.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_2" + "\":\"" + text_levelmaterialQP2.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_3" + "\":\"" + text_levelmaterialQP3.Text + "\"" + "," +
                    "\"" + "levelMaterialQP_4" + "\":\"" + text_levelmaterialQP4.Text + "\""
                    + "}");
                progressBar1.Value = 50;
                #endregion
                #region NP
                String[,] _strfibase =
                {
                    {"np_Rank2",textNPrank2.Text },
                    { "np_1_Effect1",textNP_Effect11.Text},
                    { "np_1_Effect2",textNP_Effect12.Text},
                    { "np_1_Effect3",textNP_Effect13.Text},
                    { "np_1_Effect4",textNP_Effect14.Text},
                    { "np_1_Effect5",textNP_Effect15.Text},
                    { "np_2_Effect1",textNP_Effect21.Text },
                    { "np_2_Effect2",textNP_Effect22.Text },
                    { "np_2_Effect3",textNP_Effect23.Text },
                    { "np_2_Effect4",textNP_Effect24.Text },
                    { "np_2_Effect5",textNP_Effect25.Text },
                };
                for (int i = 0; i < 11; i++)
                {
                    if (_strfibase[i, 1] != null && _strfibase[i, 1] != "")
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + _strfibase[i, 0] + "\":\"" + _strfibase[i, 1] + "\""
                        + "}");
                    }
                    progressBar1.Value++;
                }

                String[,] _firbaseclassskill = {
                    {"class_Describe1" ,textClassSkillDescribe01.Text},
                    {"class_Describe2" ,textClassSkillDescribe02.Text},
                    {"class_Describe3" ,textClassSkillDescribe03.Text},
                    {"class_Describe4" ,textClassSkillDescribe04.Text},
                    { "img_ClassSkill01", _img_ClassSkill[0].ToString()},
                    { "img_ClassSkill02", _img_ClassSkill[1].ToString()},
                    { "img_ClassSkill03", _img_ClassSkill[2].ToString()},
                    { "img_ClassSkill04", _img_ClassSkill[3].ToString()},
                };
                for (int i = 0; i < 8; i++)
                {
                    if (_firbaseclassskill[i, 1] != null && _firbaseclassskill[i, 1] != "" && i < 4)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + _firbaseclassskill[i, 0] + "\":\"" + _firbaseclassskill[i, 1] + "\""
                        + "}");
                    }

                    if (_firbaseclassskill[i, 1] != "999999" && _firbaseclassskill[i, 1] != "" && _firbaseclassskill[i, 1] != null && i >= 4)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + _firbaseclassskill[i, 0] + "\":" + _firbaseclassskill[i, 1] + ""
                        + "}");
                    }
                    else
                    {
                        if (i >= 4)
                        {
                            patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                              "\"" + _firbaseclassskill[i, 0] + "\":" + "999999" + ""
                              + "}");
                        }
                    }
                    progressBar1.Value++;
                }


                #endregion

                #region Material
                for (int i = 0; i < 52; i++)
                {
                    if (_str_material[i] != "" && _str_material[i] != null)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                        "\"" + str_Firebase_material[i] + "\":\"" + _str_material[i] + "\""
                        + "}");
                    }
                    progressBar1.Value++;
                }


                for (int i = 0; i < 52; i++)
                {
                    if (_textQuantity[i] != "" && _textQuantity[i] != null)
                    {
                        patchResponse = FirebaseServant.Node(comboBox1.Text).Patch("{" +
                       "\"" + _str_Firebase_Quantity[i] + "\":\"" + _textQuantity[i] + "\"" + "}");
                    }
                    progressBar1.Value++;
                }

                MessageBox.Show("Update Sucessfuly", "Message", MessageBoxButtons.OK);
                progressBar1.Value = 0;


                #endregion
                #endregion
            }
            
        }


        private void Read_Data_Servant_Function()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            t2 = new Thread(ProgressBar2_Run);  t2.Start();             
            #region Reading Data From Firebase by Get apporach
            textServantNO.Text = (comboBox1.SelectedIndex + 1).ToString();
            //FirebaseDB firebaseDB = new FirebaseDB("https://csharp-9f233.firebaseio.com/Servant");

            FirebaseDB firebaseDB = FirebaseServant.Node(comboBox1.Text);
            //GET Request
            if (!checkBox_Editmode.Checked)
            {

                FirebaseResponse getResponse = firebaseDB.Get();

                //if (getResponse.Success)
                //    textBox1.Text += getResponse.JSONContent.ToString();
                FGOHelper.FGOHelperS fgo = new FGOHelper.FGOHelperS();
                try
                {
                    fgo = JsonConvert.DeserializeObject<FGOHelper.FGOHelperS>(getResponse.JSONContent.ToString());
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error:" + er.ToString(), "Hint", MessageBoxButtons.OK);
                    comboBox1.SelectedIndex = 1;
                }

                #endregion

                #region Image initial
                pic_ClassSkill01.Image = null;
                pic_ClassSkill02.Image = null;
                pic_ClassSkill03.Image = null;
                pic_ClassSkill04.Image = null;
                pic_Skill01.Image = null;
                pic_Skill02.Image = null;
                pic_Skill03.Image = null;
                pic_Commandcard01.Image = null;
                pic_Commandcard02.Image = null;
                pic_Commandcard03.Image = null;
                pic_Commandcard04.Image = null;
                pic_Commandcard05.Image = null;
                pic_NPCard01.Image = pic_NPCard02.Image = null;
                pic_levelmaterial_11.Image = null;
                pic_levelmaterial_12.Image = null;
                pic_levelmaterial_13.Image = null;
                pic_levelmaterial_14.Image = null;
                pic_levelmaterial_21.Image = null;
                pic_levelmaterial_22.Image = null;
                pic_levelmaterial_23.Image = null;
                pic_levelmaterial_24.Image = null;
                pic_levelmaterial_31.Image = null;
                pic_levelmaterial_32.Image = null;
                pic_levelmaterial_33.Image = null;
                pic_levelmaterial_34.Image = null;
                pic_levelmaterial_41.Image = null;
                pic_levelmaterial_42.Image = null;
                pic_levelmaterial_43.Image = null;
                pic_levelmaterial_44.Image = null;
                pic_Skill_Material101.Image = null;
                pic_Skill_Material102.Image = null;
                pic_Skill_Material103.Image = null;
                pic_Skill_Material104.Image = null;
                pic_Skill_Material21.Image = null;
                pic_Skill_Material22.Image = null;
                pic_Skill_Material23.Image = null;
                pic_Skill_Material24.Image = null;
                pic_Skill_Material31.Image = null;
                pic_Skill_Material32.Image = null;
                pic_Skill_Material33.Image = null;
                pic_Skill_Material34.Image = null;
                pic_Skill_Material41.Image = null;
                pic_Skill_Material42.Image = null;
                pic_Skill_Material43.Image = null;
                pic_Skill_Material44.Image = null;
                pic_Skill_Material51.Image = null;
                pic_Skill_Material52.Image = null;
                pic_Skill_Material53.Image = null;
                pic_Skill_Material54.Image = null;
                pic_Skill_Material61.Image = null;
                pic_Skill_Material62.Image = null;
                pic_Skill_Material63.Image = null;
                pic_Skill_Material64.Image = null;
                pic_Skill_Material71.Image = null;
                pic_Skill_Material72.Image = null;
                pic_Skill_Material73.Image = null;
                pic_Skill_Material74.Image = null;
                pic_Skill_Material81.Image = null;
                pic_Skill_Material82.Image = null;
                pic_Skill_Material83.Image = null;
                pic_Skill_Material84.Image = null;
                pic_Skill_Material91.Image = null;
                pic_Skill_Material92.Image = null;
                pic_Skill_Material93.Image = null;
                pic_Skill_Material94.Image = null;

                #endregion

                try
                {
                    #region Status Info
                    ServantNameChinese.Text = fgo.NameCH;
                    ServantNameEN.Text = fgo.NameEN;
                    ServantNameJP.Text = fgo.NameJP;
                    ServantNameChina.Text = fgo.NameChina;
                    textRarity.Text = fgo.Rarity.ToString();
                    textCost.Text = fgo.COST.ToString();
                    textMaxLv.Text = fgo.MAX_LV.ToString();
                    textClass_int.Text = fgo.servantClass.ToString();
                    if (fgo.servantClass != 999999)
                    {
                        textClass_str.Text = str_class[fgo.servantClass - 1];
                    }
                    else
                    {
                        textClass_str.Text = fgo.servantClass.ToString();
                    }

                    if (fgo.servantClass != 999999 && fgo.servantClass > 0)
                    {
                        picimgclass.Image = imgclass[fgo.servantClass - 1];
                    }
                    textATK01.Text = fgo.StatusATKLV1.ToString();
                    textHP01.Text = fgo.Status_HPLV1.ToString();
                    textATKMax.Text = fgo.StatusATKFinal.ToString();
                    textHPMax.Text = fgo.Status_HPFinal.ToString();
                    textATK100.Text = fgo.StatusATKLV100.ToString();
                    textHP100.Text = fgo.Status_HPLV100.ToString();
                    #endregion

                    #region Skill Describe
                    pic_Skill01.Image = icon_skill[fgo.img_Skill01 - 1];
                    pic_Skill02.Image = icon_skill[fgo.img_Skill02 - 1];
                    pic_Skill03.Image = icon_skill[fgo.img_Skill03 - 1];

                    text_Skill_Describe1.Text = fgo.Skill_Describe1;
                    text_Skill_Describe2.Text = fgo.Skill_Describe2;
                    text_Skill_Describe3.Text = fgo.Skill_Describe3;
                    text_Skill_Describe4.Text = fgo.Skill_Describe4;
                    text_Skill_Describe5.Text = fgo.Skill_Describe5;
                    text_Skill_Describe6.Text = fgo.Skill_Describe6;

                    textSkillEffect11.Text = fgo.Skill_1_Effect1;
                    textSkillEffect12.Text = fgo.Skill_1_Effect2;
                    textSkillEffect13.Text = fgo.Skill_1_Effect3;
                    textSkillEffect14.Text = fgo.Skill_1_Effect4;
                    textSkillEffect15.Text = fgo.Skill_1_Effect5;
                    textSkillEffect16.Text = fgo.Skill_1_Effect6;
                    textSkillEffect17.Text = fgo.Skill_1_Effect7;
                    textSkillEffect18.Text = fgo.Skill_1_Effect8;
                    textSkillEffect19.Text = fgo.Skill_1_Effect9;
                    textSkillEffect110.Text = fgo.Skill_1_Effect10;

                    textSkillEffect21.Text = fgo.Skill_2_Effect1;
                    textSkillEffect22.Text = fgo.Skill_2_Effect2;
                    textSkillEffect23.Text = fgo.Skill_2_Effect3;
                    textSkillEffect24.Text = fgo.Skill_2_Effect4;
                    textSkillEffect25.Text = fgo.Skill_2_Effect5;
                    textSkillEffect26.Text = fgo.Skill_2_Effect6;
                    textSkillEffect27.Text = fgo.Skill_2_Effect7;
                    textSkillEffect28.Text = fgo.Skill_2_Effect8;
                    textSkillEffect29.Text = fgo.Skill_2_Effect9;
                    textSkillEffect210.Text = fgo.Skill_2_Effect10;

                    textSkillEffect31.Text = fgo.Skill_3_Effect1;
                    textSkillEffect32.Text = fgo.Skill_3_Effect2;
                    textSkillEffect33.Text = fgo.Skill_3_Effect3;
                    textSkillEffect34.Text = fgo.Skill_3_Effect4;
                    textSkillEffect35.Text = fgo.Skill_3_Effect5;
                    textSkillEffect36.Text = fgo.Skill_3_Effect6;
                    textSkillEffect37.Text = fgo.Skill_3_Effect7;
                    textSkillEffect38.Text = fgo.Skill_3_Effect8;
                    textSkillEffect39.Text = fgo.Skill_3_Effect9;
                    textSkillEffect310.Text = fgo.Skill_3_Effect10;
                    #endregion

                    #region Class Skill Describe


                    if (fgo.img_ClassSkill01 != 999999)
                    {
                        pic_ClassSkill01.Image = icon_skill[fgo.img_ClassSkill01 - 1];
                    }

                    if (fgo.img_ClassSkill02 != 999999)
                    {
                        pic_ClassSkill02.Image = icon_skill[fgo.img_ClassSkill02 - 1];
                    }

                    if (fgo.img_ClassSkill03 != 999999)
                    {
                        pic_ClassSkill03.Image = icon_skill[fgo.img_ClassSkill03 - 1];
                    }

                    if (fgo.img_ClassSkill04 != 999999)
                    {
                        pic_ClassSkill04.Image = icon_skill[fgo.img_ClassSkill04 - 1];
                    }

                    textClassSkillDescribe01.Text = fgo.Class_Describe1;
                    textClassSkillDescribe02.Text = fgo.Class_Describe2;
                    textClassSkillDescribe03.Text = fgo.Class_Describe3;
                    textClassSkillDescribe04.Text = fgo.Class_Describe4;
                    #endregion

                    #region Command Card 
                    int Buster = fgo.Command_Buster;
                    int Arts = fgo.Command_Arts;
                    int Quick = fgo.Command_Quick;

                    for (int c = 0; c < 5; c++)
                    {
                        if (Buster != 0)
                        {
                            Buster--;
                            switch (c)
                            {
                                case 0:
                                    pic_Commandcard01.Image = _Card[0];
                                    break;
                                case 1:
                                    pic_Commandcard02.Image = _Card[0];
                                    break;
                                case 2:
                                    pic_Commandcard03.Image = _Card[0];
                                    break;
                                case 3:
                                    pic_Commandcard04.Image = _Card[0];
                                    break;
                                case 4:
                                    pic_Commandcard05.Image = _Card[0];
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (Arts != 0)
                            {
                                Arts--;
                                switch (c)
                                {
                                    case 0:
                                        pic_Commandcard01.Image = _Card[1];
                                        break;
                                    case 1:
                                        pic_Commandcard02.Image = _Card[1];
                                        break;
                                    case 2:
                                        pic_Commandcard03.Image = _Card[1];
                                        break;
                                    case 3:
                                        pic_Commandcard04.Image = _Card[1];
                                        break;
                                    case 4:
                                        pic_Commandcard05.Image = _Card[1];
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                if (Quick != 0)
                                {
                                    Quick--;
                                    switch (c)
                                    {
                                        case 0:
                                            pic_Commandcard01.Image = _Card[2];
                                            break;
                                        case 1:
                                            pic_Commandcard02.Image = _Card[2];
                                            break;
                                        case 2:
                                            pic_Commandcard03.Image = _Card[2];
                                            break;
                                        case 3:
                                            pic_Commandcard04.Image = _Card[2];
                                            break;
                                        case 4:
                                            pic_Commandcard05.Image = _Card[2];
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region NP
                    textNPname1.Text = fgo.NP_Name1;
                    textNPname2.Text = fgo.NP_Name2;
                    textNPdescribe.Text = fgo.NP_Describe;
                    textNPrank1.Text = fgo.NP_Describe_Rank1;
                    textNPrank2.Text = fgo.NP_Rank2;
                    textNPtarget.Text = fgo.NP_Describe_Target;

                    textNP_Effect11.Text = fgo.NP_1_Effect1;
                    textNP_Effect12.Text = fgo.NP_1_Effect2;
                    textNP_Effect13.Text = fgo.NP_1_Effect3;
                    textNP_Effect14.Text = fgo.NP_1_Effect4;
                    textNP_Effect15.Text = fgo.NP_1_Effect5;

                    textNP_Effect21.Text = fgo.NP_2_Effect1;
                    textNP_Effect22.Text = fgo.NP_2_Effect2;
                    textNP_Effect23.Text = fgo.NP_2_Effect3;
                    textNP_Effect24.Text = fgo.NP_2_Effect4;
                    textNP_Effect25.Text = fgo.NP_2_Effect5;

                    if (fgo.NP_CardColor != 4 || fgo.NP_CardColor != 999999)
                    {
                        switch (fgo.NP_CardColor)
                        {
                            case 0:
                                pic_NPCard01.Image = _Card[0];
                                break;
                            case 1:
                                pic_NPCard01.Image = _Card[1];
                                break;
                            case 2:
                                pic_NPCard01.Image = _Card[2];
                                break;
                            default:
                                break;
                        }
                    }
                    if (fgo.NP_Rank2 != null)
                    {
                        switch (fgo.NP_CardColor)
                        {
                            case 0:
                                pic_NPCard02.Image = _Card[0];
                                break;
                            case 1:
                                pic_NPCard02.Image = _Card[1];
                                break;
                            case 2:
                                pic_NPCard02.Image = _Card[2];
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion

                    #region  Material
                    String[] str_levelmaterial =
                    {
                fgo.LevelMaterial_11,fgo.LevelMaterial_12,fgo.LevelMaterial_13,fgo.LevelMaterial_14,
                fgo.LevelMaterial_21,fgo.LevelMaterial_22,fgo.LevelMaterial_23,fgo.LevelMaterial_24,
                fgo.LevelMaterial_31,fgo.LevelMaterial_32,fgo.LevelMaterial_33,fgo.LevelMaterial_34,
                fgo.LevelMaterial_41,fgo.LevelMaterial_42,fgo.LevelMaterial_43,fgo.LevelMaterial_44
            };
                    String[] str_skillmaterial = {
                fgo.Skill_Material21,fgo.Skill_Material22,fgo.Skill_Material23,fgo.Skill_Material24,
                fgo.Skill_Material31,fgo.Skill_Material32,fgo.Skill_Material33,fgo.Skill_Material34,
                fgo.Skill_Material41,fgo.Skill_Material42,fgo.Skill_Material43,fgo.Skill_Material44,
                fgo.Skill_Material51,fgo.Skill_Material52,fgo.Skill_Material53,fgo.Skill_Material54,
                fgo.Skill_Material61,fgo.Skill_Material62,fgo.Skill_Material63,fgo.Skill_Material64,
                fgo.Skill_Material71,fgo.Skill_Material72,fgo.Skill_Material73,fgo.Skill_Material74,
                fgo.Skill_Material81,fgo.Skill_Material82,fgo.Skill_Material83,fgo.Skill_Material84,
                fgo.Skill_Material91,fgo.Skill_Material92,fgo.Skill_Material93,fgo.Skill_Material94,
                fgo.Skill_Material101,fgo.Skill_Material102,fgo.Skill_Material103,fgo.Skill_Material104,

            };

                    bool bool_find = false;

                    #region Level Material

                    #region text
                    text_levelmaterialQP1.Text = fgo.LevelMaterialQP_1;
                    text_levelmaterialQP2.Text = fgo.LevelMaterialQP_2;
                    text_levelmaterialQP3.Text = fgo.LevelMaterialQP_3;
                    text_levelmaterialQP4.Text = fgo.LevelMaterialQP_4;

                    text_RequireQuantity11.Text = fgo.RequireQuantity11;
                    text_RequireQuantity12.Text = fgo.RequireQuantity12;
                    text_RequireQuantity13.Text = fgo.RequireQuantity13;
                    text_RequireQuantity14.Text = fgo.RequireQuantity14;

                    text_RequireQuantity21.Text = fgo.RequireQuantity21;
                    text_RequireQuantity22.Text = fgo.RequireQuantity22;
                    text_RequireQuantity23.Text = fgo.RequireQuantity23;
                    text_RequireQuantity24.Text = fgo.RequireQuantity24;

                    text_RequireQuantity31.Text = fgo.RequireQuantity31;
                    text_RequireQuantity32.Text = fgo.RequireQuantity32;
                    text_RequireQuantity33.Text = fgo.RequireQuantity33;
                    text_RequireQuantity34.Text = fgo.RequireQuantity34;

                    text_RequireQuantity41.Text = fgo.RequireQuantity41;
                    text_RequireQuantity42.Text = fgo.RequireQuantity42;
                    text_RequireQuantity43.Text = fgo.RequireQuantity43;
                    text_RequireQuantity44.Text = fgo.RequireQuantity44;
                    #endregion

                    for (int i = 0; i < 16; i++)
                    {
                        if (str_levelmaterial[i] != null)
                        {
                            #region Switch
                            switch (i)
                            {
                                case 0:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_11.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    if (!bool_find)
                                    {
                                        for (int j = 0; j < str_EventMaterial.Length; j++)
                                        {
                                            if (fgo.LevelMaterial_11.Equals(str_EventMaterial[j]))
                                            {
                                                pic_levelmaterial_11.Image = img_EventMaterial[j];
                                                pic_levelmaterial_21.Image = img_EventMaterial[j];
                                                pic_levelmaterial_31.Image = img_EventMaterial[j];
                                                pic_levelmaterial_41.Image = img_EventMaterial[j];
                                                bool_find = true;
                                                i = 16;//break loop
                                                break;
                                            }
                                        }
                                    }
                                    #endregion
                                    break;
                                case 1:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_12.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_13.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_14.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 4:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_21.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 5:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_22.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 6:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_23.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 7:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_24.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 8:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_31.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 9:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_32.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 10:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_33.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 11:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_34.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 12:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_41.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 13:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_42.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 14:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_43.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 15:
                                    #region setting image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_levelmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_levelmaterial_44.Image = img_Material[j];
                                            bool_find = true;
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Skill Material

                    #region text
                    text_Skill_RequireQuantity21.Text = fgo.Skill_RequireQuantity21;
                    text_Skill_RequireQuantity22.Text = fgo.Skill_RequireQuantity22;
                    text_Skill_RequireQuantity23.Text = fgo.Skill_RequireQuantity23;
                    text_Skill_RequireQuantity24.Text = fgo.Skill_RequireQuantity24;

                    text_Skill_RequireQuantity31.Text = fgo.Skill_RequireQuantity31;
                    text_Skill_RequireQuantity32.Text = fgo.Skill_RequireQuantity32;
                    text_Skill_RequireQuantity33.Text = fgo.Skill_RequireQuantity33;
                    text_Skill_RequireQuantity34.Text = fgo.Skill_RequireQuantity34;

                    text_Skill_RequireQuantity41.Text = fgo.Skill_RequireQuantity41;
                    text_Skill_RequireQuantity42.Text = fgo.Skill_RequireQuantity42;
                    text_Skill_RequireQuantity43.Text = fgo.Skill_RequireQuantity43;
                    text_Skill_RequireQuantity44.Text = fgo.Skill_RequireQuantity44;

                    text_Skill_RequireQuantity51.Text = fgo.Skill_RequireQuantity51;
                    text_Skill_RequireQuantity52.Text = fgo.Skill_RequireQuantity52;
                    text_Skill_RequireQuantity53.Text = fgo.Skill_RequireQuantity53;
                    text_Skill_RequireQuantity54.Text = fgo.Skill_RequireQuantity54;

                    text_Skill_RequireQuantity61.Text = fgo.Skill_RequireQuantity61;
                    text_Skill_RequireQuantity62.Text = fgo.Skill_RequireQuantity62;
                    text_Skill_RequireQuantity63.Text = fgo.Skill_RequireQuantity63;
                    text_Skill_RequireQuantity64.Text = fgo.Skill_RequireQuantity64;

                    text_Skill_RequireQuantity71.Text = fgo.Skill_RequireQuantity71;
                    text_Skill_RequireQuantity72.Text = fgo.Skill_RequireQuantity72;
                    text_Skill_RequireQuantity73.Text = fgo.Skill_RequireQuantity73;
                    text_Skill_RequireQuantity74.Text = fgo.Skill_RequireQuantity74;

                    text_Skill_RequireQuantity81.Text = fgo.Skill_RequireQuantity81;
                    text_Skill_RequireQuantity82.Text = fgo.Skill_RequireQuantity82;
                    text_Skill_RequireQuantity83.Text = fgo.Skill_RequireQuantity83;
                    text_Skill_RequireQuantity84.Text = fgo.Skill_RequireQuantity84;

                    text_Skill_RequireQuantity91.Text = fgo.Skill_RequireQuantity91;
                    text_Skill_RequireQuantity92.Text = fgo.Skill_RequireQuantity92;
                    text_Skill_RequireQuantity93.Text = fgo.Skill_RequireQuantity93;
                    text_Skill_RequireQuantity94.Text = fgo.Skill_RequireQuantity94;

                    text_Skill_RequireQuantity101.Text = fgo.Skill_RequireQuantity101;
                    text_Skill_RequireQuantity102.Text = fgo.Skill_RequireQuantity102;
                    text_Skill_RequireQuantity103.Text = fgo.Skill_RequireQuantity103;
                    text_Skill_RequireQuantity104.Text = fgo.Skill_RequireQuantity104;

                    text_Skill_QP2.Text = fgo.Skill_QP2;
                    text_Skill_QP3.Text = fgo.Skill_QP3;
                    text_Skill_QP4.Text = fgo.Skill_QP4;
                    text_Skill_QP5.Text = fgo.Skill_QP5;
                    text_Skill_QP6.Text = fgo.Skill_QP6;
                    text_Skill_QP7.Text = fgo.Skill_QP7;
                    text_Skill_QP8.Text = fgo.Skill_QP8;
                    text_Skill_QP9.Text = fgo.Skill_QP9;
                    text_Skill_QP10.Text = fgo.Skill_QP10;

                    #endregion

                    #region image
                    for (int i = 0; i < 36; i++)
                    {
                        if (str_skillmaterial[i] != null)
                        {
                            #region Switch
                            switch (i)
                            {
                                case 0:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material21.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 1:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material22.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material23.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material24.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 4:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material31.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 5:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material32.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 6:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material33.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 7:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material34.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 8:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material41.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 9:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material42.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 10:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material43.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 11:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material44.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 12:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material51.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 13:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material52.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 14:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material53.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 15:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material54.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 16:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material61.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 17:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material62.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 18:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material63.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 19:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material64.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 20:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material71.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 21:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material72.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 22:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material73.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 23:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material74.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 24:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material81.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 25:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material82.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 26:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material83.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 27:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material84.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 28:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material91.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 29:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material92.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 30:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material93.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 31:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material94.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 32:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material101.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 33:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material102.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 34:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material103.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 35:
                                    #region Setting Image
                                    for (int j = 0; j < str_Material.Length; j++)
                                    {
                                        if (str_skillmaterial[i].Equals(str_Material[j]))
                                        {
                                            pic_Skill_Material104.Image = img_Material[j];
                                            break;
                                        }
                                    }
                                    #endregion
                                    break;

                                default:
                                    break;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #endregion




                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Error:" + ex.ToString(), "Hint");
                }
            }

            progressBar2.Visible = false;
            t2.Abort();            
        }

        private void ProgressBar2_Run()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            progressBar2.Visible = true;
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            progressBar2.Value = 20;
            for(; ; )
            {
                if(progressBar2.Value>=100)
                {
                    progressBar2.Value = 0;
                }
                else
                {
                    progressBar2.Value++;
                    Thread.Sleep(20);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            t2.Abort();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNOServentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_add = new Form_Add_NoServents();
            form_add.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            textSkillEffect11.Text = "";
            textSkillEffect12.Text = "";
            textSkillEffect13.Text = "";
            textSkillEffect14.Text = "";
            textSkillEffect15.Text = "";
            textSkillEffect16.Text = "";
            textSkillEffect17.Text = "";
            textSkillEffect18.Text = "";
            textSkillEffect19.Text = "";
            textSkillEffect110.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textSkillEffect21.Text = "";
            textSkillEffect22.Text = "";
            textSkillEffect23.Text = "";
            textSkillEffect24.Text = "";
            textSkillEffect25.Text = "";
            textSkillEffect26.Text = "";
            textSkillEffect27.Text = "";
            textSkillEffect28.Text = "";
            textSkillEffect29.Text = "";
            textSkillEffect210.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textSkillEffect31.Text = "";
            textSkillEffect32.Text = "";
            textSkillEffect33.Text = "";
            textSkillEffect34.Text = "";
            textSkillEffect35.Text = "";
            textSkillEffect36.Text = "";
            textSkillEffect37.Text = "";
            textSkillEffect38.Text = "";
            textSkillEffect39.Text = "";
            textSkillEffect310.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            text_Skill_Describe1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            text_Skill_Describe2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            text_Skill_Describe3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //updateDataToolStripMenuItem_Click(object sender, EventArgs e)
            updateDataToolStripMenuItem_Click(this, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textNPdescribe.Text = null;
            textNPname1.Text = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textClassSkillDescribe01.Text = null;
            textClassSkillDescribe02.Text = null;
            textClassSkillDescribe03.Text = null;
            textClassSkillDescribe04.Text = null;
        }

        private void CleanQuantity()
        {
            text_Skill_RequireQuantity21.Text = null;
            text_Skill_RequireQuantity22.Text = null;
            text_Skill_RequireQuantity23.Text = null;
            text_Skill_RequireQuantity24.Text = null;
            text_Skill_RequireQuantity31.Text = null;
            text_Skill_RequireQuantity32.Text = null;
            text_Skill_RequireQuantity33.Text = null;
            text_Skill_RequireQuantity34.Text = null;
            text_Skill_RequireQuantity41.Text = null;
            text_Skill_RequireQuantity42.Text = null;
            text_Skill_RequireQuantity43.Text = null;
            text_Skill_RequireQuantity44.Text = null;
            text_Skill_RequireQuantity51.Text = null;
            text_Skill_RequireQuantity52.Text = null;
            text_Skill_RequireQuantity53.Text = null;
            text_Skill_RequireQuantity54.Text = null;
            text_Skill_RequireQuantity61.Text = null;
            text_Skill_RequireQuantity62.Text = null;
            text_Skill_RequireQuantity63.Text = null;
            text_Skill_RequireQuantity64.Text = null;
            text_Skill_RequireQuantity71.Text = null;
            text_Skill_RequireQuantity72.Text = null;
            text_Skill_RequireQuantity73.Text = null;
            text_Skill_RequireQuantity74.Text = null;
            text_Skill_RequireQuantity81.Text = null;
            text_Skill_RequireQuantity82.Text = null;
            text_Skill_RequireQuantity83.Text = null;
            text_Skill_RequireQuantity84.Text = null;
            text_Skill_RequireQuantity91.Text = null;
            text_Skill_RequireQuantity92.Text = null;
            text_Skill_RequireQuantity93.Text = null;
            text_Skill_RequireQuantity94.Text = null;
            text_Skill_RequireQuantity101.Text = "1";
            text_Skill_RequireQuantity102.Text = null;
            text_Skill_RequireQuantity103.Text = null;
            text_Skill_RequireQuantity104.Text = null;
            pic_Skill_Material101.Image = Properties.Resources.item_skill_00;
            pic_Skill_Material21.Image = null;
            pic_Skill_Material22.Image = null;
            pic_Skill_Material23.Image = null;
            pic_Skill_Material24.Image = null;
            pic_Skill_Material31.Image = null;
            pic_Skill_Material32.Image = null;
            pic_Skill_Material33.Image = null;
            pic_Skill_Material34.Image = null;
            pic_Skill_Material41.Image = null;
            pic_Skill_Material42.Image = null;
            pic_Skill_Material43.Image = null;
            pic_Skill_Material44.Image = null;
            pic_Skill_Material51.Image = null;
            pic_Skill_Material52.Image = null;
            pic_Skill_Material53.Image = null;
            pic_Skill_Material54.Image = null;
            pic_Skill_Material61.Image = null;
            pic_Skill_Material62.Image = null;
            pic_Skill_Material63.Image = null;
            pic_Skill_Material64.Image = null;
            pic_Skill_Material71.Image = null;
            pic_Skill_Material72.Image = null;
            pic_Skill_Material73.Image = null;
            pic_Skill_Material74.Image = null;
            pic_Skill_Material81.Image = null;
            pic_Skill_Material82.Image = null;
            pic_Skill_Material83.Image = null;
            pic_Skill_Material84.Image = null;
            pic_Skill_Material91.Image = null;
            pic_Skill_Material92.Image = null;
            pic_Skill_Material93.Image = null;
            pic_Skill_Material94.Image = null;
            pic_Skill_Material102.Image = null;
            pic_Skill_Material103.Image = null;
            pic_Skill_Material104.Image = null;
            pic_levelmaterial_11.Image = null;
            pic_levelmaterial_12.Image = null;
            pic_levelmaterial_13.Image = null;
            pic_levelmaterial_14.Image = null;
            pic_levelmaterial_21.Image = null;
            pic_levelmaterial_22.Image = null;
            pic_levelmaterial_23.Image = null;
            pic_levelmaterial_24.Image = null;
            pic_levelmaterial_31.Image = null;
            pic_levelmaterial_32.Image = null;
            pic_levelmaterial_33.Image = null;
            pic_levelmaterial_34.Image = null;
            pic_levelmaterial_41.Image = null;
            pic_levelmaterial_42.Image = null;
            pic_levelmaterial_43.Image = null;
            pic_levelmaterial_44.Image = null;

        }
        private void button10_Click(object sender, EventArgs e)
        {
            text_levelmaterialQP1.Text = "10,000";
            text_levelmaterialQP2.Text = "30,000";
            text_levelmaterialQP3.Text = "90,000";
            text_levelmaterialQP4.Text = "300,000";

            text_Skill_QP2.Text = "10,000";
            text_Skill_QP3.Text = "20,000";
            text_Skill_QP4.Text = "60,000";
            text_Skill_QP5.Text = "80,000";
            text_Skill_QP6.Text = "200,000";
            text_Skill_QP7.Text = "250,000";
            text_Skill_QP8.Text = "500,000";
            text_Skill_QP9.Text = "600,000";
            text_Skill_QP10.Text = "1,000,000";
            CleanQuantity();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            text_levelmaterialQP1.Text = "15,000";
            text_levelmaterialQP2.Text = "45,000";
            text_levelmaterialQP3.Text = "150,000";
            text_levelmaterialQP4.Text = "450,000";

            text_Skill_QP2.Text = "20,000";
            text_Skill_QP3.Text = "40,000";
            text_Skill_QP4.Text = "120,000";
            text_Skill_QP5.Text = "160,000";
            text_Skill_QP6.Text = "400,000";
            text_Skill_QP7.Text = "500,000";
            text_Skill_QP8.Text = "1,000,000";
            text_Skill_QP9.Text = "1,200,000";
            text_Skill_QP10.Text = "2,000,000";
            CleanQuantity();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            text_levelmaterialQP1.Text = "50,000";
            text_levelmaterialQP2.Text = "100,000";
            text_levelmaterialQP3.Text = "300,000";
            text_levelmaterialQP4.Text = "900,000";

            text_Skill_QP2.Text = "50,000";
            text_Skill_QP3.Text = "100,000";
            text_Skill_QP4.Text = "300,000";
            text_Skill_QP5.Text = "400,000";
            text_Skill_QP6.Text = "1,000,000";
            text_Skill_QP7.Text = "1,250,000";
            text_Skill_QP8.Text = "2,500,000";
            text_Skill_QP9.Text = "3,000,000";
            text_Skill_QP10.Text = "5,000,000";
            CleanQuantity();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            text_levelmaterialQP1.Text = "50,000";
            text_levelmaterialQP2.Text = "150,000";
            text_levelmaterialQP3.Text = "500,000";
            text_levelmaterialQP4.Text = "1,500,000";

            text_Skill_QP2.Text = "100,000";
            text_Skill_QP3.Text = "200,000";
            text_Skill_QP4.Text = "600,000";
            text_Skill_QP5.Text = "800,000";
            text_Skill_QP6.Text = "2,000,000";
            text_Skill_QP7.Text = "2,500,000";
            text_Skill_QP8.Text = "5,000,000";
            text_Skill_QP9.Text = "6,200,000";
            text_Skill_QP10.Text = "10,000,000";
            CleanQuantity();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            text_levelmaterialQP1.Text = "100,000";
            text_levelmaterialQP2.Text = "300,000";
            text_levelmaterialQP3.Text = "1,000,000";
            text_levelmaterialQP4.Text = "3,000,000";

            text_Skill_QP2.Text = "200,000";
            text_Skill_QP3.Text = "400,000";
            text_Skill_QP4.Text = "1,200,000";
            text_Skill_QP5.Text = "1,600,000";
            text_Skill_QP6.Text = "4,000,000";
            text_Skill_QP7.Text = "5,000,000";
            text_Skill_QP8.Text = "10,000,000";
            text_Skill_QP9.Text = "12,000,000";
            text_Skill_QP10.Text = "20,000,000";
            CleanQuantity();
        }
    }
}




