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
		projectile.netImportant = true;
		projectile.netUpdate = true;
		projectile.magic = true; 
		projectile.timeLeft = 240;
		aiType = ProjectileID.Bee;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.penetrate = 1;
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BeeHeal == true)
			{
				if (Main.rand.Next(10) == 0)
				{
				player.statLife += 2;
				player.HealEffect(2, true);
				}
			}
		}
	}
}
