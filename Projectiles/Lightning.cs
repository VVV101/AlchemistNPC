using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class Lightning : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker Lightning");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(580);
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.aiStyle = 88;
			aiType = 580;
		}
		
		public override bool CanHitPlayer(Player target)
		{
		return false;
		}
		
		public override bool? CanHitNPC(NPC target)	
		{
			if (target.friendly)
			{
			return false;
			}
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[projectile.owner] = 3;
		}
	}
}
