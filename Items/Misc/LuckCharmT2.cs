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
	public class LuckCharmT2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Absolute Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nAlso affects accessories (Menacing->Lucky->Warding)");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Абсолютной Удачи");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nРаботает и с аксессуарами (Грозный->Удачливый->Оберегающий)");
			DisplayName.AddTranslation(GameCulture.Chinese, "绝对幸运符咒");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置于物品栏时, 重铸时有更高概率获得更好的词缀\n能够影响饰品 (险恶->幸运->护佑)");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 2000000;
			item.rare = ItemRarityID.Yellow;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LuckCharm");
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
