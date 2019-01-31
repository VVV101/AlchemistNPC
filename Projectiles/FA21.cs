using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA21 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Cloud 1");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(511);
			projectile.magic = false;
			projectile.thrown = true;
			projectile.aiStyle = 92;
			aiType = 511;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 8;
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.OnFire, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.CursedInferno, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.Daybreak, 180);
			}
		}
	}
}
