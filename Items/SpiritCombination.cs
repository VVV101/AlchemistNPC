using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
    public class SpiritCombination : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("SpiritMod") != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Combination");
			Tooltip.SetDefault("Grants most buffs from Spirit Mod potions (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Spirit");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода Spirit (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");

            DisplayName.AddTranslation(GameCulture.Chinese, "魂灵药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得大部分魂灵Buff (符文之力, 灵魂之护, 魂灵, 星之燃烧, 坚定和毒素)");
		}    

		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.buffType = ModLoader.GetMod("SpiritMod").BuffType("SpiritBuff");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override bool UseItem(Player player)
		{
				player.AddBuff((ModLoader.GetMod("SpiritMod").BuffType("RunePotionBuff")), 52000, true);
				player.AddBuff((ModLoader.GetMod("SpiritMod").BuffType("SoulPotionBuff")), 52000, true);
				player.AddBuff((ModLoader.GetMod("SpiritMod").BuffType("StarPotionBuff")), 52000, true);
				player.AddBuff((ModLoader.GetMod("SpiritMod").BuffType("TurtlePotionBuff")), 52000, true);
				player.AddBuff((ModLoader.GetMod("SpiritMod").BuffType("BismitePotionBuff")), 52000, true);
				return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("BismitePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("RunePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SoulPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SpiritPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("StarPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("TurtlePotion")), 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
