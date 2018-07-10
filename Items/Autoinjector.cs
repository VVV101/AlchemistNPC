using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class Autoinjector : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Autoinjector");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions and increases length of invincibility after taking hit"
				+ "\nAdds 10% to all damage and 8% to all critical chances"
				+ "\nAlso gives permanent effect of Universal Combination (contains Ranger, Mage, Summoner and Tank Combinations effects altogether)");
				DisplayName.AddTranslation(GameCulture.Russian, "Автоинъектор");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию жизней \nУменьшает откат зелий лечения \nУвеличивает период неуязвимости после получения урона\nДобавляет 10% ко всем видам урона и 8% ко всем шансам критического удара\nТакже даёт постоянный эффект Комбинации Универсала (включает в себя эффекты Комбинаций Мага, Стрелка, Призывателя и Танка)");
            DisplayName.AddTranslation(GameCulture.Chinese, "自动注射器");
            Tooltip.AddTranslation(GameCulture.Chinese, "提供生命回复, 降低治疗药水的冷却时间, 延长收到伤害后的无敌时间\n增加10%全伤害和8%全伤害的暴击几率\n同时永久给予万能药剂包buff（包含坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包）");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 4;
			item.lifeRegen = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
			player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.thrownCrit += 8;
			player.pStone = true;
			player.longInvince = true;
			player.AddBuff(mod.BuffType("UniversalComb"), 1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistNecklace", 1);
			recipe.AddIngredient(null, "TankCombination", 30);
			recipe.AddIngredient(null, "RangerCombination", 30);
			recipe.AddIngredient(null, "MageCombination", 30);
			recipe.AddIngredient(null, "SummonerCombination", 30);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 25);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.ShroomiteBar, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.AddIngredient(null, "AlchemicalBundle", 1);
			recipe.AddIngredient(ItemID.HerculesBeetle, 1);
			recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
			recipe.AddIngredient(null, "MasksBundle", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WatcherAmulet", 1);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 25);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.ShroomiteBar, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 25);
			recipe.AddIngredient(ItemID.HerculesBeetle, 1);
			recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
			recipe.AddIngredient(null, "TankCombination", 30);
			recipe.AddIngredient(null, "RangerCombination", 30);
			recipe.AddIngredient(null, "MageCombination", 30);
			recipe.AddIngredient(null, "SummonerCombination", 30);
			recipe.AddIngredient(null, "MasksBundle", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}