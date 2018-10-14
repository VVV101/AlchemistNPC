using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DeadlyLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deadly Lazer");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(100);
			projectile.width = 6;
			projectile.tileCollide = false;
			projectile.aiStyle = 1;
			aiType = 100;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.friendly)
			{
			damage = 5;
			}
		}
	}
}
