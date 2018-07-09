using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
    public class ReversivityCoinTier5 : ModItem
    {
        public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("CalamityMod") != null;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reversivity Coin Tier 5");
			DisplayName.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Пятый");
            Tooltip.SetDefault("Can be used for buying Treasure Bags from Operator");
			Tooltip.AddTranslation(GameCulture.Russian, "Может быть использована для покупки сумок у Оператора");
            DisplayName.AddTranslation(GameCulture.Chinese, "5级扭蛋币");
            Tooltip.AddTranslation(GameCulture.Chinese, "可以用来在操作员处购买宝藏袋");
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReversivityCoinTier6", 1);
            recipe.AddTile((ModLoader.GetMod("CalamityMod").TileType("DraedonsForge")));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}