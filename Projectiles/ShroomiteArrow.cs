using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles
{
	public class ShroomiteArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.IchorArrow);
			aiType = ProjectileID.IchorArrow;
		}

		public override void AI()
		{
			projectile.velocity *= 1.02f;
			if (Main.rand.Next(2) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("JustitiaPale"),
						projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.noGravity = true;
					dust.velocity += projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
			projectile.Kill();
			Main.PlaySound(SoundID.Item94.WithVolume(.9f), projectile.position);
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionShroom"), projectile.damage, 0, Main.myPlayer);
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 600);
			Main.PlaySound(SoundID.Item94.WithVolume(.9f), projectile.position);
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionShroom"), projectile.damage, 0, Main.myPlayer);
		}
	}
}