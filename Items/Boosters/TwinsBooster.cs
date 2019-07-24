using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class TwinsBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twins booster");
			Tooltip.SetDefault("Archery and Ammo Reservation effects, immunity to Cursed Flames and Ichor");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Близнецов");
			Tooltip.AddTranslation(GameCulture.Russian, "Эффекты Стрельбы и Экономии Боеприпасов, иммунитет к Проклятому Пламени и Ихору");
			DisplayName.AddTranslation(GameCulture.Chinese, "双子魔眼增益容器");
			Tooltip.AddTranslation(GameCulture.Chinese, "箭术和弹药储备药剂效果，免疫咒焰和脓血");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().TwinsBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().TwinsBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().TwinsBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().TwinsBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
