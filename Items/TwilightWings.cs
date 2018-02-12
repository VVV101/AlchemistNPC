using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPC.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class TwilightWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Wings (O-02-63)");
			Tooltip.SetDefault("They withstood the twilight and faced the dawn. In the forest, did the birds twitter stop?"
			+ "\n[c/FF0000:EGO Gift]"
			+ "\nWorks as Wings");
			DisplayName.AddTranslation(GameCulture.Russian, "Крылья Сумерек (O-02-63)");
			Tooltip.AddTranslation(GameCulture.Russian, "Они выстояли Сумерки и всретили Закат. Прекратили ли птицы чирикать в лесу?\n[c/FF0000:Э.П.О.С. Дар]\nРаботает как Крылья"); 
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 240;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 16f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BigBirdLamp");
			recipe.AddIngredient(null, "EmagledFragmentation", 50);
			recipe.AddRecipeGroup("AlchemistNPC:AnyCelestialWings");
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}