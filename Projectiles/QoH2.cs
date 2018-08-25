using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH2");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(503);
			projectile.melee = false;
			projectile.magic = true;
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
			Player player = Main.player[projectile.owner]; 
			player.statMana += 10;
			player.ManaEffect(10);
			target.immune[projectile.owner] = 1;
		}
	}
}
