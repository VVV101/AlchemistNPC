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
    public class MorePotionsCombination : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("MorePotions") != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("More Potions Combination");
			Tooltip.SetDefault("Grants most buffs from More Potions *potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация More Potioins");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода More Potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
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
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("MorePotionsComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("CouragePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DawnPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DuskPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DiamondSkinPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("EnhancedRegenerationPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("GladiatorsPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("RangersDroughtPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SoulbindingElixerPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SpeedPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SummonersDroughtPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SwiftHandsPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("WarriorsDroughtPotion")), 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
