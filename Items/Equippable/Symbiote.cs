using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Symbiote : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbiote");
			Tooltip.SetDefault("Adds 10% to all damage and critical strike chances"
				+ "\nLowers cooldown of healing potions"
				+ "\nIncreases length of invincibility after taking hit"
				+ "\nHas two states (Offense and Defense)"
				+ "\nOffensive state increases attack speed by 20%"
				+ "\nActivates while you have > 50% of HP"
				+ "\nDefensive state greatly increases regeneration, defense and damage reduction"
				+ "\nActivates while you have < 50% of HP");
				DisplayName.AddTranslation(GameCulture.Russian, "Симбиот");
            Tooltip.AddTranslation(GameCulture.Russian, "Усиливает регенерацию\nУменьшает откат зелий лечения\nУвеличивает период неуязвимости после получения урона\nДобавляет 10% ко всем видам урона и 10% ко всем шансам критического удара\nИмеет 2 состояния (Боевое и Защитное)\nБоевое состояние увеличивает скорость ближнего боя на 20%\nАктивируется когда здоровье >50%\nЗащитное состояние сильно усиливает регенерацию, повышает защиту и поглощение урона\nАктивируется когда здоровье <50%");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 6;
			item.lifeRegen = 4;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Item.potionDelay = 2100;
			if (player.statLife > player.statLifeMax2/2)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Symbiote = true;
			player.AddBuff(mod.BuffType("SymbOff"), 2, true);
			}
			if (player.statLife < player.statLifeMax2/2)
			{
			player.lifeRegen += 11;
			player.statDefense += 14;
			player.endurance += 0.15f;
			player.AddBuff(mod.BuffType("SymbDef"), 2, true);
			}
			player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			player.longInvince = true;
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.1f;
            RedemptionPlayer.druidCrit += 10;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.1f;
            ThoriumPlayer.symphonicCrit += 10;
			ThoriumPlayer.radiantBoost += 0.1f;
            ThoriumPlayer.radiantCrit += 10;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		
		
	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DestroyerEmblem);
			recipe.AddIngredient(null, "ChromaticCrystal", 10);
			recipe.AddIngredient(null, "SunkroveraCrystal", 10);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 50);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 250);
			if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddTile(null, "MateriaTransmutator");
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
}