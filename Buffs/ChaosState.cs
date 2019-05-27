using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ChaosState : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Chaos State");
			Description.SetDefault("Rapidly lowers enemy HP");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Хаотическое состояние");
			Description.AddTranslation(GameCulture.Russian, "Отнимает здоровье противника");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>(mod).chaos = true;
        }
	}
}
