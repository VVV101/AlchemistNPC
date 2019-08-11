using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BrainOfCthulhuBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu booster");
			Tooltip.SetDefault("Increases max amount of minions by 1, Heartreach effect");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Мозга Ктулху");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальной количество прислужников на 1, сердца притягиваются к игроку");
			DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之脑增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "增加1召唤物上限，获得心之彼端效果");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
