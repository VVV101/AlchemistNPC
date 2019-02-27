using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class GreaterDangersense : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense");
			Description.SetDefault("Lights up enemy projectiles");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Великого Чувства Опасности");
			Description.AddTranslation(GameCulture.Russian, "Подсвечивает снаряды противника");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPC.GreaterDangersense = true;
		}
	}
}
