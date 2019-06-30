using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Waist)]
	public class BigBirdLamp : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Bird's Lamp (O-02-40)");
			Tooltip.SetDefault("A month later we concluded, there was no such thing as the beast."
			+ "\n[c/FF0000:EGO Gift]"
			+"\nProvides light around the character"
			+"\nIncreases all damages and critical strike chances by 5%"
			+"\nAttacks remove most of the enemy defense");
			DisplayName.AddTranslation(GameCulture.Russian, "Лампа Большой Птицы (O-02-40)");
            Tooltip.AddTranslation(GameCulture.Russian, "Месяц спустя мы заключили, что не было никакого Зверя.\nСоздаёт свет вокруг персонажа\nПовышает все виды урона и шанс критической атаки на 5%\nАтаки разрушают броню противника");

            DisplayName.AddTranslation(GameCulture.Chinese, "大鸟灯 (O-02-40)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'一个月后我们得出了结论：那些所谓的怪物根本就不存在.'\n[c/FF0000:EGO 礼物]\n点亮玩家周围\n增加5%全伤害和暴击\n攻击移除敌人大部分护甲");
        }
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BigBirdLamp"), 60);
			player.thrownDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
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
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.05f;
            CalamityPlayer.throwingCrit += 5;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.05f;
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.05f;
            ThoriumPlayer.symphonicCrit += 5;
			ThoriumPlayer.radiantBoost += 0.05f;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CloudinaBottle);
			recipe.AddIngredient(null, "DivineLava", 30);
			recipe.AddIngredient(ItemID.PutridScent);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddIngredient(ItemID.SoulofSight, 25);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}