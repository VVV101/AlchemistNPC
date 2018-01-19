using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class Chloroshard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chloroshard Bullet");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
			projectile.damage = 50;
			projectile.timeLeft = 240;
			aiType = ProjectileID.ChlorophyteBullet;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int h = 0; h < 2; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), projectile.damage, 0, Main.myPlayer);
				}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
			for (int g = 0; g < 2; g++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), projectile.damage, 0, Main.myPlayer);
			
			}
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	}
}