using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.QuestFishes
{
	public class MiniShark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Shark");
			DisplayName.AddTranslation(GameCulture.Russian, "Мини Акула");
		}

		public override void SetDefaults()
		{
			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
			item.rare = -11;
		}

		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MiniShark = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return true;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "As I heard, sometimes sharks can't grow big enough to be counted as actual sharks. Then they should be called ''Mini Sharks''. And now you are gonna get me one of these!";
			catchLocation = "Caught in the Ocean.";
		}
	}
}
