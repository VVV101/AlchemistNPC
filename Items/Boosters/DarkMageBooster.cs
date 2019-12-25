using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class DarkMageBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Mage Booster");
			Tooltip.SetDefault("Increases magic damage by 25%, max mana by 50 and mana regeneration greatly");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Тёмного Мага");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 25%, максимальную ману на 50 и значительно увеличивает скорость регенерации маны");
			DisplayName.AddTranslation(GameCulture.Chinese, "黑魔法师增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "提升25%魔法伤害，增加50魔法上限并极大提升魔力再生速度");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().DarkMageBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().DarkMageBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().DarkMageBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().DarkMageBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
