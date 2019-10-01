using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class DimensionalRift : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 64;
			item.noUseGraphic = true;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("DimensionalRift");
			item.shootSpeed = 10f;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Rift");
			Tooltip.SetDefault(@"Glass globe containing the rift between dimensions
Don't break it!!!");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Разрыв между измерениями");
			Tooltip.AddTranslation(GameCulture.Russian, @"Стеклянный шар, хранящий разрыв между измерениями внутри
Не разбей его!!!");
			DisplayName.AddTranslation(GameCulture.Chinese, "次元裂隙");
			Tooltip.AddTranslation(GameCulture.Chinese, @"含有次元之间裂缝的玻璃球
别打破了!!!");
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("StrangeTopHat"));
			recipe.AddIngredient(170, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
