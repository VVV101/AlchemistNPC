using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class SymbolOfPain : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 3200;
			projectile.height = 3200;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SymbolOfPain");
		}
		
		public override void AI()
		{
			Main.monolithType = 4;
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(projectile.Hitbox) && !target.friendly)
				{
						for (int i = 0; i < 10; i++)
						{
							int dustIndex = Dust.NewDust(target.position, target.width, target.height, mod.DustType("RainbowDust"));
							Dust dust = Main.dust[dustIndex];
							dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
							dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
							dust.scale *= 0.9f;
							dust.noGravity = true;
						}
						target.buffImmune[mod.BuffType("SymbolOfPain")] = false;
						target.AddBuff(mod.BuffType("SymbolOfPain"), 3600);
				}
			}
		}
	}
}
