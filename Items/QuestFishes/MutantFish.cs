using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.QuestFishes
{
	public class MutantFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Fish");
		}

		public override void SetDefaults()
		{
			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
			item.rare = -11;		//The rarity of -11 gives the item orange color
		}

		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DriedFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return Main.hardMode;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "It seems like our dear Alchemist often fails in making ''quality'' potions. He always pouring his bad results into nearest big pool. And today, I saw consequences of that. A Mutant fish, which was looking like Airplane. I want you to get it to me!";
			catchLocation = "Caught anywhere.";
		}
	}
}
