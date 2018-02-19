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
		}
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 50000;
			item.rare = 6;
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