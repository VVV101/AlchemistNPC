using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Arrow");
			Tooltip.SetDefault("These arrows consume any form of light."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Никтосифиевая стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Эти стрелы поглощают любой свет.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании в противника/cтену\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "夜蛾箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "这些箭消耗任意形式的光\n可穿墙, 第一次撞击墙壁或敌人后释放追踪敌人的子弹\n无限");
        }

		public override void SetDefaults()
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 10;
			item.shoot = mod.ProjectileType("NyctosythiaArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NyctosythiaArrow", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
