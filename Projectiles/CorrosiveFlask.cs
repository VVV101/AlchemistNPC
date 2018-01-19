using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class CorrosiveFlask : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ToxicFlask);
			projectile.damage = 350;
			aiType = ProjectileID.ToxicFlask;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.ToxicFlask;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 704, 1f);
			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(20, 31);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(20, 402) * 0.01f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, mod.ProjectileType("CorrosiveFlaskCloud"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(mod.BuffType("Corrosion"), 300);
				target.immune[projectile.owner] = 1;
			}
	}
}