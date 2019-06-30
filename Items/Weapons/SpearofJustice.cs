using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SpearofJustice : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 175;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("SpearofJustice");
			item.shootSpeed = 32f;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && player.statMana < 200)
			{
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 175;
				item.shootSpeed = 32f;
				item.shoot = mod.ProjectileType("SpearofJustice");
			}
			if (player.altFunctionUse == 2 && player.statMana > 200)
			{
				item.useTime = 90;
				item.useAnimation = 90;
				item.damage = 200;
				item.shootSpeed = 64f;
				item.shoot = mod.ProjectileType("SpearofJusticeG");
			}
			if (player.altFunctionUse != 2)
			{
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 175;
				item.shootSpeed = 32f;
				item.shoot = mod.ProjectileType("SpearofJustice");
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				if (player.statMana > 390)
					{
					Projectile.NewProjectile(position.X, position.Y-20, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-40, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-80, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-100, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-120, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+20, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+40, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+80, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+100, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+120, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-15, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-30, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-45, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-75, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y-90, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+15, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+30, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+45, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+75, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X-50, position.Y+90, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					player.statMana -= 390;
					}
				if (player.statMana > 200)
					{
					Projectile.NewProjectile(position.X, position.Y-15, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-30, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-45, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-75, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y-90, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+15, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+30, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+45, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+60, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+75, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					Projectile.NewProjectile(position.X, position.Y+90, speedX, speedY, mod.ProjectileType("SpearofJusticeG"), damage, knockBack, player.whoAmI);
					player.statMana -= 200;
					}
			}
			return true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear of Justice");
			Tooltip.SetDefault("Its strike can destroy everything in its way"
			+"\nVery own spear of a [c/FF0000:True Hero]"
			+"\nHas alternative attack mode on right-click"
			+"\n200 or 400 mana is required for using alternative attack");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Копье Правосудия");
			Tooltip.AddTranslation(GameCulture.Russian, "Его удары могут уничтожить все на своем пути\nКопье истинного героя\nИмеет альтернативную атаку (правая кнопка мыши)\nДля ее использования нужно 200 или 400 маны");

            DisplayName.AddTranslation(GameCulture.Chinese, "正义之矛");
            Tooltip.AddTranslation(GameCulture.Chinese, "它的攻击可以摧毁沿途的一切\n一个[c/FF0000:真英雄]特有的矛\n右键会有特殊的攻击方式\n特殊攻击需要200/400法力");
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoulEssence", 7);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(3543);
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
