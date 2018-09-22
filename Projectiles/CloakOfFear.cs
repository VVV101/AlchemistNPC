using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
			for (int i = 0; i < 5; i++)
				{
					int dustType = Main.rand.Next(51, 54);
					int dustIndex = Dust.NewDust(projectile.position, 96, 96, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.95f;
					dust.noGravity = true;
				}
			
			if (player.dead || !player.HasBuff(mod.BuffType("CloakOfFear")))
			{
				projectile.Kill();
			}
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
				if(target.active && !target.friendly && !target.townNPC && !target.boss)
				{
					if (target.Hitbox.Intersects(projectile.Hitbox))
					{
					Fear(target);
					}
				}
			}
		}
			
			public void Fear(NPC target)
			{
				target.velocity *= -1;
				target.buffImmune[mod.BuffType("CloakOfFearDebuff")] = false;
				target.AddBuff(mod.BuffType("CloakOfFearDebuff"), 360);
			}
	}
}
