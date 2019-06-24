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
	public class ExplorersBrew : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Explorer's Brew");
			Description.SetDefault("Grants all possible vision buffs, increases mining speed greatly, greatly increases light radius around player and your attacks can Electrocute enemies"
			+"\nAlso gives effects of Gills, Flippers and Water Walking Potions");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Варево Исследователя");
            Description.AddTranslation(GameCulture.Russian, "Даёт все возможные виды зрения, значительно увеличивает скорость копания.\nЗначительно увеличивает радиус света вокруг игрока и ваши атаки могут поразить врага Электрошоком\nТакже даёт эффекты Подводного Дыхания, Ласт и Хождения по воде");
            DisplayName.AddTranslation(GameCulture.Chinese, "探险者陈酿");
            Description.AddTranslation(GameCulture.Chinese, "获得所有感知效果, 极大增加召唤速度, 极大增加玩家周围的光照效果, 并且你的攻击会使敌人触电\n同时给予水肺、脚蹼和水上行走药剂效果");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 4f, 4f, 4f);
			player.nightVision = true;
			player.detectCreature = true;
			player.pickSpeed -= 0.50f;
			player.dangerSense = true;
			player.gills = true;
			player.waterWalk = true;
			player.ignoreWater = true;
            player.accFlipper = true;
			player.buffImmune[mod.BuffType("ExplorerComb")] = true;
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
