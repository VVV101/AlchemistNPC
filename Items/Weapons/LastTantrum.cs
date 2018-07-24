using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class LastTantrum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Last Tantrum");
			Tooltip.SetDefault("Shoots homing, all-eleminating bullets");
			DisplayName.AddTranslation(GameCulture.Russian, "Последний Тантрум");
			Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает самонаводящиеся пули, уничтожающие всё");

            DisplayName.AddTranslation(GameCulture.Chinese, "最终之怒");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射自动追踪、全元素伤害的子弹");
        }

		public override void SetDefaults()
		{
			item.damage = 22222;
			item.ranged = true;
			item.width = 92;
			item.height = 40;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 5000000;
			item.rare = 8;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 64f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("LastTantrum");
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
