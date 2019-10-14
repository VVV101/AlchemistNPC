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
	public class Extractor : ModItem
	{
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extractor");
			Tooltip.SetDefault("Allows to extract Soul Essences and Hate Vials from bosses"
			+"\nWould work if placed in inventory"
			+"\nCan extract essence with 1/3 chance if boss has more than 50K HP"
			+"\nCan extract Hate with 1/10 chance if boss has more than 55K HP");
			DisplayName.AddTranslation(GameCulture.Russian, "Экстрактор");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет извлекать эссенцию души из боссов\nБудет работать, если находится в инвентаре\nМожет извлечь эссенцию души с вероятностью 1/3, если у босса >= 50K HP\nМожет извлечь Ненависть с вероятностью 1/10, если у босса >= 55K HP");

            DisplayName.AddTranslation(GameCulture.Chinese, "抽取器");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许你从Boss中抽取灵魂精华和仇恨\n放置在背包中就会工作\n如果Boss血量多于5万, 将有三分之一的几率抽取灵魂精华\n如果Boss血量多于5.5万, 将有十分之一的几率抽取仇恨");
        }

		public override void SetDefaults()
		{
			item.width = 56;
			item.height = 56;
			item.value = 100000;
			item.rare = 11;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Extractor = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
