using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Blinker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blinker");
			Tooltip.SetDefault("Gives you dash in the form of instant teleport for short distance\nGives a chance to dodge attacks and allows the ability to climb walls");
			DisplayName.AddTranslation(GameCulture.Russian, "Блинкер");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт вам рывок в форме мгновенного телепорта на небольшое расстояние\nДаёт шанс увернуться от атаки и позволяет цепляться за стены");
        
			DisplayName.AddTranslation(GameCulture.Chinese, "闪位大师装备");
            Tooltip.AddTranslation(GameCulture.Chinese, "让你的短距离冲刺变成传送\n有机会躲避攻击并能在墙壁攀爬");
		}
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Blinker = true;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.RodofDiscord);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}