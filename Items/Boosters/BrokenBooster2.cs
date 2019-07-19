using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BrokenBooster2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Booster (2)");
			Tooltip.SetDefault("Can be fixed if use certain materials");
			DisplayName.AddTranslation(GameCulture.Russian, "Сломанный усилитель (2)");
			Tooltip.AddTranslation(GameCulture.Russian, "Может быть починен если найти необходимые материалы");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = 4;
		}
	}
}
