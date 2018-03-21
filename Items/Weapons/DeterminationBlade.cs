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
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Determination Blade");
			Tooltip.SetDefault("Contains Determination of 7 souls inside"
			+"\nAttacks building Hate" 
			+"\nAfter certain amount of hits you could release it by right-click.");
			DisplayName.AddTranslation(GameCulture.Russian, "Клинок Решимости");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе Решимость семи душ\nАтаки заряжают Ненависть\nПосле определённого количества ударов вы можете её выпустить, нажав правую кнопку мыши"); 
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 200;
			item.width = 32;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = 1000000;
			item.rare = 10;
            item.knockBack = 8f;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("DBB");
			item.shootSpeed = 16f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			if (AlchemistNPC.DTH >= 5)
			{
			player.AddBuff(mod.BuffType("Hate"), 60);
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
					if (count == 4)
					{
					int numberProjectiles = 3 + Main.rand.Next(2);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DBB"), damage, knockBack, player.whoAmI);
						}
					}
					return true;
		}
	}
}
