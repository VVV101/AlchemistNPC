using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CloakOfFearDebuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cloak Of Fear Debuff");
			Description.SetDefault("Make non-boss enemies nearby you change their movement direction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Плащ Страха Дебафф");
			Description.AddTranslation(GameCulture.Russian, "Заставляет изменить направление движения противников вблизи игрока");
        }
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.confused = true;
		}
	}
}
