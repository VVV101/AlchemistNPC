using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class KnucklesBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("Knuckles");
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("EdgeOfChaos"));
			player.QuickSpawnItem(mod.ItemType("LastTantrum"));
			player.QuickSpawnItem(mod.ItemType("BreathOfTheVoid"));
			player.QuickSpawnItem(mod.ItemType("ChaosBomb"));
			player.QuickSpawnItem(mod.ItemType("UgandanTotem"));
			player.QuickSpawnItem(mod.ItemType("AutoinjectorMK2"));
			player.QuickSpawnItem(ItemID.PlatinumCoin, 25);
		}
	}
}