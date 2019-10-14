using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPC.NPCs;
using AlchemistNPC.Items.Misc;

namespace AlchemistNPC.Interface
{
	class DimensionalCasketUI : UIState
	{
		Mod mod = ModLoader.GetMod("AlchemistNPC");
		public static bool forcetalk = false;
		public static int k = -1;
		public UIPanel DimensionalCasketPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			DimensionalCasketPanel = new UIPanel();
			DimensionalCasketPanel.SetPadding(0);
			DimensionalCasketPanel.Left.Set(600f, 0f);
			DimensionalCasketPanel.Top.Set(150f, 0f);
			DimensionalCasketPanel.Width.Set(430f, 0f);
			DimensionalCasketPanel.Height.Set(520f, 0f);
			DimensionalCasketPanel.BackgroundColor = new Color(73, 94, 171);

			DimensionalCasketPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			DimensionalCasketPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			string ArmsDealer; 
			string Merchant; 
			string Demolitionist; 
			string Dryad; 
			string Painter; 
			string DyeTrader; 
			string GoblinTinkerer; 
			string Mechanic; 
			string Steampunker; 
			string Wizard;
			string WitchDoctor;
			string Cyborg;
			string Pirate;
			string Clothier;
			string Truffle;
			string Stylist;
			string PartyGirl;
			string Alchemist;
			string Brewer;
			string Architect;
			string Architect1;
			string Operator;
			string Jeweler;
			string YoungBrewer;
			string Musician;
			string Explorer;

			if(Language.ActiveCulture == GameCulture.Chinese)
				{
					ArmsDealer = "军火商";
					Merchant = "商人";
					Demolitionist = "爆破专家";
					Dryad = "树妖";
					Painter = "画家";
					DyeTrader = "染料商";
					GoblinTinkerer = "哥布林工匠";
					Mechanic = "机械师/电工";
					Steampunker = "蒸汽朋克人";
					Wizard = "魔法师";
					WitchDoctor = "巫医";
					Cyborg = "电子人";
					Pirate = "海盗";
					Clothier = "服装商";
					Truffle = "松露人";
					Stylist = "美发师";
					PartyGirl = "派对女孩";
					Alchemist = "炼金师";
					Brewer = "药剂师";
					Architect = "建筑师";
					Architect1 = "商店";
					Operator = "操作员";
					Jeweler = "珠宝商";
					YoungBrewer = "年轻药剂师";
					Musician = "音乐家";
					Explorer = "探险家";
				}
			else
				{
					ArmsDealer = "Arms Dealer";
					Merchant = "Merchant";
					Demolitionist = "Demolitionist";
					Dryad = "Dryad";
					Painter = "Painter";
					DyeTrader = "Dye Trader";
					GoblinTinkerer = "Goblin Tinkerer";
					Mechanic = "Mechanic";
					Steampunker = "Steampunker";
					Wizard = "Wizard";
					WitchDoctor = "Witch Doctor";
					Cyborg = "Cyborg";
					Pirate = "Pirate";
					Clothier = "Clothier";
					Truffle = "Truffle";
					Stylist = "Stylist";
					PartyGirl = "Party Girl";
					Alchemist = "Alchemist";
					Brewer = "Brewer";
					Architect = "Architect";
					Architect1 = "Shops";
					Operator = "Operator";
					Jeweler = "Jeweler";
					YoungBrewer = "Young Brewer";
					Musician = "Musician";
					Explorer = "Explorer";
				}
			
			UIText text = new UIText(ArmsDealer);
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text);
			
			UIText text2 = new UIText(Merchant);
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(50, 0f);
			text2.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text2);
			
			UIText text3 = new UIText(Demolitionist);
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(65, 0f);
			text3.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text3);
			
			UIText text4 = new UIText(Dryad);
			text4.Left.Set(35, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(50, 0f);
			text4.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text4);
			
			UIText text5 = new UIText(Painter);
			text5.Left.Set(35, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(55, 0f);
			text5.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text5);
			
			UIText text6 = new UIText(DyeTrader);
			text6.Left.Set(35, 0f);
			text6.Top.Set(160, 0f);
			text6.Width.Set(60, 0f);
			text6.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text6);
			
			UIText text7 = new UIText(GoblinTinkerer);
			text7.Left.Set(75, 0f);
			text7.Top.Set(190, 0f);
			text7.Width.Set(80, 0f);
			text7.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text7);
			
			UIText text8 = new UIText(Mechanic);
			text8.Left.Set(35, 0f);
			text8.Top.Set(220, 0f);
			text8.Width.Set(55, 0f);
			text8.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text8);
			
			UIText text9 = new UIText(Steampunker);
			text9.Left.Set(35, 0f);
			text9.Top.Set(250, 0f);
			text9.Width.Set(60, 0f);
			text9.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text9);
			
			UIText text10 = new UIText(Wizard);
			text10.Left.Set(35, 0f);
			text10.Top.Set(280, 0f);
			text10.Width.Set(50, 0f);
			text10.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text10);
			
			UIText text11 = new UIText(WitchDoctor);
			text11.Left.Set(35, 0f);
			text11.Top.Set(310, 0f);
			text11.Width.Set(60, 0f);
			text11.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text11);
			
			UIText text12 = new UIText(Cyborg);
			text12.Left.Set(35, 0f);
			text12.Top.Set(340, 0f);
			text12.Width.Set(60, 0f);
			text12.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text12);
			
			UIText text13 = new UIText(Pirate);
			text13.Left.Set(35, 0f);
			text13.Top.Set(370, 0f);
			text13.Width.Set(55, 0f);
			text13.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text13);
			
			UIText text14 = new UIText(Clothier);
			text14.Left.Set(35, 0f);
			text14.Top.Set(400, 0f);
			text14.Width.Set(60, 0f);
			text14.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text14);
			
			UIText text15 = new UIText(Truffle);
			text15.Left.Set(35, 0f);
			text15.Top.Set(430, 0f);
			text15.Width.Set(60, 0f);
			text15.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text15);
			
			UIText text16 = new UIText(Stylist);
			text16.Left.Set(70, 0f);
			text16.Top.Set(460, 0f);
			text16.Width.Set(55, 0f);
			text16.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text16);
			
			UIText text17 = new UIText(PartyGirl);
			text17.Left.Set(35, 0f);
			text17.Top.Set(490, 0f);
			text17.Width.Set(70, 0f);
			text17.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text17);
			
			UIText text18 = new UIText(Alchemist);
			text18.Left.Set(180, 0f);
			text18.Top.Set(10, 0f);
			text18.Width.Set(70, 0f);
			text18.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text18);
			
			UIText text19 = new UIText(Brewer);
			text19.Left.Set(330, 0f);
			text19.Top.Set(40, 0f);
			text19.Width.Set(55, 0f);
			text19.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text19);
			
			UIText text20 = new UIText(Architect);
			text20.Left.Set(300, 0f);
			text20.Top.Set(70, 0f);
			text20.Width.Set(65, 0f);
			text20.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text20);
			UIText text201 = new UIText(Architect1);
			text201.Left.Set(305, 0f);
			text201.Top.Set(100, 0f);
			text201.Width.Set(50, 0f);
			text201.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text201);
			
			UIText text21 = new UIText(Operator);
			text21.Left.Set(300, 0f);
			text21.Top.Set(130, 0f);
			text21.Width.Set(60, 0f);
			text21.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text21);
			
			UIText text22 = new UIText(Jeweler);
			text22.Left.Set(210, 0f);
			text22.Top.Set(160, 0f);
			text22.Width.Set(60, 0f);
			text22.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text22);
			
			UIText text23 = new UIText(YoungBrewer);
			text23.Left.Set(270, 0f);
			text23.Top.Set(190, 0f);
			text23.Width.Set(100, 0f);
			text23.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text23);
			
			UIText text24 = new UIText(Musician);
			text24.Left.Set(240, 0f);
			text24.Top.Set(220, 0f);
			text24.Width.Set(65, 0f);
			text24.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text24);
			
			UIText text25 = new UIText(Explorer);
			text25.Left.Set(180, 0f);
			text25.Top.Set(250, 0f);
			text25.Width.Set(60, 0f);
			text25.Height.Set(22, 0f);
			DimensionalCasketPanel.Append(text25);

			Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			DimensionalCasketPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			DimensionalCasketPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			DimensionalCasketPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			DimensionalCasketPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			DimensionalCasketPanel.Append(playButton5);
			UIImageButton playButton6 = new UIImageButton(buttonPlayTexture);
			playButton6.Left.Set(10, 0f);
			playButton6.Top.Set(160, 0f);
			playButton6.Width.Set(22, 0f);
			playButton6.Height.Set(22, 0f);
			playButton6.OnClick += new MouseEvent(PlayButtonClicked6);
			DimensionalCasketPanel.Append(playButton6);
			UIImageButton playButton7 = new UIImageButton(buttonPlayTexture);
			playButton7.Left.Set(10, 0f);
			playButton7.Top.Set(190, 0f);
			playButton7.Width.Set(22, 0f);
			playButton7.Height.Set(22, 0f);
			playButton7.OnClick += new MouseEvent(PlayButtonClicked7);
			DimensionalCasketPanel.Append(playButton7);
			UIImageButton playButton7R = new UIImageButton(buttonPlayTexture);
			playButton7R.Left.Set(40, 0f);
			playButton7R.Top.Set(190, 0f);
			playButton7R.Width.Set(22, 0f);
			playButton7R.Height.Set(22, 0f);
			playButton7R.OnClick += new MouseEvent(PlayButtonClicked7R);
			DimensionalCasketPanel.Append(playButton7R);
			UIImageButton playButton8 = new UIImageButton(buttonPlayTexture);
			playButton8.Left.Set(10, 0f);
			playButton8.Top.Set(220, 0f);
			playButton8.Width.Set(22, 0f);
			playButton8.Height.Set(22, 0f);
			playButton8.OnClick += new MouseEvent(PlayButtonClicked8);
			DimensionalCasketPanel.Append(playButton8);
			UIImageButton playButton9 = new UIImageButton(buttonPlayTexture);
			playButton9.Left.Set(10, 0f);
			playButton9.Top.Set(250, 0f);
			playButton9.Width.Set(22, 0f);
			playButton9.Height.Set(22, 0f);
			playButton9.OnClick += new MouseEvent(PlayButtonClicked9);
			DimensionalCasketPanel.Append(playButton9);
			UIImageButton playButton10 = new UIImageButton(buttonPlayTexture);
			playButton10.Left.Set(10, 0f);
			playButton10.Top.Set(280, 0f);
			playButton10.Width.Set(22, 0f);
			playButton10.Height.Set(22, 0f);
			playButton10.OnClick += new MouseEvent(PlayButtonClicked10);
			DimensionalCasketPanel.Append(playButton10);
			UIImageButton playButton11 = new UIImageButton(buttonPlayTexture);
			playButton11.Left.Set(10, 0f);
			playButton11.Top.Set(310, 0f);
			playButton11.Width.Set(22, 0f);
			playButton11.Height.Set(22, 0f);
			playButton11.OnClick += new MouseEvent(PlayButtonClicked11);
			DimensionalCasketPanel.Append(playButton11);
			UIImageButton playButton12 = new UIImageButton(buttonPlayTexture);
			playButton12.Left.Set(10, 0f);
			playButton12.Top.Set(340, 0f);
			playButton12.Width.Set(22, 0f);
			playButton12.Height.Set(22, 0f);
			playButton12.OnClick += new MouseEvent(PlayButtonClicked12);
			DimensionalCasketPanel.Append(playButton12);
			UIImageButton playButton13 = new UIImageButton(buttonPlayTexture);
			playButton13.Left.Set(10, 0f);
			playButton13.Top.Set(370, 0f);
			playButton13.Width.Set(22, 0f);
			playButton13.Height.Set(22, 0f);
			playButton13.OnClick += new MouseEvent(PlayButtonClicked13);
			DimensionalCasketPanel.Append(playButton13);
			UIImageButton playButton14 = new UIImageButton(buttonPlayTexture);
			playButton14.Left.Set(10, 0f);
			playButton14.Top.Set(400, 0f);
			playButton14.Width.Set(22, 0f);
			playButton14.Height.Set(22, 0f);
			playButton14.OnClick += new MouseEvent(PlayButtonClicked14);
			DimensionalCasketPanel.Append(playButton14);
			UIImageButton playButton15 = new UIImageButton(buttonPlayTexture);
			playButton15.Left.Set(10, 0f);
			playButton15.Top.Set(430, 0f);
			playButton15.Width.Set(22, 0f);
			playButton15.Height.Set(22, 0f);
			playButton15.OnClick += new MouseEvent(PlayButtonClicked15);
			DimensionalCasketPanel.Append(playButton15);
			UIImageButton playButton16 = new UIImageButton(buttonPlayTexture);
			playButton16.Left.Set(10, 0f);
			playButton16.Top.Set(460, 0f);
			playButton16.Width.Set(22, 0f);
			playButton16.Height.Set(22, 0f);
			playButton16.OnClick += new MouseEvent(PlayButtonClicked16);
			DimensionalCasketPanel.Append(playButton16);
			UIImageButton playButton16R = new UIImageButton(buttonPlayTexture);
			playButton16R.Left.Set(40, 0f);
			playButton16R.Top.Set(460, 0f);
			playButton16R.Width.Set(22, 0f);
			playButton16R.Height.Set(22, 0f);
			playButton16R.OnClick += new MouseEvent(PlayButtonClicked16R);
			DimensionalCasketPanel.Append(playButton16R);
			UIImageButton playButton17 = new UIImageButton(buttonPlayTexture);
			playButton17.Left.Set(10, 0f);
			playButton17.Top.Set(490, 0f);
			playButton17.Width.Set(22, 0f);
			playButton17.Height.Set(22, 0f);
			playButton17.OnClick += new MouseEvent(PlayButtonClicked17);
			DimensionalCasketPanel.Append(playButton17);
			UIImageButton playButton18 = new UIImageButton(buttonPlayTexture);
			playButton18.Left.Set(150, 0f);
			playButton18.Top.Set(10, 0f);
			playButton18.Width.Set(22, 0f);
			playButton18.Height.Set(22, 0f);
			playButton18.OnClick += new MouseEvent(PlayButtonClicked18);
			DimensionalCasketPanel.Append(playButton18);
			
			UIImageButton playButton191 = new UIImageButton(buttonPlayTexture);
			playButton191.Left.Set(150, 0f);
			playButton191.Top.Set(40, 0f);
			playButton191.Width.Set(22, 0f);
			playButton191.Height.Set(22, 0f);
			playButton191.OnClick += new MouseEvent(PlayButtonClicked191);
			DimensionalCasketPanel.Append(playButton191);
			UIImageButton playButton192 = new UIImageButton(buttonPlayTexture);
			playButton192.Left.Set(180, 0f);
			playButton192.Top.Set(40, 0f);
			playButton192.Width.Set(22, 0f);
			playButton192.Height.Set(22, 0f);
			playButton192.OnClick += new MouseEvent(PlayButtonClicked192);
			DimensionalCasketPanel.Append(playButton192);
			UIImageButton playButton1921 = new UIImageButton(buttonPlayTexture);
			playButton1921.Left.Set(210, 0f);
			playButton1921.Top.Set(40, 0f);
			playButton1921.Width.Set(22, 0f);
			playButton1921.Height.Set(22, 0f);
			playButton1921.OnClick += new MouseEvent(PlayButtonClicked1921);
			DimensionalCasketPanel.Append(playButton1921);
			UIImageButton playButton193 = new UIImageButton(buttonPlayTexture);
			playButton193.Left.Set(240, 0f);
			playButton193.Top.Set(40, 0f);
			playButton193.Width.Set(22, 0f);
			playButton193.Height.Set(22, 0f);
			playButton193.OnClick += new MouseEvent(PlayButtonClicked193);
			DimensionalCasketPanel.Append(playButton193);
			UIImageButton playButton194 = new UIImageButton(buttonPlayTexture);
			playButton194.Left.Set(270, 0f);
			playButton194.Top.Set(40, 0f);
			playButton194.Width.Set(22, 0f);
			playButton194.Height.Set(22, 0f);
			playButton194.OnClick += new MouseEvent(PlayButtonClicked194);
			DimensionalCasketPanel.Append(playButton194);
			UIImageButton playButton195 = new UIImageButton(buttonPlayTexture);
			playButton195.Left.Set(300, 0f);
			playButton195.Top.Set(40, 0f);
			playButton195.Width.Set(22, 0f);
			playButton195.Height.Set(22, 0f);
			playButton195.OnClick += new MouseEvent(PlayButtonClicked195);
			DimensionalCasketPanel.Append(playButton195);
			
			UIImageButton playButton201 = new UIImageButton(buttonPlayTexture);
			playButton201.Left.Set(150, 0f);
			playButton201.Top.Set(70, 0f);
			playButton201.Width.Set(22, 0f);
			playButton201.Height.Set(22, 0f);
			playButton201.OnClick += new MouseEvent(PlayButtonClicked201);
			DimensionalCasketPanel.Append(playButton201);
			UIImageButton playButton202 = new UIImageButton(buttonPlayTexture);
			playButton202.Left.Set(180, 0f);
			playButton202.Top.Set(70, 0f);
			playButton202.Width.Set(22, 0f);
			playButton202.Height.Set(22, 0f);
			playButton202.OnClick += new MouseEvent(PlayButtonClicked202);
			DimensionalCasketPanel.Append(playButton202);
			UIImageButton playButton203 = new UIImageButton(buttonPlayTexture);
			playButton203.Left.Set(210, 0f);
			playButton203.Top.Set(70, 0f);
			playButton203.Width.Set(22, 0f);
			playButton203.Height.Set(22, 0f);
			playButton203.OnClick += new MouseEvent(PlayButtonClicked203);
			DimensionalCasketPanel.Append(playButton203);
			UIImageButton playButton204 = new UIImageButton(buttonPlayTexture);
			playButton204.Left.Set(240, 0f);
			playButton204.Top.Set(70, 0f);
			playButton204.Width.Set(22, 0f);
			playButton204.Height.Set(22, 0f);
			playButton204.OnClick += new MouseEvent(PlayButtonClicked204);
			DimensionalCasketPanel.Append(playButton204);
			UIImageButton playButton205 = new UIImageButton(buttonPlayTexture);
			playButton205.Left.Set(270, 0f);
			playButton205.Top.Set(70, 0f);
			playButton205.Width.Set(22, 0f);
			playButton205.Height.Set(22, 0f);
			playButton205.OnClick += new MouseEvent(PlayButtonClicked205);
			DimensionalCasketPanel.Append(playButton205);
			UIImageButton playButton206 = new UIImageButton(buttonPlayTexture);
			playButton206.Left.Set(150, 0f);
			playButton206.Top.Set(100, 0f);
			playButton206.Width.Set(22, 0f);
			playButton206.Height.Set(22, 0f);
			playButton206.OnClick += new MouseEvent(PlayButtonClicked206);
			DimensionalCasketPanel.Append(playButton206);
			UIImageButton playButton207 = new UIImageButton(buttonPlayTexture);
			playButton207.Left.Set(180, 0f);
			playButton207.Top.Set(100, 0f);
			playButton207.Width.Set(22, 0f);
			playButton207.Height.Set(22, 0f);
			playButton207.OnClick += new MouseEvent(PlayButtonClicked207);
			DimensionalCasketPanel.Append(playButton207);
			UIImageButton playButton208 = new UIImageButton(buttonPlayTexture);
			playButton208.Left.Set(210, 0f);
			playButton208.Top.Set(100, 0f);
			playButton208.Width.Set(22, 0f);
			playButton208.Height.Set(22, 0f);
			playButton208.OnClick += new MouseEvent(PlayButtonClicked208);
			DimensionalCasketPanel.Append(playButton208);
			UIImageButton playButton209 = new UIImageButton(buttonPlayTexture);
			playButton209.Left.Set(240, 0f);
			playButton209.Top.Set(100, 0f);
			playButton209.Width.Set(22, 0f);
			playButton209.Height.Set(22, 0f);
			playButton209.OnClick += new MouseEvent(PlayButtonClicked209);
			DimensionalCasketPanel.Append(playButton209);
			UIImageButton playButton210 = new UIImageButton(buttonPlayTexture);
			playButton210.Left.Set(270, 0f);
			playButton210.Top.Set(100, 0f);
			playButton210.Width.Set(22, 0f);
			playButton210.Height.Set(22, 0f);
			playButton210.OnClick += new MouseEvent(PlayButtonClicked210);
			DimensionalCasketPanel.Append(playButton210);
			
			UIImageButton playButton211 = new UIImageButton(buttonPlayTexture);
			playButton211.Left.Set(150, 0f);
			playButton211.Top.Set(130, 0f);
			playButton211.Width.Set(22, 0f);
			playButton211.Height.Set(22, 0f);
			playButton211.OnClick += new MouseEvent(PlayButtonClicked211);
			DimensionalCasketPanel.Append(playButton211);
			UIImageButton playButton212 = new UIImageButton(buttonPlayTexture);
			playButton212.Left.Set(180, 0f);
			playButton212.Top.Set(130, 0f);
			playButton212.Width.Set(22, 0f);
			playButton212.Height.Set(22, 0f);
			playButton212.OnClick += new MouseEvent(PlayButtonClicked212);
			DimensionalCasketPanel.Append(playButton212);
			UIImageButton playButton213 = new UIImageButton(buttonPlayTexture);
			playButton213.Left.Set(210, 0f);
			playButton213.Top.Set(130, 0f);
			playButton213.Width.Set(22, 0f);
			playButton213.Height.Set(22, 0f);
			playButton213.OnClick += new MouseEvent(PlayButtonClicked213);
			DimensionalCasketPanel.Append(playButton213);
			UIImageButton playButton214 = new UIImageButton(buttonPlayTexture);
			playButton214.Left.Set(240, 0f);
			playButton214.Top.Set(130, 0f);
			playButton214.Width.Set(22, 0f);
			playButton214.Height.Set(22, 0f);
			playButton214.OnClick += new MouseEvent(PlayButtonClicked214);
			DimensionalCasketPanel.Append(playButton214);
			UIImageButton playButton215 = new UIImageButton(buttonPlayTexture);
			playButton215.Left.Set(270, 0f);
			playButton215.Top.Set(130, 0f);
			playButton215.Width.Set(22, 0f);
			playButton215.Height.Set(22, 0f);
			playButton215.OnClick += new MouseEvent(PlayButtonClicked215);
			DimensionalCasketPanel.Append(playButton215);
			
			UIImageButton playButton221 = new UIImageButton(buttonPlayTexture);
			playButton221.Left.Set(150, 0f);
			playButton221.Top.Set(160, 0f);
			playButton221.Width.Set(22, 0f);
			playButton221.Height.Set(22, 0f);
			playButton221.OnClick += new MouseEvent(PlayButtonClicked221);
			DimensionalCasketPanel.Append(playButton221);
			UIImageButton playButton222 = new UIImageButton(buttonPlayTexture);
			playButton222.Left.Set(180, 0f);
			playButton222.Top.Set(160, 0f);
			playButton222.Width.Set(22, 0f);
			playButton222.Height.Set(22, 0f);
			playButton222.OnClick += new MouseEvent(PlayButtonClicked222);
			DimensionalCasketPanel.Append(playButton222);
			
			UIImageButton playButton231 = new UIImageButton(buttonPlayTexture);
			playButton231.Left.Set(210, 0f);
			playButton231.Top.Set(190, 0f);
			playButton231.Width.Set(22, 0f);
			playButton231.Height.Set(22, 0f);
			playButton231.OnClick += new MouseEvent(PlayButtonClicked231);
			DimensionalCasketPanel.Append(playButton231);
			UIImageButton playButton232 = new UIImageButton(buttonPlayTexture);
			playButton232.Left.Set(240, 0f);
			playButton232.Top.Set(190, 0f);
			playButton232.Width.Set(22, 0f);
			playButton232.Height.Set(22, 0f);
			playButton232.OnClick += new MouseEvent(PlayButtonClicked232);
			DimensionalCasketPanel.Append(playButton232);
			
			UIImageButton playButton241 = new UIImageButton(buttonPlayTexture);
			playButton241.Left.Set(150, 0f);
			playButton241.Top.Set(220, 0f);
			playButton241.Width.Set(22, 0f);
			playButton241.Height.Set(22, 0f);
			playButton241.OnClick += new MouseEvent(PlayButtonClicked241);
			DimensionalCasketPanel.Append(playButton241);
			UIImageButton playButton242 = new UIImageButton(buttonPlayTexture);
			playButton242.Left.Set(180, 0f);
			playButton242.Top.Set(220, 0f);
			playButton242.Width.Set(22, 0f);
			playButton242.Height.Set(22, 0f);
			playButton242.OnClick += new MouseEvent(PlayButtonClicked242);
			DimensionalCasketPanel.Append(playButton242);
			UIImageButton playButton243 = new UIImageButton(buttonPlayTexture);
			playButton243.Left.Set(210, 0f);
			playButton243.Top.Set(220, 0f);
			playButton243.Width.Set(22, 0f);
			playButton243.Height.Set(22, 0f);
			playButton243.OnClick += new MouseEvent(PlayButtonClicked243);
			DimensionalCasketPanel.Append(playButton243);
			
			UIImageButton playButton25 = new UIImageButton(buttonPlayTexture);
			playButton25.Left.Set(150, 0f);
			playButton25.Top.Set(250, 0f);
			playButton25.Width.Set(22, 0f);
			playButton25.Height.Set(22, 0f);
			playButton25.OnClick += new MouseEvent(PlayButtonClicked25);
			DimensionalCasketPanel.Append(playButton25);
			
			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(370, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			DimensionalCasketPanel.Append(closeButton);
			base.Append(DimensionalCasketPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.ArmsDealer))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.ArmsDealer)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 2;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Merchant))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Merchant)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Demolitionist))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Demolitionist)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 4;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Dryad))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Dryad)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 3;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Painter))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Painter)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 15;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.DyeTrader))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.DyeTrader)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 12;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.GoblinTinkerer))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.GoblinTinkerer)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 6;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked7R(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.GoblinTinkerer))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.GoblinTinkerer)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.InReforgeMenu = true;
					}
				}
			}
		}
		
		private void PlayButtonClicked8(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Mechanic))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Mechanic)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 8;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked9(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Steampunker))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Steampunker)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 11;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked10(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Wizard))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Wizard)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 7;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked11(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.WitchDoctor))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.WitchDoctor)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 16;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked12(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Cyborg))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Cyborg)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 14;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked13(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Pirate))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Pirate)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 17;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked14(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Clothier))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Clothier)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 5;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked15(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Truffle))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Truffle)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 10;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked16(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Stylist))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Stylist)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 18;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked16R(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.Stylist))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.Stylist)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.OpenHairWindow();
					}
				}
			}
		}
		
		private void PlayButtonClicked17(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(NPCID.PartyGirl))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == NPCID.PartyGirl)
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = 13;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npcShop);
					}
				}
			}
		}
		
		private void PlayButtonClicked18(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Alchemist")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Alchemist"))
					{
						Alchemist.baseShop = true;
						Alchemist.tremorShop = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked191(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 1;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked192(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 2;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked1921(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 21;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked193(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 3;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked194(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 4;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked195(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Brewer"))
					{
						Brewer.Shop = 5;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked201(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 1;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked202(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 2;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked203(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 3;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked204(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 4;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked205(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 5;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked206(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 6;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked207(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 7;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked208(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 8;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked209(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 9;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked210(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Architect")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Architect"))
					{
						Architect.Shop = 10;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked211(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Operator")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Operator"))
					{
						Operator.Shop = 1;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked212(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Operator")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Operator"))
					{
						Operator.Shop = 2;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked213(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Operator")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Operator"))
					{
						Operator.Shop = 3;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked214(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Operator")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Operator"))
					{
						Operator.Shop = 4;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked215(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Operator")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Operator"))
					{
						Operator.Shop = 5;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked221(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Jeweler")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Jeweler"))
					{
						Jeweler.OH = true;
						Jeweler.AS = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked222(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Jeweler")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Jeweler"))
					{
						Jeweler.OH = false;
						Jeweler.AS = true;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked231(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Young Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Young Brewer"))
					{
						YoungBrewer.Shop1 = true;
						YoungBrewer.Shop2 = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked232(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Young Brewer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Young Brewer"))
					{
						YoungBrewer.Shop2 = true;
						YoungBrewer.Shop1 = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked241(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Musician")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Musician"))
					{
						Musician.S1 = true;
						Musician.S2 = false;
						Musician.S3 = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked242(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Musician")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Musician"))
					{
						Musician.S1 = false;
						Musician.S2 = true;
						Musician.S3 = false;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked243(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Musician")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Musician"))
					{
						Musician.S1 = false;
						Musician.S2 = false;
						Musician.S3 = true;
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}
		
		private void PlayButtonClicked25(UIMouseEvent evt, UIElement listeningElement)
		{
			visible = false;
			if (NPC.AnyNPCs(mod.NPCType("Explorer")))
			{
				for (k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (Main.npc[k].type == mod.NPCType("Explorer"))
					{
						Main.playerInventory = true;
						forcetalk = true;
						Main.player[Main.myPlayer].talkNPC = k;
						Main.npcShop = Main.MaxShopIDs - 1;
						Main.instance.shop[Main.npcShop].SetupShop(Main.npc[k].type);
					}
				}
			}
		}

		private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuOpen);
			visible = false;
		}

		Vector2 offset;
		public bool dragging = false;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			offset = new Vector2(evt.MousePosition.X - DimensionalCasketPanel.Left.Pixels, evt.MousePosition.Y - DimensionalCasketPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			DimensionalCasketPanel.Left.Set(end.X - offset.X, 0f);
			DimensionalCasketPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (DimensionalCasketPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				DimensionalCasketPanel.Left.Set(MousePosition.X - offset.X, 0f);
				DimensionalCasketPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
