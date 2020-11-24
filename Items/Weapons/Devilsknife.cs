using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Devilsknife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Tooltip.SetDefault("Summons Devilsknife to destroy your foes"
			+"\nMore than 1 cannot be summoned"
			+"\nMETAMORPHOSIS!");
			DisplayName.AddTranslation(GameCulture.Russian, "Дьявольский Нож");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает Дьявольский Нож для уничтожения ваших врагов\nНельзя призвать более одного\nМЕТАМОРФОЗ!");
			DisplayName.AddTranslation(GameCulture.Chinese, "恶魔之刃");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤恶魔之刃摧毁你的敌人"
			+"\n最多只能召唤1体"
			+"\nMETAMORPHOSIS!");
        }
		
		public override void SetDefaults()
		{
			item.damage = 222;
			item.mana = 33;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = Item.buyPrice(15, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("Devilsknife");
			item.shootSpeed = 16f;
			item.buffType = mod.BuffType("Devilsknife");
			item.summon = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
		
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			return player.altFunctionUse != 2;
		}
	}
}
