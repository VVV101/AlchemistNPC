using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class DestroyerBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Destroyer booster");
			Tooltip.SetDefault("Increases mining speed by 33% and increases max life by 25%");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Уничтожителя");
			Tooltip.AddTranslation(GameCulture.Russian, "Cкорость копания увеличена на 33% и увеличивает максимальное здоровье на 25%");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().DestroyerBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().DestroyerBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().DestroyerBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().DestroyerBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
