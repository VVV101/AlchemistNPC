using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SunkroveraBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunkrovera Bullet");
			Tooltip.SetDefault("Its glow makes you chill."
			+"\nReleases life stealing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.Russian, "Пули с кристальной пылью");
			Tooltip.AddTranslation(GameCulture.Russian, "Её сияние вызывает у вас дрожь.\nВыпускает похищающие жизнь снаряды при попадании"); 
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
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("SunkroveraBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordBullet, 100);
			recipe.AddIngredient(null, "SunkroveraCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
