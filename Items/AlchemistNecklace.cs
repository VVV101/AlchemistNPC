using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	[AutoloadEquip(EquipType.Neck)]
	public class AlchemistNecklace : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Necklace");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions, and increases length of invincibility after taking damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Ожерелье Алхимика");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию жизней, уменьшает откат лечебных зелий и увеличивает период неуязвимости после получения урона"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = 6;
			item.accessory = true;
			item.defense = 2;
			item.lifeRegen = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pStone = true;
			player.longInvince = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CharmofMyths, 1);
			recipe.AddIngredient(ItemID.CrossNecklace, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}