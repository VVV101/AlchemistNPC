using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class NULLCD : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("NULL CD");
			Description.SetDefault("");
			Main.debuff[Type] = true;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "NULL перезарядка");
			Description.AddTranslation(GameCulture.Russian, "");
			DisplayName.AddTranslation(GameCulture.Chinese, "NULL 再启");
        }
	}
}