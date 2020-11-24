using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
            Tooltip.AddTranslation(GameCulture.Chinese, "提供生命回复, 降低治疗药水的冷却时间, 延长收到伤害后的无敌时间\n增加10%全伤害和8%全伤害的暴击率\n给予万能药剂包buff（包含坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包）\n使用后永久赋予玩家以下效果:\n死亡后Buff不消失\nBuff持续时间x2\n永久获得炼金石的效果");
        }
	
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
			item.defense = 4;
			item.lifeRegen = 2;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.allDamage += 0.1f;
			player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.thrownCrit += 8;
			player.pStone = true;
			player.longInvince = true;
			player.AddBuff(mod.BuffType("UniversalComb"), 2);
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 8);
			}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 8;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 8;
            ThoriumPlayer.radiantCrit += 8;
        }

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
			recipe.AddIngredient(null, "MaskBundle", 1);
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
			recipe.AddIngredient(null, "MaskBundle", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
