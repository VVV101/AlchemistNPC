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
	public class AkumuShield : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumu Shield");
			projectile.light = 0.2f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.width = 72;
			projectile.height = 72;
			projectile.penetrate = 200;
			projectile.timeLeft = 9999;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center;
			if (++projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
			
			if (player.statLife > player.statLifeMax2/4 || player.dead || player.GetModPlayer<AlchemistNPCPlayer>().Akumu == false)
			{
				projectile.Kill();
			}
			for(int i = 0; i < 1000; ++i)
			{
				if(Main.projectile[i].active && i != projectile.whoAmI )
				{
					if(Main.projectile[i].Hitbox.Intersects(projectile.Hitbox) && !Main.projectile[i].friendly)
					{
					ReflectProjectile(Main.projectile[i]);
					}
				}
			}
		}
			
			public void ReflectProjectile(Projectile proj)
			{
				proj.velocity *= -1;
				proj.damage *= 10;
				proj.hostile = false;
				proj.friendly = true;
			}
	}
}
