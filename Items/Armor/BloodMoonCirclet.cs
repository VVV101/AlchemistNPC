using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodMoonCirclet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horns Circlet");
			DisplayName.AddTranslation(GameCulture.Russian, "Ободок с рожками");
			Tooltip.SetDefault("Changes player's hairstyle and hair color (can be changed back by Stylist)");
            Tooltip.AddTranslation(GameCulture.Russian, "Меняет причёску и цвет волос (может быть изменено с помощью Стилиста)");
			
			ModTranslation text = mod.CreateTranslation("BloodMoonSetBonus");
		    text.SetDefault("Increases all damage by 25% and adds 20% to critical strike chance"
		    + "\n+36 defense"
		    + "\nIncreases movement speed by 25%"
			+ "\nYou have a chance to dodge attacks"
		    + "\nPlayer is under permanent effect of Mage Combination");
			text.AddTranslation(GameCulture.Russian, "Увеличивает весь урон на 25% и добавляет 20% к шансу критического удара\n+36 защиты\nСкорость передвижения увеличена на 25%\nПостоянный эффект комбинации Мага\nДаёт шанс увернуться при атаке");
			mod.AddTranslation(text);
        }
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BloodMoonDress") && legs.type == mod.ItemType("BloodMoonStockings");
		}

		public override void UpdateVanity(Player player, EquipType type)
		{
			player.hair = 83;
			player.hairColor = new Color(240, 210, 135);
		}
		
		public override void UpdateArmorSet(Player player)
		{
            string BloodMoonSetBonus = Language.GetTextValue("Mods.AlchemistNPC.BloodMoonSetBonus");
			player.setBonus = BloodMoonSetBonus;
            player.statDefense += 36;
			player.moveSpeed += 0.25f;
			player.AddBuff(mod.BuffType("MageComb"), 2);
			player.blackBelt = true;
			player.meleeDamage += 0.25f;
			player.magicDamage += 0.25f;
			player.minionDamage += 0.25f;
			player.magicDamage += 0.25f;
			player.thrownDamage += 0.25f;
			player.meleeCrit += 20;
			player.magicCrit += 20;
			player.rangedCrit += 20;
            player.thrownCrit += 20;
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
			CalamityPlayer.throwingDamage += 0.25f;
            CalamityPlayer.throwingCrit += 20;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.25f;
            RedemptionPlayer.druidCrit += 20;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.25f;
            ThoriumPlayer.symphonicCrit += 20;
			ThoriumPlayer.radiantBoost += 0.25f;
            ThoriumPlayer.radiantCrit += 20;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		}
	}