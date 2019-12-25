using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class FieldsMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Deltarune OST - Field of Hopes and Dreams)");
			Tooltip.SetDefault("By Toby Fox");
			DisplayName.AddTranslation(GameCulture.Russian, "Музыкальная шкатулка (Deltarune OST - Field of Hopes and Dreams)");
			DisplayName.AddTranslation(GameCulture.Chinese, "音乐盒 (Deltarune OST - Field of Hopes and Dreams)");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("FieldsMusicBox");
			item.width = 24;
			item.height = 24;
			item.rare = 4;
			item.value = 500000;
			item.accessory = true;
		}
	}
}
