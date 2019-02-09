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
     public class NatureBlessingPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature Blessing Potion");
			Tooltip.SetDefault("Grants Dryad's Blessing buff");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Благословления Природы");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт бафф Благословления Дриады");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 2;
            item.buffType = 165;
            item.buffTime = 36000;
            return;
        }
    }
}
