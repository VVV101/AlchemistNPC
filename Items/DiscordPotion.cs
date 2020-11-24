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
     public class DiscordPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discord Potion");
			Tooltip.SetDefault("Allows to teleport on cursor position by hotkey"
			+"\nDistorts player for 1 second after teleport"
			+"\nInflicts heavy damage while you have Chaos State"
			+"\nChaos State time is increased to 10 seconds");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Раздора");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет телепортироваться на курсор при нажатии горячей клавиши\nНарушает гравитацию игрока на 1 секунду после использования\nНаносит значительные повреждения, если вы в Хаотическом состоянии\nДлительность дебаффа увеличена до 10 секунд");

            DisplayName.AddTranslation(GameCulture.Chinese, "混乱药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许使用快捷键传送到鼠标位置"
            + "\n传送后扭曲玩家一秒钟"
            + "\n混乱状态时使用会受到巨大的伤害"
            + "\n混乱状态延长至10秒");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = ItemUseStyleID.EatingUsing;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.buffType = mod.BuffType("DiscordBuff");           //this is where you put your Buff
            item.buffTime = 18000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
