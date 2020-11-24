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
	public class SephirothicFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sephirotic Fruit");
			Tooltip.SetDefault("The last of Echidna's seeds... Holds incredible powers inside."
			+"\nIncreases minions damage by 15%"
			+"\nIncreases max amount of minions by 2"
			+"\nMinions nearly ignore enemy invincibility frames");
			DisplayName.AddTranslation(GameCulture.Russian, "Плод Сефирот");
            Tooltip.AddTranslation(GameCulture.Russian, "Последнее из семян Ехидны... Хранит невероятные силы внутри\nПовышает урон прислужников на 15%\nУвеличивает максимальное количество прислужников на 2\nПрислужники почти полностью игнорируют период неуязвимости у противника");

            DisplayName.AddTranslation(GameCulture.Chinese, "瑟芙罗克之果");
            Tooltip.AddTranslation(GameCulture.Chinese, "埃凯德娜最后的种子... 拥有不可思议的力量.\n增加15%召唤伤害\n增加2个最大召唤物数量\n召唤物无视敌人无敌帧");
        }
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().SF = true;
            player.minionDamage += 0.15f;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeFruit, 10);
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.Nanites, 50);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.NecromanticScroll);
			recipe.AddIngredient(ItemID.PygmyNecklace);
			recipe.AddIngredient(ItemID.FragmentStardust, 30);
			recipe.AddIngredient(ItemID.LunarBar, 15); 
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}