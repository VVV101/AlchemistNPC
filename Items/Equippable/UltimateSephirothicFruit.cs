using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class UltimateSephirothicFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate Sephirotic Fruit");
			Tooltip.SetDefault("The last of Echidna's seeds... Holds incredible powers inside."
			+"\nIncreases minion damage by 15%"
			+"\nIncreases max amount of minions by 3"
			+"\nMinions can critically hit with 10% chance"
			+"\nMinions nearly ignore enemy invincibility frames");
			DisplayName.AddTranslation(GameCulture.Russian, "Расцвёвший Плод Сефирот");
            Tooltip.AddTranslation(GameCulture.Russian, "Последнее из семян Ехидны... Хранит невероятные силы внутри\nПовышает урон прислужников на 15%\nУвеличивает максимальное количество прислужников на 3\nПрислужники могут нанести критический удар с вероятностью в 10%\nПрислужники почти полностью игнорируют период неуязвимости у противника");
			DisplayName.AddTranslation(GameCulture.Chinese, "终极瑟芙罗克之果");
			Tooltip.AddTranslation(GameCulture.Chinese, "埃凯德娜最后的种子... 拥有不可思议的力量.\n增加15%召唤伤害\n增加3个最大召唤物数量\n召唤物有10%概率暴击\n召唤物无视敌人无敌帧");
        }
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().SF = true;
			player.GetModPlayer<AlchemistNPCPlayer>().SFU = true;
            player.minionDamage += 0.15f;
			++player.maxMinions;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SephirothicFruit");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 20);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
			recipe.AddTile(null, "MateriaTransmutator");
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}