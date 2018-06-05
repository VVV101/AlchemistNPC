using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class AkumuMirror : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AkumuMirror");
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = false;
			projectile.ranged = true;
			projectile.width = 50;
			projectile.height = 46;
			projectile.penetrate = 200;
			projectile.timeLeft = 70;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
			projectile.scale = 2f;
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(180f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(0f);
			}
			if (projectile.frameCounter < 10)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 20)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 20 && projectile.frameCounter < 30)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 30 && projectile.frameCounter < 40)
				projectile.frame = 3;
			else if (projectile.frameCounter >= 40 && projectile.frameCounter < 50)
				projectile.frame = 4;
			else if (projectile.frameCounter >= 50 && projectile.frameCounter < 60)
				projectile.frame = 5;
			else if (projectile.frameCounter >= 60 && projectile.frameCounter < 70)
				projectile.frame = 6;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
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
