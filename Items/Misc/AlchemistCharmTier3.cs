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
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 3");
			Tooltip.SetDefault("While placed in inventory, you have high chance not to consume potion");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Тир 3");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет большой шанс не потратить зелье");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 3000000;
			item.rare = 10;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 15);
			recipe.AddRecipeGroup("AlchemistNPC:HardmodeComponent", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
