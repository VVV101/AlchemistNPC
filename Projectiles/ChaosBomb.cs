using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class ChaosBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Bomb");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(261);
			projectile.width = 40;
			projectile.height = 62;
			projectile.magic = false;
			projectile.thrown = true;
			projectile.aiStyle = 14;
			aiType = 261;
		}
		
		public override void AI()
		{
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			
			for (int index1 = 0; index1 < 30; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index2].velocity *= 1.4f;
			}
			for (int index1 = 0; index1 < 20; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 3.5f);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 7f;
				int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
				Main.dust[index3].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
				float num2 = 0.4f;
				if (index1 == 1)
				num2 = 0.8f;
				int index2 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index2].velocity *= num2;
				++Main.gore[index2].velocity.X;
				++Main.gore[index2].velocity.Y;
				int index3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index3].velocity *= num2;
				--Main.gore[index3].velocity.X;
				++Main.gore[index3].velocity.Y;
				int index4 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index4].velocity *= num2;
				++Main.gore[index4].velocity.X;
				--Main.gore[index4].velocity.Y;
				int index5 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(), Main.rand.Next(61, 64), 1f);
				Main.gore[index5].velocity *= num2;
				--Main.gore[index5].velocity.X;
				--Main.gore[index5].velocity.Y;
			}
			
            if (projectile.owner == Main.myPlayer)
            {
				Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
				float num75 = 10f;
				float num82 = (float)projectile.Center.X - vector2.X;
				float num83 = (float)projectile.Center.Y - vector2.Y;
				float num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
				float num85 = num84;
				if ((float.IsNaN(num82) && float.IsNaN(num83)) || (num82 == 0f && num83 == 0f))
				{
					num82 = (float)projectile.direction;
					num83 = 0f;
					num84 = 11f;
				}
				else
				{
					num84 = 11f / num84;
				}
				num82 *= num84;
				num83 *= num84;
				int num117 = 5;
				for (int num118 = 0; num118 < num117; num118++)
				{
					vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + ((float)projectile.Center.X - player.position.X), projectile.Center.Y - 600f);
					vector2.X = (vector2.X + player.Center.X) / 2f + (float)Main.rand.Next(-350, 351);
					vector2.Y -= (float)(100 * num118);
					num82 = (float)projectile.Center.X - vector2.X;
					num83 = (float)projectile.Center.Y - vector2.Y;
					float ai2 = num83 + vector2.Y;
					if (num83 < 0f)
					{
						num83 *= -1f;
					}
					if (num83 < 20f)
					{
						num83 = 20f;
					}
					num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
					num84 = num75 / num84;
					num82 *= num84;
					num83 *= num84;
					Vector2 vector11 = new Vector2(num82, num83) / 2f;
					switch (Main.rand.Next(4))
					{
						case 0:
							Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, mod.ProjectileType("CB1"), projectile.damage*2, 8f, player.whoAmI);
							break;
						case 1:
							Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, mod.ProjectileType("CB2"), projectile.damage*2, 8f, player.whoAmI);
							break;
						case 2:
							Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, mod.ProjectileType("CB3"), projectile.damage*2, 8f, player.whoAmI);
							break;
						case 3:
							Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X*2f, vector11.Y*2f, mod.ProjectileType("CB4"), projectile.damage*2, 8f, player.whoAmI);
							break;
					}
				}
			}
		}
		
					
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == mod.NPCType("BillCipher"))
			{
			damage /= 250;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.Kill();
		}
	}
}
