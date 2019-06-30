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
    public class ExecutionersEyes : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Executioner's Eyes''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Executioner's Eyes''"
			+"\nWhile used, you are getting your damage multiplied by 15% for 1 minute"
			+"\nAlso increases critical strike chance by 5%"
			+"\nGives you 5% chance to crit your crit, dealing 4x damage"
			+"\nExhausts player for 1 minute after ending of effect, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток ''Глаза Палача''");
            Tooltip.AddTranslation(GameCulture.Russian, "Одноразовый предмет\nЭтот свиток содержит заклинание ''Глаза Палача''\nКогда применён, повышает урон игрока на 15%, увеличивает шанс крита на 5%\nТакже позволяет вашим критам критовать с 5% шансом, нанося вдвое больше урона\nИстощает игрока на 1 минуту после окончания действия, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.Chinese, "卷轴 ''行刑者之眼''");
			Tooltip.AddTranslation(GameCulture.Chinese, "一次性物品"
			+"\n包含着 ''行刑者之眼''法术"
			+"\n使用时, 1分钟内伤害增加15%"
			+"\n同样增加5%暴击率"
			+"\n暴击有5%概率再次暴击, 造成4倍伤害"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }
		
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item123;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = 11;
			item.mana = 200;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("ExecutionersEyes"), 3600);
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
