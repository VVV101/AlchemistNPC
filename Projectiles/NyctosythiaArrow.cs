using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class NyctosythiaArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			aiType = ProjectileID.WoodenArrowFriendly;
			
		}
		
		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("Hate"),
						projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
					dust.velocity += projectile.velocity * 0.3f;
					dust.velocity *= 0.2f;
				}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(SoundID.NPCDeath52.WithVolume(.3f), projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 12f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("NyctosyphiaBeam"), projectile.damage/4, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(0, -1);
			vel2 = vel.RotatedBy(rand);
			vel2 *= 12f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel2.X, vel2.Y, mod.ProjectileType("NyctosyphiaBeam"), projectile.damage/4, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(0, -1);
			vel3 = vel.RotatedBy(rand);
			vel3 *= 12f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel3.X, vel3.Y, mod.ProjectileType("NyctosyphiaBeam"), projectile.damage/4, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(0, -1);
			vel4 = vel.RotatedBy(rand);
			vel4 *= 12f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel4.X, vel4.Y, mod.ProjectileType("NyctosyphiaBeam"), projectile.damage/4, 0, Main.myPlayer);
			return true;
		}
	}
}