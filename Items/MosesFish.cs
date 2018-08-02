using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Items
{
	public class MosesFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moses Fish");
		}

		public override void SetDefaults()
		{
			item.questItem = true;
			item.maxStack = 1;
			item.width = 42;
			item.height = 42;
			item.uniqueStack = true;
			item.rare = -11;		//The rarity of -11 gives the item orange color
		}

		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Manna = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			Player player = Main.player[Main.myPlayer];
			return (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3);
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "You heard about Moses, don't you? Then hear what I found in one old fairy tale book. There said that Moses still returning to our world even after his life. And he is prefering Desert pools. Long story short, I want you to get me this fish! It could be the really hard catch, but the reward can be great too!";
			catchLocation = "Caught in Desert.";
		}
	}
}
