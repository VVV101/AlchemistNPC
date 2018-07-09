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
	public class BuilderComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Builder Combination");
			Description.SetDefault("Combination of Building, Mining and Calming buffs");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Строителя");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Добычи, Строителя и Покоя");
            DisplayName.AddTranslation(GameCulture.Chinese, "建筑师药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：镇静, 建筑工, 挖矿");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.pickSpeed -= 0.25f;
			player.calmed = true;
			player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            ++player.blockRange;
			player.buffImmune[104] = true;
			player.buffImmune[106] = true;
			player.buffImmune[107] = true;
		}
	}
}
