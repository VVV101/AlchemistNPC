using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class DBD : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBD");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.ranged = false;
			projectile.melee = true;
			projectile.width = 60;
			projectile.height = 34;
			projectile.timeLeft = 300;
			aiType = ProjectileID.Bullet;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.HellfireArrow;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.lifeMax > 6666)
			{
			damage = 150;
			}
			if (target.lifeMax <= 6666)
			{
			damage = 6666;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			AlchemistNPC.DTH++;
		}
	}
}