using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.NPCs;

namespace AlchemistNPC.Projectiles
{
	public class DimensionalRift : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Rift");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(261);
			projectile.width = 32;
			projectile.height = 32;
			projectile.magic = false;
			projectile.damage = 0;
			projectile.aiStyle = 14;
			projectile.timeLeft = 300;
			aiType = 261;
		}
		
		public override void AI()
		{
			if (projectile.timeLeft <= 290)
			{
				projectile.width = 64;
				projectile.height = 64;
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BillCipher"));
			BillCipher.introduction = 0;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
	}
}
