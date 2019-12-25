using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class SkeletronBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron booster");
			Tooltip.SetDefault("Skeletons contact damage is reduced, all damages/critical strike chances are increased by 10%");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Скелетрона");
			Tooltip.AddTranslation(GameCulture.Russian, "Контактный урон скелетов уменьшен, показатели урона и шанса критического удара повышены на 10%");
			DisplayName.AddTranslation(GameCulture.Chinese, "骷髅王增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "骷髅的接触伤害降低，所有伤害和暴击率提升10%");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().SkeletronBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().SkeletronBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().SkeletronBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().SkeletronBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
