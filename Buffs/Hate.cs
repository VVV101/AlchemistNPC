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
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ненависть");
			Description.AddTranslation(GameCulture.Russian, "Вы готовы выпустить свою Ненависть"); 
		}
	}
}
