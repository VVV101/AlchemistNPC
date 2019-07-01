using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class AlchemistCharmTier4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 4");
			Tooltip.SetDefault("While this is in your inventory, you have a very high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 50% discount"
			+"\nMakes potions non-consumable if Supreme Calamitas is defeated");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Четвертого Уровня");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет очень большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 50%\nЗелья не будут тратиться, если побеждена Supreme Calamitas");
			DisplayName.AddTranslation(GameCulture.Chinese, "炼金师符咒 T-4");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置物品栏中时, 极大概率不消耗药剂"
			+"\n'快速增益'键能够使用猪猪储蓄罐中的药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供50%折扣"
			+"如果至尊灾厄已被击败, 不消耗药剂");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 4000000;
			item.rare = 9;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 = true;
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistCharmTier3");
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
