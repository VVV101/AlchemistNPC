using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class MartianSaucerBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Martian Saucer booster");
			Tooltip.SetDefault("Provides immunity to Electrified and Distorted debuffs");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Летающей Тарелки");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт иммунитет к Электризации и Дестабилизации");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().MartianSaucerBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().MartianSaucerBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().MartianSaucerBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().MartianSaucerBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
