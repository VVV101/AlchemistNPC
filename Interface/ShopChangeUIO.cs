using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.Localization;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPC.NPCs;

namespace AlchemistNPC.Interface
{
	class ShopChangeUIO : UIState
	{
		public UIPanel OperatorShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			OperatorShopsPanel = new UIPanel();
			OperatorShopsPanel.SetPadding(0);
			OperatorShopsPanel.Left.Set(575f, 0f);
			OperatorShopsPanel.Top.Set(275f, 0f);
			OperatorShopsPanel.Width.Set(260f, 0f);
			OperatorShopsPanel.Height.Set(160f, 0f);
			OperatorShopsPanel.BackgroundColor = new Color(73, 94, 171);

			OperatorShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			OperatorShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			string OperatorShops1; 
			string OperatorShops2; 
			string OperatorShops3; 
			string OperatorShops4; 
			string OperatorShops5;

			if(Language.ActiveCulture == GameCulture.Chinese)
				{
					OperatorShops1 = "材料/Boss掉落物品";
					OperatorShops2 = "EGO商店";
					OperatorShops3 = "原版宝藏袋";
					OperatorShops4 = "模组宝藏袋#1";
					OperatorShops5 = "模组宝藏袋#2";
				}
			else
				{
					OperatorShops1 = "Materials/Boss Drops";
					OperatorShops2 = "EGO shop";
					OperatorShops3 = "Vanilla Treasure Bags";
					OperatorShops4 = "Modded Treasure Bags #1";
					OperatorShops5 = "Modded Treasure Bags #2";
				}
			
			UIText text = new UIText(OperatorShops1);
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(90, 0f);
			text.Height.Set(22, 0f);
			OperatorShopsPanel.Append(text);
			
			UIText text2 = new UIText(OperatorShops2);
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(70, 0f);
			text2.Height.Set(22, 0f);
			OperatorShopsPanel.Append(text2);
			
			UIText text3 = new UIText(OperatorShops3);
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(120, 0f);
			text3.Height.Set(22, 0f);
			OperatorShopsPanel.Append(text3);
			
			UIText text4 = new UIText(OperatorShops4);
			text4.Left.Set(35, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(120, 0f);
			text4.Height.Set(22, 0f);
			OperatorShopsPanel.Append(text4);
			
			UIText text5 = new UIText(OperatorShops5);
			text5.Left.Set(35, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(120, 0f);
			text5.Height.Set(22, 0f);
			OperatorShopsPanel.Append(text5);
			
			Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			OperatorShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			OperatorShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			OperatorShopsPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			OperatorShopsPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			OperatorShopsPanel.Append(playButton5);

			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(230, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			OperatorShopsPanel.Append(closeButton);
			base.Append(OperatorShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop = 1;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIO.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop = 2;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIO.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop = 3;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIO.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop = 4;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIO.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop = 5;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIO.visible = false;
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
			offset = new Vector2(evt.MousePosition.X - OperatorShopsPanel.Left.Pixels, evt.MousePosition.Y - OperatorShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			OperatorShopsPanel.Left.Set(end.X - offset.X, 0f);
			OperatorShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (OperatorShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				OperatorShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				OperatorShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
