using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Judgement : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Judgement");
			Description.SetDefault("You are spawning sharp bones to impale your foes"
			+"\n33% chance to reduce taken damage to 2 hitpoints"
			+"\nYour endurance is reduced by 33%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Правосудие");
            Description.AddTranslation(GameCulture.Russian, "Вы призываете острые кости, чтобы пронзить своих врагов\n33% шанс уменьшить полученный урон до 2 единиц здоровья\nПонижает ваше сопротивление урону на 33%");
            DisplayName.AddTranslation(GameCulture.Chinese, "审判");
            Description.AddTranslation(GameCulture.Chinese, "你产生锋利的骨刺穿透你的敌人\n有33%的概率减少2点所受伤害\n耐力降低33%");
        }
		
		public override void Update(Player player, ref int buffIndex)
        {
            player.yoraiz0rEye = 9 - 2;
        }
	}
}
