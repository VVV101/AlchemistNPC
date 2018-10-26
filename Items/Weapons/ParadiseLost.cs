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
using AlchemistNPC.Items.PaleDamageClass;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class ParadiseLost : PaleDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost (T-03-46)");
			Tooltip.SetDefault("''I knocked on the door, and it opened."
			+"\nI am from the end, I am merely staying."
			+"\nI am the one who kindled the lantern to face the world."
			+"\nMy loved ones, I shall show thou the best path from now on``"
			+ "\n[c/FF0000:EGO weapon]"
			+"\nLeft click launcher travelling through walls projectile"
			+"\nRight click slices the air in place"
			+"\nFull set of Paradise Lost is required to use this weapon");
			DisplayName.AddTranslation(GameCulture.Russian, "Потерянный Рай (T-03-46)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Я постучал в дверь, и она открылась.\nЯ из конца, я просто остаюсь.\nЯ тот, кто зажег фонарь.\nМои близкие, я покажу вам лучший путь с этого момента.''\n[c/FF0000:Оружие Э.П.О.С.]\nЗапускает проходящий сквозь стены снаряд по нажатию левой кнопки мыши\nРазрезает воздух на месте по нажатию правой кнопки мыши\nТребуется полный сет Потерянного Рая для использования");

            DisplayName.AddTranslation(GameCulture.Chinese, "失乐园 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.Chinese, "乐园的大门因我的敲击而缓缓打开." +
                "\n我自终末而来, 我并无留恋, 只是在此驻足." +
                "\n我就是那个点燃希望之灯, 面对世界之人." +
                "\n我心爱的人儿, 从现在开始, 我会将那最美妙的, 无比璀璨的道路展现在你们面前." +
                "\n[c/FF0000:EGO 武器]" +
                "\n左键发射穿越方块的刀波" +
                "\n右键割裂周围的空间" +
                "\n只有穿着全套失乐园盔甲才能使用这件武器");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 666;
			item.crit = 66;
			item.width = 52;
			item.height = 52;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 8;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("ParadiseLostProjectile");
			item.shootSpeed = 8f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				item.useTime = 40;
				item.useAnimation = 40;
			}
			else
			{
				item.useTime = 30;
				item.useAnimation = 30;
			}
			return false;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse != 2)
			{
			item.noMelee = false;
			Vector2 SPos = player.position;
			position = SPos;
			if (player.direction == 1)
				{
				Projectile.NewProjectile(position.X+10, position.Y, speedX, speedY, mod.ProjectileType("ParadiseLostProjectile"), damage, knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
				Projectile.NewProjectile(position.X-10, position.Y, speedX, speedY, mod.ProjectileType("ParadiseLostProjectile"), damage, knockBack, player.whoAmI);
				}
			}
			if (player.altFunctionUse == 2)
			{
				item.noMelee = true;
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("ParadiseLost"), damage, knockBack, player.whoAmI);
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, mod.ProjectileType("ParadiseLostMirror"), damage, knockBack, player.whoAmI);
					}
				}
			}
			return false;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Twilight"), 600);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Twilight");
			recipe.AddIngredient(null, "ChromaticCrystal", 10);
			recipe.AddIngredient(null, "SunkroveraCrystal", 10);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 250);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
