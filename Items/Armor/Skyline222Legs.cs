using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Skyline222Legs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyline222's (Noire) skirt");
			DisplayName.AddTranslation(GameCulture.Russian, "Юбка Нуар"); 
			Tooltip.SetDefault("Skyline222's short skirt with boots");
			Tooltip.AddTranslation(GameCulture.Russian, "Коротенькая юбка Нуар с ботинками");

            DisplayName.AddTranslation(GameCulture.Chinese, "Skyline222 (Noire) 的裙子");
            Tooltip.AddTranslation(GameCulture.Chinese, "Skyline222的短裙, 配有一双靴子");
        }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 16;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}