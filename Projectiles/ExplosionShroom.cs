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
	public class ExplosionShroom : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ExplosionShroom");
			projectile.timeLeft = 30;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(443);
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.magic = false;
			projectile.ranged = true;
			projectile.width = 40;
			projectile.height = 40;
			projectile.penetrate = 2;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			aiType = 443;
		}

		public override void AI()
		{
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 400f && target.catchItem == 0 && !target.friendly && target.active)
                {
                    if (projectile.ai[0] > 25f)
                    {
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						Main.PlaySound(SoundID.Item93.WithVolume(.5f), projectile.position);
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX*3, shootToY*3, 435, projectile.damage, 0, Main.myPlayer, 0f, 0f);
						Main.projectile[proj].hostile = false;
						Main.projectile[proj].friendly = true;
						Main.projectile[proj].ranged = true;
						Main.projectile[proj].penetrate = 3;
						Main.projectile[proj].tileCollide = false;
						Main.projectile[proj].usesLocalNPCImmunity = true;
						Main.projectile[proj].localNPCHitCooldown = -1;
						Main.projectile[proj].timeLeft = 300;
                        projectile.ai[0] = 0f;
                    }
                }
            }
		}
	}
}
