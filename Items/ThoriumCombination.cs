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
    public class ThoriumCombination : ModItem
    {
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("ThoriumMod") != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorium Combination");
			Tooltip.SetDefault("Grants most buffs from Thorium Mod potions"
			+"\nAssassin, Blood, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Thorium");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода Thorium\nAssassin, Blood, Combat, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");

            DisplayName.AddTranslation(GameCulture.Chinese, "瑟银捆绑包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得瑟银的大部分药水Buff" +
                "\n嗜血, 精准, 狂热, 狂怒, 创造力, 耳虫, 灵感爆发, 光辉, 圣洁");
		}    

		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = ItemUseStyleID.EatingUsing;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.buffType = mod.BuffType("ThoriumComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AssassinPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("BloodPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FrenzyPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("CreativityPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("EarwormPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InspirationReachPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GlowingPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HolyPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HydrationPotion")), 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
