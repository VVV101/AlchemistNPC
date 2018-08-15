using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class NyctosythiaCrystal : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Crystal");
			Tooltip.SetDefault("Diamond of Nihility"
			+"\nConsumes any form of light");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристалл Никтосифии");
			Tooltip.AddTranslation(GameCulture.Russian, "Алмаз Нигилизма\nПоглощает свет любой формы");

            DisplayName.AddTranslation(GameCulture.Chinese, "夜蛾水晶");
            Tooltip.AddTranslation(GameCulture.Chinese, "夜蛾的钻石\n消耗任意形式的光");
        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 50000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(null, "CrystalDust", 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.FragmentVortex, 2);
			recipe.AddIngredient(ItemID.FragmentStardust, 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
