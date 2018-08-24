using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH1");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(503);
			projectile.aiStyle = 5;
			aiType = 503;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner]; 
			player.statLife += 2;
			player.HealEffect(2, true);
			target.immune[projectile.owner] = 1;
		}
	}
}
