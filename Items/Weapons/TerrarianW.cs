using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class TerrarianW : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terrarian-W (V-05-516)");
			Tooltip.SetDefault("''Angela's actions have rewrote the understandings of souls themselves''\n[c/FF0000:EGO weapon]\nLeft click to shoot burst of lasers\nRight click to shoot burst of bullets");
			DisplayName.AddTranslation(GameCulture.Russian, "Terrarian-W (V-05-516)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Действия Анджелы переписали само понимание душ''\n[c/FF0000:Э.П.О.С. Оружие]\nНа левый клик выстреливает очередью из лазеров\n\nНа правый клик выстреливает очередью из пуль");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LaserRifle);
			item.damage = 25;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.UseSound = SoundID.Item31;
				item.mana = 0;
				item.useAnimation = 12;
				item.useTime = 4;
				item.reuseDelay = 14;
				item.shoot = 10;
				item.useAmmo = AmmoID.Bullet;
				item.magic = false;
				item.ranged = true;
				item.damage = 18;
			}
			else
			{
				item.UseSound = SoundID.Item12;
				item.mana = 5;
				item.useAnimation = 12;
				item.useTime = 4;
				item.reuseDelay = 14;
				item.shoot = 88;
				item.useAmmo = 0;
				item.ranged = false;
				item.magic = true;
				item.damage = 25;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			else
			{
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}