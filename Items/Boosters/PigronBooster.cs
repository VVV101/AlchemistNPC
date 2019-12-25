using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class PigronBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pigron Booster");
			Tooltip.SetDefault("Provides Well Fed");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Ледяного Голема");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт постоянную Сытость");
			DisplayName.AddTranslation(GameCulture.Chinese, "猪龙增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "吃得饱!");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().PigronBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PigronBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().PigronBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PigronBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
