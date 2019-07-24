using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BetsyBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Betsy Booster");
			Tooltip.SetDefault("Your attacks inflict Daybroken, flight abilities are increased");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Бетси");
			Tooltip.AddTranslation(GameCulture.Russian, "Ваши атаки накладывают Солнечное Пламя, улучшает способности к полёту");
			DisplayName.AddTranslation(GameCulture.chinese, "贝特西增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "你的攻击造成破晓，飞行能力提升");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().BetsyBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BetsyBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().BetsyBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BetsyBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
