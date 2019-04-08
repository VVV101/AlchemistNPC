using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Autoinjector : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Autoinjector");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions and increases length of invincibility after taking hit"
				+ "\nAdds 10% to all damage and 8% to all critical chances"
				+ "\nGives effect of Universal Combination"
				+ "\nCan be consumed to give permanent effects to player:"
				+ "\nBuffs will never wear off after death"
				+ "\nBuffs's duration will become 2x"
				+ "\nWill also give permanent effect of Philosopher's Stone");
				DisplayName.AddTranslation(GameCulture.Russian, "Автоинъектор");
            Tooltip.AddTranslation(GameCulture.Russian, "Усиливает регенерацию \nУменьшает откат зелий лечения \nУвеличивает период неуязвимости после получения урона\nДобавляет 10% ко всем видам урона и 8% ко всем шансам критического удара\nТакже даёт эффект Комбинации Универсала\nМожет быть использован для получения постоянных эффектов:\nБаффы не будут исчезать после смерти\nБаффы будут действовать вдвое дольше\nТакже даст постоянный эффект Философского камня");

            DisplayName.AddTranslation(GameCulture.Chinese, "自动注射器");
            Tooltip.AddTranslation(GameCulture.Chinese, "提供生命回复, 降低治疗药水的冷却时间, 延长收到伤害后的无敌时间\n增加10%全伤害和8%全伤害的暴击几率\n同时永久给予万能药剂包buff（包含坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包）");
        }
	
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
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
			player.AddBuff(mod.BuffType("UniversalComb"), 2);
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.1f;
            CalamityPlayer.throwingCrit += 8;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.1f;
            RedemptionPlayer.druidCrit += 8;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.1f;
            ThoriumPlayer.symphonicCrit += 8;
			ThoriumPlayer.radiantBoost += 0.1f;
            ThoriumPlayer.radiantCrit += 8;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCPlayer>().KeepBuffs < 1;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().KeepBuffs += 1;
			return true;
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