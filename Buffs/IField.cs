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
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class IField : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Immortality Field");
			Description.SetDefault("If NPC dies under this, he/she will be resurrected");
			DisplayName.AddTranslation(GameCulture.Russian, "Поле Бессмертия");
			Description.AddTranslation(GameCulture.Russian, "Если НПС погибнет под действием баффа, он будет мгновенно возрождён");
        }
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.color = new Color(255, 255, 200, 100);
		}
	}
}
