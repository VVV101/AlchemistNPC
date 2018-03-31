using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Justitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia (O-02-62)");
			Tooltip.SetDefault("It is implicative of a tall bird's balance, that signifies a need to weigh sins in every dispute."
			+ "\n[c/FF0000:EGO weapon]");
			DisplayName.AddTranslation(GameCulture.Russian, "Юстиция (O-02-62)");
			Tooltip.AddTranslation(GameCulture.Russian, "Он является отражением баланса Высокой Птицы, который показывает нужду взвесить грехи при каждом споре.\n[c/FF0000:Э.П.О.С. оружие]"); 
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.width = 44;
			item.height = 44;
			item.useTime = 30;
			item.useAnimation = 50;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = 12;
			item.noUseGraphic = true;
            item.channel = true;
            item.noMelee = true;
            item.damage = 166;
            item.knockBack = 4f;
            item.autoReuse = false;
            item.noMelee = true;
            item.melee = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("JP");
			item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("JP"), damage, knockBack, player.whoAmI);
            Main.projectile[p].scale = 1.5f;
            return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
