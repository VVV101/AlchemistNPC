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
	public class IField : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 1920;
			projectile.height = 1080;
			projectile.penetrate = -1;
			projectile.timeLeft = 90;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Immortality Field");
		}
		
		public override void AI()
		{
			for (int k = 0; k < 200; k++)
			{
				NPC target = Main.npc[k];
				if(target.Hitbox.Intersects(projectile.Hitbox) && target.townNPC)
				{
					target.buffImmune[mod.BuffType("IField")] = false;
					target.AddBuff(mod.BuffType("IField"), 3600);
				}
			}
		}
	}
}
