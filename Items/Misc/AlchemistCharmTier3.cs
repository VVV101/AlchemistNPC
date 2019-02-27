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
	public class AlchemistCharmTier3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 3");
			Tooltip.SetDefault("While this is in your inventory, you have a high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 35% discount");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Третьего Уровня");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 35%");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 3000000;
			item.rare = 7;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 = true;
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistCharmTier2");
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 10);
			recipe.AddRecipeGroup("AlchemistNPC:HardmodeComponent", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
