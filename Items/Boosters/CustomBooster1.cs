using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class CustomBooster1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Custom Booster 1");
			Tooltip.SetDefault("Gives Shine and Nightvision effects");
			DisplayName.AddTranslation(GameCulture.Russian, "Выборочный усилитель 1");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт эффекты Свечения и Ночного Зрения");
			DisplayName.AddTranslation(GameCulture.Chinese, "普通增益容器1号");
			Tooltip.AddTranslation(GameCulture.Chinese, "给予发光和夜视效果");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.consumable = false;
			item.value = 100000;
		}

		public override bool UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenBooster1"), 1);
			recipe.AddIngredient(ItemID.ShinePotion, 30);
			recipe.AddIngredient(ItemID.NightOwlPotion, 30);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
