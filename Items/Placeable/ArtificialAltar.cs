using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class ArtificialAltar : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Artificial Altar, made by occult powers");
            DisplayName.AddTranslation(GameCulture.Russian, "Искусственный Алтарь");
            Tooltip.AddTranslation(GameCulture.Russian, "Искусственный алтарь, созданный оккультными силами");

            DisplayName.AddTranslation(GameCulture.Chinese, "人造祭坛");
            Tooltip.AddTranslation(GameCulture.Chinese, "人造祭坛, 使用神秘力量制作而成");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 10000;
			item.createTile = mod.TileType("ArtificialAltar");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
			recipe.AddIngredient(ItemID.RottenChunk, 15);
			recipe.AddIngredient(ItemID.BattlePotion, 5);
			recipe.AddIngredient(ItemID.ThornsPotion, 5);
			recipe.AddIngredient(ItemID.Deathweed, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
			recipe.AddIngredient(ItemID.Vertebrae, 15);
			recipe.AddIngredient(ItemID.BattlePotion, 5);
			recipe.AddIngredient(ItemID.ThornsPotion, 5);
			recipe.AddIngredient(ItemID.Deathweed, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}