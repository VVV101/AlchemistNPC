using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles

{
	public class WatcherCrystal : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 40;  
            projectile.hostile = false;  
            projectile.friendly = false;
            projectile.ignoreWater = true; 
            Main.projFrames[projectile.type] = 9;
            projectile.timeLeft = 18000;
            projectile.penetrate = -1; 
            projectile.tileCollide = false; 
            projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

		public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Watcher Crystal");
		}
	
        public override void AI()
        {
			{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.dead || player.FindBuffIndex(mod.BuffType("WatcherCrystal")) <= -1)
			{
				modPlayer.watchercrystal = false;
			}
			if (modPlayer.watchercrystal)
			{
				projectile.timeLeft = 2;
			}
			
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 520f && target.catchItem == 0 && !target.friendly && target.active && target.type != 488)
                {
                    if (projectile.ai[0] > 60f) // Time in (60 = 1 second) 
                    {
                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 617, projectile.damage, 0, Main.myPlayer, 0f, 0f);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
			projectile.frameCounter++;
			if (projectile.frameCounter > 20)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 8)
			{ projectile.frame = 0; }
        }
    }
}
}