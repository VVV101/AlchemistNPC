using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF398 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF398)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nChargeable Laser Device"
			+"\nAttacking fills Disaster Gauge"
			+"\nFull gauge allows you to switch weapon's form"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 398)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nЗаряжаемый лазер\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF398)");
			Tooltip.AddTranslation(GameCulture.Chinese, "'来自地狱的武器, 有666种不同的形态'"
			+"\n修复了的潘多拉, 解锁了破坏潜力"
			+"\n可蓄力的激光发射器"
			+"\n攻击装填灾厄槽"
			+"\n灾厄槽集满时能够切换武器形态"
			+"\n右键切换形态");
        }

		public override void SetDefaults()
		{
			item.damage = 250;
			item.noMelee = true;
			item.ranged = true;
			item.channel = true;
			item.rare = 12;
			item.width = 18;
			item.height = 14;
			item.useTime = 40;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 40;   
			item.knockBack = 10;			
			item.shoot = mod.ProjectileType("PF398");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}

		public override void HoldItem(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).PH = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge += 10;
			if (player.altFunctionUse != 2)
			{
			return true;
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
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 500)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 0;
				item.SetDefaults(mod.ItemType("PandoraPF594"));
			}
			return false;
		}
	}
}
