using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class Wellcheers : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("'Wellcheers' Vending Machine");
			Tooltip.SetDefault("'Opened can of Wellcheers' Vending Machine"
			+ "\n[c/FF0000:Abnormality]"
			+ "\nRisk level: [c/00FF00:ZAYIN]"
			+ "\nProduces 4 different types of Soda"
			+ "\nWorks only on Night Time"
			+ "\nCan be used 10 times without any consequences");
			DisplayName.AddTranslation(GameCulture.Russian, "Машина по продаже напитков 'Wellcheers'");
			Tooltip.AddTranslation(GameCulture.Russian, "Машина по продаже напитков 'Opened can of Wellcheers'\n[c/FF0000:Аномалия]\nУровень риска: [c/00FF00:ZAYIN]\nПроизводит 4 различных вида Соды\nРаботает только ночью\nМожет быть использована 10 раз без последствий"); 
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("Wellcheers");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 25);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}