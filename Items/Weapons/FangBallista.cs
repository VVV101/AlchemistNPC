using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class FangBallista : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fang Ballista");
			Tooltip.SetDefault("Shoots highly damaging spider fang"
			+"\nNormal enemies would be impaled and immobilized");
			DisplayName.AddTranslation(GameCulture.Russian, "Клыковая баллиста");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает прибивающий противников паучий клык\nМожет обездвижить обычных противников");
        }

		public override void SetDefaults()
		{
			item.damage = 99;
			item.ranged = true;
			item.crit = 21;
			item.width = 32;
			item.height = 46;
			item.useTime = 90;
			item.useAnimation = 90;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SpiderFang");
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}