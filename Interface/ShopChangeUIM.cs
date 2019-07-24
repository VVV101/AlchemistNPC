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
	class ShopChangeUIM : UIState
	{
		public UIPanel MusicianShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			MusicianShopsPanel = new UIPanel();
			MusicianShopsPanel.SetPadding(0);
			MusicianShopsPanel.Left.Set(575f, 0f);
			MusicianShopsPanel.Top.Set(275f, 0f);
			MusicianShopsPanel.Width.Set(260f, 0f);
			MusicianShopsPanel.Height.Set(105f, 0f);
			MusicianShopsPanel.BackgroundColor = new Color(73, 94, 171);

			MusicianShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			MusicianShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Vanilla Music Boxes");
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(90, 0f);
			text.Height.Set(22, 0f);
			MusicianShopsPanel.Append(text);
			
			UIText text2 = new UIText("Calamity Music Boxes");
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(90, 0f);
			text2.Height.Set(22, 0f);
			MusicianShopsPanel.Append(text2);
			
			UIText text3 = new UIText("Mod/Thorium Music Boxes");
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(90, 0f);
			text3.Height.Set(22, 0f);
			MusicianShopsPanel.Append(text3);
			
			Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			MusicianShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			MusicianShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			MusicianShopsPanel.Append(playButton3);

			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(230, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			MusicianShopsPanel.Append(closeButton);
			base.Append(MusicianShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Musician.S1 = true;
			Musician.S2 = false;
			Musician.S3 = false;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIM.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Musician.S1 = false;
			Musician.S2 = true;
			Musician.S3 = false;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIM.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = Main.MaxShopIDs - 1;
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Musician.S1 = false;
			Musician.S2 = false;
			Musician.S3 = true;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIM.visible = false;
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
			offset = new Vector2(evt.MousePosition.X - MusicianShopsPanel.Left.Pixels, evt.MousePosition.Y - MusicianShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			MusicianShopsPanel.Left.Set(end.X - offset.X, 0f);
			MusicianShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (MusicianShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				MusicianShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				MusicianShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
