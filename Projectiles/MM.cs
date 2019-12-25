using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class MM : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Missile");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.ranged = false;
			projectile.magic = true;
			projectile.width = 16;
			projectile.height = 22;
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
				float num1 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
                float num2 = projectile.localAI[0];
                if (num2 == 0.0)
                {
                    projectile.localAI[0] = num1;
                    num2 = num1;
                }
                float num3 = projectile.position.X;
                float num4 = projectile.position.Y;
                float num5 = 300f;
                bool flag2 = false;
                int num6 = 0;
                if (projectile.ai[1] == 0.0)
                {
                    for (int index = 0; index < 200; ++index)
                    {
                        if (Main.npc[index].CanBeChasedBy(this, false) && (projectile.ai[1] == 0.0 || projectile.ai[1] == (double)(index + 1)))
                        {
                            float num7 = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                            float num8 = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                            float num9 = Math.Abs(projectile.position.X + (projectile.width / 2) - num7) + Math.Abs(projectile.position.Y + (projectile.height / 2) - num8);
                            if (num9 < num5 && Collision.CanHit(new Vector2(projectile.position.X + (projectile.width / 2), projectile.position.Y + (projectile.height / 2)), 1, 1, Main.npc[index].position, Main.npc[index].width, Main.npc[index].height))
                            {
                                num5 = num9;
                                num3 = num7;
                                num4 = num8;
                                flag2 = true;
                                num6 = index;
                            }
                        }
                    }
                    if (flag2)
                        projectile.ai[1] = (float)(num6 + 1);
                    flag2 = false;
                }
                if (projectile.ai[1] > 0.0)
                {
                    int index = (int)(projectile.ai[1] - 1.0);
                    if (Main.npc[index].active && Main.npc[index].CanBeChasedBy(this, true) && !Main.npc[index].dontTakeDamage)
                    {
                        if ((double)(Math.Abs(projectile.position.X + (projectile.width / 2) - (Main.npc[index].position.X + (float)(Main.npc[index].width / 2))) + Math.Abs(projectile.position.Y + (projectile.height / 2) - (Main.npc[index].position.Y + (float)(Main.npc[index].height / 2)))) < 1000.0)
                        {
                            flag2 = true;
                            num3 = Main.npc[index].position.X + (float)(Main.npc[index].width / 2);
                            num4 = Main.npc[index].position.Y + (float)(Main.npc[index].height / 2);
                        }
                    }
                    else
                        projectile.ai[1] = 0.0f;
                }
                if (!projectile.friendly)
                    flag2 = false;
                if (flag2)
                {
                    float num7 = num2;
                    Vector2 vector2 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    float num8 = num3 - vector2.X;
                    float num9 = num4 - vector2.Y;
                    float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
                    float num11 = num7 / num10;
                    float num12 = num8 * num11;
                    float num13 = num9 * num11;
                    int num14 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num14 - 1) + num12) / num14;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num14 - 1) + num13) / num14;
                }
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	}
}
