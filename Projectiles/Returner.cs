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
	public class Returner : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 1920;
			projectile.height = 1080;
			projectile.penetrate = -1;
			projectile.timeLeft = 1;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Returner");
		}
	}
}
