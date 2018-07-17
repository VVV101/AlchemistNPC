using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class FungalosphereProjectileDummy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.ranged = true;
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.extraUpdates = 3;
			projectile.timeLeft = 120;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungalosphere Projectile Dummy");

		}

		public override void AI()
		{
			if (projectile.timeLeft > 90)
			{
				projectile.timeLeft = 90;
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * projectile.direction;
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
			target.AddBuff(mod.BuffType("Electrocute"), 300);
			target.AddBuff(44, 300);
		}
	}
}
