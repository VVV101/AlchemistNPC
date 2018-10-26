using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class Skyline222Body : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skyline222's (Noire) shirt");
            DisplayName.AddTranslation(GameCulture.Russian, "Блузка Нуар");
            Tooltip.SetDefault("Skyline222's cute shirt");
            Tooltip.AddTranslation(GameCulture.Russian, "Милая блузка Нуар");

            DisplayName.AddTranslation(GameCulture.Chinese, "Skyline222's (Noire) 的衬衫");
            Tooltip.AddTranslation(GameCulture.Chinese, "Skyline222的可爱衬衫");
        }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}