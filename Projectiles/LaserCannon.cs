using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class LaserCannon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Cannon");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.width = 12;
			projectile.height = 12;
			projectile.timeLeft = 300;
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			for (int i = 0; i < 2; i++)
				{
					int dustIndex = Dust.NewDust(projectile.Center, projectile.width, projectile.height, mod.DustType("RainbowDust"));
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
					dust.scale *= 0.9f;
					dust.noGravity = true;
				}
			
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 300f;
			bool target = false;
			for (int k = 0; k < 100; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 5f;
				AdjustMagnitude(ref projectile.velocity);
			}
		}
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 9f / magnitude;
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
            
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int i = 0; i < projectile.oldPos.Length; i++) {
                Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle(0, projectile.frame * Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type], Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
		
		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionPlasma"), projectile.damage, 0, Main.myPlayer);
			projectile.type = ProjectileID.Bullet;
			return true;
		}
	}
}
