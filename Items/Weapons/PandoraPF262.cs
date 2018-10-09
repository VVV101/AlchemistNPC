using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF262 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF262)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nChaingun with very high shooting speed"
			+"\nAttacking raises Disaster Gauge"
			+"\n500 allows to change weapon"
			+"\nRight click to change form");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 262)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nПулемёт с очень высокой скоростью атаки\nПри наборе полной шкалы Бедствия вы можете сменить форму Пандоры\nНажмите правую кнопку мыши для смены формы");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF262)");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ChainGun);
			item.damage = 66;
			item.ranged = true;
			item.knockBack = 3;
			item.width = 50;
			item.height = 30;
			item.useTime = 4;
			item.useAnimation = 4;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.value = 1000000;
			item.rare = 12;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = 0;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge++;
			if (player.altFunctionUse != 2)
			{
			Projectile.NewProjectile(position.X, position.Y+3+Main.rand.Next(-5,5), speedX, speedY, 638, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y+Main.rand.Next(-5,5), speedX, speedY, 638, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y-3+Main.rand.Next(-5,5), speedX, speedY, 638, damage, knockBack, player.whoAmI);
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
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge < 500)
			{
				return false;
			}
			if (player.altFunctionUse == 2 && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge >= 500)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 0;
				item.SetDefaults(mod.ItemType("PandoraPF398"));
			}
			return false;
		}
	}
}
