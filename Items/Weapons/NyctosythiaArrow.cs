using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("These arrows consume any form of light."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.Russian, "Никтосифиевая стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Эти стрелы поглощают любой свет.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании");
            DisplayName.AddTranslation(GameCulture.Chinese, "夜蛾箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "这些箭消耗任意形式的光\n可穿墙, 第一次撞击墙壁或敌人后释放追踪敌人的子弹");
        }

		public override void SetDefaults()
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10000;
			item.rare = 10;
			item.shoot = mod.ProjectileType("NyctosythiaArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 150);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}
