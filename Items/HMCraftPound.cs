using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
    public class HMCraftPound : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superb Crafting Pound");
            Tooltip.SetDefault("Now you can do best stuff");
            DisplayName.AddTranslation(GameCulture.Russian, "Сложный Крафтовый Фунт");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы можете делать крутые штуки");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 1;
            item.value = 10000000;
            item.rare = 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bookcase);
            recipe.AddRecipeGroup("AlchemistNPC:AnyAnvil");
            recipe.AddRecipeGroup("AlchemistNPC:AnyForge");
			recipe.AddIngredient(ItemID.ImbuingStation);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
			recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
