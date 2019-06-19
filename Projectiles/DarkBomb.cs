using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DarkBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Bomb");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(261);
			projectile.width = 30;
			projectile.height = 28;
			projectile.aiStyle = 14;
			aiType = 261;
		}
		
		public override void AI()
		{
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			for (int index1 = 0; index1 < 60; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, Color.Purple, 1.5f);
				Main.dust[index2].velocity *= 1f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.Kill();
		}
	}
}
