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
using System.Collections.Generic;
using Terraria.ID;
using System.Linq;
using AlchemistNPC.Items;

namespace AlchemistNPC.Interface
{
	class CoinsConvertMenu : UIState
	{
		public UIPanel CoinsConvertPanel;
		public UIMoneyDisplay CoinsDisplay;
		public static bool visible = false;

		public override void OnInitialize()
		{
			CoinsConvertPanel = new UIPanel();
			CoinsConvertPanel.SetPadding(0);
			CoinsConvertPanel.Left.Set(275f, 0f);
			CoinsConvertPanel.Top.Set(275f, 0f);
			CoinsConvertPanel.Width.Set(180f, 0f);
			CoinsConvertPanel.Height.Set(350f, 0f);
			CoinsConvertPanel.BackgroundColor = new Color(73, 94, 171);

			CoinsConvertPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			CoinsConvertPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			string Tier1;
			string Tier2;
			string Tier3;
			string Tier4;
			string Tier5;
			string Tier6;
			string BottonText;

			if(Language.ActiveCulture == GameCulture.Chinese)
			{
				Tier1 = "1级硬币";
				Tier2 = "2级硬币";
				Tier3 = "3级硬币";
				Tier4 = "4级硬币";
				Tier5 = "5级硬币";
				Tier6 = "6级硬币";
				BottonText = "将1个高等级币转化为2个低等级币";
			}
			else
			{
				Tier1 = "Tier 1 coins";
				Tier2 = "Tier 2 coins";
				Tier3 = "Tier 3 coins";
				Tier4 = "Tier 4 coins";
				Tier5 = "Tier 5 coins";
				Tier6 = "Tier 6 coins";
				BottonText = "Convert 1 coin into 2 of the lower tier";
			}
			
			UIText text = new UIText(Tier1);
			text.Left.Set(10, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text);
			
			UIText text2 = new UIText(Tier2);
			text2.Left.Set(10, 0f);
			text2.Top.Set(70, 0f);
			text2.Width.Set(60, 0f);
			text2.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text2);
			
			UIText text3 = new UIText(Tier3);
			text3.Left.Set(10, 0f);
			text3.Top.Set(130, 0f);
			text3.Width.Set(60, 0f);
			text3.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text3);
			
			UIText text4 = new UIText(Tier4);
			text4.Left.Set(10, 0f);
			text4.Top.Set(190, 0f);
			text4.Width.Set(60, 0f);
			text4.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text4);
			
			UIText text5 = new UIText(Tier5);
			text5.Left.Set(10, 0f);
			text5.Top.Set(250, 0f);
			text5.Width.Set(60, 0f);
			text5.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text5);
			
			UIText text6 = new UIText(Tier6);
			text6.Left.Set(10, 0f);
			text6.Top.Set(310, 0f);
			text6.Width.Set(60, 0f);
			text6.Height.Set(22, 0f);
			CoinsConvertPanel.Append(text6);

			Mod mod = AlchemistNPC.Instance;
			Texture2D buttonBackTexture = mod.GetTexture("Interface/ButtonUp");
			UIHoverImageButton playButton = new UIHoverImageButton(buttonBackTexture, BottonText);
			playButton.Left.Set(130, 0f);
			playButton.Top.Set(40, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			CoinsConvertPanel.Append(playButton);
			UIHoverImageButton playButton2 = new UIHoverImageButton(buttonBackTexture, BottonText);
			playButton2.Left.Set(130, 0f);
			playButton2.Top.Set(100, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			CoinsConvertPanel.Append(playButton2);
			UIHoverImageButton playButton3 = new UIHoverImageButton(buttonBackTexture, BottonText);
			playButton3.Left.Set(130, 0f);
			playButton3.Top.Set(160, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			CoinsConvertPanel.Append(playButton3);
			UIHoverImageButton playButton4 = new UIHoverImageButton(buttonBackTexture, BottonText);
			playButton4.Left.Set(130, 0f);
			playButton4.Top.Set(220, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			CoinsConvertPanel.Append(playButton4);
			UIHoverImageButton playButton5 = new UIHoverImageButton(buttonBackTexture, BottonText);
			playButton5.Left.Set(130, 0f);
			playButton5.Top.Set(280, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			CoinsConvertPanel.Append(playButton5);
			
			CoinsDisplay = new UIMoneyDisplay();
			CoinsDisplay.Left.Set(100, 0f);
			CoinsDisplay.Top.Set(10, 0f);
			CoinsDisplay.Width.Set(40f, 0f);
			CoinsDisplay.Height.Set(40, 1f);
			CoinsConvertPanel.Append(CoinsDisplay);

			Append(CoinsConvertPanel);
			
			base.Append(CoinsConvertPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.RCT2 > 0) AlchemistNPCPlayer.ConvertCoins(1);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.RCT3 > 0) AlchemistNPCPlayer.ConvertCoins(2);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.RCT4 > 0) AlchemistNPCPlayer.ConvertCoins(3);
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.RCT5 > 0) AlchemistNPCPlayer.ConvertCoins(4);
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (modPlayer.RCT6 > 0) AlchemistNPCPlayer.ConvertCoins(5);
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
			offset = new Vector2(evt.MousePosition.X - CoinsConvertPanel.Left.Pixels, evt.MousePosition.Y - CoinsConvertPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			CoinsConvertPanel.Left.Set(end.X - offset.X, 0f);
			CoinsConvertPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (CoinsConvertPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				CoinsConvertPanel.Left.Set(MousePosition.X - offset.X, 0f);
				CoinsConvertPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
	
	internal class UIHoverImageButton : UIImageButton
	{
		internal string HoverText;

		public UIHoverImageButton(Texture2D texture, string hoverText) : base(texture) {
			HoverText = hoverText;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) {
			base.DrawSelf(spriteBatch);

			if (IsMouseHovering) {
				Main.hoverItemName = HoverText;
			}
		}
	}
	
	public class UIMoneyDisplay : UIElement
	{
		public UIMoneyDisplay() {
			Width.Set(40, 0f);
			Height.Set(40, 0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) {
			CalculatedStyle innerDimensions = GetInnerDimensions();	
			//Vector2 drawPos = new Vector2(innerDimensions.X + 5f, innerDimensions.Y + 30f);

			float shopx = innerDimensions.X;
			float shopy = innerDimensions.Y;

			Player player = Main.LocalPlayer;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			int anchorX = (int)shopx;
			DynamicSpriteFont font = Main.fontMouseText;
			string maxText = "9999";
			Vector2 maxTextSize = font.MeasureString(maxText);
			Color textColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT1, new Vector2(shopx + (float)(24) + (float)1, shopy), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT2, new Vector2(shopx + (float)(24) + (float)1, shopy+60), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT3, new Vector2(shopx + (float)(24) + (float)1, shopy+120), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT4, new Vector2(shopx + (float)(24) + (float)1, shopy+180), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT5, new Vector2(shopx + (float)(24) + (float)1, shopy+240), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, "" + modPlayer.RCT6, new Vector2(shopx + (float)(24) + (float)1, shopy+300), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
		}
	}
}
