using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Judgement : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Judgement");
			Description.SetDefault("You are spawning sharp bones impaling your foes"
			+"\n33% chance to reduce damage taken to 2 hitpoints"
			+"\nDamage reduction is reduced by 33%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Правосудие");
            Description.AddTranslation(GameCulture.Russian, "Вы призываете острые кости, пронзающие врагов\n33% шанс уменьшить полученный урон до 2 единиц здоровья\nПонижает ваше сопротивление урону на 33%");
            DisplayName.AddTranslation(GameCulture.Chinese, "审判");
            Description.AddTranslation(GameCulture.Chinese, "产生锋利的骨刺穿透你的敌人\n有33%的概率减少2点所受伤害\n伤害减免降低33%");
        }
		
		public override void Update(Player player, ref int buffIndex)
        {
            player.yoraiz0rEye = 9 - 2;
        }
	}
}
