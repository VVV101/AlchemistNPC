using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Bullet");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time");
			DisplayName.AddTranslation(GameCulture.Russian, "Улучшенная Грибная Пуля");
			Tooltip.AddTranslation(GameCulture.Russian, "Выпускает электрическое облако, стреляющее электическими лучами\nСо временем ускоряется");

            DisplayName.AddTranslation(GameCulture.Chinese, "强化型菱形弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "释放出电云, 电云会向敌人发射电束\n越飞越快");
        }    
		public override void SetDefaults()
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.shoot = mod.ProjectileType("ShroomiteBullet");
			item.shootSpeed = 24f; 
			item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 3);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 3);
			recipe.AddIngredient(ItemID.MoonlordBullet, 333);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}
