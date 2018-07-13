using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaArrow : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The worthy usage of Hallowed material"
			+"\nReleases heavy damaging light beams and inflicts Daybroken debuff");
			DisplayName.AddTranslation(GameCulture.Russian, "Хромоварийная стрела");
			Tooltip.AddTranslation(GameCulture.Russian, "Достойное применение Святого материала\nВыпускает наносящие значительный урон лучи света и накладывает мощный дебафф"); 
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
			item.value = 10;
			item.rare = 10;
			item.shoot = mod.ProjectileType("ChromovariaArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalyzedArrow", 150);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
