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
	public class CloakOfFear : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak of Fear");
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.width = 96;
			projectile.height = 96;
			projectile.penetrate = -1;
			projectile.timeLeft = 9999;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = false;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center;
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
