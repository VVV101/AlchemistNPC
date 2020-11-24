using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorDesert : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Desert''");
			Tooltip.SetDefault("Forces biome state to Desert while placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Пустыня''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует Пустынный биом когда размещён");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''神圣''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为神圣");
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
			item.createTile = mod.TileType("HoloprojectorDesert");
		}
	}
}