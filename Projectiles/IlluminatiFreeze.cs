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
	public class IlluminatiFreeze : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 3200;
			projectile.height = 3200;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illuminati Freeze");
		}
		
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(projectile.Hitbox) && !target.townNPC && !target.friendly && !target.boss)
				{
						target.buffImmune[mod.BuffType("Patience")] = false;
						target.AddBuff(mod.BuffType("Patience"), 600);
				}
			}
		}
	}
}
