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
using AlchemistNPC.Items;

namespace AlchemistNPC.Interface
{
	class CoinsConvertMenu : UIState
	{
		public UIPanel CoinsConvertMenu;
		public static bool visible = false;

		public override void OnInitialize()
		{
			CoinsConvertMenu = new UIPanel();
			CoinsConvertMenu.SetPadding(0);
			CoinsConvertMenu.Left.Set(575f, 0f);
			CoinsConvertMenu.Top.Set(275f, 0f);
			CoinsConvertMenu.Width.Set(250f, 0f);
			CoinsConvertMenu.Height.Set(200f, 0f);
			CoinsConvertMenu.BackgroundColor = new Color(73, 94, 171);

			CoinsConvertMenu.OnMouseDown += new UIElement.MouseEvent(DragStart);
			CoinsConvertMenu.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			string Tier1;
			string Tier2;
			string Tier3;
			string Tier4;
			string Tier5;
			string Tier6;
		
			Tier1 = "Tier 1 coins";
			Tier2 = "Tier 2 coins";
			Tier3 = "Tier 3 coins";
			Tier4 = "Tier 4 coins";
			Tier5 = "Tier 5 coins";
			Tier6 = "Tier 6 coins";
			
			UIText text = new UIText(Tier1);
			text.Left.Set(60, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			CoinsConvertMenu.Append(text);
			
			UIText text2 = new UIText(Tier2);
			text2.Left.Set(60, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(120, 0f);
			text2.Height.Set(22, 0f);
			CoinsConvertMenu.Append(text2);
			
			UIText text3 = new UIText(Tier3);
			text3.Left.Set(60, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(70, 0f);
			text3.Height.Set(22, 0f);
			text3.OnClick += new MouseEvent(PlayButtonClicked3);
			CoinsConvertMenu.Append(text3);
			
			UIText text4 = new UIText(Tier4);
			text4.Left.Set(60, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(140, 0f);
			text4.Height.Set(22, 0f);
			CoinsConvertMenu.Append(text4);
			
			UIText text5 = new UIText(Tier5);
			text5.Left.Set(60, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(100, 0f);
			text5.Height.Set(22, 0f);
			CoinsConvertMenu.Append(text5);
			
			UIText text6 = new UIText(Tier16);
			text6.Left.Set(60, 0f);
			text6.Top.Set(160, 0f);
			text6.Width.Set(75, 0f);
			text6.Height.Set(22, 0f);
			text6.OnClick += new MouseEvent(PlayButtonClicked6);
			CoinsConvertMenu.Append(text6);

			Mod mod = AlchemistNPC.Instance;
			Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			Texture2D buttonBackTexture = mod.GetTexture("Interface/ButtonBack");
			UIImageButton playButton = new UIImageButton(buttonBackTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			CoinsConvertMenu.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonBackTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			CoinsConvertMenu.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			CoinsConvertMenu.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonBackTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			CoinsConvertMenu.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonBackTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			CoinsConvertMenu.Append(playButton5);
			
			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(220, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			CoinsConvertMenu.Append(closeButton);
			base.Append(CoinsConvertMenu);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLite.ConvertCoins(1);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLite.ConvertCoins(2);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLite.ConvertCoins(3);
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLite.ConvertCoins(4);
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLite.ConvertCoins(5);
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
			offset = new Vector2(evt.MousePosition.X - CoinsConvertMenu.Left.Pixels, evt.MousePosition.Y - CoinsConvertMenu.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			CoinsConvertMenu.Left.Set(end.X - offset.X, 0f);
			CoinsConvertMenu.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (CoinsConvertMenu.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				CoinsConvertMenu.Left.Set(MousePosition.X - offset.X, 0f);
				CoinsConvertMenu.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
