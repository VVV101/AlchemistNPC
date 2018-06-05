using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class SpearofJusticeG : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 900;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			aiType = 616;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SpearofJusticeG");
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}

		}
	}
}
