using Terraria;
using Terraria.ModLoader;
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