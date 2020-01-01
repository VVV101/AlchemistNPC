using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Blinker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blinker");
			Tooltip.SetDefault("Gives you dash in the form of instant teleport for short distance");
			DisplayName.AddTranslation(GameCulture.Russian, "Блинкер");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт вам рывок в форме мгновенного телепорта на небольшое расстояние");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Blinker = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Tabi);
			recipe.AddIngredient(ItemID.RodofDiscord);
			recipe.AddIngredient(mod.ItemType("ChromaticCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("SunkroveraCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("NyctosythiaCrystal"), 5);
			recipe.AddTile(mod.TileType("MateriaTransmutator"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
}
