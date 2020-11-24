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
	public class UgandanTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Totem");
			Tooltip.SetDefault("Summons Ugandan Warrior to protect you"
			+"\nMore than 1 cannot be summoned"
			+"\nMax minions slots multiply summon's damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Тотем Уганды");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает Воина Уганды для уничтожения ваших врагов\nНельзя призвать более одного\nМаксимальное количество прислужников увеличивает урон");
			DisplayName.AddTranslation(GameCulture.Chinese, "乌干达图腾");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤乌干达战士保护你"
			+"\n最多召唤1个"
			+"\n召唤物伤害与最大召唤栏数量成正比");
        }
		
		public override void SetDefaults()
		{
			item.damage = 12345;
			item.mana = 200;
			item.width = 28;
			item.height = 22;
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
			item.shoot = mod.ProjectileType("UgandanWarrior");
			item.shootSpeed = 16f;
			item.buffType = mod.BuffType("UgandanWarrior");
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
