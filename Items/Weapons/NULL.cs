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
	public class NULL : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Katana");
			Tooltip.SetDefault("NULL");
			DisplayName.AddTranslation(GameCulture.Russian, "Катана");
            Tooltip.AddTranslation(GameCulture.Russian, "NULL");
			DisplayName.AddTranslation(GameCulture.Chinese, "武士刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "NULL");
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
			item.rare = 10;
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
			item.shoot = mod.ProjectileType("NULL");
			item.shootSpeed = 15f;
		}
		
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.damage = 120;
				item.shootSpeed = 14f;
				item.shoot = mod.ProjectileType("NULL");
				item.channel = true;
				item.useTime = 30;
				item.useAnimation = 50;
			}
			if (player.altFunctionUse == 2)
			{
				item.channel = false;
				item.useTime = 30;
				item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("NULLCD")))
			{
				player.AddBuff(mod.BuffType("NULL"), 300);
				player.AddBuff(mod.BuffType("NULLCD"), 1800);
				return false;
			}
			if (player.altFunctionUse != 2)
			{
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("NULL"), damage, knockBack, player.whoAmI);
				return false;
			}
			return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Katana);
			recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}