using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class WoFBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh booster booster");
			Tooltip.SetDefault("Increases max amount of minions/sentries by 1, defense and DR by 10/10%");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Стены Плоти");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальной количество прислужников/турелей на 1, защиту и сопротивление урону на 10/10%");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().WoFBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().WoFBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().WoFBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().WoFBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
