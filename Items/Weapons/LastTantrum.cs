using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class LastTantrum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Last Tantrum");
			Tooltip.SetDefault("Shoots homing bullets that eradicate everything");
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
			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.value = 5000000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 32f;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 59;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("LastTantrum");
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y+3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-10,10), position.Y-3+Main.rand.Next(-3,3), speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
