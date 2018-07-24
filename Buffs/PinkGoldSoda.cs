using System;
using System.Collections.Generic;
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
	public class PinkGoldSoda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pink Gold Soda Effect");
			Description.SetDefault("Removes most debuffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Эффект Розово-золотой Соды");
			Description.AddTranslation(GameCulture.Russian, "Убирает большинство дебаффов");
            DisplayName.AddTranslation(GameCulture.Chinese, "桃金苏打加持");
            Description.AddTranslation(GameCulture.Chinese, "移除大部分Debuff");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[20] = true;
			player.buffImmune[22] = true;
			player.buffImmune[23] = true;
			player.buffImmune[24] = true;
			player.buffImmune[30] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.buffImmune[33] = true;
			player.buffImmune[35] = true;
			player.buffImmune[36] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[70] = true;
		}
	}
}
