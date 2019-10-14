using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class AlchemistCharmTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 2");
			Tooltip.SetDefault("While this is in your inventory, you have a moderate chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 25% discount");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Второго Уровня");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет средний шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 25%");
			DisplayName.AddTranslation(GameCulture.Chinese, "炼金师符咒 T-2");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置物品栏中时, 概率不消耗药剂"
			+"\n'快速增益'键能够使用猪猪储蓄罐中的药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供25%折扣");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 2000000;
			item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 = true;
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistCharmTier1");
			recipe.AddRecipeGroup("AlchemistNPC:EvilBar", 15);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
