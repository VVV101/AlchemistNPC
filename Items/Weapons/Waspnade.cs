using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class Waspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.Russian, "Осаната");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает дружественных ос после взрыва\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
			DisplayName.AddTranslation(GameCulture.Chinese, "黄蜂雷");
			Tooltip.AddTranslation(GameCulture.Chinese, "爆炸后释放友善的黄蜂"
			+"\n装备蜂窝背包/瘟疫蜂巢(灾厄)时威力增强");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Beenade);
			item.thrown = true;
			item.damage = 20;
			item.useTime = 15;
			item.useAnimation = 15;
			item.value = 10000;
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Waspnade");
			item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Beenade, 25);
			recipe.AddIngredient(ItemID.VialofVenom);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}
