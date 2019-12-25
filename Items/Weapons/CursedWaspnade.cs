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
	public class CursedWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps are inflicting Frostburn and Cursed Flame debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.Russian, "Осаната из Проклятого Льда");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает дружественных ос после взрыва\nОсы накладывают Морозный Ожог и поджигают Проклятым Пламенем\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
			DisplayName.AddTranslation(GameCulture.Chinese, "诅咒冰蜂");
			Tooltip.AddTranslation(GameCulture.Chinese, "爆炸后释放友好黄蜂"
			+"\n黄蜂造成霜火和咒火Debuff"
			+"\n装备蜂窝背包/瘟疫蜂巢(灾厄)时威力增强");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Beenade);
			item.thrown = true;
			item.damage = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.value = 10000;
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CursedWaspnade");
			item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Waspnade", 25);
			recipe.AddIngredient(null, "CursedIce");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}
