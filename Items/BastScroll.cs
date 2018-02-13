using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items
{
	public class BastScroll : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Tooltip.SetDefault("'The strong shall hunt the weak — that is the law of nature! And my rule is law!'"
			+"\nGives effects of Master Ninja Gear"
			+"\nAllows to jump higher"
			+"\nAllows to jump 3 times"
			+"\nBonus jumps could be disabled by changing visibility of accessory"
			+"\n+10% damage reduction"
			+"\nIncreases melee/throwing damage and crits by 15%"
			+"\nAttacks destroys enemy armor totally"
			+"\nThrowing attacks goes through tiles");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток Баст");
			Tooltip.AddTranslation(GameCulture.Russian, "'Сильные должны охотиться на слабых - таков закон природы! И моё слово - закон!'\nДаёт все эффекты Снаряжения Мастера Ниндзя\nПозволяет прыгать выше\nПозволяет прыгать 3 раза\nДополнительные прыжки можно отключить с помощью изменения видимости аксессуара\nУменьшает получаемый урон на 10%\nПовышает урон и шанс критической атаки оружия ближнего боя/метательного на 15%\nАтаки полностью разрушают броню противника\nМетательные атаки проходят сквозь блоки"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 50000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BastScroll"), 60);
			AlchemistNPC.scroll = true;
			player.endurance += 0.1f;
			player.statDefense += 5;
			player.thrownDamage += 0.15f;
            player.meleeDamage += 0.15f;
			player.meleeCrit += 15;
            player.thrownCrit += 15;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
			player.jumpBoost = true;
			player.noFallDmg = true;
			if (!hideVisual)
			{
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.BlackInk, 10);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 10);
			recipe.AddIngredient(ItemID.Nanites, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 30);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "EmagledFragmentation", 250);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CalamitousEssence")), 5);
					}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
					{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
					}
			if (ModLoader.GetLoadedMods().Contains("SacredTools"))
					{
			recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("QuasarSigil")));
					}
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}