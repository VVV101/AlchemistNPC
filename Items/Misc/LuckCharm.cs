using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class LuckCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nDoes not affect accessories");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Удачи");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nНе работает с аксессуарами");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 4;
		}
	}
}
