using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class ChloroshardArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chloroshard Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.IchorArrow);
			aiType = ProjectileID.IchorArrow;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.IchorArrow;
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				for (int h = 0; h < 2; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Chloroshard1"), projectile.damage/4, 0, Main.myPlayer);
				}
			}
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
				for (int h = 0; h < 2; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Chloroshard1"), projectile.damage/4, 0, Main.myPlayer);
				}
			}
		}
	}