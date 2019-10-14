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
	public class Fear2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 256;
			projectile.height = 256;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear 2");
		}
		
		public override void AI()
		{
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
				if(target.active && !target.friendly && !target.townNPC && !target.boss)
				{
					if (target.Hitbox.Intersects(projectile.Hitbox))
					{
					SoulFear(target);
					}
				}
			}
		}

		public void SoulFear(NPC target)
		{
			target.buffImmune[mod.BuffType("CurseOfLight")] = false;
			target.AddBuff(mod.BuffType("CurseOfLight"), 600);
			target.buffImmune[BuffID.Ichor] = false;
			target.AddBuff(BuffID.Ichor, 600);
			target.buffImmune[BuffID.CursedInferno] = false;
			target.AddBuff(BuffID.CursedInferno, 600);
			target.buffImmune[BuffID.ShadowFlame] = false;
			target.AddBuff(BuffID.ShadowFlame, 600);
		}
	}
}
