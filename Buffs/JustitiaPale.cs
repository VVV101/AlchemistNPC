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
			Description.SetDefault("Life's being drained out of you..");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Бледность Юстиции");
			Description.AddTranslation(GameCulture.Russian, "Жизненные силы иссякают..");
            DisplayName.AddTranslation(GameCulture.Chinese, "无力的审判鸟");
            Description.AddTranslation(GameCulture.Chinese, "失去生命...");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>(mod).justitiapale = true;
        }
	}
}
