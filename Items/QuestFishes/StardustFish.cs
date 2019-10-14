using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.QuestFishes
{
	public class StardustFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Fish");
			DisplayName.AddTranslation(GameCulture.Russian, "Пылезвездная Рыба");
			DisplayName.AddTranslation(GameCulture.Chinese, "星尘鱼");
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
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).StardustFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			if (Main.hardMode && NPC.downedAncientCultist)
			{
				return true;
			}
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!";
			catchLocation = "Caught nearby Stardust Pillar.";
		}
	}
}
