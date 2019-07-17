using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class Fear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 192;
			projectile.height = 192;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear");
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
			target.buffImmune[BuffID.OnFire] = false;
			target.AddBuff(BuffID.OnFire, 600);
		}
	}
}
