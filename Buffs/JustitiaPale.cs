using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class JustitiaPale : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Justitia Pale");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Бледный урон Юстиции");
			Description.AddTranslation(GameCulture.Russian, "Потеря жизней"); 
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>(mod).justitiapale = true;
        }
	}
}
