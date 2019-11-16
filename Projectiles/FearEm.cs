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
	public class FearEm : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear emitter effect");
		}

		public override void SetDefaults()
		{
			projectile.width = 256;
			projectile.height = 256;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = false;
		}
		public override void AI()
		{
			projectile.ai[0]++;
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
				if(target.active && !target.friendly && !target.townNPC && !target.boss)
				{
					if (target.Hitbox.Intersects(projectile.Hitbox))
					{
						if (!target.HasBuff(mod.BuffType("CloakOfFearDebuff"))) target.velocity *= -1;
						if (projectile.ai[0] == 5) target.velocity += target.velocity*(-3);
						target.buffImmune[mod.BuffType("CloakOfFearDebuff")] = false;
						target.AddBuff(mod.BuffType("CloakOfFearDebuff"), 360);
					}
				}
			}
			if (projectile.ai[0] == 6) projectile.ai[0] = 0;
		}
	}
}
