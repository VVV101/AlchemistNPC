using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class PF422 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PF422");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(190);
			projectile.ranged = false;
			projectile.thrown = true;
			projectile.aiStyle = 39;
			aiType = 190;
		}
		
		public override void AI()
		{
			projectile.velocity *= 1.2f;
			projectile.velocity *= 1.02f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[projectile.owner] = 2;
		projectile.rotation *= 1.1f;
		}
	}
}
