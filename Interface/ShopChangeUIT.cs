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
	class ShopChangeUIT : UIState
	{
		public UIPanel TinkererShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			TinkererShopsPanel = new UIPanel();
			TinkererShopsPanel.SetPadding(0);
			TinkererShopsPanel.Left.Set(575f, 0f);
			TinkererShopsPanel.Top.Set(275f, 0f);
			TinkererShopsPanel.Width.Set(200f, 0f);
			TinkererShopsPanel.Height.Set(75f, 0f);
			TinkererShopsPanel.BackgroundColor = new Color(73, 94, 171);

			TinkererShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			TinkererShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Movement/Misc");
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(90, 0f);
			text.Height.Set(22, 0f);
			text.OnClick += new MouseEvent(PlayButtonClicked1);
			TinkererShopsPanel.Append(text);
			
			UIText text2 = new UIText("Combat");
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(50, 0f);
			text2.Height.Set(22, 0f);
			text2.OnClick += new MouseEvent(PlayButtonClicked2);
			TinkererShopsPanel.Append(text2);
			
			Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			TinkererShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			TinkererShopsPanel.Append(playButton2);

			Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(170, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			TinkererShopsPanel.Append(closeButton);
			base.Append(TinkererShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Tinkerer.Shop = 1;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIT.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Tinkerer.Shop = 2;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIT.visible = false;
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
			offset = new Vector2(evt.MousePosition.X - TinkererShopsPanel.Left.Pixels, evt.MousePosition.Y - TinkererShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			TinkererShopsPanel.Left.Set(end.X - offset.X, 0f);
			TinkererShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (TinkererShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				TinkererShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				TinkererShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
