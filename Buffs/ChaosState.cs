using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ChaosState : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Chaos State");
			Description.SetDefault("Rapidly lowering enemy HP");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Хаотическое состояние");
			Description.AddTranslation(GameCulture.Russian, "Отнимает здоровье противника");
			DisplayName.AddTranslation(GameCulture.Chinese, "混沌状态");
			Description.AddTranslation(GameCulture.Chinese, "迅速降低敌人生命值");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>().chaos = true;
        }
	}
}
