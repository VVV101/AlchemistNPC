using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Items
{
	public class KnucklesBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Knuckles");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("LastTantrum"));
			player.QuickSpawnItem(mod.ItemType("AutoinjectorMK2"));
			player.QuickSpawnItem(ItemID.PlatinumCoin, 50);
		}
	}
}