using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class QueenBeeBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee booster");
			Tooltip.SetDefault("Hostile bees do less damage and your regeneration is increased by 6, immunity to poisons");
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель Королевы Пчёл");
			Tooltip.AddTranslation(GameCulture.Russian, "Враждебные пчёлы наносят меньше урона и ваша регенерация увеличена на 6, иммунитет к ядам");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().QueenBeeBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().QueenBeeBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().QueenBeeBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().QueenBeeBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
