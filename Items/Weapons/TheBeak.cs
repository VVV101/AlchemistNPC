using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class TheBeak : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Beak (O-02-56)");
			Tooltip.SetDefault("''Size has no meaning while it overflowed with power.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nShoots 2 times in one use"
			+ "\nBullets are setting enemies ablaze"
			+ "\n25% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Клюв (O-02-56)");
			Tooltip.AddTranslation(GameCulture.Russian, "Размер не имеет значения, пока он переполнен силой.\n[c/FF0000:Э.П.О.С. оружие]\nВыстреливает по 2 пули\nПули поджигают противника\n25% шанс не потратить патроны"); 
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.useAnimation = 20;
			item.useTime = 10;
			item.reuseDelay = 20;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage/2, knockBack, player.whoAmI);
			type = mod.ProjectileType("BB");
			return true;
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .25;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 4);
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
					{
					item.damage = 150;
					item.useAnimation = 12;
					item.useTime = 6;
					item.reuseDelay = 6;
					}
					else
					{
					item.damage = 12;
					item.useAnimation = 20;
					item.useTime = 10;
					item.reuseDelay = 20;
					}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("AlchemistNPC:EvilBar", 12);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 10);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}