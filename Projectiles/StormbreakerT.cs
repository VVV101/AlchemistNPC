using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class StormbreakerT : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker's Throw");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(182);
			projectile.width = 50;
			projectile.height = 40;
			projectile.aiStyle = 3;
			projectile.melee = false;
			projectile.thrown = true;
			aiType = 182;
			projectile.usesLocalNPCImmunity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			Main.PlaySound(SoundID.Item94.WithVolume(.6f), projectile.position);
			for (int h = 0; h < 2; h++)
				{
					Vector2 vel1 = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel1 = vel1.RotatedBy(rand);
					vel1 *= 16f;
					float ai = Main.rand.Next(100);
					int n1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel1.X, vel1.Y, 580, damage/5, .5f, player.whoAmI, vel1.ToRotation(), ai);
					Main.projectile[n1].usesLocalNPCImmunity = true;
				}
		}
	}
}
