using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class LastTantrum : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharp Needle");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(616);
			projectile.width = 10;
			projectile.height = 24;
			aiType = 616;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			Main.PlaySound(SoundID.Item34, projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionPlasma"), projectile.damage, 0, Main.myPlayer);
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
			Main.PlaySound(SoundID.Item34, projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 0f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("ExplosionPlasma"), projectile.damage, 0, Main.myPlayer);
		}
	}
}