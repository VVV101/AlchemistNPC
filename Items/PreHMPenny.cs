using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
    public class PreHMPenny : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Simple Crafting Penny");
            Tooltip.SetDefault("Makes you look like a master of carpentry"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.Russian, "Простой Крафтовый Пенни");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы теперь мастер-слесарь\nМожет быть размещён как станция крафта");
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
			item.createTile = mod.TileType("PreHMPenny");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddRecipeGroup("AlchemistNPC:AnyPreHMAnvil");
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.DyeVat);
            recipe.AddIngredient(ItemID.WoodenTable);
            recipe.AddIngredient(ItemID.WoodenChair);
            recipe.AddIngredient(ItemID.CookingPot);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddIngredient(mod, "ArtificialAltar");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
