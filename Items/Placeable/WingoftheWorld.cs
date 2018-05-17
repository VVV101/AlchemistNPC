using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class WingoftheWorld : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wing of the World");
			Tooltip.SetDefault("Needed to craft EGO equipment"
			+"\nCounts as table, chair and light source");
			DisplayName.AddTranslation(GameCulture.Russian, "Крыло Мира");
			Tooltip.AddTranslation(GameCulture.Russian, "Необходимо для создания Э.П.О.С экипировки\nСчитается за стол, стул и источник света"); 
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 100000;
			item.createTile = mod.TileType("WingoftheWorld");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}