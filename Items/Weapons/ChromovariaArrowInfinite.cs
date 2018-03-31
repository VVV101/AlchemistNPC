using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The worthy usage of Hallowed materia (Infinite)l"
			+"\nReleases heavy damaging light beams and inflicts Daybroken debuff"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Хромоварийная стрела (Бесконечная)");
			Tooltip.AddTranslation(GameCulture.Russian, "Достойное применение Святого материала\nВыпускает наносящие значительный урон лучи света и накладывает мощный дебафф\nБесконечна"); 
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("ChromovariaArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChromovariaArrow", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
