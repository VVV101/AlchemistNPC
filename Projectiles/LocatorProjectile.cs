using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace AlchemistNPC.Projectiles
{
	class LocatorProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			// NO! projectile.aiStyle = 48;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.extraUpdates = 100;
			projectile.timeLeft = 100; // lowered from 300
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}

		// Note, this Texture is actually just a blank texture, FYI.
		public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly;

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 8f)
			{
				int i = 0;
				if (Main.rand.NextBool(4))
				{
					Vector2 projectilePosition = projectile.position;
					projectilePosition -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					// Important, changed 173 to 178!
					int dust = Dust.NewDust(projectilePosition, 1, 1, 178, 0f, 0f, 0, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectilePosition;
					Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
					Main.dust[dust].velocity *= 0.2f;
				}
			}
		}
	}
}