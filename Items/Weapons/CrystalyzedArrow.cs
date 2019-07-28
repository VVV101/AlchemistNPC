using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalyzedArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Explodes to shards on hit.");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальные стрелы");
			Tooltip.AddTranslation(GameCulture.Russian, "Разрываются на осколки при попадании");

            DisplayName.AddTranslation(GameCulture.Chinese, "晶尘箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "爆炸变成致命碎片.");
        }

		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 18;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("CrystalyzedArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 150);
			recipe.AddIngredient(null, "CrystalDust", 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
