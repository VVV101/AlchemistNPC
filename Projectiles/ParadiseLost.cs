using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class ParadiseLost : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost");
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			projectile.magic = false;
			projectile.melee = true;
			projectile.width = 60;
			projectile.height = 46;
			projectile.penetrate = 200;
			projectile.timeLeft = 70;
			projectile.tileCollide = false;
			aiType = ProjectileID.LaserMachinegunLaser;
			projectile.extraUpdates = 1;
			projectile.scale = 2f;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner]; 
			projectile.position.X = player.position.X;
			projectile.position.Y = player.position.Y-10;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(0f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(180f);
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
			target.immune[projectile.owner] = 2;
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			if (Main.rand.Next(6) == 0)
			{
				for (int h = 0; h < 1; h++)
				{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 0f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("PaleStar"), projectile.damage, 0, Main.myPlayer);
				}
			}
		}
	
	}
}
