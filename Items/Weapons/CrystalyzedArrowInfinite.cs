using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalyzedArrowInfinite : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Explodes to shards on hit"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальные стрелы");
			Tooltip.AddTranslation(GameCulture.Russian, "Взрывается на осколки при попадании\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "水晶尘之箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "爆炸变成致命碎片\n无限");
        }

		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 18;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
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
			recipe.AddIngredient(null, "CrystalyzedArrow", 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
