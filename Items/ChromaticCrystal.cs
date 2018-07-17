using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ChromaticCrystal : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromatic Crystal");
			Tooltip.SetDefault("Hallowed Crystal, overflowed by power");
			DisplayName.AddTranslation(GameCulture.Russian, "Хроматический кристалл");
			Tooltip.AddTranslation(GameCulture.Russian, "Святой кристалл, переполненный мощью");

            DisplayName.AddTranslation(GameCulture.Chinese, "炫彩水晶");
            Tooltip.AddTranslation(GameCulture.Chinese, "神圣的水晶, 充斥着无尽的能量");
        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 5000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 5);
			recipe.AddIngredient(null, "CrystalDust", 3);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
