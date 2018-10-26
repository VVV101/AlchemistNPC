using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Bullet");
			Tooltip.SetDefault("Don't keep them close."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.Russian, "Никтосифиевая пуля");
            Tooltip.AddTranslation(GameCulture.Russian, "Чем дальше держать их от себя, тем лучше.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании в противника/cтену");

            DisplayName.AddTranslation(GameCulture.Chinese, "夜蛾弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "最好尽可能快的抓住它\n可穿墙, 第一次撞击墙壁或敌人后释放追踪敌人的子弹");
        }    
		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("NyctosythiaBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordBullet, 100);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
