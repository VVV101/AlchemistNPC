using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class AkumuSphere : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Akumu");
			projectile.light = 0.5f;
			Main.projFrames[projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(533);
			projectile.width = 28;
			projectile.height = 28;
			projectile.aiStyle = 66;
			aiType = 533;
			projectile.tileCollide = false;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)	
		{
			return false;
		}
			
		public override void AI()
		{
			projectile.tileCollide = false;
			Player player = Main.player[projectile.owner]; 
			if (player.statLife < player.statLifeMax2*0.35f || player.dead || !player.HasBuff(mod.BuffType("TrueAkumuAttack")))
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 3;
		}
	}
}
