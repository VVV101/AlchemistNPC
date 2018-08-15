using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
    public class HMCraftPound : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superb Crafting Pound");
            Tooltip.SetDefault("Now you can do best stuff"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.Russian, "Сложный Крафтовый Фунт");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы можете делать крутые штуки\nМожет быть размещён как станция крафта");

            DisplayName.AddTranslation(GameCulture.Chinese, "豪华手工英镑");
            Tooltip.AddTranslation(GameCulture.Chinese, "现在你可以做出最棒的东东了\n可代替工作台");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 1;
            item.value = 1000000;
            item.rare = 7;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("HMCraftPound");
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
			recipe.AddIngredient(ItemID.LihzahrdFurnace);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
