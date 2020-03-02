using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Enums;
namespace AlchemistNPC.Projectiles
{
	class LocatorProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.light = 0.75f;
			projectile.width = 22;
			projectile.height = 28;
			// NO! projectile.aiStyle = 48;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.timeLeft = 61; // lowered from 300
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			int NPCnumber = (int)projectile.ai[0];
			Vector2 npcpos = new Vector2((int)Main.npc[NPCnumber].Center.X, (int)Main.npc[NPCnumber].Center.Y);
			Player player = Main.player[projectile.owner];

			if (projectile.owner == Main.myPlayer) // Multiplayer support
			{
				Vector2 diff = npcpos - player.Center;
				diff.Normalize();
				projectile.velocity = diff;
				projectile.direction = npcpos.X > player.Center.X ? 1 : -1;
				projectile.netUpdate = true;
			}
			projectile.position = player.position + projectile.velocity * 45f;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
		}
	}
}