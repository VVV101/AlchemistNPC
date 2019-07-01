using Terraria;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class BillCipherBag : ModItem
	{
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
			bossBagNPC = mod.NPCType("BillCipher");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("GoldenKnuckles"));
			player.QuickSpawnItem(mod.ItemType("WrathOfTheCelestial"));
			player.QuickSpawnItem(mod.ItemType("LaserCannon"));
			player.QuickSpawnItem(mod.ItemType("GrapplingHookGunItem"));
			player.QuickSpawnItem(mod.ItemType("IlluminatiGift"));
			if (player.HasBuff(mod.BuffType("GrimReaper")) && Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("MysticAmulet"));
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModRevengeance)
				{
					player.QuickSpawnItem(mod.ItemType("MysticAmulet"));
				}
			}
			player.QuickSpawnItem(ItemID.PlatinumCoin, 50);
		}
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.CalamityWorld.revenge; }
        }
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
	}
}