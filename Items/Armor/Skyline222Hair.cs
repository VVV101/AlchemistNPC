using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Skyline222Hair : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyline222's (Noire) hairstyle");
			DisplayName.AddTranslation(GameCulture.Russian, "Причёска Нуар"); 
			Tooltip.SetDefault("Skyline222's fancy hairstyle");
			Tooltip.AddTranslation(GameCulture.Russian, "Красивая причёска Нуар");
			
		ModTranslation text = mod.CreateTranslation("NoireSetBonus");
		text.SetDefault("Increases current ranged/minion damage by 20% and adds 20% to ranged critical strike chance"
		+ "\n+40 defense"
		+ "\nPrices are lower");
		text.AddTranslation(GameCulture.Russian, "Увеличивает текущий урон в дальнем бою/прислужников на 20% и добаляет 20% к шансу критического удара\n+48 защиты\nЦены в магазинах ниже");
		mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("Skyline222Body") && legs.type == mod.ItemType("Skyline222Legs");
		}

		public override void UpdateArmorSet(Player player)
		{
			string NoireSetBonus = Language.GetTextValue("Mods.AlchemistNPC.NoireSetBonus");
			player.setBonus = NoireSetBonus;
			player.discount = true;
            player.statDefense += 40;
			player.rangedDamage += 0.2f;
            player.minionDamage += 0.2f;
            player.rangedCrit += 20;
		}
	}
}