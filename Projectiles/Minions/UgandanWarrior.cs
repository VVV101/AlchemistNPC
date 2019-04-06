using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles.Minions
{
	public class UgandanWarrior : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Warrior");
			Main.projFrames[projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(533);
			projectile.width = 96;
			projectile.height = 76;
			projectile.aiStyle = 66;
			projectile.minionSlots = 1;
			aiType = 533;
			projectile.tileCollide = false;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)	
		{
			return false;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			damage += (damage/5) * player.maxMinions;
			if (target.type == mod.NPCType("BillCipher"))
			{
				damage /= 100;
			}
		}
			
		public override void AI()
		{
			projectile.tileCollide = false;
			Player player = Main.player[projectile.owner]; 
			if (player.dead || !player.HasBuff(mod.BuffType("UgandanWarrior")))
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
	}
}
