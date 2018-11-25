using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class BloodthirstyBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodthirsty Blade");
			Tooltip.SetDefault("Becomes stronger the more enemies are defeated by it"
			+"\nKilling boss gives bigger damage boost"
			+"\nBlue Slimes and Spiked Blue Slimes will not give the weapon boosts"
			+"\nDoes not getting any benefits from bonus damage/critical strike chance"
			+"\nDamage is capped until entering Hardmode (36) and beating Moon Lord (99)");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровожадный Клинок");
            Tooltip.AddTranslation(GameCulture.Russian, "Чем больше врагов побеждено им, тем сильнее он становится\nУбийство босса даёт больший бонус к урону\nСиние и Синие шипастные слизни не дают бонуса к урону\nНе получает никаких бонусов по урону и шансу критического удара\nУрон ограничен до Хардмода (36) и победы над Лунным Лордом (99)");
        }

		public override void SetDefaults()
		{
			item.damage = 10;
			item.crit = 50;
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 100000;
			item.rare = 4;
            item.knockBack = 8;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.5f;
		}

		public override void UpdateInventory(Player player)
		{
			item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP/100);
			if (!Main.hardMode)
			{
				if (item.damage > 36)
				{
					item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				if (item.damage > 99)
				{
					item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				item.useTime = 10;
				item.useAnimation = 10;
			}
		}
		
		public override void HoldItem(Player player)
		{
			item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP/100);
			if (!Main.hardMode)
			{
				if (item.damage > 36)
				{
					item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				if (item.damage > 99)
				{
					item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				item.useTime = 10;
				item.useAnimation = 10;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BloodButcherer);
			recipe.AddIngredient(ItemID.Vertebrae, 15);
			recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddIngredient(ItemID.RottenChunk, 15);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
