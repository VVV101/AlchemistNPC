using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class GrimReaper : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);

			aiType = ProjectileID.Bunny;
			Main.projFrames[projectile.type] = 8;
			projectile.width = 40;
			projectile.height = 50;
			Main.projPet[projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gregg the Grim Reaper");

		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.dead || !player.HasBuff(mod.BuffType("GrimReaper")))
			{
				modPlayer.grimreaper = false;
			}
			if (modPlayer.grimreaper)
			{
				projectile.timeLeft = 2;
			}
			
			if (projectile.frameCounter > 20)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 8)
			{ projectile.frame = 0; }
		}
	}
}
