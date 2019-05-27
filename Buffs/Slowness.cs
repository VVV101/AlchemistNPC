using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Slowness : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Slowness");
			Description.SetDefault("Enemy is slowed down");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Замедление");
			Description.AddTranslation(GameCulture.Russian, "Противник замедлен");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.velocity *= 0.98f;
        }
	}
}
