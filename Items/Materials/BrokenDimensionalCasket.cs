using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			DisplayName.AddTranslation(GameCulture.Chinese, "破损的次元匣");
			Tooltip.AddTranslation(GameCulture.Chinese, @"破损的次元匣
用于制作次元匣");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = ItemRarityID.Pink;
	
		}
	}
}
