using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC.Interface;

namespace AlchemistNPC.Items.Misc
{
	public class DimensionalCasket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Casket");
			Tooltip.SetDefault("Modified Dimensional Casket"
			+"\nAllows to trade with any NPC from any distance"
			+"\nClick to open UI"
			+"\nPress ESC to stop dialing");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортирующая Шкатулка");
            Tooltip.AddTranslation(GameCulture.Russian, "Модифицированная межизмеренческая шкатулка\nПозволяет торговать с любым NPC с любого расстояния\nКлик для открытия интерфейса\nНажмите ESC для прекращения связи");
			DisplayName.AddTranslation(GameCulture.Chinese, "次元匣");
			Tooltip.AddTranslation(GameCulture.Chinese, "修好的次元匣\n允许无视距离与NPC交易\n点击打开UI\n按ESC键关闭");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 5000000;
			item.rare = 10;
			item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = false;
			item.expert = true;
		}
		
		public override bool UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				DimensionalCasketUI.visible = true;
			}
			return true;
		}
		
		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			if (Main.myPlayer == player.whoAmI)
			{
				DimensionalCasketUI.visible = true;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenDimensionalCasket"));
			recipe.AddIngredient(mod.ItemType("DivineLava"), 15);
			recipe.AddRecipeGroup("AlchemistNPC:Tier3Bar", 10);
			recipe.AddIngredient(ItemID.MechanicalBatteryPiece);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
