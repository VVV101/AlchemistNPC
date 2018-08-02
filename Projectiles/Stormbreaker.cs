using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class Stormbreaker : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker's Throw");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(182);
			projectile.width = 40;
			projectile.height = 34;
			projectile.aiStyle = 3;
			aiType = 182;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(SoundID.Item94.WithVolume(.6f), projectile.position);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionShroom"), projectile.damage, 0, Main.myPlayer);
		}
	}
}
