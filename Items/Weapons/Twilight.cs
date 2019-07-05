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
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight (O-02-63)");
			Tooltip.SetDefault("''Eyes that never close, a scale that could measure all sins, and a beak that could swallow everything"
			+ "\nprotected the Black Forest in peace, and those who could wield this could also bring peace.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts several types of damage on hit"
			+ "\nHits every enemy on screen by 200 each second while held"
			+ "\nRight click teleports you to cursor, boosting your damage by 3x and making you unvulnerable for 2 seconds");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумерки (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Russian, "Глаза, что не закроются никогда, чешуя, что может измерить все грехи и клюв, \nкоторый способен поглотить всё, хранят Чёрный Лес в покое. \nИ те, кто способны носить ЕГО, тоже могут нести покой.\n[c/FF0000:Оружие Э.П.О.С.]\nПричиняет несколько типов урона\nРанит всех противников на экране по 150 урона каждую секунду\nПравый клик телепортирует вас на позицию курсора, делает вас неуязвимым и повышает ваш урон в 3 раза на 2 секунды");

            DisplayName.AddTranslation(GameCulture.Chinese, "黄昏将至 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'那永不闭合的眼睛, 那能衡量一切罪恶的天平, 那能吞噬一切的巨口'\n'这三者守护着黑森林的和平, 而那些能够同时驾驭这三者的人也能带来和平.'\n[c/FF0000:EGO 武器]\n对命中的敌人造成多种不同伤害\n伤害类型可通过右键切换\n如果敌人血量少于10000点, 武器会秒杀他们.");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 300;
			item.width = 60;
			item.height = 62;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 6;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void HoldItem(Player player)
		{
			counter++;
			if (counter == 60)
			{
				counter = 0;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Returner"), 200, 0, player.whoAmI);
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Twilight"), 600);
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
				{
					item.damage = 400;
					item.useTime = 10;
					item.useAnimation = 10;
				}
				else
				{
					item.damage = 300;
					item.useTime = 12;
					item.useAnimation = 12;
				}
			}
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("TwilightCD")))
			{
				player.AddBuff(mod.BuffType("TwilightBoost"), 120);
				player.AddBuff(mod.BuffType("TwilightCD"), 600);
				Vector2 vector = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				player.Teleport(vector, 1, 0);
			}
			if (player.altFunctionUse == 2 && player.HasBuff(mod.BuffType("TwilightCD")))
			{
				return false;
			}
			return base.CanUseItem(player);
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
