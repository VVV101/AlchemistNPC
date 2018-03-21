using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Reverberation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation (T-04-53)");
			Tooltip.SetDefault("This weapon will no longer be needed if the time comes when everyone's lust is substituted with flowers."
			+ "\n[c/FF0000:EGO weapon]"
			+ "\n50% chance to shot additional tile piercing projectile"
			+ "\nProjectile deals same damage is main, but consumes 15 mana each"
			+ "\nCan be powered up by equipping full 'Reverberation' set");
			DisplayName.AddTranslation(GameCulture.Russian, "Реверберация (T-04-53)");
			Tooltip.AddTranslation(GameCulture.Russian, "Это оружие будет более не нужно, если придёт время когда всеобщая похоть заменится цветами\n[c/FF0000:Э.П.О.С. оружие]\n50% шанс выстрелить дополнительным снарядом, проходящим сквозь блоки\nУрон этого снаряда будет равен урону основного, но будет расходоваться по 15 маны за каждый\nМожет быть усилен, если экипировать полный сет 'Реверберация'");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DynastyWood, 200);
			recipe.AddIngredient(ItemID.SoulofLight, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.HallowedRepeater);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (AlchemistNPC.RevSet)
				{
					if (player.statMana >= 30)
					{
					int numberProjectiles = 2 + Main.rand.Next(3);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalLeafShot, damage/2, knockBack, player.whoAmI);
						player.statMana -= 4;
						}
					}
				}
			if (!AlchemistNPC.RevSet)
				{
					if (Main.rand.Next(2) == 0 && player.statMana >= 30)
						{
						Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.CrystalLeafShot, damage, knockBack, player.whoAmI);
						player.statMana -= 15;
						}
				}
			return true;
		}
	}
}
