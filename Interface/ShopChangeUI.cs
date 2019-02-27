using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPC.NPCs;

namespace AlchemistNPC.Interface
{
	class ShopChangeUI : UIState
	{
		public UIPanel BrewerShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			BrewerShopsPanel = new UIPanel();
			BrewerShopsPanel.SetPadding(0);
			BrewerShopsPanel.Left.Set(575f, 0f);
			BrewerShopsPanel.Top.Set(275f, 0f);
			BrewerShopsPanel.Width.Set(385f, 0f);
			BrewerShopsPanel.Height.Set(160f, 0f);
			BrewerShopsPanel.BackgroundColor = new Color(73, 94, 171);

			BrewerShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			BrewerShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Vanilla");
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			text.OnClick += new MouseEvent(PlayButtonClicked1);
			BrewerShopsPanel.Append(text);
			
			UIText text2 = new UIText("Mod/Calamity/Thorium/RG");
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(120, 0f);
			text2.Height.Set(22, 0f);
			text2.OnClick += new MouseEvent(PlayButtonClicked2);
			BrewerShopsPanel.Append(text2);
			
			UIText text3 = new UIText("MorePotions");
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(70, 0f);
			text3.Height.Set(22, 0f);
			text3.OnClick += new MouseEvent(PlayButtonClicked3);
			BrewerShopsPanel.Append(text3);
			
			UIText text4 = new UIText("UnuBattleRods/Tacklebox/Tremor");
			text4.Left.Set(35, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(150, 0f);
			text4.Height.Set(22, 0f);
			text4.OnClick += new MouseEvent(PlayButtonClicked4);
			BrewerShopsPanel.Append(text4);
			
			UIText text5 = new UIText("Wildlife/Sacred/Spirit/Cristilium/ExpSentr");
			text5.Left.Set(35, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(200, 0f);
			text5.Height.Set(22, 0f);
			text5.OnClick += new MouseEvent(PlayButtonClicked5);
			BrewerShopsPanel.Append(text5);

			Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			BrewerShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			BrewerShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			BrewerShopsPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			BrewerShopsPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			BrewerShopsPanel.Append(playButton5);
			
			Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(350, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			BrewerShopsPanel.Append(closeButton);
			base.Append(BrewerShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Brewer.Shop = 1;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUI.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Brewer.Shop = 2;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUI.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Brewer.Shop = 3;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUI.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Brewer.Shop = 4;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUI.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Brewer.Shop = 5;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUI.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
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
			offset = new Vector2(evt.MousePosition.X - BrewerShopsPanel.Left.Pixels, evt.MousePosition.Y - BrewerShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			BrewerShopsPanel.Left.Set(end.X - offset.X, 0f);
			BrewerShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (BrewerShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				BrewerShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				BrewerShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
