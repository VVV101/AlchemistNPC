using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class EyeOfCthulhuBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Cthulhu booster");
			Tooltip.SetDefault("Provides creatures, treasures and traps detection");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Глаза Ктулху");
			Tooltip.AddTranslation(GameCulture.Russian, "Позволяет видеть сокровища, существ и ловушки");
			DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之眼增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "提供生物，宝藏和陷阱的探测能力");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().EyeOfCthulhuBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().EyeOfCthulhuBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().EyeOfCthulhuBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().EyeOfCthulhuBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
