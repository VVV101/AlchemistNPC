using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles.Pets
{
	public class YuiS : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			projectile.width = 72;
			projectile.height = 64;
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.ZephyrFish;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.LightPet[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			projectile.scale = 0.5f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yui");

		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false;
			return true;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 1f);
			}
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = (AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer");
			if (player.dead)
			{
				modPlayer.Yui = false;
			}
			if (modPlayer.Yui)
			{
				projectile.timeLeft = 2;
			}
			Lighting.AddLight(projectile.position, 3.0f, 3.0f, 3.0f);
		}
	}
}