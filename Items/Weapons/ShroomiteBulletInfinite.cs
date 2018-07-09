using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Bullet");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Улучшенная Грибная Пуля");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает электрическое облако, стреляющее электическими лучами\nБесконечна");
            DisplayName.AddTranslation(GameCulture.Chinese, "强化型菱形弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "释放出电云, 电云会向敌人发射电束\n越飞越快\n无限");
        }    
		public override void SetDefaults()
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShroomiteBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShroomiteBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
