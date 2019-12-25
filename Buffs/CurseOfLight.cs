using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CurseOfLight : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Curse of Light");
			Description.SetDefault("Weakens enemies");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Проклятие Света");
			Description.AddTranslation(GameCulture.Russian, "Ослабляет противника");
            DisplayName.AddTranslation(GameCulture.Chinese, "诅咒之光");
            Description.AddTranslation(GameCulture.Chinese, "虚弱敌人");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (npc.type != 222 && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerShade")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlagueBeeLargeG")))
				{	
				npc.velocity *= 0.99f;
				}
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
				if (npc.type != 222)
				{	
				npc.velocity *= 0.99f;
				}
			}
        }
	}
}
