using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class XtraT : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("XtraT");
			Tooltip.SetDefault("Shoots 2 arrows and an energy bolt"
			+ "\nBolt deals triple weapon damage and pierces through enemies and tiles"
			+ "\n50% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "XtraT");
			Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает 2 стрелы и энергетический снаряд\nЭнергетический снаряд наносит утроенный урон оружия и проходит сквозь противников и блоки\n50% шанс не потратить стрелы");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.ranged = true;
			item.width = 92;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 32f;
			item.useAmmo = AmmoID.Arrow;
			item.scale = 0.75f;
		}

		public override bool ConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .5;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(ItemID.ChlorophyteShotbow);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y+10, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("XtraTBeam"), damage*3, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y-10, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
