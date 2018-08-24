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
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 4");
			Tooltip.SetDefault("While placed in inventory, you have very high chance not to consume potion"
			+"\nMakes potions to not consume if Supreme Calamitas is defeated");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Тир 4");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет очень большой шанс не потратить зелье\nЗелья не будут тратиться, если побеждена Supreme Calamitas");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 4000000;
			item.rare = 12;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
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
