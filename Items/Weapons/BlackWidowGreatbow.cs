using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class BlackWidowGreatbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Widow Greatbow");
			Tooltip.SetDefault("Shoots 3 highly damaging spider fangs"
			+"\nNormal enemies would be impaled and immobilized");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой лук Чёрной Вдовы");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает 3 прибивающих противников паучий клыка\nМожет обездвижить обычных противников");
			DisplayName.AddTranslation(GameCulture.Chinese, "黑寡妇巨弓");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射3发高伤害蜘蛛毒牙\n正常敌人会被刺穿并被束缚");
        }

		public override void SetDefaults()
		{
			item.damage = 140;
			item.ranged = true;
			item.crit = 21;
			item.width = 32;
			item.height = 46;
			item.useTime = 75;
			item.useAnimation = 75;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SpiderFang");
			float num121 = 0.314159274f;
			int num122 = 3;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num82 = Main.mouseX + Main.screenPosition.X - vector2.X;
			float num83 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
			Vector2 vector14 = new Vector2(speedX, speedY);
			vector14.Normalize();
			vector14 *= 40f;
			bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector14, 0, 0);
			int arrowtype = type;
			for (int num123 = 0; num123 < num122; num123++)
			{
				float num124 = num123 - (num122 - 1f) / 2f;
				Vector2 vector15 = vector14.RotatedBy(num121 * num124, default);
				if (!flag11)
				{
					vector15 -= vector14;
				}
				if (Main.rand.NextBool(8))
				{
					type = mod.ProjectileType("OceanicArrow");
				}
				else
				{
					type = arrowtype;
				}
				int num125 = Projectile.NewProjectile(vector2.X + vector15.X, vector2.Y + vector15.Y, num82, num83, type, damage, knockBack, player.whoAmI);
				Main.projectile[num125].noDropItem = true;
			}
			return false;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(mod.ItemType("FangBallista"));
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}