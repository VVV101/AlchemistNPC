using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EbonyIvory : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebony & Ivory");
			Tooltip.SetDefault("''Twin handguns of a Demon Hunter''"
			+ "\nCan do very rare critical hit, which would deal 66666 damage"
			+ "\nShoot custom demonic bullets, which are exploding on hit"
			+ "\n66% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Чёрный и Белый");
            Tooltip.AddTranslation(GameCulture.Russian, "''Парные пистолеты Демона-Охотника''\nМогут сделать очень редкий критический удар, наносящий 66666 повреждений\n66% шанс не потратить патроны"); 
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 1000000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
			item.scale = 0.5f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("DemonicBullet");
			Projectile.NewProjectile(position.X, position.Y-5, speedX, speedY, type, damage/2, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage/2, knockBack, player.whoAmI);
			return false;
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .66;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(ItemID.DemonScythe);
			recipe.AddIngredient(ItemID.UnholyTrident);
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddIngredient(ItemID.VenusMagnum, 2);
			recipe.AddIngredient(null, "AlchemicalBundle");
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}