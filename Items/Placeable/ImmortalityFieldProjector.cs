using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
    public class ImmortalityFieldProjector : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Immortality Field Projector");
            Tooltip.SetDefault("Makes town NPCs instantly respawn after being killed in its working range");
            DisplayName.AddTranslation(GameCulture.Russian, "Излучатель Поля Бессмертия");
            Tooltip.AddTranslation(GameCulture.Russian, "Мгновенно возрождает городских НПС, убитых в пределах действия устройства");
        }
		
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.value = 1000000;
            item.rare = 7;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("ImmortalityFieldProjector");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
            recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(ItemID.Wire, 200);
			recipe.AddIngredient(mod.ItemType("ChromaticCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("SunkroveraCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("NyctosythiaCrystal"), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
