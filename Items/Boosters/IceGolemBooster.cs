using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class IceGolemBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Golem Booster");
			Tooltip.SetDefault("Provides immunity to Chilled, Frozen and Frostburn debuffs");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Ледяного Голема");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт невосприимчивость к Охлаждению, Заморозке и Морозному Ожогу");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
