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
     public class CloakOfFear : ModItem
    {
        public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Cloak of Fear''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Cloak of Fear''"
			+"\nMakes non-boss enemies nearby player to change their movement direction"
			+"\nExhausts player for 30 seconds after ending of effect, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток ''Плащ Страха''");
            Tooltip.AddTranslation(GameCulture.Russian, "Одноразовый предмет\nЭтот свиток содержит заклинание ''Плащ Страха''\nЗаставляет изменить направление движения противников вблизи игрока\nИстощает игрока на 30 секунд после окончания действия, не позволяя ему использовать магию");
        }
		
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item123;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = 11;
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
