using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class SasscadeYoyo : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(555);
			aiType = 555;
			projectile.aiStyle = 99;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sasscade Yoyo");
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 500f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20f;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[projectile.owner] = 2;

		}

		public override void AI()
		{
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 500f && !target.friendly && target.active)
                {
                    if (projectile.ai[0] > 45f) // Time in (60 = 1 second) 
                    {
                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						if (Main.rand.Next(12) == 0)
						{
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("TP"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
						}
                        projectile.ai[0] = 0f;
                    }
                }
            }
			if (Main.rand.NextBool())
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 187, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
		}
	}
}
