using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalDustBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust Bullet");
			Tooltip.SetDefault("Explodes into even deadlier shards"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Пули с кристальной пылью");
            Tooltip.AddTranslation(GameCulture.Russian, "Разрываются на ещё более смертоносные осколки при попадании\nБесконечная");

            DisplayName.AddTranslation(GameCulture.Chinese, "晶尘弹 (无限)");
            Tooltip.AddTranslation(GameCulture.Chinese, "爆炸变成致命碎片\n无限");
        }    
		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Yellow;
			item.shoot = mod.ProjectileType("CrystalDust");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrystalDustBullet"), 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
