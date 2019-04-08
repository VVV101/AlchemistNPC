using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class BreathOfTheVoid : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 22222;
			item.magic = true;
			item.width = 38;
			item.height = 34;
			item.useTime = 5;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.UseSound = SoundID.Item34;
			item.value = 10000000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Void");
			item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Breath of the Void");
			Tooltip.SetDefault("May briefly paralize enemy on hit");
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Void"), damage, knockBack, player.whoAmI);
			}
			int numberProjectiles1 = 6;
			for (int i = 0; i < numberProjectiles1; i++)
			{
				Vector2 perturbedSpeed1 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, mod.ProjectileType("VoidDummy"), damage, knockBack, player.whoAmI);
			}
			return true;
		}
	}
}
