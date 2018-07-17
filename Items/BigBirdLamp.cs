using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	[AutoloadEquip(EquipType.Waist)]
	public class BigBirdLamp : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Bird's Lamp (O-02-40)");
			Tooltip.SetDefault("A month later we concluded, there was no such thing as the beast."
			+ "\n[c/FF0000:EGO Gift]"
			+"\nProvides light around the character"
			+"\nIncreases all damage and crits for 5%"
			+"\nAttacks destroys enemy armor");
			DisplayName.AddTranslation(GameCulture.Russian, "Лампа Большой Птицы (O-02-40)");
            Tooltip.AddTranslation(GameCulture.Russian, "Месяц спустя мы заключили, что не было никакого Зверя.\nСоздаёт свет вокруг персонажа\nПовышает все виды урона и шанс критической атаки на 5%\nАтаки разрушают броню противника");

            DisplayName.AddTranslation(GameCulture.Chinese, "大鸟灯 (O-02-40)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'一个月后我们得出了结论：那些所谓的怪物根本就不存在.'\n[c/FF0000:EGO 礼物]\n点亮玩家周围\n增加5%全伤害和暴击\n攻击穿透敌人护甲");
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
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CloudinaBottle);
			recipe.AddIngredient(null, "DivineLava", 30);
			recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}