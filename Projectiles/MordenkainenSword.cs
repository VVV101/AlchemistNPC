using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class MordenkainenSword : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MordenkainenSword");
			projectile.light = 0.8f;
			Main.projFrames[projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.width = 44;
			projectile.height = 44;
			projectile.timeLeft = 30;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.melee = true;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)	
		{
			return false;
		}
			
		public override void AI()
		{
			projectile.tileCollide = false;
			projectile.velocity *= 0f;
			projectile.rotation += 0.15f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 6;
		}
	}
}
