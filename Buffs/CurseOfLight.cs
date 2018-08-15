using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
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
			Description.AddTranslation(GameCulture.Russian, "Ослабляет Противника");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.velocity *= 0.98f;
        }
	}
}
