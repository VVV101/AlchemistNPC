using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items
{
	public class SephirothicFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sephirotic Fruit");
			Tooltip.SetDefault("The last of Echidna's seeds... Holds incredible powers inside."
			+"\nIncreases minions damage by 10%"
			+"\nIncreases max amount of minions by 2"
			+"\nMinions ignore enemy invincibility frames");
			DisplayName.AddTranslation(GameCulture.Russian, "Плод Сефирот");
			Tooltip.AddTranslation(GameCulture.Russian, "Последнее семя Ехидны... Хранит невероятные силы внутри\nПовышает урон прислужников на 10%\nПрислужники игнорируют период неуязвимости у противника"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AlchemistNPC.SF = true;
            player.minionDamage += 0.10f;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeFruit, 10);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.Nanites, 50);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.NecromanticScroll);
			recipe.AddIngredient(ItemID.PygmyNecklace);
			recipe.AddIngredient(ItemID.FragmentStardust, 30);
			recipe.AddIngredient(ItemID.LunarBar, 15); 
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}