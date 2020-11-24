using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
    public class Pommel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pommel");
			DisplayName.AddTranslation(GameCulture.Russian, "Навершие");
            Tooltip.SetDefault("Contains the Light of Purity");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит Свет Чистоты");
			DisplayName.AddTranslation(GameCulture.Chinese, "球饰");
			Tooltip.AddTranslation(GameCulture.Chinese, "包含着纯净之光");
        }
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.value = 100000;
			item.rare = ItemRarityID.Yellow;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
            recipe.AddTile(mod.TileType("MateriaTransmutator"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}