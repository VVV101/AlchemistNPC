using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
    public class ReversivityCoinTier3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reversivity Coin Tier 3");
			DisplayName.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Третий");
            Tooltip.SetDefault("Some Tooltip");
			Tooltip.AddTranslation(GameCulture.Russian, "Тоже еще не придумал описание"); 
        }
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 8;
		}
        public override void AddRecipes()
        {
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReversivityCoinTier4", 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
			}
        }
    }
}