using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;
using Terraria.ID;

namespace AlchemistNPC.Buffs
{
	public class Infested : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Infested");
			Description.SetDefault("Slowed, spiders are ready to burst");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Заражён");
			Description.AddTranslation(GameCulture.Russian, "Замедлен, пауки готовы к выходу");
			DisplayName.AddTranslation(GameCulture.Chinese, "蛛群滋生");
			Description.AddTranslation(GameCulture.Chinese, "减速，蜘蛛种群暴涨");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			if (!npc.boss)
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (npc.type != NPCID.QueenBee && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerShade")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlagueBeeLargeG")))
					{	
						npc.velocity *= 0.95f;
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (npc.type != NPCID.QueenBee)
					{	
						npc.velocity *= 0.95f;
					}
				}
			}
        }
	}
}
