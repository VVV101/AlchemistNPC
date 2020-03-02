using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class Void : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.magic = true;
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
			DisplayName.SetDefault("Void Breath");

		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
			if (projectile.timeLeft > 75)
			{
				projectile.timeLeft = 75;
			}
			if (projectile.ai[0] > 4f)
			{
				float num302 = 1f;
				if (projectile.ai[0] == 8f)
				{
					num302 = 0.25f;
				}
				else if (projectile.ai[0] == 9f)
				{
					num302 = 0.5f;
				}
				else if (projectile.ai[0] == 10f)
				{
					num302 = 0.75f;
				}
				projectile.ai[0] += 1f;
				int num303 = 86;
				if (Main.rand.Next(2) == 0)
				{
					int num3;
					for (int num304 = 0; num304 < 1; num304 = num3 + 1)
					{
						int num305 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num303, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						Dust dust;
						if (Main.rand.Next(3) != 0 || (Main.rand.Next(3) == 0))
						{
							Main.dust[num305].noGravity = true;
							dust = Main.dust[num305];
							dust.scale *= 2.5f;
							Dust var_2_E189_cp_0_cp_0 = Main.dust[num305];
							var_2_E189_cp_0_cp_0.velocity.X = var_2_E189_cp_0_cp_0.velocity.X * 2f;
							Dust var_2_E1AA_cp_0_cp_0 = Main.dust[num305];
							var_2_E1AA_cp_0_cp_0.velocity.Y = var_2_E1AA_cp_0_cp_0.velocity.Y * 2f;
						}
						if (projectile.type == 188)
						{
							dust = Main.dust[num305];
							dust.scale *= 1.25f;
						}
						else
						{
							dust = Main.dust[num305];
							dust.scale *= 1.5f;
						}
						Dust var_2_E21E_cp_0_cp_0 = Main.dust[num305];
						var_2_E21E_cp_0_cp_0.velocity.X = var_2_E21E_cp_0_cp_0.velocity.X * 1.2f;
						Dust var_2_E23F_cp_0_cp_0 = Main.dust[num305];
						var_2_E23F_cp_0_cp_0.velocity.Y = var_2_E23F_cp_0_cp_0.velocity.Y * 1.2f;
						dust = Main.dust[num305];
						dust.scale *= num302;
						if (num303 == 86)
						{
							dust = Main.dust[num305];
							dust.velocity += projectile.velocity;
							if (!Main.dust[num305].noGravity)
							{
								dust = Main.dust[num305];
								dust.velocity *= 0.5f;
							}
						}
						num3 = num304;
					}
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == mod.NPCType("BillCipher"))
			{
			damage /= 200;
			}
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
			if (Main.rand.NextBool(15))
			{
				target.buffImmune[mod.BuffType("Patience")] = false;
				target.AddBuff(mod.BuffType("Patience"), 10);
			}
		}
	}
}
