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
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reversivity Coin Tier 3");
			DisplayName.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Третий");
            Tooltip.SetDefault("Can be used for buying Treasure Bags from Operator");
			Tooltip.AddTranslation(GameCulture.Russian, "Может быть использована для покупки сумок у Оператора"); 
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