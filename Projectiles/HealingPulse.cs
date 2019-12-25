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
	public class HealingPulse : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 1920;
			projectile.height = 1080;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healing Pulse");
		}
		
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(projectile.Hitbox) && target.friendly && target.life != target.lifeMax)
				{
						for (int i = 0; i < 10; i++)
						{
							int dustType = Main.rand.Next(74, 75);
							int dustIndex = Dust.NewDust(target.position, target.width, target.height, dustType);
							Dust dust = Main.dust[dustIndex];
							dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
							dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
							dust.scale *= 0.9f;
							dust.noGravity = true;
						}
						target.life += 10;
						target.HealEffect(10, true);
						if (target.life > target.lifeMax)
						{
							target.life = target.lifeMax;
						}
				}
			}
		}
	}
}
