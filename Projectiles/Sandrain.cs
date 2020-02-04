using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent.Events;
using Terraria.Localization;

namespace AlchemistNPC.Projectiles
{
	public class Sandrain : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandrain");
		}

		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.damage = 0;
			projectile.timeLeft = 1;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			if (player.ZoneDesert)
			{
				if (Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.SandstormStopped"), 255, 255, 255);
					}
					Sandstorm.Happening = false;
					Sandstorm.TimeLeft = 0;
					return;
				}
				if (!Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.SandstormStarted"), 255, 255, 255);
					}
					Sandstorm.Happening = true;
					Sandstorm.TimeLeft = 36000;
					return;
				}
			}
			if (Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.RainStopped"), 255, 255, 255);
				}
				Main.rainTime = 0;
				Main.maxRaining = 0f;
				Main.raining = false;
				return;
			}
			if (!Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.RainStarted"), 255, 255, 255);
				}
				Main.rainTime = 24000;
				Main.maxRaining = 1f;
				Main.raining = true;
				return;
			}
		}
	}
}
