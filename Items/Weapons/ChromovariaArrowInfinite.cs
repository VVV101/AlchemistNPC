using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Arrow");
			Tooltip.SetDefault("The worthy usage of Hallowed material"
			+"\nReleases heavy damaging light beams and inflicts Daybroken debuff"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Хромоварийная стрела (Бесконечная)");
            Tooltip.AddTranslation(GameCulture.Russian, "Достойное применение Святого материала\nВыпускает наносящие значительный урон лучи света и накладывает мощный дебафф\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "炫彩箭 (无限)");
            Tooltip.AddTranslation(GameCulture.Chinese, "神圣材料的合理使用 (无限)\n释放出粗大的破坏光束并给予破日Debuff\n无限");
        }

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1;
			item.value = 10;
			item.rare = 10;
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
