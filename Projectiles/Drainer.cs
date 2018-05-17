using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class Drainer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drainer");
			projectile.timeLeft = 150;
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.hostile = true;
			projectile.width = 98;
			projectile.height = 98;
			projectile.penetrate = 2;
			projectile.damage = 100;
			projectile.timeLeft = 70;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
		}
		
		public override void AI()
		{
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
		
		public override void OnHitPlayer(Player target, int damage, bool crit)	
		{
			Player player = Main.player[projectile.owner]; 
			player.statLife += 200;
			player.HealEffect(200, true);
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.townNPC == true || target.friendly == true)
			{
			damage = 1;
			}
		}
	}
}
