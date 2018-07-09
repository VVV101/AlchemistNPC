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
	public class OnyxSoda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Onyx Soda Effect");
			Description.SetDefault("Increases endurance by 75%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Эффект Ониксовой Соды");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает вашу стойкость на 75%");
            DisplayName.AddTranslation(GameCulture.Chinese, "玛瑙苏打加持");
            Description.AddTranslation(GameCulture.Chinese, "增加75%耐力");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.75f;
		}
	}
}
