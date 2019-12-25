using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SunkroveraBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunkrovera Bullet");
			Tooltip.SetDefault("Its glow makes you chill."
			+"\nReleases life stealing projectiles on enemy/wall impact"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавые пули");
            Tooltip.AddTranslation(GameCulture.Russian, "Её сияние вызывает у вас дрожь.\nВыпускает похищающие жизнь снаряды при попадании во врага/стену\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "森克罗维拉弹 (无限)");
            Tooltip.AddTranslation(GameCulture.Chinese, "即便是带着它你也能感受到那份...压力\n击中墙壁或敌人后释放可以汲取生命的子弹\n无限");
        }    
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("SunkroveraBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SunkroveraBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
