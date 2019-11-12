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
    public class FearEmitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FEAR Emitter");
            Tooltip.SetDefault("Restricts non-boss enemies from going through certain region");
            DisplayName.AddTranslation(GameCulture.Russian, "Излучатель страха");
            Tooltip.AddTranslation(GameCulture.Russian, "Не позволяет враждебным НПС - не-боссам пересечь зону страха");
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
			item.createTile = mod.TileType("FearEmitter");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.Wire, 150);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
