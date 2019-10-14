using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class ConeOfColdProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cone Of Cold");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(118);
			projectile.melee = false;
			projectile.magic = true;
			projectile.aiStyle = 28;
			aiType = 118;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!target.boss && Main.rand.Next(10) == 0)
			{
			target.buffImmune[mod.BuffType("Slowness")] = false;
			target.AddBuff(mod.BuffType("Slowness"), 120);
			}
			if (!target.boss && Main.rand.Next(30) == 0)
			{
			target.buffImmune[mod.BuffType("Patience")] = false;
			target.AddBuff(mod.BuffType("Patience"), 120);
			}
		}
	}
}
