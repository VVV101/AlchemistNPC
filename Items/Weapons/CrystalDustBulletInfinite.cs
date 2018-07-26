using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalDustBulletInfinite : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust Bullet");
			Tooltip.SetDefault("Explodes into even deadlier shards"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Пули с кристальной пылью");
            Tooltip.AddTranslation(GameCulture.Russian, "Взрываются на ещё более смертоносные осколки при попадании\nБесконечная");

            DisplayName.AddTranslation(GameCulture.Chinese, "水晶尘子弹");
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
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 8;
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
