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
	public class ScreamingHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Screaming Head");
			Tooltip.SetDefault("Someone's screaming head\nBreaks concentration");
			DisplayName.AddTranslation(GameCulture.Russian, "Кричащая голова");
            Tooltip.AddTranslation(GameCulture.Russian, "Чья-то кричащая голова\nНарушает концентрацию");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.silence = true;
		}
	}
}
