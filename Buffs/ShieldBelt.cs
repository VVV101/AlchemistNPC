using System;
using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ShieldBelt : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shield Belt Charge");
			Description.SetDefault("Reduces incoming damage by charge");
			Main.buffNoTimeDisplay[Type] = true;
			Main.pvpBuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Заряд щитового пояса");
			Description.AddTranslation(GameCulture.Russian, "Заряд щита");
        }

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
			Player player = Main.player[Main.myPlayer];
			tip = "Current charge is " + ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Shield;
		}
		
        public override void Update(Player player, ref int buffIndex)
        {
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Shield < 150)
			{
				if (Main.rand.Next(4) == 0)
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Shield++;
			}
        }
	}
}
