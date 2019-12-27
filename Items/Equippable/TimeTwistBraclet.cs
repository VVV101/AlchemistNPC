using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class TimeTwistBraclet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braclet of Time Twist");
			Tooltip.SetDefault("Gives a chance to get double loot from defeated mobs"
			+"\nLowers defense/damage reduction by 20/20%");
			DisplayName.AddTranslation(GameCulture.Russian, "Браслет Искривления Времени");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт шанс получить удвоенный лут с убитых мобов\nПонижает защиту/сопротивление урону на 20/20%");
        }
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().TimeTwist = true;
			player.endurance -= 0.2f;
			player.statDefense -= 20;
		}
	}
}