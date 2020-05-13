using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			Tooltip.SetDefault("Grants most buffs from Calamity Mod potions (Yharim's Stimulants, Cadence, Titan Scale, Soaring, Bounding and Fabsol's Vodka)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Calamity");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода Calamity (Стимулянты Ярима, Каденции, Титановой Чешуи, Полёта, Связующее и Водки Фабсола)");

            DisplayName.AddTranslation(GameCulture.Chinese, "灾厄药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "给予大部分灾厄药剂的增益效果 (魔君牌兴奋剂, 尾音, 腾飞，泰坦之鳞, Fabsol伏特加)");
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
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 10;
            item.buffType = item.buffType = mod.BuffType("CalamityComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("YharimsStimulants")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FabsolsVodka")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CadencePotion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("TitanScalePotion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SoaringPotion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BoundingPotion")), 1);
			}
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
