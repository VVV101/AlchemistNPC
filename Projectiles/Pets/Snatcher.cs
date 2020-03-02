using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Projectiles.Pets
{
	public class Snatcher : ModProjectile
	{
		public static int c1 = 0;
		public static int c2 = 0;
		public override void SetDefaults()
		{
			Main.projFrames[projectile.type] = 8;
			projectile.width = 56;
			projectile.height = 58;
			Main.projPet[projectile.type] = true;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snatcher, the Cursed Prince");
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(mod.BuffType("Snatcher")))
			{
				modPlayer.snatcher = false;
			}
			if (modPlayer.snatcher)
			{
				projectile.timeLeft = 2;
			}
			
			if (player.direction == 1)
			{
				projectile.spriteDirection = 1;
				projectile.position.X = player.position.X - 60;
				
			}
			if (player.direction == -1)
			{
				projectile.spriteDirection = -1;
				projectile.position.X = player.position.X + 25;
			}
			if (c1 < 75)
			{
				c1++;
				c2++;
				projectile.position.Y = player.position.Y - 80 + c1/5;
			}
			if (c1 >= 75)
			{
				c2--;
				projectile.position.Y = player.position.Y - 80 + c2/5;
			}
			if (c2 == 0)
			{
				c1 = 0;
				projectile.position.Y = player.position.Y - 80;
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && projectile.frame != 0)
			{
				if (++projectile.frameCounter > 3)
				{
					if (projectile.frame > 0)
					{
						projectile.frame--;
						projectile.frameCounter = 0;
					}
				}
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && projectile.frame == 2)
			{
				projectile.frame = 0;
			}
			
			if ((player.velocity.Y != 0f || player.velocity.X != 0f) && projectile.frame != 7)
			{
				if (++projectile.frameCounter > 1)
				{
					if (projectile.frame < 7)
					{
						projectile.frame++;
						projectile.frameCounter = 0;
					}
				}
			}
			
			if (modPlayer.SnatcherCounter >= 15000)
			{
				projectile.ai[0]++;
				for (int i = 0; i < 200; i++)
				{
					NPC target = Main.npc[i];

					float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
					float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
					float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

					if (distance < 500f && target.catchItem == 0 && !target.dontTakeDamage && !target.friendly && target.active)
					{
						if (projectile.ai[0] > 60f)
						{
							int dmg = 1;
							if (player.HeldItem.damage < 50)
							{
								dmg = player.HeldItem.damage*4;
							}
							else if (player.HeldItem.damage < 100)
							{
								dmg = player.HeldItem.damage*2;
							}
							else
							{
								dmg = player.HeldItem.damage/2;
							}
							Vector2 vel = new Vector2(0, -1);
							vel *= 10f;
							Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode.WithVolume(.8f), projectile.position);
							for (int j = 0; j < 2; j++)
							{
								Vector2 perturbedSpeed = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed1 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed2 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed3 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Vector2 perturbedSpeed4 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
								Projectile.NewProjectile(target.Center.X, target.Center.Y+48, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ShadowBurst"), dmg, 0, Main.myPlayer, 0f, 0f);
								Projectile.NewProjectile(target.Center.X, target.Center.Y+48, perturbedSpeed1.X, perturbedSpeed1.Y, mod.ProjectileType("ShadowBurst"), dmg, 0, Main.myPlayer, 0f, 0f);
								Projectile.NewProjectile(target.Center.X, target.Center.Y+48, perturbedSpeed2.X, perturbedSpeed2.Y, mod.ProjectileType("ShadowBurst"), dmg, 0, Main.myPlayer, 0f, 3f);
								Projectile.NewProjectile(target.Center.X, target.Center.Y+48, perturbedSpeed3.X, perturbedSpeed3.Y, mod.ProjectileType("ShadowBurst"), dmg, 0, Main.myPlayer, 0f, 3f);
								Projectile.NewProjectile(target.Center.X, target.Center.Y+48, perturbedSpeed4.X, perturbedSpeed4.Y, mod.ProjectileType("ShadowBurst"), dmg, 0, Main.myPlayer, 0f, 0f);
							}
							projectile.ai[0] = 0f;
						}
					}
				}
			}
		}
	}
}
