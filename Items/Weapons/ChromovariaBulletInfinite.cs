using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromovaria Bullet (Infinite)");
			Tooltip.SetDefault("Creates heavy damaging light explosion and inflicts Daybroken debuff"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Хромовариевая пуля (Бесконечная)");
			Tooltip.AddTranslation(GameCulture.Russian, "Создаёт взрыв, наносящий значительные повреждения и накладывает мощный дебафф\nБесконечна"); 
		}    
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 8;
			item.shoot = mod.ProjectileType("ChromovariaBullet");
			item.shootSpeed = 16f; 
			item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChromovariaBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
