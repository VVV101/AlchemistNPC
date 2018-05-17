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
		public bool AC = false;
		public bool DTT = true;
		public int DT = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight (O-02-63)");
			Tooltip.SetDefault("''Eyes that never close, a scale that could measure all sins, and a beak that could swallow everything"
			+ "\nprotected the Black Forest in peace, and those who could wield this could also bring peace.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nInflicts several types of damage on hit"
			+ "\nDamage type could be changed by right-click"
			+ "\nIf enemy have less than 10000 HP, then projectile will kill it");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумерки (O-02-63)");
			Tooltip.AddTranslation(GameCulture.Russian, "Глаза, что не закроются никогда, чешуя, что может измерить все грехи и клюв, \nкоторый способен поглотить всё, хранят Чёрный Лес в покое. \nИ те, кто способны носить ЕГО, тоже могут нести покой.\n[c/FF0000:Э.П.О.С. оружие]\nПричиняет несколько типов урона\nТип урона можно изменить с помощью нажатия правой кнопки мыши\nЕсли цель имеет меньше 10000 жизней, то снаряд убьёт её"); 
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
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && DT == 0 && DTT)
			{
				item.magic = true;
				item.melee = false;
				item.mana = 10;
				item.shoot = 0;
				item.damage = 300;
				item.noMelee = true;
				item.noUseGraphic = true;
				DT++;
				DTT = false;
			}
			if (player.altFunctionUse == 2 && DT == 1 && DTT)
			{
				item.magic = false;
				item.melee = true;
				item.mana = 0;
				item.shoot = 0;
				item.damage = 300;
				item.noMelee = true;
				item.noUseGraphic = true;
				DT = 0;
			}
			if (!DTT)
			{
			DTT = true;
			}
			if (player.altFunctionUse == 0)
			{
				item.noMelee = false;
				item.noUseGraphic = false;
				item.useTime = 15;
				item.useAnimation = 15;
				item.damage = 300;
				item.shoot = mod.ProjectileType("TP");
			}
			return base.CanUseItem(player);
		}
		
		public override bool UseItem(Player player)
		{
			if (DT == 0 || player.altFunctionUse == 2 & !DTT)
			{
			Main.PlaySound(SoundID.MenuClose, player.position, 0);
			string key = "Mods.AlchemistNPC.DC2";
			Color messageColor = Color.Blue;
			Main.NewText(Language.GetTextValue(key), messageColor);
			AC = true;
			}
			if (DT == 1 || player.altFunctionUse == 2 && DTT && !AC)
			{
			Main.PlaySound(SoundID.MenuOpen, player.position, 0);
			string key = "Mods.AlchemistNPC.DC1";
			Color messageColor = Color.Blue;
			Main.NewText(Language.GetTextValue(key), messageColor);
			}
			AC = false;
			return true;
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
