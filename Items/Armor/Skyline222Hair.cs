using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Skyline222Hair : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyline222's (Noire) hairstyle");
			DisplayName.AddTranslation(GameCulture.Russian, "Причёска Нуар"); 
			Tooltip.SetDefault("Skyline222's fancy hairstyle.");
			Tooltip.AddTranslation(GameCulture.Russian, "Красивая причёска Нуар"); 
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 100000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}