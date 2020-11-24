using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BrokenBooster1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Booster (1)");
			Tooltip.SetDefault("Can be fixed if use certain materials");
			DisplayName.AddTranslation(GameCulture.Russian, "Сломанный усилитель (1)");
			Tooltip.AddTranslation(GameCulture.Russian, "Может быть починен если найти необходимые материалы");
			DisplayName.AddTranslation(GameCulture.Chinese, "破损的增益容器(1)");
			Tooltip.AddTranslation(GameCulture.Chinese, "使用某些材料可以修复");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = ItemRarityID.LightRed;
		}
	}
}
