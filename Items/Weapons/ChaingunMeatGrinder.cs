using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChaingunMeatGrinder : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Gun ''Meat Grinder''");
			Tooltip.SetDefault("Forged by technologies of ancient colonizers."
			+"\nHas 6 rotating barrels with 17mm caliber"
			+"\nGains shooting speed over time"
			+"\nUses special ammo"
			+"\n66% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Пулемёт ''Мясорубка''");
            Tooltip.AddTranslation(GameCulture.Russian, "Изготовлен по технологии древних колонизаторов\nОружие имеет шесть вращающихся стволов калибра 17мм\nСкорость стрельбы постепенно возрастает\nИспользует специальные патроны\n66% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF262)");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ChainGun);
			item.damage = 40;
			item.ranged = true;
			item.knockBack = 3;
			item.width = 50;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.noMelee = true;
			item.value = 1000000;
			item.rare = 12;
			item.autoReuse = true;
			item.shoot = 638;
			item.useAmmo = mod.ItemType("MGB");
		}

		public override void UseStyle(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderOnUse = true;
			item.useTime = 10;
			item.useAnimation = 10;
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderUsetime++;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderUsetime >= 240)
			{
				item.useTime = 3;
				item.useAnimation = 3;
			}
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderUsetime >= 180)
			{
				item.useTime = 5;
				item.useAnimation = 5;
			}
			else if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderUsetime >= 90)
			{
				item.useTime = 8;
				item.useAnimation = 8;
			}
		}

		public override void HoldItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderOnUse == false)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).MeatGrinderUsetime = 0;
			}
		}
		
		public override bool ConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .66;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
			Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			Projectile.NewProjectile(vector.X, vector.Y+4, speedX2, speedY2, 638, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, 638, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(vector.X, vector.Y-4, speedX3, speedY3, 638, damage, knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 20);
			recipe.AddIngredient(null, "AlchemicalBundle");
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
