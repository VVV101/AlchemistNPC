using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Arrow");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time");
			DisplayName.AddTranslation(GameCulture.Russian, "Улучшенная Грибная стрела");
			Tooltip.AddTranslation(GameCulture.Russian, "Выпускает электрическое облако, стреляющее электическими лучами"); 
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10000;
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShroomiteArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 3);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 3);
			recipe.AddIngredient(ItemID.MoonlordArrow, 333);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}
