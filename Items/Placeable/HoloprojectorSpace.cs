using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorSpace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Space''");
			Tooltip.SetDefault("Forces biome state to Space while placed"
			+"\nNo visual/music effect will appear");
			DisplayName.AddTranslation(GameCulture.Russian, "Голопроектор ''Космос''");
            Tooltip.AddTranslation(GameCulture.Russian, "Фиксирует биом Космос когда размещён\nНикаких визуальных эффектов или музыки не появится");
			DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''太空''");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置时强制把地形状态变为太空");
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
			item.createTile = mod.TileType("HoloprojectorSpace");
		}
	}
}