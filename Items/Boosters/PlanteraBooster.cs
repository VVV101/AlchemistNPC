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
