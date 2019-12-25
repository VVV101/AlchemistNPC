using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC.Items.PaleDamageClass;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ParadiseLostHead : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Paradise Lost Crown of Thorns (T-03-46)");
            DisplayName.AddTranslation(GameCulture.Russian, "Терновый Венец Потерянного Рая (T-03-46)");
            Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
            + "\nHave thou not yet realized that pain is nothing?"
            + "\nThou want me to prove the miracle."
            + "\nThou shall believe in me and granted with life. I shall show you the power.''"
            + "\n[c/FF0000:EGO armor piece]"
            + "\n+100 max mana"
            + "\nIncreases melee speed by 33%");
            Tooltip.AddTranslation(GameCulture.Russian, "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы хотите, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Часть брони Э.П.О.С.]\n+100 к максимуму маны\nУвеличивает скорость ближнего боя на 35%");

            DisplayName.AddTranslation(GameCulture.Chinese, "失乐园荆棘王冠 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'你不必担心, 我已经听到了你那略带惊恐的祈祷." +
                "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?" +
                "\n你要我证明奇迹." +
                "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'" +
                "\n[c/FF0000:EGO 盔甲]" +
                "\n增加 100 最大法力值" +
                "\n增加 33% 近战速度");

            ModTranslation text = mod.CreateTranslation("ParadiseLostSetBonus");
            text.SetDefault("Increases all damage by 35% and adds 25% to critical strike chance"
            + "\nIncreases damage dealt by EGO weapons"
            + "\nChanges would be seen after first usage of weapons"
            + "\nIf hit taken deals less than 100 damage, then it will be nullified.");
            text.AddTranslation(GameCulture.Russian, "Увеличивает любой урон на 35% и добаляет 25% к шансу критического удара\nУвеличивает урон наносимый оружием Э.П.О.С.\nЕсли вы получаете меньше 150 урона, то урон будет аннулирован");
            text.AddTranslation(GameCulture.Chinese, "增加 35% 所有伤害, 增加 25% 暴击率"
            + "\n使用 EGO 武器造成更多伤害"
            + "\n第一次使用武器后就能看见变化"
            + "\n如果你受到的伤害小于 150 , 伤害将会无效化.");
            mod.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 11;
			item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 100;
			player.meleeSpeed += 0.33f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ParadiseLostBody") && legs.type == mod.ItemType("ParadiseLostLegs");
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}

		public override void UpdateArmorSet(Player player)
		{
			string ParadiseLostSetBonus = Language.GetTextValue("Mods.AlchemistNPC.ParadiseLostSetBonus");
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost = true;
			player.setBonus = ParadiseLostSetBonus;
			player.AddBuff(mod.BuffType("BigBirdLamp"), 60);
			player.allDamage += 0.35f;
			player.meleeCrit += 25;
			player.magicCrit += 25;
			player.rangedCrit += 25;
            player.thrownCrit += 25;
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
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            CalamityPlayer.throwingCrit += 25;
        }
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 25;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 25;
            ThoriumPlayer.radiantCrit += 25;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TwilightCrown");
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 7);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}