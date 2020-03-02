using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PaperTube2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube (T2)");
			Tooltip.SetDefault("Contains blueprints of a random hardmode/post Skeletron accessory\nUse to unlock");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус (2)");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного хардмодного/пост-Скелетронового аксессуара\nИспользуйте для разблокировки");
			DisplayName.AddTranslation(GameCulture.Chinese, "蓝图纸管 (T-2)");
			Tooltip.AddTranslation(GameCulture.Chinese, "包含一项随机困难模式/骷髅王后饰品的蓝图\n使用以解锁");

			ModTranslation text = mod.CreateTranslation("PaperTubeT2Info1");
            text.SetDefault("You need to defeat any mechanical boss to unlock 2 leftover early hardmode accessories.");
            text.AddTranslation(GameCulture.Chinese, "你需要打败任何的机械三王之一以解锁剩下两个困难模式(肉山后)前期的饰品.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("PaperTubeT2Info2");
            text.SetDefault("There was nothing interesting in those blueprints.");
            text.AddTranslation(GameCulture.Chinese, "这些蓝图没什么意思.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("PaperTubeT2Info3");
            text.SetDefault("You have found a new accessory blueprint. You can ask Tinkerer about making it now.");
            text.AddTranslation(GameCulture.Chinese, "你发现了一个新的饰品蓝图. 你可以现在问问工匠这东西能干什么.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("PaperTubeT2Info4");
            text.SetDefault("You have found all early hardmode blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.");
            text.AddTranslation(GameCulture.Chinese, "你已经找到了所有血肉之墙后前期的蓝图. 恭喜! 你可以把剩下的蓝图都兜售给工匠.");
            mod.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 100000;
			item.rare = 6;
			item.maxStack = 99;
			item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
			item.UseSound = SoundID.Item37;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCWorld.foundT2)
			{
				return false;
			}
			return true;
		}
		
		public override bool UseItem(Player player)
        {
			var randomAcc = new List<string>();
								
			if (!AlchemistNPCWorld.foundPStone) {
			randomAcc.Add("foundPStone");}
			if (!AlchemistNPCWorld.foundGoldRing) {
			randomAcc.Add("foundGoldRing");}
			if (!AlchemistNPCWorld.foundLuckyCoin) {
			randomAcc.Add("foundLuckyCoin");}
			if (!AlchemistNPCWorld.foundDiscountCard) {
			randomAcc.Add("foundDiscountCard");}
			if (NPC.downedMechBossAny)
			{
				if (!AlchemistNPCWorld.foundNeptuneShell) {
				randomAcc.Add("foundNeptuneShell");}
			}
			if (!AlchemistNPCWorld.foundYoyoGlove) {
			randomAcc.Add("foundYoyoGlove");}
			if (!AlchemistNPCWorld.foundBlindfold) {
			randomAcc.Add("foundBlindfold");}
			if (!AlchemistNPCWorld.foundArmorPolish) {
			randomAcc.Add("foundArmorPolish");}
			if (!AlchemistNPCWorld.foundVitamins) {
			randomAcc.Add("foundVitamins");}
			if (!AlchemistNPCWorld.foundBezoar) {
			randomAcc.Add("foundBezoar");}
			if (!AlchemistNPCWorld.foundAdhesiveBandage) {
			randomAcc.Add("foundAdhesiveBandage");}
			if (!AlchemistNPCWorld.foundFastClock) {
			randomAcc.Add("foundFastClock");}
			if (!AlchemistNPCWorld.foundTrifoldMap) {
			randomAcc.Add("foundTrifoldMap");}
			if (!AlchemistNPCWorld.foundMegaphone) {
			randomAcc.Add("foundMegaphone");}
			if (!AlchemistNPCWorld.foundNazar) {
			randomAcc.Add("foundNazar");}
			if (!AlchemistNPCWorld.foundSorcE) {
			randomAcc.Add("foundSorcE");}
			if (!AlchemistNPCWorld.foundWE) {
			randomAcc.Add("foundWE");}
			if (!AlchemistNPCWorld.foundRE) {
			randomAcc.Add("foundRE");}
			if (!AlchemistNPCWorld.foundSumE) {
			randomAcc.Add("foundSumE");}
			if (!AlchemistNPCWorld.foundTitanGlove) {
			randomAcc.Add("foundTitanGlove");}
			if (!AlchemistNPCWorld.foundMoonCharm) {
			randomAcc.Add("foundMoonCharm");}
			if (!AlchemistNPCWorld.foundFrozenTurtleShell) {
			randomAcc.Add("foundFrozenTurtleShell");}
			if (NPC.downedMechBossAny)
			{
				if (!AlchemistNPCWorld.foundMoonStone) {
				randomAcc.Add("foundMoonStone");}
			}
			if (!AlchemistNPCWorld.foundPutridScent) {
			randomAcc.Add("foundPutridScent");}
			if (!AlchemistNPCWorld.foundFleshKnuckles) {
			randomAcc.Add("foundFleshKnuckles");}
			if (!AlchemistNPCWorld.foundMagicQuiver) {
			randomAcc.Add("foundMagicQuiver");}
			if (!AlchemistNPCWorld.foundCobaltShield) {
			randomAcc.Add("foundCobaltShield");}
			if (!AlchemistNPCWorld.foundCrossNecklace) {
			randomAcc.Add("foundCrossNecklace");}
			if (!AlchemistNPCWorld.foundStarCloak) {
			randomAcc.Add("foundStarCloak");}
			if (randomAcc.Count == 0 && !NPC.downedMechBossAny)
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.PaperTubeT2Info1"), 100,149,237);
				return true;
			}
			if (Main.rand.NextBool(5))
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.PaperTubeT2Info2"), 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.PaperTubeT2Info3"), 255, 255, 255);
			
			if (randomAcc[acc] == "foundPStone") {
			AlchemistNPCWorld.foundPStone = true;}
			if (randomAcc[acc] == "foundGoldRing") {
			AlchemistNPCWorld.foundGoldRing = true;}
			if (randomAcc[acc] == "foundLuckyCoin") {
			AlchemistNPCWorld.foundLuckyCoin = true;}
			if (randomAcc[acc] == "foundDiscountCard") {
			AlchemistNPCWorld.foundDiscountCard = true;}
			if (randomAcc[acc] == "foundNeptuneShell") {
			AlchemistNPCWorld.foundNeptuneShell = true;}
			if (randomAcc[acc] == "foundYoyoGlove") {
			AlchemistNPCWorld.foundYoyoGlove = true;}
			if (randomAcc[acc] == "foundBlindfold") {
			AlchemistNPCWorld.foundBlindfold = true;}
			if (randomAcc[acc] == "foundArmorPolish") {
			AlchemistNPCWorld.foundArmorPolish = true;}
			if (randomAcc[acc] == "foundVitamins") {
			AlchemistNPCWorld.foundVitamins = true;}
			if (randomAcc[acc] == "foundBezoar") {
			AlchemistNPCWorld.foundBezoar = true;}
			if (randomAcc[acc] == "foundAdhesiveBandage") {
			AlchemistNPCWorld.foundAdhesiveBandage = true;}
			if (randomAcc[acc] == "foundFastClock") {
			AlchemistNPCWorld.foundFastClock = true;}
			if (randomAcc[acc] == "foundTrifoldMap") {
			AlchemistNPCWorld.foundTrifoldMap = true;}
			if (randomAcc[acc] == "foundMegaphone") {
			AlchemistNPCWorld.foundMegaphone = true;}
			if (randomAcc[acc] == "foundNazar") {
			AlchemistNPCWorld.foundNazar = true;}
			if (randomAcc[acc] == "foundSorcE") {
			AlchemistNPCWorld.foundSorcE = true;}
			if (randomAcc[acc] == "foundWE") {
			AlchemistNPCWorld.foundWE = true;}
			if (randomAcc[acc] == "foundRE") {
			AlchemistNPCWorld.foundRE = true;}
			if (randomAcc[acc] == "foundSumE") {
			AlchemistNPCWorld.foundSumE = true;}
			if (randomAcc[acc] == "foundTitanGlove") {
			AlchemistNPCWorld.foundTitanGlove = true;}
			if (randomAcc[acc] == "foundMoonCharm") {
			AlchemistNPCWorld.foundMoonCharm = true;}
			if (randomAcc[acc] == "foundMoonStone") {
			AlchemistNPCWorld.foundMoonStone = true;}
			if (randomAcc[acc] == "foundFrozenTurtleShell") {
			AlchemistNPCWorld.foundFrozenTurtleShell = true;}
			if (randomAcc[acc] == "foundPutridScent") {
			AlchemistNPCWorld.foundPutridScent = true;}
			if (randomAcc[acc] == "foundFleshKnuckles") {
			AlchemistNPCWorld.foundFleshKnuckles = true;}
			if (randomAcc[acc] == "foundMagicQuiver") {
			AlchemistNPCWorld.foundMagicQuiver = true;}
			if (randomAcc[acc] == "foundCobaltShield") {
			AlchemistNPCWorld.foundCobaltShield = true;}
			if (randomAcc[acc] == "foundCrossNecklace") {
			AlchemistNPCWorld.foundCrossNecklace = true;}
			if (randomAcc[acc] == "foundStarCloak") {
			AlchemistNPCWorld.foundStarCloak = true;}
			if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			
			if (randomAcc.Count == 1 && NPC.downedMechBossAny)
			{
				Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.PaperTubeT2Info4"), 0, 255, 0);
				AlchemistNPCWorld.foundT2 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
			return true;
		}
	}
}
