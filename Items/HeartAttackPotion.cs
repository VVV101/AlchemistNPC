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
    public class HeartAttackPotion : ModItem
    {
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Darkness");
			Tooltip.SetDefault("Fills Rage meter and causes Heart Attack"
			+"\nInflicts Heart Ache debuff for 5 minutes"
			+"\nNON-CALAMITY POTION");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Тьмы");
            Tooltip.AddTranslation(GameCulture.Russian, "Заполняет счётчик Ярости и вызывает Сердечный Приступ\nВызывает Сердечную Боль на на 5 минут\nЗЕЛЬЕ НЕ ИЗ КАЛАМИТИ МОДА");
			DisplayName.AddTranslation(GameCulture.Chinese, "黑暗药剂");
			Tooltip.AddTranslation(GameCulture.Chinese, "装填愤怒槽, 造成心脏衰竭"
			+"\n获得5分钟的心脏衰竭效果"
			+"\n非灾厄药剂");
        }    

		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("HeartAche");
            item.buffTime = 18000;
        }
		
		public bool CalamityModRevengeance
		{
			get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		public override bool CanUseItem(Player player)
		{
			if (CalamityModRevengeance && !player.HasBuff(mod.BuffType("HeartAche")))
			{
				return true;
			}
			return false;
		}
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		public override bool UseItem(Player player)
		{
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>(Calamity);
			CalamityPlayer.stress = 10000;
			player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("HeartAttack"), 18000, true);
			return true;
		}
    }
}
