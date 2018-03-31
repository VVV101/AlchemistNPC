using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Bullet");
			Tooltip.SetDefault("Creates heavy damaging light explosion and inflicts Daybroken debuff");
			DisplayName.AddTranslation(GameCulture.Russian, "Пули с кристальной пылью");
			Tooltip.AddTranslation(GameCulture.Russian, "Создаёт взрыв, наносящий значительные повреждения и накладывает мощный дебафф"); 
		}    
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 8;
			item.shoot = mod.ProjectileType("ChromovariaBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ExplodingBullet, 100);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
