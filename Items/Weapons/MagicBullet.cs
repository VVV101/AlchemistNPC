using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class MagicBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Bullet (F-01-69)");
			Tooltip.SetDefault("Though, unable to fully extract its original power, the magical power it holds is still potent."
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nBullet, shot by this weapon will go through tiles"
			+ "\nPierces through multiple enemies");
			DisplayName.AddTranslation(GameCulture.Russian, "Волшебная Пуля (F-01-69)");
			Tooltip.AddTranslation(GameCulture.Russian, "Несмотря на невозможность извлечения его полного потенциала, магическая мощь этого оружия всё ещё велика.\n[c/FF0000:Э.П.О.С. оружие]\nПули проходят сквозь блони\nПробивает значительное количество противников одним выстрелом"); 
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SniperRifle);
			item.damage = 500;
			item.autoReuse = true;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("MB");
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.Ectoplasm, 30);
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}