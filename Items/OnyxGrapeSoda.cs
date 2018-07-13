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
    public class OnyxGrapeSoda : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Grape Soda");
			Tooltip.SetDefault("Returns you home and gives you 75% endurance for 5 seconds."
			+ "\nHas a 30 seconds cooldown, applies Chaos State debuff");
			DisplayName.AddTranslation(GameCulture.Russian, "Сода Ониксового Винограда");
			Tooltip.AddTranslation(GameCulture.Russian, "Возвращает вас домой и даёт бафф на 75% поглощения урона на 5 секунд.\nИмеет 30-ти секундный откат, накладывает дебафф Хаос"); 
		}    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RecallPotion);
            item.maxStack = 99;
			item.value = 0;
            item.consumable = true;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			player.Spawn();
			player.AddBuff(BuffID.ChaosState, 1800);
			player.AddBuff(mod.BuffType("OnyxSoda"), 300);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(mod.BuffType("OnyxSoda")) == false && player.HasBuff(BuffID.ChaosState) == false);
		}
    }
}
