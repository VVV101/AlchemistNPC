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
    public class CalamityCombination : ModItem
    {
		
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("CalamityMod") != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Tooltip.SetDefault("Grants most buffs from Calamity Mod potions (Yharim's Stimulants, Cadence, Titan Scale, Fabsol's Vodka and Omniscience)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Calamity");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода Calamity (Yharim's Stimulants, Cadence, Titan Scale, Fabsol's Vodka and Omniscience)"); 
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
            item.height = 36;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.buffType = ModLoader.GetMod("CalamityMod").BuffType("YharimPower");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override bool UseItem(Player player)
		{
				player.AddBuff((ModLoader.GetMod("CalamityMod").BuffType("Cadence")), 52000, true);
				player.AddBuff((ModLoader.GetMod("CalamityMod").BuffType("TitanScale")), 52000, true);
				player.AddBuff((ModLoader.GetMod("CalamityMod").BuffType("FabsolVodka")), 52000, true);
				player.AddBuff((ModLoader.GetMod("CalamityMod").BuffType("Omniscience")), 52000, true);
				return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("PotionofOmniscience")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("YharimsStimulants")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FabsolsVodka")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CadencePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("TitanScalePotion")), 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
