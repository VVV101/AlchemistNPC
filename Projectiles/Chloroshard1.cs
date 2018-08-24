using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class Chloroshard1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chloroshard Bullet 1");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(616);
			projectile.timeLeft = 240;
			aiType = 616;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			for (int h = 0; h < 2; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), projectile.damage/2, 0, Main.myPlayer);
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
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Home"), projectile.damage/2, 0, Main.myPlayer);
			
			}
		}
	}
}