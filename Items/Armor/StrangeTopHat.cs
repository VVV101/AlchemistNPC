using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC.NPCs;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StrangeTopHat : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strange Top Hat");
			DisplayName.AddTranslation(GameCulture.Russian, "Странный Циллиндр"); 
			Tooltip.SetDefault("''We'll meet again, don't know where, don't know when!"
			+"\nOh, I know we'll meet again some sunny day!''"
			+"\nUse with the extreme care");
            Tooltip.AddTranslation(GameCulture.Russian, "''Не знаю где, не знаю когда, но мы встретимся вновь!\nО, я знаю, что мы встетимся вновь в какой-нибудь солнечный день!''\nИспользовать с крайней осторожностью");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 2;
			item.vanity = true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BillCipher"));
			BillCipher.introduction = 0;
			return true;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
	}
}