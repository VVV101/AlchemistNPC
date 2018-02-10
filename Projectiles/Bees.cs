using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class Bees : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bees");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
		projectile.CloneDefaults(ProjectileID.Bee);
		projectile.magic = true; 
		projectile.timeLeft = 240;
		aiType = ProjectileID.Bee;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		for (int h = 0; h < 1; h++)
				{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Bees"), projectile.damage, 0, Main.myPlayer);
				}
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	}
}
