using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SoulOfPower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Power");
			Tooltip.SetDefault("''No one can stop me now!''"
				+ "\nIncreases all damages by 15%"
				+ "\nReduces damage reduction by 10%");
				DisplayName.AddTranslation(GameCulture.Russian, "Душа Мощи");
            Tooltip.AddTranslation(GameCulture.Russian, "''Никто меня теперь не остановит!''\nУвеличивает урон всех типов на 15%\nСнижает сопротивление к урону на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "伟力之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, "''我无人可挡!''\n增加15%所有伤害");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 27;
			item.height = 28;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 0.1f;
			player.allDamage += 0.15f;
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 99);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}