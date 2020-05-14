using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			ModGlobalNPC.bsu = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
	}
}
