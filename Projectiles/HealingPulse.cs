using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
