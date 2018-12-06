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
			Description.SetDefault("Make nearby non-boss enemies change their movement direction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Дебафф Плаща Страха");
			Description.AddTranslation(GameCulture.Russian, "Заставляет обычных врагов около игрока менять направление движения");
        }
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.confused = true;
			npc.target = 0;
		}
	}
}
