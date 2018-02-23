using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class IcedamnedArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icedamned Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CursedArrow);
			aiType = ProjectileID.CursedArrow;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.CursedArrow;
			return true;
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
				if (Main.rand.Next(4) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("JustitiaPale"),
						0, 0, 254, Scale: 0.3f);
					dust.velocity += projectile.velocity * 0.5f;
					dust.velocity *= 0.5f;
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(39, 600);
				target.AddBuff(44, 600);
			}
		}
	}
}