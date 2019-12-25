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
    public class SpecCraftPoint : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Special Crafting Point");
            Tooltip.SetDefault("You've proven that you can do anything with any material"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.Russian, "СпецКрафтовый Поинт");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы доказали, что можете сделать что угодно с любым материалом\nМожет быть размещён как станция крафта");

            DisplayName.AddTranslation(GameCulture.Chinese, "特殊手工位点");
            Tooltip.AddTranslation(GameCulture.Chinese, "你已经证明了你可以用任何材料做出任何东西\n可代替工作台");
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
			item.value = 10000;
			item.createTile = mod.TileType("SpecCraftPoint");
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HoneyDispenser);
			recipe.AddIngredient(ItemID.SteampunkBoiler);
			recipe.AddIngredient(ItemID.FleshCloningVaat);
			recipe.AddIngredient(ItemID.SkyMill);
			recipe.AddIngredient(ItemID.Solidifier);
			recipe.AddIngredient(ItemID.Keg);
			recipe.AddIngredient(ItemID.IceMachine);
			recipe.AddIngredient(ItemID.GlassKiln);
			recipe.AddIngredient(ItemID.LivingLoom);
			recipe.AddIngredient(ItemID.BoneWelder);
			recipe.AddIngredient(ItemID.WaterBucket);
			recipe.AddIngredient(ItemID.LavaBucket);
			recipe.AddIngredient(ItemID.HoneyBucket);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
        }
    }
}
