using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
    public class JP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Arkhalis);
            projectile.width = 50;
            projectile.height = 46;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            Main.projFrames[mod.ProjectileType("JP")] = 28;
            projectile.aiStyle = 75;
            aiType = 595;
        }
        public override void AI()
        {
			if (Main.myPlayer == projectile.owner)
            {
                //Do net updatey thing. Syncs this projectile.
				if (Main.rand.Next(3) == 0)
                {
                 int num30 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 2f);
                    Main.dust[num30].noGravity = true;
                    Main.dust[num30].position -= projectile.velocity;
                 }
                projectile.netUpdate = true;
                Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                if (Main.player[projectile.owner].Center.Y < mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    projectile.position.X = (Main.player[projectile.owner].Center.X + DistXT) - 30;
                    projectile.position.Y = (Main.player[projectile.owner].Center.Y + DistYT) - 30;
                }
                if (Main.player[projectile.owner].Center.Y >= mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    projectile.position.X = (Main.player[projectile.owner].Center.X + (0 - DistXT)) - 30;
                    projectile.position.Y = (Main.player[projectile.owner].Center.Y + (0 - DistYT)) - 30;
                }
            }
			
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("JustitiaPale"), 600);
			target.immune[projectile.owner] = 3;
		}

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            projHitbox.X -= projHitbox.Width / 2;
            projHitbox.Y -= projHitbox.Height / 2;
            projHitbox.Width *= 2;
            projHitbox.Height *= 2;
            return projHitbox.Intersects(targetHitbox);
        }
    }
}

