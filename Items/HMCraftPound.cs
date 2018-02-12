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
            DisplayName.SetDefault("Superb Crafting Pound");
            Tooltip.SetDefault("Now you can do best stuff");
            DisplayName.AddTranslation(GameCulture.Russian, "������� ��������� ����");
            Tooltip.AddTranslation(GameCulture.Russian, "�� ������ ������ ������ �����");
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
            recipe.AddIngredient(ItemID.MythrilAnvil);
            recipe.AddIngredient(ItemID.AdamantiteForge);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bookcase);
            recipe.AddIngredient(ItemID.OrichalcumAnvil);
            recipe.AddIngredient(ItemID.AdamantiteForge);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bookcase);
            recipe.AddIngredient(ItemID.MythrilAnvil);
            recipe.AddIngredient(ItemID.TitaniumForge);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bookcase);
            recipe.AddIngredient(ItemID.OrichalcumAnvil);
            recipe.AddIngredient(ItemID.TitaniumForge);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

        }
    }
}
