using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorSnow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Snow''");
			Tooltip.SetDefault("Forces biome state to Snow while placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Зимний''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует Зимний биом когда размещён");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''冰雪''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为冰雪");
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
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 100000;
			item.createTile = mod.TileType("HoloprojectorSnow");
		}
	}
}