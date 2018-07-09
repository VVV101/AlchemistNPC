using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class AlchemicalBundle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemical Bundle");
			Tooltip.SetDefault("Contains some Lunar Materials"
				+ "\nRequired for making Elixir of Life");
			DisplayName.AddTranslation(GameCulture.Russian, "Алхимический набор");
            Tooltip.AddTranslation(GameCulture.Russian, "Содержит в себе немного материалов Лунара\nНеобходим для создания Эликсира Жизни");
            DisplayName.AddTranslation(GameCulture.Chinese, "炼金捆绑包");
            Tooltip.AddTranslation(GameCulture.Chinese, "包含一些月之材料\n制作仙丹需要用到它");

        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 2500000;
			item.rare = 9;
			item.knockBack = 6;
			item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 25);
			recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(ItemID.FragmentStardust, 25);
			recipe.AddIngredient(ItemID.LunarOre, 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
