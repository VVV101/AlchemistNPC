using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
            DisplayName.AddTranslation(GameCulture.Chinese, "耐力瘫痪");
            Description.AddTranslation(GameCulture.Chinese, "冻结目标");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			if (npc.type != 488)
			{
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
			}
        }
	}
}
