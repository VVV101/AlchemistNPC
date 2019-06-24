using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Twilight : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight Pale");
			Description.SetDefault("Life's being drained out of you..");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Бледный урон Сумерек");
			Description.AddTranslation(GameCulture.Russian, "Жизненные силы иссякают..");
            DisplayName.AddTranslation(GameCulture.Chinese, "苍白的蕾蒂希娅");
            Description.AddTranslation(GameCulture.Chinese, "生命从你的身体中流失...");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>(mod).twilight = true;
        }
	}
}
