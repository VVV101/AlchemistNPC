using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC.NPCs;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StrangeTopHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strange Top Hat");
			DisplayName.AddTranslation(GameCulture.Russian, "Странный Циллиндр"); 
			Tooltip.SetDefault("''We'll meet again, don't know where, don't know when!"
			+"\nOh, I know we'll meet again some sunny day!''");
            Tooltip.AddTranslation(GameCulture.Russian, "''Не знаю где, не знаю когда, но мы встретимся вновь!\nО, я знаю, что мы встретимся вновь в какой-нибудь солнечный день!''");
            DisplayName.AddTranslation(GameCulture.Chinese, "奇怪的高顶礼帽");
            Tooltip.AddTranslation(GameCulture.Chinese, "''我们会再见的, 不知何地, 不知何时!\n哦, 那将是个大晴天!");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.vanity = true;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
	}
}
