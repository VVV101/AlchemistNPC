using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ID;

namespace AlchemistNPC.Items.Placeable
{
	public class TheWorldRevolvingMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Deltarune OST - The World Revolving)");
			Tooltip.SetDefault("By Toby Fox");
			DisplayName.AddTranslation(GameCulture.Russian, "Музыкальная шкатулка (Deltarune OST - The World Revolving)");
			DisplayName.AddTranslation(GameCulture.Chinese, "音乐盒 (Deltarune OST - The World Revolving)");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("TheWorldRevolvingMusicBox");
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.LightRed;
			item.value = 500000;
			item.accessory = true;
		}
	}
}
