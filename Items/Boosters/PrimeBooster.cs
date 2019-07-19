using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class PrimeBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron Prime booster");
			Tooltip.SetDefault("Increases armor penetration and melee speed by 15/15%, gives 200% thorns effect");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Скелетрона Прайма");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает пробивание брони и скорость ближнего боя на 15/15%, даёт 200% эффект шипов");
			DisplayName.AddTranslation(GameCulture.Chinese, "机械骷髅王增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "提升15点护甲穿透和15%的近战速度，给予200%的荆棘药剂效果");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().PrimeBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PrimeBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().PrimeBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().PrimeBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
