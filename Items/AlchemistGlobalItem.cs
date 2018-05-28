using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Rampage == true && type == 14)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("Chloroshard");
			}
		}
		
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SuspiciousLookingScythe"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HeartofYui"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BanHammer"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PinkGuyHead"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyBody"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BlackCatHead"));
				player.QuickSpawnItem(mod.ItemType("BlackCatBody"));
				player.QuickSpawnItem(mod.ItemType("BlackCatLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Skyline222Hair"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Body"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Legs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("somebody0214Hood"));
				player.QuickSpawnItem(mod.ItemType("somebody0214Robe"));
			}
		}
	}
}
