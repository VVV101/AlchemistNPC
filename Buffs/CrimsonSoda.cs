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
	public class CrimsonSoda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crimson Soda Effect");
			Description.SetDefault("Increases life regeneration greatly");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Эффект соды Кримзона");
			Description.AddTranslation(GameCulture.Russian, "Значительно увеличивает регенерацию здоровья"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 10;
		}
	}
}
