using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Buffs;

namespace AlchemistNPC.Projectiles
{
	public class Globe199 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Globe199");
			projectile.light = 0.5f;
			Main.projFrames[projectile.type] = 10;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.penetrate = -1;
			projectile.timeLeft = 3600;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.extraUpdates = 0;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center;
			projectile.position.Y = player.Center.Y-116;
			if (++projectile.frameCounter >= 6)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 10)
                {
                    projectile.frame = 0;
                }
            }
			if (ProjCounter.counter == 0)
			{
				for (int i = 0; i < 25; i++)
				{
					int dustType = 193;
					int dustIndex = Dust.NewDust(projectile.position, 96, 96, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-10, 10) * 0.5f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-10, 10) * 0.5f;
					dust.scale *= 0.98f;
					dust.noGravity = true;
				}
			}
			if (player.dead || !player.HasBuff(mod.BuffType("ProjCounter")))
			{
				projectile.Kill();
			}
		}
	}
}
