using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles.Minions
{
	public class Devilsknife : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(533);
			projectile.aiStyle = 66;
			aiType = 533;
            projectile.width = 78;
            projectile.height = 86;  
            projectile.ignoreWater = true; 
            projectile.timeLeft = 36000;
            projectile.penetrate = -1; 
            projectile.tileCollide = false; 
            projectile.minion = true;
			projectile.minionSlots = 1;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}
		
				
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)	
		{
			return false;
		}
		
		public override void AI()
		{
			projectile.tileCollide = false;
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.dead || !player.HasBuff(mod.BuffType("Devilsknife")))
			{
				modPlayer.devilsknife = false;
			}
			if (modPlayer.devilsknife)
			{
				projectile.timeLeft = 2;
			}
			if (player.direction == 1)
			{
				projectile.spriteDirection = -1;
			}
			if (player.direction == -1)
			{
				projectile.spriteDirection = 1;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 2;
		}
	}
}