using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class SpringShield : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spring Shield");
			projectile.light = 0.1f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.width = 48;
			projectile.height = 48;
			projectile.penetrate = 200;
			projectile.timeLeft = 99999;
			projectile.tileCollide = false;
			projectile.friendly = false;
			projectile.magic = false;
			aiType = ProjectileID.LaserMachinegunLaser;
			projectile.extraUpdates = 1;
			projectile.scale = 1.5f;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = (AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer");
			projectile.position.X = player.position.X-15;
			projectile.position.Y = player.position.Y;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(0f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(180f);
			}
			if (projectile.frameCounter < 20)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 20 && projectile.frameCounter < 40)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 40 && projectile.frameCounter < 60)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 60 && projectile.frameCounter < 80)
				projectile.frame = 3;
			else if (projectile.frameCounter >= 80 && projectile.frameCounter < 100)
				projectile.frame = 4;
			else if (projectile.frameCounter >= 100 && projectile.frameCounter < 120)
				projectile.frame = 5;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
			
			if (player.dead || modPlayer.RevSet == false)
			{
				projectile.Kill();
			}
		}
	}
}
