using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class Akumu : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''Akumu''");
			Tooltip.SetDefault("It means ''[c/FF00FF:nightmare]'' in Japanese"
			+"\nIts slice pierces through any amount of enemies on its way"
			+"\nLeft click launches a short travelling projectile"
			+"\nRight click slices the air in place"
			+"\nWhile at 25% of life or lower, Akumu generates projectile reflecting shield"
			+"\nThis would lower weapon's power until life regens back to 25%");
			DisplayName.AddTranslation(GameCulture.Russian, "''Акуму''");
            Tooltip.AddTranslation(GameCulture.Russian, "Это означает ''кошмар'' на Японском\nЕё удар пронзает любое количество врагов\nЗапускает снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nЕсли здоровье ниже 25% Акуму создает щит, отражающий снаряды\nНаличие щита снижает урон Акуму");

            DisplayName.AddTranslation(GameCulture.Chinese, "''Akumu''");
            Tooltip.AddTranslation(GameCulture.Chinese, "在日语里, 'Akumu'的意思是'梦魇'\n它的斩击能穿透经过的所有敌人\n左键发射剑气\n右键近距离攻击\n生命值低于25%时, Akumu会生成反射抛射物的护盾\n这将会降低武器的威力, 直至生命回复到25%");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 150;
			item.width = 58;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 12;
			item.knockBack = 8;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("Akumu");
			item.shootSpeed = 8f;
		}
		
		public override void HoldItem(Player player)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Akumu = true;
				player.AddBuff(mod.BuffType("Akumu"), 2);
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useTime = 40;
				item.useAnimation = 40;
			}
			else
			{
				item.useTime = 30;
				item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
			damage /= 2;
			}
			if (player.altFunctionUse != 2)
			{
			item.noMelee = false;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AkumuThrow"), damage, knockBack, player.whoAmI);
			}
			if (player.altFunctionUse == 2)
			{
				item.noMelee = true;
				if (player.direction == 1)
				{
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("Akumu"), damage, knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("AkumuMirror"), damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
	}
}
