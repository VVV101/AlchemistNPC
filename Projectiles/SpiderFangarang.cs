using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;

namespace AlchemistNPC.Projectiles
{
	public class SpiderFangarang : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Fangarang");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(272);
			projectile.melee = false;
			projectile.thrown = true;
			projectile.aiStyle = 3;
			aiType = 272;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			return base.OnTileCollide(oldVelocity);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[BuffID.Poisoned] = false;
			target.AddBuff(BuffID.Poisoned, 300);
		}
	}
}
