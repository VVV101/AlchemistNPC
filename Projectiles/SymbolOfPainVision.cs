using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class SymbolOfPainVision : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumu Shield");
			projectile.light = 0.2f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 60;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.position.X = player.Center.X;
			projectile.position.Y = player.Center.Y - 100;
			if (++projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
			if (player.dead)
			{
				projectile.Kill();
			}
		}
	}
}
