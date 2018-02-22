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
     public class TitanSkinPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Skin Potion");
			Tooltip.SetDefault("Grants immunity to some debuffs (On Fire!, Frostburn, Cursed Flame, Chilled, Frozen, Ichor)"
			+ "\nImmunity to Cursed Flame and Ichor would work only after beating Twins");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Титановой Кожи");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт иммунитет к некоторым серьёзным дебаффам (Горение, Морозный ожог, Проклятое Пламя, Замедление, Заморозка, Ихор)\nИммунитет к Проклятому Пламени или Ихору активируется только после победы над Близнецами"); 
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
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("TitanSkin");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.Shiverthorn, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.AddIngredient(ItemID.CrystalShard, 1);
			recipe.AddIngredient(ItemID.CursedFlame, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.Shiverthorn, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.AddIngredient(ItemID.CrystalShard, 1);
			recipe.AddIngredient(ItemID.Ichor, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
