using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class IcedamnedArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icedamned Arrow");
			Tooltip.SetDefault("The unusual usage of cursed materials\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Стрела Проклятого Льда");
			Tooltip.AddTranslation(GameCulture.Russian, "Необычное использование Проклятого Материала\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "冰咒箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "被诅咒材料的独特用法");
        }

		public override void SetDefaults()
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1;
			item.value = 10;
			item.rare = ItemRarityID.Green;
			item.shoot = mod.ProjectileType("IcedamnedArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "IcedamnedArrow", 3996);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
