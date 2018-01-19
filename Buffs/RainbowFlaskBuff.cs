using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class RainbowFlaskBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Rainbow Imbue");
			Description.SetDefault("You enemies will feel your strike");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Радужное зачарование");
			Description.AddTranslation(GameCulture.Russian, "Ваши враги почуствуют ваш удар"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AlchemistNPCPlayer>(mod).rainbowdust = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>(mod).rainbowdust = true;
		}
	}
}
