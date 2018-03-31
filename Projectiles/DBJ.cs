using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class DBJ : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBJ");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.ranged = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.scale = 0.75f;
			aiType = ProjectileID.Bullet;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.RocketIII;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	
	}
}