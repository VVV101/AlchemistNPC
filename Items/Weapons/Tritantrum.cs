using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Tritantrum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tritantrum");
			Tooltip.SetDefault("Shoots exploding plasma balls"
			+ "\nRequires special ammo"
			+ "\n50% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Тритантрум");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает взрывающиеся плазменные шары\nТребует особые патроны для стрельбы\n50% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.Chinese, "三项之怒");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射会爆炸的等离子体\n需要特殊弹药\n50%的几率不消耗弹药");
        }

		public override void SetDefaults()
		{
			item.damage = 50;
			item.ranged = true;
			item.width = 92;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 64f;
			item.useAmmo = mod.ItemType("PlasmaRound");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool ConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .5;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
