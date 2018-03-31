using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Patience : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Patience Paralyzation");
			Description.SetDefault("Freezes target in place");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Парализация Терпения");
			Description.AddTranslation(GameCulture.Russian, "Обездвиживает цель"); 
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
        }
	}
}
