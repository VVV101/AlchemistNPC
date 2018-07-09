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
	public class ExplorerComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Explorer Combination");
			Description.SetDefault("Combination of Dangersense, Hunter, Spelunker, Night Owl, Shine & Mining buffs"
			+"\nAlso gives effects of Gills, Flippers and Water Walking Potions");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Исследователя");
            Description.AddTranslation(GameCulture.Russian, "Сочетания баффов Предчувствия, Охотника, Шахтёра, Ночного Зрения, Сияния и Добычи\nТакже даёт эффекты зельев Подводного Дыхания, Ласт и Хождения по воде");
            DisplayName.AddTranslation(GameCulture.Chinese, "探索者药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：危险感知, 狩猎, 洞穴探险, 夜猫子, 光芒, 挖矿\n同时给予水肺、脚蹼和水上行走药剂效果");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
			player.nightVision = true;
			player.detectCreature = true;
			player.pickSpeed -= 0.25f;
			player.dangerSense = true;
			player.gills = true;
			player.waterWalk = true;
			player.ignoreWater = true;
            player.accFlipper = true;
			player.buffImmune[4] = true;
			player.buffImmune[15] = true;
			player.buffImmune[109] = true;
			player.buffImmune[9] = true;
			player.buffImmune[11] = true;
			player.buffImmune[12] = true;
			player.buffImmune[17] = true;
			player.buffImmune[104] = true;
			player.buffImmune[111] = true;
		}
	}
}
