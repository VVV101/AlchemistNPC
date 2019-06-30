using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace AlchemistNPC.Projectiles
{
	public class Bees : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bees");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
		projectile.CloneDefaults(ProjectileID.Bee);
		projectile.netImportant = true;
		projectile.netUpdate = true;
		projectile.magic = true; 
		projectile.timeLeft = 240;
		aiType = ProjectileID.Bee;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					{
						projectile.scale = 1.5f;
					}	
					else if (player.armor[index1].type == 3333)
					{
						projectile.scale = 1.5f;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							projectile.scale = 1.5f;
						}
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (player.armor[index1].type == 3333)
					{
						projectile.scale = 1.5f;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							projectile.scale = 1.5f;
						}
					}
				}	
			}
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (player.armor[index1].type == ModLoader.GetMod("CalamityMod").ItemType("PlagueHive"))
					{
						damage += damage/2;
					}
					else if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							damage += damage/2;
						}
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (player.armor[index1].type == 3333)
					{
						damage += damage/2;
					}
					else if (ModLoader.GetMod("FargowiltasSouls") != null)
					{
						if (player.armor[index1].type == ModLoader.GetMod("FargowiltasSouls").ItemType("BeeEnchant"))
						{
							damage += damage/2;
						}
					}
				}	
			}
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			projectile.penetrate = 1;
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BeeHeal == true)
			{
				if (Main.rand.Next(10) == 0)
				{
				player.statLife += 2;
				player.HealEffect(2, true);
				}
			}
		}
	}
}
