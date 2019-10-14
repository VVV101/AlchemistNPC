using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class TwilightWings : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twilight Wings (O-02-63)");
            Tooltip.SetDefault("''They withstood the twilight and faced the dawn. In the forest, did the birds twitter stop?''"
            + "\n[c/FF0000:EGO Gift]"
            + "\nCounts as wings"
            + "\nHas huge wing time and excellent horizontal speed");
            DisplayName.AddTranslation(GameCulture.Russian, "Крылья Сумерек (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Они выстояли Сумерки и встретили Закат. Прекратили ли птицы чирикать в лесу?''\n[c/FF0000:Э.П.О.С. Дар]\nСчитаются крыльями\nИмеют большое время полёта и великолепную горизонтальную скорость");

            DisplayName.AddTranslation(GameCulture.Chinese, "薄暝之翼 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'人们最终战胜了黄昏的黑暗, 准备面对黎明的光辉.'\n'而在那片昏暗的森林中, 鸟儿的叽喳鸣唱依旧响彻着吗?'\n[c/FF0000:EGO 礼物]\n拥有很长的飞行时间和很快的飞行速度");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BigBirdLamp"), 60);
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
