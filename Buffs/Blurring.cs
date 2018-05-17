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
	public class Blurring : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blurring");
			Description.SetDefault("Enemies cannot clearly see you (Shadow Dodge with 30 second CD)");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Размытие");
			Description.AddTranslation(GameCulture.Russian, "Враги едва могут видеть вас (Теневое уклонение с 30-ти секундным откатом)"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.onHitDodge = true;
		if (player.onHitDodge && player.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
            {
                if (!player.shadowDodge)
                    player.shadowDodgeTimer = 1800;
                player.AddBuff(59, 1800, true);
            }
		}
	}
}
