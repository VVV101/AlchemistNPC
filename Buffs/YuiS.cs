using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class YuiS : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Yui");
			Description.SetDefault("Welcome back to A... Wait, that is not Alfheim! Where are we?"
			+"\nEnlights treasures, creatures and traps");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Юи"); 
			Description.AddTranslation(GameCulture.Russian, "Добро пожаловать обратно в А... Погоди-ка, это не Альфхейм! Где мы?\nПодсвечивает сокровища, существ и ловушки");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.GetModPlayer<AlchemistNPCPlayer>(mod).YuiS = true;
			player.GetModPlayer<AlchemistNPCPlayer>(mod).Yui = false;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("YuiS")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("YuiS"), 0, 0f, player.whoAmI, 0f, 0f);
			}
			if ((player.controlDown && player.releaseDown))
			{
				if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].type == mod.ProjectileType("YuiS") && Main.projectile[j].owner == player.whoAmI)
						{
							Projectile lightpet = Main.projectile[j];
							Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
							lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
						}
					}
				}
			}
		}
	}
}