using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class MoneyVacuum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of the Greed");
			Tooltip.SetDefault("While this is in your inventory, all dropped in world money go to your inventory");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			for (int number = 0; number < 400; ++number)
			{
				if (Main.item[number].active && Main.item[number].type == 71)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 72)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 73)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				else if (Main.item[number].active && Main.item[number].type == 74)
				{
					Main.item[number] = player.GetItem(player.whoAmI, Main.item[number], false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}
		
		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimsonHeart);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(mod.ItemType("BrokenDimensionalCasket"));
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(mod.ItemType("DivineLava"), 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowOrb);
			recipe.AddIngredient(ItemID.GoldRing);
			recipe.AddIngredient(mod.ItemType("BrokenDimensionalCasket"));
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(mod.ItemType("DivineLava"), 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
