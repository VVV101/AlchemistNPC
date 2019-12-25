using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Corrosion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Corrosion");
			Description.SetDefault("Your flesh is melting!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Коррозия");
			Description.AddTranslation(GameCulture.Russian, "Ваша плоть плавится!");
            DisplayName.AddTranslation(GameCulture.Chinese, "腐蚀");
            Description.AddTranslation(GameCulture.Chinese, "你的肉体正在融化!");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>().corrosion = true;
        }
	}
}
