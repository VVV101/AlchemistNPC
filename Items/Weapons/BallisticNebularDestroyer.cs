using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class BallisticNebularDestroyer : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ballistic Nebular Destroyer");
			Tooltip.SetDefault("Shoots spread of Vortex Rockets"
			+ "\n25% chance to not consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Баллистический Уничтожитель Туманностей");
			Tooltip.AddTranslation(GameCulture.Russian, "Стреляет веером Вихревых Ракет\n25% шанс не потратить патроны");
		}

		public override void SetDefaults()
		{
			item.damage = 70;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 100000;
			item.rare = 8;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(ItemID.FragmentNebula, 30);
			recipe.AddIngredient(ItemID.LunarBar, 15); 
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 5);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
				int numberProjectiles = 3 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
					{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.VortexBeaterRocket, damage, knockBack, player.whoAmI);
					}
			return false;
		}
	}
}
