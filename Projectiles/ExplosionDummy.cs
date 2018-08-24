using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class ExplosionDummy : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
			projectile.timeLeft = 150;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.penetrate = 40;
			projectile.timeLeft = 40;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 3;
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	
	}
}
