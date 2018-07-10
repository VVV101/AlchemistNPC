using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class Twilight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight (O-02-63)");
			Tooltip.SetDefault("''Eyes that never close, a scale that could measure all sins, and a beak that could swallow everything"
			+ "\nprotected the Black Forest in peace, and those who could wield this could also bring peace.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts several types of damage on hit"
			+ "\nIf enemy have less than 10000 HP, then projectile will kill it");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумерки (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Russian, "Глаза, что не закроются никогда, чешуя, что может измерить все грехи и клюв, \nкоторый способен поглотить всё, хранят Чёрный Лес в покое. \nИ те, кто способны носить ЕГО, тоже могут нести покой.\n[c/FF0000:Э.П.О.С. оружие]\nПричиняет несколько типов урона\nЕсли цель имеет меньше 10000 жизней, то снаряд убьёт её");
            DisplayName.AddTranslation(GameCulture.Chinese, "黄昏将至 (O-02-63)");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'那永不闭合的眼睛, 那能衡量一切罪恶的天平, 那能吞噬一切的巨口'\n'这三者守护着黑森林的和平, 而那些能够同时驾驭这三者的人也能带来和平.'\n[c/FF0000:EGO 武器]\n对命中的敌人造成多种不同伤害\n伤害类型可通过右键切换\n如果敌人血量少于10000点, 武器会秒杀他们.");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 300;
			item.width = 44;
			item.height = 44;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 12;
            item.knockBack = 6f;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("TP");
			item.shootSpeed = 6f;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Twilight"), 600);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Justitia");
			recipe.AddIngredient(null, "TheBeak");
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(null, "EmagledFragmentation", 200);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
