using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class PF666 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 1920;
			projectile.height = 1080;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PF666");
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			player.inferno = true;
			if (projectile.timeLeft == 30)
			{
			projectile.friendly = false;
			}
			Main.monolithType = 3;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	}
}
