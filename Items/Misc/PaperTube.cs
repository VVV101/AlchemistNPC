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
	public class PaperTube : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube");
			Tooltip.SetDefault("Contains blueprints of a random prehardmode accessory\nUse to unlock");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного прехардмодного аксессуара\nИспользуйте для разблокировки");
			DisplayName.AddTranslation(GameCulture.Chinese, "纸管");
			Tooltip.AddTranslation(GameCulture.Chinese, "包含一项随机饰品的蓝图\n使用以解锁");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 50000;
			item.rare = 4;
			item.maxStack = 99;
			item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
			item.UseSound = SoundID.Item37;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCWorld.foundT1)
			{
				return false;
			}
			return true;
		}
		
		public override bool UseItem(Player player)
        {
            var randomAcc = new List<string>();
								
			if (!AlchemistNPCWorld.foundAglet) {
			randomAcc.Add("foundAglet");}
			if (!AlchemistNPCWorld.foundClimbingClaws) {
			randomAcc.Add("foundClimbingClaws");}
			if (!AlchemistNPCWorld.foundShoeSpikes) {
			randomAcc.Add("foundShoeSpikes");}
			if (!AlchemistNPCWorld.foundAnklet) {
			randomAcc.Add("foundAnklet");}
			if (!AlchemistNPCWorld.foundBalloon) {
			randomAcc.Add("foundBalloon");}
			if (!AlchemistNPCWorld.foundHermesBoots) {
			randomAcc.Add("foundHermesBoots");}
			if (!AlchemistNPCWorld.foundFlippers) {
			randomAcc.Add("foundFlippers");}
			if (!AlchemistNPCWorld.foundFrogLeg) {
			randomAcc.Add("foundFrogLeg");}
			if (!AlchemistNPCWorld.foundCloud) {
			randomAcc.Add("foundCloud");}
			if (!AlchemistNPCWorld.foundBlizzard) {
			randomAcc.Add("foundBlizzard");}
			if (!AlchemistNPCWorld.foundSandstorm) {
			randomAcc.Add("foundSandstorm");}
			if (!AlchemistNPCWorld.foundPuffer) {
			randomAcc.Add("foundPuffer");}
			if (!AlchemistNPCWorld.foundTsunami) {
			randomAcc.Add("foundTsunami");}
			if (!AlchemistNPCWorld.foundWWB) {
			randomAcc.Add("foundWWB");}
			if (!AlchemistNPCWorld.foundIceSkates) {
			randomAcc.Add("foundIceSkates");}
			if (!AlchemistNPCWorld.foundLavaCharm) {
			randomAcc.Add("foundLavaCharm");}
			if (!AlchemistNPCWorld.foundHorseshoe) {
			randomAcc.Add("foundHorseshoe");}
			if (!AlchemistNPCWorld.foundCMagnet) {
			randomAcc.Add("foundCMagnet");}
			if (!AlchemistNPCWorld.foundHTFL) {
			randomAcc.Add("foundHTFL");}
			if (!AlchemistNPCWorld.foundAnglerEarring) {
			randomAcc.Add("foundAnglerEarring");}
			if (!AlchemistNPCWorld.foundTackleBox) {
			randomAcc.Add("foundTackleBox");}
			if (!AlchemistNPCWorld.foundJFNeck) {
			randomAcc.Add("foundJFNeck");}
			if (!AlchemistNPCWorld.foundFlowerBoots) {
			randomAcc.Add("foundFlowerBoots");}
			if (!AlchemistNPCWorld.foundString) {
			randomAcc.Add("foundString");}
			if (!AlchemistNPCWorld.foundGreenCW) {
			randomAcc.Add("foundGreenCW");}
			if (!AlchemistNPCWorld.foundFeralClaw) {
			randomAcc.Add("foundFeralClaw");}
			if (!AlchemistNPCWorld.foundMagmaStone) {
			randomAcc.Add("foundMagmaStone");}
			if (!AlchemistNPCWorld.foundSharkTooth) {
			randomAcc.Add("foundSharkTooth");}
			if (!AlchemistNPCWorld.foundPanicNecklace) {
			randomAcc.Add("foundPanicNecklace");}
			if (!AlchemistNPCWorld.foundObsidianRose) {
			randomAcc.Add("foundObsidianRose");}
			if (!AlchemistNPCWorld.foundShackle) {
			randomAcc.Add("foundShackle");}
			if (Main.rand.NextBool(5))
			{
				Main.NewText("There was nothing interesting in those blueprints.", 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText("You have found a new accessory blueprint. You can ask Tinkerer about making it now.", 255, 255, 255);
			
			if (randomAcc[acc] == "foundAglet") {
			AlchemistNPCWorld.foundAglet = true;}
			if (randomAcc[acc] == "foundClimbingClaws") {
			AlchemistNPCWorld.foundClimbingClaws = true;}
			if (randomAcc[acc] == "foundShoeSpikes") {
			AlchemistNPCWorld.foundShoeSpikes = true;}
			if (randomAcc[acc] == "foundAnklet") {
			AlchemistNPCWorld.foundAnklet = true;}
			if (randomAcc[acc] == "foundBalloon") {
			AlchemistNPCWorld.foundBalloon = true;}
			if (randomAcc[acc] == "foundHermesBoots") {
			AlchemistNPCWorld.foundHermesBoots = true;}
			if (randomAcc[acc] == "foundFlippers") {
			AlchemistNPCWorld.foundFlippers = true;}
			if (randomAcc[acc] == "foundFrogLeg") {
			AlchemistNPCWorld.foundFrogLeg = true;}
			if (randomAcc[acc] == "foundCloud") {
			AlchemistNPCWorld.foundCloud = true;}
			if (randomAcc[acc] == "foundBlizzard") {
			AlchemistNPCWorld.foundBlizzard = true;}
			if (randomAcc[acc] == "foundSandstorm") {
			AlchemistNPCWorld.foundSandstorm = true;}
			if (randomAcc[acc] == "foundPuffer") {
			AlchemistNPCWorld.foundPuffer = true;}
			if (randomAcc[acc] == "foundTsunami") {
			AlchemistNPCWorld.foundTsunami = true;}
			if (randomAcc[acc] == "foundWWB") {
			AlchemistNPCWorld.foundWWB = true;}
			if (randomAcc[acc] == "foundIceSkates") {
			AlchemistNPCWorld.foundIceSkates = true;}
			if (randomAcc[acc] == "foundLavaCharm") {
			AlchemistNPCWorld.foundLavaCharm = true;}
			if (randomAcc[acc] == "foundHorseshoe") {
			AlchemistNPCWorld.foundHorseshoe = true;}
			if (randomAcc[acc] == "foundCMagnet") {
			AlchemistNPCWorld.foundCMagnet = true;}
			if (randomAcc[acc] == "foundHTFL") {
			AlchemistNPCWorld.foundHTFL = true;}
			if (randomAcc[acc] == "foundAnglerEarring") {
			AlchemistNPCWorld.foundAnglerEarring = true;}
			if (randomAcc[acc] == "foundTackleBox") {
			AlchemistNPCWorld.foundTackleBox = true;}
			if (randomAcc[acc] == "foundJFNeck") {
			AlchemistNPCWorld.foundJFNeck = true;}
			if (randomAcc[acc] == "foundFlowerBoots") {
			AlchemistNPCWorld.foundFlowerBoots = true;}
			if (randomAcc[acc] == "foundString") {
			AlchemistNPCWorld.foundString = true;}
			if (randomAcc[acc] == "foundGreenCW") {
			AlchemistNPCWorld.foundGreenCW = true;}
			if (randomAcc[acc] == "foundFeralClaw") {
			AlchemistNPCWorld.foundFeralClaw = true;}
			if (randomAcc[acc] == "foundMagmaStone") {
			AlchemistNPCWorld.foundMagmaStone = true;}
			if (randomAcc[acc] == "foundSharkTooth") {
			AlchemistNPCWorld.foundSharkTooth = true;}
			if (randomAcc[acc] == "foundPanicNecklace") {
			AlchemistNPCWorld.foundPanicNecklace = true;}
			if (randomAcc[acc] == "foundObsidianRose") {
			AlchemistNPCWorld.foundObsidianRose = true;}
			if (randomAcc[acc] == "foundShackle") {
			AlchemistNPCWorld.foundShackle = true;}
			
			if (randomAcc.Count == 1)
			{
				Main.NewText("You have found all prehardmode blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.", 0, 255, 0);
				AlchemistNPCWorld.foundT1 = true;
			}
            return true;
        }
	}
}
