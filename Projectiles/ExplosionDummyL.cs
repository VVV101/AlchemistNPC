using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class ExplosionDummyL : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion Dummy");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = true;
			projectile.width = 96;
			projectile.height = 96;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
		}
	}
}
