using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class FishronBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron booster");
			Tooltip.SetDefault("Gives ability to dash, all stats up while on surface");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Рыброна");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт способность к рывку, все параметры усилены когда на поверхности");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
