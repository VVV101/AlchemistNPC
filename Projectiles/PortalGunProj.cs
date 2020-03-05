using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class PortalGunProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Portal Gun Projectile");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
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
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), projectile.damage-projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), projectile.damage+projectile.damage/2, 0, Main.myPlayer);
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
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), projectile.damage-projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), projectile.damage+projectile.damage/2, 0, Main.myPlayer);
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
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal1"), projectile.damage*2, 0, Main.myPlayer);
			break;
			case 1:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal2"), projectile.damage, 0, Main.myPlayer);
			break;
			case 2:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal3"), projectile.damage, 0, Main.myPlayer);
			break;
			case 3:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal4"), projectile.damage-projectile.damage/4, 0, Main.myPlayer);
			break;
			case 4:
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("RickPortal5"), projectile.damage+projectile.damage/2, 0, Main.myPlayer);
			break;
			}
			return true;
		}
	}
}
