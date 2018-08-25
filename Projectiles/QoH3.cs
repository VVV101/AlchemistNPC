using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH3");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(503);
			projectile.melee = false;
			projectile.ranged = true;
			projectile.aiStyle = 5;
			aiType = 503;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 503;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[projectile.owner] = 1;
		target.AddBuff(mod.BuffType("JustitiaPale"), 300);
		}
	}
}
