using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorJungle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Jungle''");
			Tooltip.SetDefault("Forces biome state to Jungle while placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Джунгли''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует Джунглевый биом когда размещён");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''丛林''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为丛林");
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
			item.value = 100000;
			item.createTile = mod.TileType("HoloprojectorJungle");
		}
	}
}