using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class EvilPresence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Evil Presence");
			Description.SetDefault("Mechanical boss would be spawned now");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			canBeCleared = false;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Присутствие Зла");
			Description.AddTranslation(GameCulture.Russian, "Сейчас заспавнится механический босс");
            DisplayName.AddTranslation(GameCulture.Chinese, "邪恶降临");
            Description.AddTranslation(GameCulture.Chinese, "机械Boss即将到来!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (!NPC.AnyNPCs(125) && !NPC.AnyNPCs(126) && !NPC.AnyNPCs(127) && !NPC.AnyNPCs(134))
			{
				switch (Main.rand.Next(3))
				{
				case 0:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
				break;
				case 1:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
				break;
				case 2:
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
				break;
				default:
				break;
				}
			}
		}
	}
}
