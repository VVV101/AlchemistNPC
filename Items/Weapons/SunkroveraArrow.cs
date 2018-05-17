using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SunkroveraArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Even holding these make you feel... uneasy."
			+"\nReleases life stealing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.Russian, "Сункроверная стрела");
			Tooltip.AddTranslation(GameCulture.Russian, "Даже держать эти стрелы в руках... нелегко.\nВыпускает похищающие жизнь снаряды при попадании"); 
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10000;
			item.rare = 10;
			item.shoot = mod.ProjectileType("SunkroveraArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 150);
			recipe.AddIngredient(null, "SunkroveraCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
