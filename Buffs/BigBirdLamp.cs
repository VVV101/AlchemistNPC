using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class BigBirdLamp : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Big Bird's Lamp");
			Description.SetDefault("Character is emitting light, all damage & crit chance are increased by 5%, attacks destroy enemy armor.");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Лампа Большой Птицы");
            Description.AddTranslation(GameCulture.Russian, "Персонаж светится, весь урон и шанс крита повышаются на 5%, атаки разрушают броню противника.");

            DisplayName.AddTranslation(GameCulture.Chinese, "大鸟灯");
            Description.AddTranslation(GameCulture.Chinese, "你会发光~~~ \n增加5%全伤害和暴击几率, 攻击造成穿甲.");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).trigger == true)
			{
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 4f, 4f, 4f);
			}
			else
			{
			}
		}
	}
}
