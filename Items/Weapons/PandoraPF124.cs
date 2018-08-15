using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF124 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF124)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nLaunches 3 heavy damaging homing rockets."
			+"\nAttacking raises Disaster LV"
			+"\nLV3 allows to change weapon"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 124)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nЗапускает 3 мощных самонаводящихся ракеты\nПри наборе 3-го уровня Бедствия, вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF124)");
        }

		public override void SetDefaults()
		{
			item.damage = 88;
			item.ranged = true;
			item.crit = 21;
			item.width = 56;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 12;
			item.autoReuse = true;
			item.shoot = 340;
			item.shootSpeed = 32f;
			item.UseSound = SoundID.Item11;
		}
		
		public override void HoldItem(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Pandora = true;
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 40)
			{
			player.AddBuff(mod.BuffType("DisasterLV0"), 2);
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 40 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 80)
			{
			player.AddBuff(mod.BuffType("DisasterLV1"), 2);
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 80 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 120)
			{
			player.AddBuff(mod.BuffType("DisasterLV2"), 2);
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 120)
			{
			player.AddBuff(mod.BuffType("DisasterLV3"), 2);
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge++;
			if (player.altFunctionUse != 2)
			{
			type = 340;
			Projectile.NewProjectile(position.X, position.Y-8, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y+8, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
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
			if (player.altFunctionUse == 2 && player.HasBuff(mod.BuffType("DisasterLV3")) == false)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && player.HasBuff(mod.BuffType("DisasterLV3")))
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 0;
				item.SetDefaults(mod.ItemType("PandoraPF262"));
			}
			return false;
		}
	}
}