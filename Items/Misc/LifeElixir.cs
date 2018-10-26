using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	class LifeElixir : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Life Elixir");
			Tooltip.SetDefault("Permanently increases maximum life by 50. Can be used twice.");
			DisplayName.AddTranslation(GameCulture.Russian, "Эликсир Жизни");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное здоровье на 50. Можно использовать дважды.");

            DisplayName.AddTranslation(GameCulture.Chinese, "仙丹");
            Tooltip.AddTranslation(GameCulture.Chinese, "永久增加50最大生命值. 能使用两次.");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 500 && player.GetModPlayer<AlchemistNPCPlayer>().LifeElixir < 2;
		}

		public override bool UseItem(Player player)
		{
			player.statLifeMax2 += 50;
			player.statLife += 50;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(50, true);
			}
			player.GetModPlayer<AlchemistNPCPlayer>().LifeElixir += 1;
			return true;
		}
	}
}
