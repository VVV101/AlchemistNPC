using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PaperTube3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube (T3)");
			Tooltip.SetDefault("Contains blueprints of a random post Plantera accessory\nUse to unlock");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус (3)");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного Пост-Плантерного аксессуара\nИспользуйте для разблокировки");
			DisplayName.AddTranslation(GameCulture.Chinese, "纸管 (T-3)");
			Tooltip.AddTranslation(GameCulture.Chinese, "包含一项随机世纪之花后饰品的蓝图\n使用以解锁");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 200000;
			item.rare = 8;
			item.maxStack = 99;
			item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
			item.UseSound = SoundID.Item37;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCWorld.foundT3)
			{
				return false;
			}
			return true;
		}
		
		public override bool UseItem(Player player)
        {
			if (AlchemistNPCWorld.foundT3)
			{
				return false;
			}
			var randomAcc = new List<string>();
								
			if (!AlchemistNPCWorld.foundTabi) {
			randomAcc.Add("foundTabi");}
			if (!AlchemistNPCWorld.foundBlackBelt) {
			randomAcc.Add("foundBlackBelt");}
			if (!AlchemistNPCWorld.foundRifleScope) {
			randomAcc.Add("foundRifleScope");}
			if (!AlchemistNPCWorld.foundPaladinShield) {
			randomAcc.Add("foundPaladinShield");}
			if (!AlchemistNPCWorld.foundNecromanticScroll) {
			randomAcc.Add("foundNecromanticScroll");}
			if (NPC.downedGolemBoss)
			{
				if (!AlchemistNPCWorld.foundSunStone) {
				randomAcc.Add("foundSunStone");}
			}
			if (!AlchemistNPCWorld.foundHerculesBeetle) {
			randomAcc.Add("foundHerculesBeetle");}
			if (!AlchemistNPCWorld.foundPygmyNecklace) {
			randomAcc.Add("foundPygmyNecklace");}
			if (randomAcc.Count == 0 && !NPC.downedGolemBoss)
			{
				Main.NewText("You need to defeat Golem to unlock leftover post Plantera accessory.", 100,149,237);
				return true;
			}
			if (Main.rand.NextBool(5))
			{
				Main.NewText("There was nothing interesting in those blueprints.", 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText("You have found a new accessory blueprint. You can ask Tinkerer about making it now.", 255, 255, 255);
			
			if (randomAcc[acc] == "foundTabi") {
			AlchemistNPCWorld.foundTabi = true;}
			if (randomAcc[acc] == "foundBlackBelt") {
			AlchemistNPCWorld.foundBlackBelt = true;}
			if (randomAcc[acc] == "foundRifleScope") {
			AlchemistNPCWorld.foundRifleScope = true;}
			if (randomAcc[acc] == "foundPaladinShield") {
			AlchemistNPCWorld.foundPaladinShield = true;}
			if (randomAcc[acc] == "foundNecromanticScroll") {
			AlchemistNPCWorld.foundNecromanticScroll = true;}
			if (randomAcc[acc] == "foundSunStone") {
			AlchemistNPCWorld.foundSunStone = true;}
			if (randomAcc[acc] == "foundHerculesBeetle") {
			AlchemistNPCWorld.foundHerculesBeetle = true;}
			if (randomAcc[acc] == "foundPygmyNecklace") {
			AlchemistNPCWorld.foundPygmyNecklace = true;}
			
			if (randomAcc.Count == 1 && NPC.downedGolemBoss)
			{
				Main.NewText("You have found all post Plantera blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.", 0, 255, 0);
				Main.NewText("Talk to Tinkerer when you will defeat Moon Lord and unlock all accessories.", 0, 255, 0);
				AlchemistNPCWorld.foundT3 = true;
			}
			return true;
		}
	}
}
