using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles.Pets
{
	public class Snatcher : ModProjectile
	{
		public static int c1 = 0;
		public static int c2 = 0;
		public override void SetDefaults()
		{
			Main.projFrames[projectile.type] = 8;
			projectile.width = 56;
			projectile.height = 58;
			Main.projPet[projectile.type] = true;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snatcher, the Cursed Prince");
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(mod.BuffType("Snatcher")))
			{
				modPlayer.snatcher = false;
			}
			if (modPlayer.snatcher)
			{
				projectile.timeLeft = 2;
			}
			
			if (player.direction == 1)
			{
				projectile.spriteDirection = 1;
				projectile.position.X = player.position.X - 60;
				
			}
			if (player.direction == -1)
			{
				projectile.spriteDirection = -1;
				projectile.position.X = player.position.X + 25;
			}
			if (c1 < 75)
			{
				c1++;
				c2++;
				projectile.position.Y = player.position.Y - 80 + c1/5;
			}
			if (c1 >= 75)
			{
				c2--;
				projectile.position.Y = player.position.Y - 80 + c2/5;
			}
			if (c2 == 0)
			{
				c1 = 0;
				projectile.position.Y = player.position.Y - 80;
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && projectile.frame != 0)
			{
				if (++projectile.frameCounter > 3)
				{
					if (projectile.frame > 0)
					{
						projectile.frame--;
						projectile.frameCounter = 0;
					}
				}
			}
			
			if (player.velocity.Y == 0f && player.velocity.X == 0f && projectile.frame == 2)
			{
				projectile.frame = 0;
			}
			
			if ((player.velocity.Y != 0f || player.velocity.X != 0f) && projectile.frame != 7)
			{
				if (++projectile.frameCounter > 1)
				{
					if (projectile.frame < 7)
					{
						projectile.frame++;
						projectile.frameCounter = 0;
					}
				}
			}
		}
	}
}
