using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class BastScroll : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Description.SetDefault("Attacks totally destroy enemy armor");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток Баст");
			Description.AddTranslation(GameCulture.Russian, "Атаки полностью разрушают броню противника."); 
		}
	}
}
