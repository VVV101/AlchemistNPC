using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class ChromovariaArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.IchorArrow);
			aiType = ProjectileID.IchorArrow;
		}

		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("JustitiaPale"),
						projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			Main.PlaySound(SoundID.Item12, projectile.position);
			Vector2 vel = new Vector2(-1, -1);
			vel *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel2.X, vel2.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel3.X, vel3.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel4.X, vel4.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 600);
			Main.PlaySound(SoundID.Item12, projectile.position);
			Vector2 vel = new Vector2(-1, -1);
			vel *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel2.X, vel2.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel3.X, vel3.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 3f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel4.X, vel4.Y, mod.ProjectileType("CAE"), projectile.damage/2, 0, Main.myPlayer);
		}
	}
}