using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class SharpBone : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Bone");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.ranged = false;
			projectile.minion = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
			aiType = ProjectileID.Bullet;
		}

		public override void AI()
		{
			projectile.velocity *= 1.01f;
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 600f;
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
			Player player = Main.player[projectile.owner]; 
			int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width/3, player.height/3, 56, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
			Main.dust[dust].scale *= 0.3f;
		}
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 9f / magnitude;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionDummySB"), projectile.damage/2, 0, Main.myPlayer);
			}
		}
		
		public Color GetColor()
		{
		return new Color(0, 0, 200);
		}
	}
}