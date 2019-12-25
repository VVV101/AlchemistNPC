using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalDustBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust Bullet");
			Tooltip.SetDefault("Explodes into even deadlier shards");
			DisplayName.AddTranslation(GameCulture.Russian, "Пули с кристальной пылью");
            Tooltip.AddTranslation(GameCulture.Russian, "Разрываются на ещё более смертоносные осколки при попадании");

            DisplayName.AddTranslation(GameCulture.Chinese, "晶尘弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "爆炸变成致命碎片");
        }    
		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 8;
			item.shoot = mod.ProjectileType("CrystalDust");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalBullet, 100);
			recipe.AddIngredient(null, "CrystalDust", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}
