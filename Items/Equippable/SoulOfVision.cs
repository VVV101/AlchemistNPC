using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SoulOfVision : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Vision");
			Tooltip.SetDefault("''I can see everything!''"
				+ "\nFree ores, treasures, creatures and traps vision");
				DisplayName.AddTranslation(GameCulture.Russian, "Душа Видения");
            Tooltip.AddTranslation(GameCulture.Russian, "''Я вижу всё''\nСвободное видение сокровищ, руд, существ и ловушек");
            DisplayName.AddTranslation(GameCulture.Chinese, "全视之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, "''我无所不见!''\n高亮矿物, 宝物, 生物和陷阱");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 15));
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 30;
			item.height = 18;
			item.value = 100000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofSight, 99);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}