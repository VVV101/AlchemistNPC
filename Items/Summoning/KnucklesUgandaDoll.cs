using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.Items.Summoning
{
    public class KnucklesUgandaDoll : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("National Ugandan Treasure");
			Tooltip.SetDefault("''I'm 100% sure this will kill you'' - Gregg"
			+"\nUsing this may cause disasterous consequences..."
			+"\nBut the reward can retribute all your sufferings");
			DisplayName.AddTranslation(GameCulture.Russian, "Национальное сокровище Уганды");
            Tooltip.AddTranslation(GameCulture.Russian, "''Я на 100 процентов уверен, что это тебя убьёт'' - Gregg\nПрименение этого может вызвать нехорошие последствия...\nНо награда способна возместить все ваши страдания");

            DisplayName.AddTranslation(GameCulture.Chinese, "乌干达国宝");
            Tooltip.AddTranslation(GameCulture.Chinese, "我100%确定这可以杀掉你 - 格雷格");
        }    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RecallPotion);
            item.maxStack = 99;
            item.consumable = false;
			item.scale = 0.5f;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Knuckles"));
			return true;
		}
    }
}
