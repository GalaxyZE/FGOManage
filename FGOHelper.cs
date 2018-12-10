using System;
using System.Collections.Generic;

namespace FateGrandOrder_Data_Helper
{
    class FGOHelper
    {
        public struct FGOHelperS
        {
            public String NameCH { get; set; }
            public String NameEN { get; set; }

            public String NameJP { get; set; }
            public String NameChina { get; set; }            
            public int Rarity { get; set; }
            public int servantClass { get; set; }
            public int StatusATKLV1 { get; set; }
            public int Status_HPLV1 { get; set; }
            public int StatusATKFinal { get; set; }
            public int Status_HPFinal { get; set; }
            public int StatusATKLV100 { get; set; }
            public int Status_HPLV100 { get; set; }
            public int COST { get; set; }
            public int MAX_LV { get; set; }            

            public String Class_Describe1 { get; set; }
            public String Class_Describe2 { get; set; }
            public String Class_Describe3 { get; set; }
            public String Class_Describe4 { get; set; }

            public int Command_Buster { get; set; }
            public int Command_Arts { get; set; }
            public int Command_Quick { get; set; }

            



            //region image
            public int img_ClassSkill01 { get; set; }
            public int img_ClassSkill02 { get; set; }
            public int img_ClassSkill03 { get; set; }
            public int img_ClassSkill04 { get; set; }
            
            public int img_Skill01 { get; set; }
            public int img_Skill02 { get; set; }
            public int img_Skill03 { get; set; }
            //image Done

            //Skill
            public String Skill_Describe1 { get; set; }
            public String Skill_Describe2 { get; set; }
            public String Skill_Describe3 { get; set; }
            public String Skill_Describe4 { get; set; }
            public String Skill_Describe5 { get; set; }
            public String Skill_Describe6 { get; set; }

            public String Skill_1_Effect1 { get; set; }
            public String Skill_1_Effect2 { get; set; }
            public String Skill_1_Effect3 { get; set; }
            public String Skill_1_Effect4 { get; set; }
            public String Skill_1_Effect5 { get; set; }
            public String Skill_1_Effect6 { get; set; }
            public String Skill_1_Effect7 { get; set; }
            public String Skill_1_Effect8 { get; set; }
            public String Skill_1_Effect9 { get; set; }
            public String Skill_1_Effect10 { get; set; }

            public String Skill_2_Effect1 { get; set; }
            public String Skill_2_Effect2 { get; set; }
            public String Skill_2_Effect3 { get; set; }
            public String Skill_2_Effect4 { get; set; }
            public String Skill_2_Effect5 { get; set; }
            public String Skill_2_Effect6 { get; set; }
            public String Skill_2_Effect7 { get; set; }
            public String Skill_2_Effect8 { get; set; }
            public String Skill_2_Effect9 { get; set; }
            public String Skill_2_Effect10 { get; set; }
            public String Skill_3_Effect1 { get; set; }
            public String Skill_3_Effect2 { get; set; }
            public String Skill_3_Effect3 { get; set; }
            public String Skill_3_Effect4 { get; set; }
            public String Skill_3_Effect5 { get; set; }
            public String Skill_3_Effect6 { get; set; }
            public String Skill_3_Effect7 { get; set; }
            public String Skill_3_Effect8 { get; set; }
            public String Skill_3_Effect9 { get; set; }
            public String Skill_3_Effect10 { get; set; }
            //Skill Done

            //NP
            public int NP_CardColor { get; set; }

            public String NP_Name1 { get; set; }

            public String NP_Describe { get; set; }
            
            public String NP_Describe_Rank1 { get; set; }
            public String NP_Describe_Target { get; set; }
            public String NP_1_Effect1 { get; set; }
            public String NP_1_Effect2 { get; set; }
            public String NP_1_Effect3 { get; set; }
            public String NP_1_Effect4 { get; set; }
            public String NP_1_Effect5 { get; set; }
            public String NP_Name2 { get; set; }
            public String NP_Rank2 { get; set; }
            public String NP_2_Effect1 { get; set; }
            public String NP_2_Effect2 { get; set; }
            public String NP_2_Effect3 { get; set; }
            public String NP_2_Effect4 { get; set; }
            public String NP_2_Effect5 { get; set; }
            //NP Done

            //Level UP Material
            public String LevelMaterial_11 { get; set; }
            public String LevelMaterial_12 { get; set; }
            public String LevelMaterial_13 { get; set; }
            public String LevelMaterial_14 { get; set; }

            public String RequireQuantity11 { get; set; }
            public String RequireQuantity12 { get; set; }
            public String RequireQuantity13 { get; set; }
            public String RequireQuantity14 { get; set; }

            public String LevelMaterial_21 { get; set; }
            public String LevelMaterial_22 { get; set; }
            public String LevelMaterial_23 { get; set; }
            public String LevelMaterial_24 { get; set; }

            public String RequireQuantity21 { get; set; }
            public String RequireQuantity22 { get; set; }
            public String RequireQuantity23 { get; set; }
            public String RequireQuantity24 { get; set; }

            public String LevelMaterial_31 { get; set; }
            public String LevelMaterial_32 { get; set; }
            public String LevelMaterial_33 { get; set; }
            public String LevelMaterial_34 { get; set; }

            public String RequireQuantity31 { get; set; }
            public String RequireQuantity32 { get; set; }
            public String RequireQuantity33 { get; set; }
            public String RequireQuantity34 { get; set; }

            public String LevelMaterial_41 { get; set; }
            public String LevelMaterial_42 { get; set; }
            public String LevelMaterial_43 { get; set; }
            public String LevelMaterial_44 { get; set; }

            public String RequireQuantity41 { get; set; }
            public String RequireQuantity42 { get; set; }
            public String RequireQuantity43 { get; set; }
            public String RequireQuantity44 { get; set; }

            public String LevelMaterialQP_1 { get; set; }
            public String LevelMaterialQP_2 { get; set; }
            public String LevelMaterialQP_3 { get; set; }
            public String LevelMaterialQP_4 { get; set; }
            //Done

            //Skill Required Material 
            public String Skill_Material21 { get; set; }
            public String Skill_Material31 { get; set; }
            public String Skill_Material41 { get; set; }
            public String Skill_Material51 { get; set; }
            public String Skill_Material61 { get; set; }
            public String Skill_Material71 { get; set; }
            public String Skill_Material81 { get; set; }
            public String Skill_Material91 { get; set; }
            public String Skill_Material101 { get; set; }

            public String Skill_Material22 { get; set; }
            public String Skill_Material32 { get; set; }
            public String Skill_Material42 { get; set; }
            public String Skill_Material52 { get; set; }
            public String Skill_Material62 { get; set; }
            public String Skill_Material72 { get; set; }
            public String Skill_Material82 { get; set; }
            public String Skill_Material92 { get; set; }
            public String Skill_Material102 { get; set; }

            public String Skill_Material23 { get; set; }
            public String Skill_Material33 { get; set; }
            public String Skill_Material43 { get; set; }
            public String Skill_Material53 { get; set; }
            public String Skill_Material63 { get; set; }
            public String Skill_Material73 { get; set; }
            public String Skill_Material83 { get; set; }
            public String Skill_Material93 { get; set; }
            public String Skill_Material103 { get; set; }

            public String Skill_Material24 { get; set; }
            public String Skill_Material34 { get; set; }
            public String Skill_Material44 { get; set; }
            public String Skill_Material54 { get; set; }
            public String Skill_Material64 { get; set; }
            public String Skill_Material74 { get; set; }
            public String Skill_Material84 { get; set; }
            public String Skill_Material94 { get; set; }
            public String Skill_Material104 { get; set; }

            public String Skill_QP2 { get; set; }
            public String Skill_QP3 { get; set; }
            public String Skill_QP4 { get; set; }
            public String Skill_QP5 { get; set; }
            public String Skill_QP6 { get; set; }
            public String Skill_QP7 { get; set; }
            public String Skill_QP8 { get; set; }
            public String Skill_QP9 { get; set; }
            public String Skill_QP10 { get; set; }

            public String Skill_RequireQuantity21 { get; set; }
            public String Skill_RequireQuantity31 { get; set; }
            public String Skill_RequireQuantity41 { get; set; }
            public String Skill_RequireQuantity51 { get; set; }
            public String Skill_RequireQuantity61 { get; set; }
            public String Skill_RequireQuantity71 { get; set; }
            public String Skill_RequireQuantity81 { get; set; }
            public String Skill_RequireQuantity91 { get; set; }
            public String Skill_RequireQuantity101 { get; set; }

            public String Skill_RequireQuantity22 { get; set; }
            public String Skill_RequireQuantity32 { get; set; }
            public String Skill_RequireQuantity42 { get; set; }
            public String Skill_RequireQuantity52 { get; set; }
            public String Skill_RequireQuantity62 { get; set; }
            public String Skill_RequireQuantity72 { get; set; }
            public String Skill_RequireQuantity82 { get; set; }
            public String Skill_RequireQuantity92 { get; set; }
            public String Skill_RequireQuantity102 { get; set; }

            public String Skill_RequireQuantity23 { get; set; }
            public String Skill_RequireQuantity33 { get; set; }
            public String Skill_RequireQuantity43 { get; set; }
            public String Skill_RequireQuantity53 { get; set; }
            public String Skill_RequireQuantity63 { get; set; }
            public String Skill_RequireQuantity73 { get; set; }
            public String Skill_RequireQuantity83 { get; set; }
            public String Skill_RequireQuantity93 { get; set; }
            public String Skill_RequireQuantity103 { get; set; }

            public String Skill_RequireQuantity24 { get; set; }
            public String Skill_RequireQuantity34 { get; set; }
            public String Skill_RequireQuantity44 { get; set; }
            public String Skill_RequireQuantity54 { get; set; }
            public String Skill_RequireQuantity64 { get; set; }
            public String Skill_RequireQuantity74 { get; set; }
            public String Skill_RequireQuantity84 { get; set; }
            public String Skill_RequireQuantity94 { get; set; }
            public String Skill_RequireQuantity104 { get; set; }            
        }
    }

    class FGOWeekQuest
    {
        public String NO_1 { get; set; }
        public String NO_2{ get; set; }
        public String NO_3 { get; set; }
        public String NO_4 { get; set; }
        public String NO_5 { get; set; }
        public String NO_6 { get; set; }
        public String NO_7 { get; set; }

    }
}


