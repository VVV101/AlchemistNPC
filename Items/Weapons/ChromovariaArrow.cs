using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The worthy usage of Hallowed material"
			+"\nReleases heavy damaging light beams and inflicts Daybroken debuff");
			DisplayName.AddTranslation(GameCulture.Russian, "Хромоварийная стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Достойное применение Святого материала\nВыпускает наносящие значительный урон лучи света и накладывает мощный дебафф");

            DisplayName.AddTranslation(GameCulture.Chinese, "炫彩箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "神圣材料的合理使用\n释放出粗大的破坏光束并给予破晓Debuff");
        }

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1;
			item.value = 10;
			item.rare = ItemRarityID.Red;
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
