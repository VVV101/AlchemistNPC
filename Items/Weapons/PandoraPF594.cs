using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF594 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF594)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nFixed Pandora with unlocked damaging potential"
			+"\nSpecial attack #1 (Homing Rockets to all directions)"
			+"\nAttack depletes Disaster Gauge"
			+"\nRight click to change special attack");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 594)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nВерсия с разблокированным потенциалом\nСпециальная Атака №1 (самонаводящиеся ракеты вокруг)\nАтака опусташает шкалу Бедствия\nНажмите правую кнопку мыши для смены специальной атаки");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF594)");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SnowmanCannon);
			item.noUseGraphic = true;
			item.ranged = false;
			item.damage = 3333;
			item.crit = 100;
			item.width = 56;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 1000000;
			item.rare = 12;
			item.autoReuse = false;
			item.shootSpeed = 32f;
			item.shoot = ProjectileID.VortexBeaterRocket;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.useAmmo = 0;
		}

		public override void HoldItem(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DisasterGauge = 500;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse != 2)
			{
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 8f;
			Projectile.NewProjectile(player.position.X+30, player.position.Y+30, vel1.X, vel1.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 8f;
			Projectile.NewProjectile(player.position.X-30, player.position.Y-30, vel2.X, vel2.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 8f;
			Projectile.NewProjectile(player.position.X-30, player.position.Y+30, vel3.X, vel3.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 8f;
			Projectile.NewProjectile(player.position.X+30, player.position.Y-30, vel4.X, vel4.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 8f;
			Projectile.NewProjectile(player.position.X, player.position.Y+30, vel5.X, vel5.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 8f;
			Projectile.NewProjectile(player.position.X, player.position.Y-30, vel6.X, vel6.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 8f;
			Projectile.NewProjectile(player.position.X-30, player.position.Y, vel7.X, vel7.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 8f;
			Projectile.NewProjectile(player.position.X+30, player.position.Y, vel8.X, vel8.Y, ProjectileID.VortexBeaterRocket, item.damage/2, 0, Main.myPlayer);
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
				item.SetDefaults(mod.ItemType("PandoraPF666"));
				return true;
			}
			return false;
		}
	}
}
