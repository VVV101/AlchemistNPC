using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ArmorDestruction : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Armor Destruction");
			Description.SetDefault("Total armor destruction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Разрушение брони");
			Description.AddTranslation(GameCulture.Russian, "Полное разрушение брони"); 
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.ichor = true;
			npc.defense -= 99999;
			npc.defense = 0;
        }
	}
}
