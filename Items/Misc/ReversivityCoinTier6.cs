using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
    public class ReversivityCoinTier6 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reversivity Coin Tier 6");
			DisplayName.AddTranslation(GameCulture.Russian, "Монета Реверсии Шестого Уровня");
            Tooltip.SetDefault("Can be used for buying Treasure Bags from Operator");
			Tooltip.AddTranslation(GameCulture.Russian, "Может быть использована для покупки сумок у Оператора");

            DisplayName.AddTranslation(GameCulture.Chinese, "逆转硬币 T-6");
            Tooltip.AddTranslation(GameCulture.Chinese, "可以用来在操作员处购买宝藏袋");
        }

        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 8;
		}
    }
}