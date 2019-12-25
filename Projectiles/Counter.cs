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
	public class Counter : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Counter");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
			projectile.ranged = false;
			projectile.width = 200;
			projectile.height = 200;
			projectile.penetrate = 1;
			projectile.timeLeft = 15;
			projectile.tileCollide = false;
			projectile.friendly = false;
			aiType = ProjectileID.BulletHighVelocity;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center;
			for(int i = 0; i < 1000; ++i)
			{
				if(Main.projectile[i].active && i != projectile.whoAmI )
				{
					if(Main.projectile[i].Hitbox.Intersects(projectile.Hitbox) && Main.projectile[i].active && !Main.projectile[i].friendly && Main.projectile[i].hostile)
					{
					DestroyProjectile(Main.projectile[i]);
					}
				}
			}
		}
		
		public void DestroyProjectile(Projectile proj)
		{
			proj.Kill();
		}
	}
}