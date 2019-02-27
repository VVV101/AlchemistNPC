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
	class ShopChangeUIA : UIState
	{
		public UIPanel ArchitectShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			ArchitectShopsPanel = new UIPanel();
			ArchitectShopsPanel.SetPadding(0);
			ArchitectShopsPanel.Left.Set(575f, 0f);
			ArchitectShopsPanel.Top.Set(275f, 0f);
			ArchitectShopsPanel.Width.Set(230f, 0f);
			ArchitectShopsPanel.Height.Set(310f, 0f);
			ArchitectShopsPanel.BackgroundColor = new Color(73, 94, 171);

			ArchitectShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			ArchitectShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Filler Blocks");
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(70, 0f);
			text.Height.Set(22, 0f);
			text.OnClick += new MouseEvent(PlayButtonClicked1);
			ArchitectShopsPanel.Append(text);
			
			UIText text2 = new UIText("Building Blocks");
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(70, 0f);
			text2.Height.Set(22, 0f);
			text2.OnClick += new MouseEvent(PlayButtonClicked2);
			ArchitectShopsPanel.Append(text2);
			
			UIText text3 = new UIText("Basic Furniture");
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(70, 0f);
			text3.Height.Set(22, 0f);
			text3.OnClick += new MouseEvent(PlayButtonClicked3);
			ArchitectShopsPanel.Append(text3);
			
			UIText text4 = new UIText("Advanced Furniture");
			text4.Left.Set(35, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(70, 0f);
			text4.Height.Set(22, 0f);
			text4.OnClick += new MouseEvent(PlayButtonClicked4);
			ArchitectShopsPanel.Append(text4);
			
			UIText text5 = new UIText("Torches");
			text5.Left.Set(35, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(50, 0f);
			text5.Height.Set(22, 0f);
			text5.OnClick += new MouseEvent(PlayButtonClicked5);
			ArchitectShopsPanel.Append(text5);
			
			UIText text6 = new UIText("Candles");
			text6.Left.Set(35, 0f);
			text6.Top.Set(160, 0f);
			text6.Width.Set(50, 0f);
			text6.Height.Set(22, 0f);
			text6.OnClick += new MouseEvent(PlayButtonClicked6);
			ArchitectShopsPanel.Append(text6);
			
			UIText text7 = new UIText("Lamps");
			text7.Left.Set(35, 0f);
			text7.Top.Set(190, 0f);
			text7.Width.Set(50, 0f);
			text7.Height.Set(22, 0f);
			text7.OnClick += new MouseEvent(PlayButtonClicked7);
			ArchitectShopsPanel.Append(text7);
			
			UIText text8 = new UIText("Lanterns");
			text8.Left.Set(35, 0f);
			text8.Top.Set(220, 0f);
			text8.Width.Set(60, 0f);
			text8.Height.Set(22, 0f);
			text8.OnClick += new MouseEvent(PlayButtonClicked8);
			ArchitectShopsPanel.Append(text8);
			
			UIText text9 = new UIText("Chandeliers");
			text9.Left.Set(35, 0f);
			text9.Top.Set(250, 0f);
			text9.Width.Set(70, 0f);
			text9.Height.Set(22, 0f);
			text9.OnClick += new MouseEvent(PlayButtonClicked9);
			ArchitectShopsPanel.Append(text9);
			
			UIText text10 = new UIText("Candelabras");
			text10.Left.Set(35, 0f);
			text10.Top.Set(280, 0f);
			text10.Width.Set(70, 0f);
			text10.Height.Set(22, 0f);
			text10.OnClick += new MouseEvent(PlayButtonClicked10);
			ArchitectShopsPanel.Append(text10);
			
			Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			ArchitectShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			ArchitectShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			ArchitectShopsPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			ArchitectShopsPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			ArchitectShopsPanel.Append(playButton5);
			UIImageButton playButton6 = new UIImageButton(buttonPlayTexture);
			playButton6.Left.Set(10, 0f);
			playButton6.Top.Set(160, 0f);
			playButton6.Width.Set(22, 0f);
			playButton6.Height.Set(22, 0f);
			playButton6.OnClick += new MouseEvent(PlayButtonClicked6);
			ArchitectShopsPanel.Append(playButton6);
			UIImageButton playButton7 = new UIImageButton(buttonPlayTexture);
			playButton7.Left.Set(10, 0f);
			playButton7.Top.Set(190, 0f);
			playButton7.Width.Set(22, 0f);
			playButton7.Height.Set(22, 0f);
			playButton7.OnClick += new MouseEvent(PlayButtonClicked7);
			ArchitectShopsPanel.Append(playButton7);
			UIImageButton playButton8 = new UIImageButton(buttonPlayTexture);
			playButton8.Left.Set(10, 0f);
			playButton8.Top.Set(220, 0f);
			playButton8.Width.Set(22, 0f);
			playButton8.Height.Set(22, 0f);
			playButton8.OnClick += new MouseEvent(PlayButtonClicked8);
			ArchitectShopsPanel.Append(playButton8);
			UIImageButton playButton9 = new UIImageButton(buttonPlayTexture);
			playButton9.Left.Set(10, 0f);
			playButton9.Top.Set(250, 0f);
			playButton9.Width.Set(22, 0f);
			playButton9.Height.Set(22, 0f);
			playButton9.OnClick += new MouseEvent(PlayButtonClicked9);
			ArchitectShopsPanel.Append(playButton9);
			UIImageButton playButton10 = new UIImageButton(buttonPlayTexture);
			playButton10.Left.Set(10, 0f);
			playButton10.Top.Set(280, 0f);
			playButton10.Width.Set(22, 0f);
			playButton10.Height.Set(22, 0f);
			playButton10.OnClick += new MouseEvent(PlayButtonClicked10);
			ArchitectShopsPanel.Append(playButton10);

			Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(200, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			ArchitectShopsPanel.Append(closeButton);
			base.Append(ArchitectShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 1;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 2;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
			
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 3;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 4;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 5;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 6;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 7;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked8(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 8;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked9(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 9;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked10(UIMouseEvent evt, UIElement listeningElement)
		{
			Architect.Shop = 10;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIA.visible = false;
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
			offset = new Vector2(evt.MousePosition.X - ArchitectShopsPanel.Left.Pixels, evt.MousePosition.Y - ArchitectShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			ArchitectShopsPanel.Left.Set(end.X - offset.X, 0f);
			ArchitectShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (ArchitectShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				ArchitectShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				ArchitectShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
