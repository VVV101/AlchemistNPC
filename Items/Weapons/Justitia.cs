using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Justitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia (O-02-62)");
			Tooltip.SetDefault("''It remembers the balance of the Long Bird that never forgot others' sins."
			+"\nThis weapon may be able to not only cut flesh but trace of sins as well.''"
			+ "\n[c/FF0000:EGO weapon]");
			DisplayName.AddTranslation(GameCulture.Russian, "Юстиция (O-02-62)");
            Tooltip.AddTranslation(GameCulture.Russian, "Он помнит баланс Высокой Птицы, никогда не забывавшей грехи других.\nЭто оружие может уничтожать не только плоть, но и следы грехов.\n[c/FF0000:Оружие Э.П.О.С.]");

            DisplayName.AddTranslation(GameCulture.Chinese, "正义裁决者 (O-02-62)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'这把武器象征着审判鸟的公平制裁, 这也意味着它需要去权衡全部的罪恶.'\n[c/FF0000:EGO 武器]");
        }

		public override void SetDefaults()
		{
			item.damage = 120;
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
            item.knockBack = 4;
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
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
				item.damage = 225;
			}
			else
			{
				item.damage = 120;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
