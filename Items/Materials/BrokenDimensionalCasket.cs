using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class BrokenDimensionalCasket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Dimensional Casket");
			Tooltip.SetDefault(@"Broken Dimensional Casket
Required for making working one");
			DisplayName.AddTranslation(GameCulture.Russian, "Сломанная Телепортирующая Шкатулка");
            Tooltip.AddTranslation(GameCulture.Russian, @"Сломанная межизмеренческая шкатулка
Необходима для создания рабочей");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 5;
	
		}
	}
}
