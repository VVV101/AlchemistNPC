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
using AlchemistNPC.Items;

namespace AlchemistNPC.Interface
{
	class PipBoyTPMenu : UIState
	{
		public UIPanel PipBoyTPPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			PipBoyTPPanel = new UIPanel();
			PipBoyTPPanel.SetPadding(0);
			PipBoyTPPanel.Left.Set(575f, 0f);
			PipBoyTPPanel.Top.Set(275f, 0f);
			PipBoyTPPanel.Width.Set(250f, 0f);
			PipBoyTPPanel.Height.Set(200f, 0f);
			PipBoyTPPanel.BackgroundColor = new Color(73, 94, 171);

			PipBoyTPPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			PipBoyTPPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Beach Left/Right");
			text.Left.Set(60, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			PipBoyTPPanel.Append(text);
			
			UIText text2 = new UIText("Ocean Left/Right");
			text2.Left.Set(60, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(120, 0f);
			text2.Height.Set(22, 0f);
			PipBoyTPPanel.Append(text2);
			
			UIText text3 = new UIText("Dungeon");
			text3.Left.Set(60, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(70, 0f);
			text3.Height.Set(22, 0f);
			text3.OnClick += new MouseEvent(PlayButtonClicked3);
			PipBoyTPPanel.Append(text3);
			
			UIText text4 = new UIText("Underworld Left/Right");
			text4.Left.Set(60, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(120, 0f);
			text4.Height.Set(22, 0f);
			PipBoyTPPanel.Append(text4);
			
			UIText text5 = new UIText("Jungle Left/Right");
			text5.Left.Set(60, 0f);
			text5.Top.Set(130, 0f);
			text5.Width.Set(100, 0f);
			text5.Height.Set(22, 0f);
			PipBoyTPPanel.Append(text5);
			
			UIText text6 = new UIText("Temple");
			text6.Left.Set(60, 0f);
			text6.Top.Set(160, 0f);
			text6.Width.Set(75, 0f);
			text6.Height.Set(22, 0f);
			text6.OnClick += new MouseEvent(PlayButtonClicked6);
			PipBoyTPPanel.Append(text6);

			Mod mod = AlchemistNPC.Instance;
			Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
			Texture2D buttonBackTexture = mod.GetTexture("Interface/ButtonBack");
			UIImageButton playButton = new UIImageButton(buttonBackTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			PipBoyTPPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonBackTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			PipBoyTPPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			PipBoyTPPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonBackTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			PipBoyTPPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonBackTexture);
			playButton5.Left.Set(10, 0f);
			playButton5.Top.Set(130, 0f);
			playButton5.Width.Set(22, 0f);
			playButton5.Height.Set(22, 0f);
			playButton5.OnClick += new MouseEvent(PlayButtonClicked5);
			PipBoyTPPanel.Append(playButton5);
			UIImageButton playButton6 = new UIImageButton(buttonPlayTexture);
			playButton6.Left.Set(10, 0f);
			playButton6.Top.Set(160, 0f);
			playButton6.Width.Set(22, 0f);
			playButton6.Height.Set(22, 0f);
			playButton6.OnClick += new MouseEvent(PlayButtonClicked6);
			PipBoyTPPanel.Append(playButton6);
			UIImageButton playButton11 = new UIImageButton(buttonPlayTexture);
			playButton11.Left.Set(35, 0f);
			playButton11.Top.Set(10, 0f);
			playButton11.Width.Set(22, 0f);
			playButton11.Height.Set(22, 0f);
			playButton11.OnClick += new MouseEvent(PlayButtonClicked11);
			PipBoyTPPanel.Append(playButton11);
			UIImageButton playButton22 = new UIImageButton(buttonPlayTexture);
			playButton22.Left.Set(35, 0f);
			playButton22.Top.Set(40, 0f);
			playButton22.Width.Set(22, 0f);
			playButton22.Height.Set(22, 0f);
			playButton22.OnClick += new MouseEvent(PlayButtonClicked22);
			PipBoyTPPanel.Append(playButton22);
			UIImageButton playButton44 = new UIImageButton(buttonPlayTexture);
			playButton44.Left.Set(35, 0f);
			playButton44.Top.Set(100, 0f);
			playButton44.Width.Set(22, 0f);
			playButton44.Height.Set(22, 0f);
			playButton44.OnClick += new MouseEvent(PlayButtonClicked44);
			PipBoyTPPanel.Append(playButton44);
			UIImageButton playButton55 = new UIImageButton(buttonPlayTexture);
			playButton55.Left.Set(35, 0f);
			playButton55.Top.Set(130, 0f);
			playButton55.Width.Set(22, 0f);
			playButton55.Height.Set(22, 0f);
			playButton55.OnClick += new MouseEvent(PlayButtonClicked55);
			PipBoyTPPanel.Append(playButton55);
			
			Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(220, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			PipBoyTPPanel.Append(closeButton);
			base.Append(PipBoyTPPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(4);
			visible = false;
		}
		private void PlayButtonClicked11(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(3);
			visible = false;
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(2);
			visible = false;
		}
		private void PlayButtonClicked22(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(1);
			visible = false;
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(0);
			visible = false;
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(6);
			visible = false;
		}
		private void PlayButtonClicked44(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(5);
			visible = false;
		}
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(9);
			visible = false;
		}
		private void PlayButtonClicked55(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(10);
			visible = false;
		}
		
		private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
		{
			Player player = Main.player[Main.myPlayer];
			TeleportClass.HandleTeleport(7);
			visible = false;
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
			offset = new Vector2(evt.MousePosition.X - PipBoyTPPanel.Left.Pixels, evt.MousePosition.Y - PipBoyTPPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			PipBoyTPPanel.Left.Set(end.X - offset.X, 0f);
			PipBoyTPPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (PipBoyTPPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				PipBoyTPPanel.Left.Set(MousePosition.X - offset.X, 0f);
				PipBoyTPPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
