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
			Description.SetDefault("Enemy is slowed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Замедление");
			Description.AddTranslation(GameCulture.Russian, "Противник замедлен");
            DisplayName.AddTranslation(GameCulture.Chinese, "缓慢");
            Description.AddTranslation(GameCulture.Chinese, "减缓敌人");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.velocity *= 0.98f;
        }
	}
}
