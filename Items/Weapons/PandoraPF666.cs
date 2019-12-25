using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF666 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF666)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nSpecial attack #2 (Energy Release)"
			+"\nAttack depletes Disaster Gauge"
			+"\nRight click to change special attack");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 666)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nСпециальная Атака №2 (Высвобождение энергии)\nАтака опустошает шкалу Бедствия\nНажмите правую кнопку мыши для смены специальной атаки");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF666)");
			Tooltip.AddTranslation(GameCulture.Chinese, "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n特殊攻击 #2 (能量放出)"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换特殊攻击");
        }
		
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SnowmanCannon);
			item.ranged = false;
			item.damage = 666;
			item.crit = 100;
			item.width = 56;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.noMelee = true;
			item.knockBack = 8;
			item.rare = 12;
			item.autoReuse = false;
			item.shootSpeed = 32f;
			item.shoot = mod.ProjectileType("PF666");
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.UseSound = SoundID.Item5;
			item.useAmmo = 0;
		}

		public override void HoldItem(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).PH = true;
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 500;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse != 2)
			{
			Vector2 vel1 = new Vector2(-0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(player.position.X, player.position.Y, vel1.X, vel1.Y, mod.ProjectileType("PF666"), item.damage, 0, Main.myPlayer);
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 0;
			item.SetDefaults(mod.ItemType("Pandora"));
			}
			if (player.altFunctionUse == 2)
			{
			return false;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				item.SetDefaults(mod.ItemType("PandoraPF594"));
				return true;
			}
			return false;
		}
	}
}
