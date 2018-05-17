using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Buffs
{
	public class Electrocute : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Electocute");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Электрошок");
			Description.AddTranslation(GameCulture.Russian, "Потеря жизней"); 
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>(mod).electrocute = true;
			if (Main.rand.Next(30) == 0)
			{
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
			}
        }
	}
}
