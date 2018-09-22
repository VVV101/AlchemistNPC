using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class Madness : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Madness");
		}

		public override void SetDefaults()
		{
			projectile.width = 128;
			projectile.height = 128;
			projectile.penetrate = -1;
			projectile.timeLeft = 99999;
			projectile.hostile = true;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.dead || !NPC.AnyNPCs(mod.NPCType("BillCipher")))
				{
					projectile.Kill();
				}
				if (player.Hitbox.Intersects(projectile.Hitbox))
				{
				player.AddBuff(BuffID.Electrified, 360);
				player.AddBuff(BuffID.OgreSpit, 360);
				}
			}
		}
	}
}