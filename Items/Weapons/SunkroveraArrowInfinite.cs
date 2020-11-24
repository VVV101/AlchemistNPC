using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SunkroveraArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunkrovera Arrow");
			Tooltip.SetDefault("Even holding these make you feel... uneasy."
			+"\nReleases life stealing projectiles on enemy/wall impact"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Сункроверная стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Даже держать эти стрелы в руках... нелегко.\nВыпускает похищающие жизнь снаряды при попадании во врага/стену\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "森克罗维拉之箭 (无限)");
            Tooltip.AddTranslation(GameCulture.Chinese, "即便是带着它你也能感受到那份...压力\n击中墙壁或敌人后释放可以汲取生命的子弹\n无限");
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
			item.value = 10000;
			item.rare = ItemRarityID.Red;
			item.shoot = mod.ProjectileType("SunkroveraArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SunkroveraArrow", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
