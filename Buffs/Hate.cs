using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Hate : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hate");
			Description.SetDefault("You are ready to release your Hate");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ненависть");
			Description.AddTranslation(GameCulture.Russian, "Вы готовы выпустить свою Ненависть");
            DisplayName.AddTranslation(GameCulture.Chinese, "仇恨");
            Description.AddTranslation(GameCulture.Chinese, "准备好释放你的仇恨吧!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.thrownDamage += 0.15f;
        player.meleeDamage += 0.15f;
        player.rangedDamage += 0.15f;
        player.magicDamage += 0.15f;
        player.minionDamage += 0.15f;
		player.meleeCrit += 15;
        player.rangedCrit += 15;
        player.magicCrit += 15;
        player.thrownCrit += 15;
		player.lifeRegen += 20;
		player.endurance -= 0.15f;
		player.statDefense -= 30;
		}
	}
}
