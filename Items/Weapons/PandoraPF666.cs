using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF666 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF666)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nSpecial attack #2 (Released Energy)"
			+"\nAttack depletes Disaster gauge"
			+"\nRight click to change special attack");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 666)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nСпециальная Атака №2 (Высвобождение энергии)\nАтака опусташает шкалу Бедствия\nНажмите правую кнопку мыши для смены специальной атаки");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF666)");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SnowmanCannon);
			item.ranged = false;
			item.damage = 666;
			item.crit = 100;
			item.width = 56;
			item.height = 30;
			item.useTime = 90;
			item.useAnimation = 90;
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
			player.AddBuff(mod.BuffType("DisasterLV3"), 2);
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
