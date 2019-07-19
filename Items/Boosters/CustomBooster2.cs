using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class CustomBooster2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Custom Booster 2");
			Tooltip.SetDefault("Provides immunity to fire blocks, gives Obsidian Skin, Gills and Flipper effects");
			DisplayName.AddTranslation(GameCulture.Russian, "Выборочный усилитель 2");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт иммунитет к огненным блокам, даёт эффекты Жабр и Обсидиановой Кожи");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenBooster2"), 1);
			recipe.AddIngredient(ItemID.ObsidianSkinPotion, 30);
			recipe.AddIngredient(ItemID.GillsPotion, 30);
			recipe.AddIngredient(ItemID.FlipperPotion, 30);
			recipe.AddRecipeGroup("AlchemistNPC:EvilBar", 8);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
