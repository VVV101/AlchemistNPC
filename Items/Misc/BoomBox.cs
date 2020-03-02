using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class BoomBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boom Box");
			Tooltip.SetDefault("While this is in your inventory, your last inventory slot plays music boxes passively");
			DisplayName.AddTranslation(GameCulture.Russian, "Бумбокс");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, ваш последний слот инвентаря позволяет пассивно играть музыкальным шкатулкам");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 250000;
			item.rare = 4;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BoomBox = true;
		}
	}
}
