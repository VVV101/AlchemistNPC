using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Laetitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia (O-01-67)");
			Tooltip.SetDefault("''It takes a lot of time, but its power cannot be ignored''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nShoots heavy damaging bullets 2 times in 1 second"
			+ "\nCan be powered up by equipping full set of 'Laetitia'");
			DisplayName.AddTranslation(GameCulture.Russian, "Летиция (O-01-67)");
            Tooltip.AddTranslation(GameCulture.Russian, "Пусть она и требует много времени, но ее мощь нельзя игнорировать.\n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает мощные пули 2 раза в секунду\nМожет быть усилена экипировкой полного сета 'Летиция'");

            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'粗糙的结构设计令它的外表有些老旧, 可它仍有不可忽视的威力.'\n[c/FF0000:EGO 武器]\n一秒发射两发威力巨大的子弹\n身着全套'蕾蒂希娅'可提升伤害");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Musket);
			item.damage = 35;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.GetModPlayer<AlchemistNPCPlayer>().LaetitiaSet == true)
			{
			item.damage = 35;
			item.useTime = 15;
			item.useAnimation = 15;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().LaetitiaSet == false)
			{
			item.damage = 35;
			item.useTime = 30;
			item.useAnimation = 30;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
			item.damage = 500;
			item.useTime = 15;
			item.useAnimation = 15;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage/2, knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TheUndertaker);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}