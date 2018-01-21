using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class CrystalDust : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CrystalBullet2");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CrystalBullet);
			projectile.damage = 10;
			aiType = ProjectileID.CrystalBullet;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				for (int h = 0; h < 2; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, ProjectileID.CrystalBullet, projectile.damage/3, 0, Main.myPlayer);
				}
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
				for (int h = 0; h < 7; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile((projectile.Center.X - 30) + Main.rand.Next(60), (projectile.Center.Y - 30) + Main.rand.Next(60), vel.X, vel.Y, ProjectileID.CrystalBullet, projectile.damage/3, 0, Main.myPlayer);
				}
			
			}
		}
	}
}