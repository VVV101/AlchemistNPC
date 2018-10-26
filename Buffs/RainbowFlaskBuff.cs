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
			Description.SetDefault("You enemies will feel your strikes");
			Main.persistentBuff[Type] = true;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Радужное зачарование");
			Description.AddTranslation(GameCulture.Russian, "Ваши враги почуствуют ваши удары");
            DisplayName.AddTranslation(GameCulture.Chinese, "彩虹侵染");
            Description.AddTranslation(GameCulture.Chinese, "你的敌人将受到你的迎头痛击");
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
