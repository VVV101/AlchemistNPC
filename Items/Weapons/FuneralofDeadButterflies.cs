using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class FuneralofDeadButterflies : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solemn Vow (T-01-68)");
			Tooltip.SetDefault("''High atmosphere. One represents sadness of dead and other represents fear of living.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts Shadowflame and Frostburn"
			+ "\n35% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Торжественная клятва (T-01-68)");
			Tooltip.AddTranslation(GameCulture.Russian, "''Высокая атмосфера. Один отражает грусть мёртвых, а другой отражает страх живущих.''\n[c/FF0000:Э.П.О.С. оружие]\nНакладывает Теневое Пламя и Морозный Ожог\n35% шанс не потратить патроны"); 
		}

		public override void SetDefaults()
		{
			item.damage = 36;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useAnimation = 6;
			item.useTime = 6;
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
			Projectile.NewProjectile(position.X, position.Y+3, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y-3, speedX, speedY, type, damage, knockBack, player.whoAmI);
			type = mod.ProjectileType("FDB");
			return true;
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .35;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 0);
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
					{
					item.damage = 125;
					}
					else
					{
					item.damage = 36;
					}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}