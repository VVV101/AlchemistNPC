using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class ShieldofSpring : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shield of Spring");
			Description.SetDefault("Reduces all incoming damage by 20%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Щит Весны");
			Description.AddTranslation(GameCulture.Russian, "Уменьшает весь входящий урон на 20%"); 
		}
		public override void Update(Player player, ref int buffIndex)
		{
		player.endurance += 0.2f;
		}
	}
}
