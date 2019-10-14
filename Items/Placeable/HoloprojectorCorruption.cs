using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorCorruption : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Corruption''");
			Tooltip.SetDefault("Forces biome state to Corruption while placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Искажения''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует биом Искажения когда размещён");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''腐化''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为腐化");
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
			item.createTile = mod.TileType("HoloprojectorCorruption");
		}
	}
}