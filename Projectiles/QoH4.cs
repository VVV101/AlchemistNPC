using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH4 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH4");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(503);
			projectile.melee = false;
			projectile.thrown = true;
			projectile.aiStyle = 5;
			aiType = 503;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = 503;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			damage *= 2;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[projectile.owner] = 1;
		}
	}
}
