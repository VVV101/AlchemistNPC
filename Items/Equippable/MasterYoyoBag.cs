using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class MasterYoyoBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Yoyo Bag");
			Tooltip.SetDefault("Increases melee damage and melee speed by 15%"
			+"\nGives effects of Fire Gauntlet, Yoyo Glove and Counterweight"
			+"\nGreatly increases max range of any yoyo");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумка Мастера Йо-йо");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон и скорость атаки в ближнем бою на 15%\nДаёт эффекты Огненной Рукавицы, Перчатки Йо-йо и Противовеса\nЗначительно увеличивает максимальную дальность любого йо-йо");
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
			player.GetModPlayer<AlchemistNPCPlayer>().MasterYoyoBag = true;
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
            player.meleeDamage += 0.15f;
			if (player.HeldItem.channel && player.HeldItem.shootSpeed < 16f) player.meleeSpeed += 0.75f;
			else if (player.HeldItem.channel && player.HeldItem.shootSpeed >= 16f) player.meleeSpeed += 0.3f;
			else player.meleeSpeed += 0.15f;
			player.kbGlove = true;
			player.magmaStone = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.YoyoBag);
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}