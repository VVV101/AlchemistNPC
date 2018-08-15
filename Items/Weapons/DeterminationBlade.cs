using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class DeterminationBlade : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Determination Blade");
			Tooltip.SetDefault("Contains Determination of 7 souls"
			+"\nAttacks building Hate" 
			+"\nAfter a certain amount of hits, right-clicking will release the Hate");
			DisplayName.AddTranslation(GameCulture.Russian, "Клинок Решимости");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе Решимость семи душ\nАтаки заряжают Ненависть\nПосле определённого количества ударов вы можете её выпустить, нажав правую кнопку мыши");

            DisplayName.AddTranslation(GameCulture.Chinese, "决绝之剑");
            Tooltip.AddTranslation(GameCulture.Chinese, "七魂之决绝蕴于此剑\n攻击增加仇恨\n在击中多次后可以右键释放它.");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 175;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = 1000000;
			item.rare = 10;
            item.knockBack = 8;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("DBD");
			item.shootSpeed = 9f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			if (AlchemistNPC.DTH >= 5)
			{
			player.AddBuff(mod.BuffType("Hate"), 2);
			}
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && (AlchemistNPC.DTH < 5))
			{
				return false;
			}
			if (player.altFunctionUse == 2 && (AlchemistNPC.DTH >= 5))
			{
				item.shoot = mod.ProjectileType("DTH");
				AlchemistNPC.DTH = 0;
			}
			if (player.altFunctionUse == 0){
			switch (count)
			{
				case 0:
				item.shoot = mod.ProjectileType("DBD");
				count++;
				break;

				case 1:
				item.shoot = mod.ProjectileType("DBPV");
				count++;
				break;
				
				case 2:
				item.shoot = mod.ProjectileType("DBJ");
				count++;
				break;
				
				case 3:
				item.shoot = mod.ProjectileType("DBB");
				count++;
				break;
				
				case 4:
				item.shoot = mod.ProjectileType("DBP");
				count++;
				break;
				
				case 5:
				item.shoot = mod.ProjectileType("DBI");
				count++;
				break;
				
				case 6:
				item.shoot = mod.ProjectileType("DBK");
				count = 0;
				break;
			}
			
		}
		return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
					if (count == 3)
					{
					item.shoot = mod.ProjectileType("DBJ");
					int numberProjectiles = 3 + Main.rand.Next(3);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DBJ"), damage, knockBack, player.whoAmI);
						}
					}
					if (count == 4)
					{
					item.shoot = mod.ProjectileType("DBB");
					int numberProjectiles = 2 + Main.rand.Next(2);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DBB"), damage, knockBack, player.whoAmI);
						}
					}
					return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoulEssence", 7);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
