using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Bullet");
			Tooltip.SetDefault("Better to hold it as far, as possible."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Никтосифиевая пуля");
			Tooltip.AddTranslation(GameCulture.Russian, "Чем дальше держать их от себя, тем лучше.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании\nБесконечна"); 
		}    
		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("NyctosythiaBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NyctosythiaBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
