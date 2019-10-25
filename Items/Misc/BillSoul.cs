using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class BillSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bill's Soul");
			Tooltip.SetDefault("Container with concentrated blue flame"
			+"\nIts fluctuations charm you"
			+"\nConsume to get permanent buff ''Demon Slayer''");
			DisplayName.AddTranslation(GameCulture.Russian, "Душа Билла");
            Tooltip.AddTranslation(GameCulture.Russian, "Контейнер с концентрированным синим пламенем\nЕго колебания очаровывают вас\nПоглотите, чтобы получить вечный бафф ''Убийца Демона''");
        }
	
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCPlayer>().BillIsDowned < 1;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().BillIsDowned += 1;
			return true;
		}
	}
}