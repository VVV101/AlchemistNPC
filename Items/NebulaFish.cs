using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Items
{
	public class NebulaFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Fish");
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
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).NebulaFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return Main.hardMode &&  NPC.downedAncientCultist;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!";
			catchLocation = "Caught nearby Nebula Pillar.";
		}
	}
}
