using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class ConeOfCold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cone of Cold");
			Tooltip.SetDefault("Magic spell which releases cone of arctic cold"
			+"\nMay slowdown or freeze normal enemies in place");
			DisplayName.AddTranslation(GameCulture.Russian, "Конус Холода");
            Tooltip.AddTranslation(GameCulture.Russian, "Магическое заклинание, испускающие конус арктического холода\nМожет замедлить или заморозить обычных противников");
			DisplayName.AddTranslation(GameCulture.Chinese, "冰锥术");
			Tooltip.AddTranslation(GameCulture.Chinese, "释放极寒冰锥的魔咒"
			+"\n概率缓慢或冻结普通敌人");
        }

		public override void SetDefaults()
		{
			item.damage = 23;
			item.noMelee = true;
			item.magic = true;
			item.mana = 15;
			item.rare = ItemRarityID.Pink;
			item.width = 30;
			item.height = 30;
			item.useTime = 12;
			item.UseSound = SoundID.Item20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 12f;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.autoReuse = true;
			item.useTime = 30;
			item.useAnimation = 30;
			item.shoot = mod.ProjectileType("ConeOfColdProjectile");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed4 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed5 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed6 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 perturbedSpeed7 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			float speedX4 = perturbedSpeed4.X;
			float speedY4 = perturbedSpeed4.Y;
			float speedX5 = perturbedSpeed5.X;
			float speedY5 = perturbedSpeed5.Y;
			float speedX6 = perturbedSpeed6.X;
			float speedY6 = perturbedSpeed6.Y;
			float speedX7 = perturbedSpeed7.X;
			float speedY7 = perturbedSpeed7.Y;
			Projectile.NewProjectile(vector.X, vector.Y+4, speedX2, speedY2, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y-4, speedX3, speedY3, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y-8, speedX4, speedY4, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y+8, speedX5, speedY5, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y-12, speedX6, speedY6, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y+12, speedX7, speedY7, mod.ProjectileType("ConeOfColdProjectile"), damage, knockBack, player.whoAmI);
			return true;
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
