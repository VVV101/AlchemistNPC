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
	public class AlchemistCharmTier2 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 2");
			Tooltip.SetDefault("While placed in inventory, you have moderate chance not to consume potion");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Тир 2");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет средний шанс не потратить зелье");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 2000000;
			item.rare = 8;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 = true;
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
