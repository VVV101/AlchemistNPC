using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class SpearofJustice : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.aiStyle = 113;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			aiType = 636;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SpearofJustice");

		}
		
		public override void AI()
		{
			if (Main.rand.Next(2) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("RainbowDust"),
						projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
					dust.noGravity = true;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionSOJ"), projectile.damage, 0, Main.myPlayer);
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionSOJ"), projectile.damage, 0, Main.myPlayer);
			}
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 4f;
			Projectile.NewProjectile(target.position.X+150, target.position.Y+150, vel1.X, vel1.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 4f;
			Projectile.NewProjectile(target.position.X-150, target.position.Y-150, vel2.X, vel2.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 4f;
			Projectile.NewProjectile(target.position.X-150, target.position.Y+150, vel3.X, vel3.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 4f;
			Projectile.NewProjectile(target.position.X+150, target.position.Y-150, vel4.X, vel4.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 4f;
			Projectile.NewProjectile(target.position.X, target.position.Y+150, vel5.X, vel5.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 4f;
			Projectile.NewProjectile(target.position.X, target.position.Y-150, vel6.X, vel6.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 4f;
			Projectile.NewProjectile(target.position.X-150, target.position.Y, vel7.X, vel7.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 4f;
			Projectile.NewProjectile(target.position.X+150, target.position.Y, vel8.X, vel8.Y, mod.ProjectileType("SpearofJusticeB"), projectile.damage/2, 0, Main.myPlayer);
		}
	}
}
