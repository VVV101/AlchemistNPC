using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class Nyx : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyx");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.MoonlordBullet);
			aiType = ProjectileID.MoonlordBullet;
		}
		
		public override void AI()
		{
		Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.9f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.3f) / 255f);
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionNyx"), projectile.damage/6, 0, Main.myPlayer);
		return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 3;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionNyx"), projectile.damage/6, 0, Main.myPlayer);
		}
	}
}
