using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class WrathOfTheCelestial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrath of the Celestial");
			Tooltip.SetDefault("Shoots cluster of exploding blue flames"
			+"\nWay more powerful than it seems");
			DisplayName.AddTranslation(GameCulture.Russian, "Гнев Целестиала");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает веером взрывающихся голубых огней\nБолее могущественнен, чем кажется");
			DisplayName.AddTranslation(GameCulture.Chinese, "天界之怒");
			Tooltip.AddTranslation(GameCulture.Chinese, "发射一簇爆裂蓝焰"
			+"\n比看上去更强大");
			Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.damage = 369;
			item.noMelee = true;
			item.magic = true;
			item.mana = 10;
			item.rare = ItemRarityID.Purple;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.UseSound = SoundID.Item20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 12f;
			item.useAnimation = 15;   
			item.knockBack = 4;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlueFlame");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed1 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed4 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed5 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed6 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed4.X, perturbedSpeed4.Y, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed5.X, perturbedSpeed5.Y, type, damage*4, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed6.X, perturbedSpeed6.Y, type, damage*4, knockBack, player.whoAmI);
			return false;
		}
	}
}
