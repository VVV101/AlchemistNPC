using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
    public class PreHMBadge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Simple Crafting Penny");
            Tooltip.SetDefault("Makes you look like a master of carpentry");
            DisplayName.AddTranslation(GameCulture.Russian, "Простой Крафтовый Пенни");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы теперь мастер-слесарь");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 1;
            item.value = 1000000;
            item.rare = 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddIngredient(ItemID.IronAnvil);
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddIngredient(ItemID.DyeVat);
            recipe.AddIngredient(ItemID.WoodenTable);
            recipe.AddIngredient(ItemID.WoodenChair);
            recipe.AddIngredient(ItemID.CookingPot);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddIngredient(ItemID.ImbuingStation);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddIngredient(mod, "ArtificialAltar")
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
