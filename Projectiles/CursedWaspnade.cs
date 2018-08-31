using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class CursedWaspnade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice Waspnade");
		}

		public override void SetDefaults()
		{
		projectile.CloneDefaults(30);
		projectile.aiStyle = 2;
		projectile.timeLeft = 180;
		projectile.scale = 0.8f;
		aiType = 30;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = 338;
			return true;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.aiStyle = 16;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
		
		public override void AI()
		{
			projectile.aiStyle = 2;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int h = 0; h < 11; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("CursedWasps"), projectile.damage, 0, Main.myPlayer);
			}
		}
	}
}
