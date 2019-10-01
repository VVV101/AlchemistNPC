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
			DisplayName.AddTranslation(GameCulture.Chinese, "共生体");
			Tooltip.AddTranslation(GameCulture.Chinese, "增加10%所有伤害和暴击率\n减少生命药水冷却时间\n增加受伤无敌帧\n拥有两种模式 (攻击/防御)\n攻击模式下增加20%攻击速度\n生命值高于50%时激活\n防御模式下极大增加生命回复, 防御和伤害减免\n生命值低于50%时激活");
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
			if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.1f;
            CalamityPlayer.throwingCrit += 10;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
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
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 50);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 250);
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