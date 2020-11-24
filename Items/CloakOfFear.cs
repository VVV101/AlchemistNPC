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
    public class CloakOfFear : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Cloak of Fear''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Cloak of Fear''"
			+"\nMakes nearby non-boss enemies change their movement direction"
			+"\nExhausts player for 30 seconds after effect ends, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток ''Плащ Страха''");
            Tooltip.AddTranslation(GameCulture.Russian, "Одноразовый предмет\nЭтот свиток содержит заклинание ''Плащ Страха''\nЗаставляет противников вблизи игрока изменять направление движения\nИстощает игрока на 30 секунд после окончания действия, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.Chinese, "卷轴 ''恐惧之袍''");
			Tooltip.AddTranslation(GameCulture.Chinese, "一次性物品"
			+"\n包含着 ''恐惧之袍''法术"
			+"\n使附近的非Boss敌人改变移动方向"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }
		
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item123;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTurn = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Purple;
			item.mana = 200;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("CloakOfFear"), 10800);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(mod.BuffType("Exhausted")) && !player.HasBuff(mod.BuffType("ExecutionersEyes")) && !player.HasBuff(mod.BuffType("CloakOfFear")))
			{
				return true;
			}
			return false;
		}
    }
}
