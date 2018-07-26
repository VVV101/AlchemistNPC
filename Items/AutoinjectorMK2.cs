using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class AutoinjectorMK2 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Autoinjector MK2");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions and increases length of invincibility after taking hit"
				+ "\nAdds 10% to all damage and 8% to all critical chances"
				+ "\nAlso gives permanent effect of Universal Combination"
				+ "\nGives effects of modded Combinations as well");
				DisplayName.AddTranslation(GameCulture.Russian, "Автоинъектор MK2");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию жизней \nУменьшает откат зелий лечения \nУвеличивает период неуязвимости после получения урона\nДобавляет 10% ко всем видам урона и 8% ко всем шансам критического удара\nТакже даёт постоянный эффект Комбинации Универсала\nТакже даёт эффекты модовых Комбинаций");

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
			item.expert = true;
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
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			player.AddBuff(mod.BuffType("CalamityComb"), 2);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("CritChance"), 2, true);
            player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("BloodRush"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("CombatProwess"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("Frenzy"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("CreativityDrop"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("EarwormBuff"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("InspirationReach"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("RadiantBoost"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("HolyBonus"), 2, true);
			player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("DashBuff"), 2, true);
			}
			if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
			{
			player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("SpiritBuff"), 2, true);
            player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("RunePotionBuff"), 2, true);
			player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("SoulPotionBuff"), 2, true);
			player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("StarPotionBuff"), 2, true);
			player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("TurtlePotionBuff"), 2, true);
			player.AddBuff(ModLoader.GetMod("SpiritMod").BuffType("BismitePotionBuff"), 2, true);
			}
		}
	}
}