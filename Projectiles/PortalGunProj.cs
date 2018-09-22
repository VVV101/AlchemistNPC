using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class PortalGunProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portal Gun Projectile");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.timeLeft = 25;
			aiType = ProjectileID.Bullet;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), 250, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), 100, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), 100, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), 75, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), 100, 0, Main.myPlayer);
			break;
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), 250, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), 100, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), 100, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), 75, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), 100, 0, Main.myPlayer);
			break;
			}
		}
		
		public override bool PreKill(int timeLeft)
		{
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			switch(Main.rand.Next(5))
			{
			case 0:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), 250, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), 100, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), 100, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), 75, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), 100, 0, Main.myPlayer);
			break;
			}
			return true;
		}
	}
}
