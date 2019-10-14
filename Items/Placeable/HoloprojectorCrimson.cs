using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorCrimson : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Crimson''");
			Tooltip.SetDefault("Forces biome state to Crimson while placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Кримзон''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует биом Кримзон когда размещён");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''血腥''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为血腥");
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
			item.createTile = mod.TileType("HoloprojectorCrimson");
		}
	}
}