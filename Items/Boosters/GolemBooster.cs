using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class GolemBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem booster");
			Tooltip.SetDefault("Increases attack speed by 10% and increases melee knockback");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Голема");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорсть атаки на 10% и усиливает отбрасывание в ближнем бою");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
