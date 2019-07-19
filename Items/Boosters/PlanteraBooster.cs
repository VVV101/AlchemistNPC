using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class PlanteraBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera booster");
			Tooltip.SetDefault("Damages and critical strike chances are boosted while you are moving, Philosopher's stone effect");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Плантеры");
			Tooltip.AddTranslation(GameCulture.Russian, "Урон и шансы критического удара повышены, когда вы двигаетесь, эффект Философского камня");
			DisplayName.AddTranslation(GameCulture.Chinese, "世纪之花增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "移动时增加伤害和暴击率，获得炼金石效果(减药水cd)");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().PlanteraBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PlanteraBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().PlanteraBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PlanteraBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
