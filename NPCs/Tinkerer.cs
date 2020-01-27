using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using AlchemistNPC.Interface;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Tinkerer : ModNPC
	{
		public static bool TubePresent = false;
		public static bool TubePresent2 = false;
		public static bool TubePresent3 = false;
		public static int Shop = 1;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Tinkerer";
			}
		}

		public override void ResetEffects()
		{
			TubePresent = false;
			TubePresent2 = false;
			TubePresent3 = false;
		}
		
		public override bool Autoload(ref string name)
		{
			name = "Tinkerer";
			return AlchemistNPC.modConfiguration.TinkererSpawn;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tinkerer");
			DisplayName.AddTranslation(GameCulture.Russian, "Инженер");
            DisplayName.AddTranslation(GameCulture.Chinese, "工匠");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 20;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -4;

            ModTranslation text = mod.CreateTranslation("Alexander");
            text.SetDefault("Alexander");
            text.AddTranslation(GameCulture.Russian, "Александр");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Peter");
            text.SetDefault("Peter");
            text.AddTranslation(GameCulture.Russian, "Пётр");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("TinkererButton1");
            text.SetDefault("Sell");
            text.AddTranslation(GameCulture.Chinese, "出售");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("TinkererButton2");
            text.SetDefault("Shop");
            text.AddTranslation(GameCulture.Chinese, "商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("TinkererButton3");
            text.SetDefault("Reward");
            text.AddTranslation(GameCulture.Chinese, "回馈");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryT1");
            text.SetDefault("Do you need something special? Just say if so...");
            text.AddTranslation(GameCulture.Russian, "Нужно что-то особенное? Если так, то только скажи...");
            text.AddTranslation(GameCulture.Chinese, "需要一些特别的东西? 尽管说...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryT2");
            text.SetDefault("Have you seen my elder sister yet? She is more Steampunker than Tinkerer...");
            text.AddTranslation(GameCulture.Russian, "Ты ещё не встречал мою старшую сестру? Она больше Паромеханик чем Инженер...");
            text.AddTranslation(GameCulture.Chinese, "你看见过我的姐姐吗? 比起工匠, 她更像个蒸汽朋克女孩...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryT3");
            text.SetDefault("If you seen Paper Tube somewhere, bring it to me and I will unlock it for you.");
            text.AddTranslation(GameCulture.Russian, "Если найдёшь где-нибудь тубус, неси его мне и я вскрою его для тебя.");
            text.AddTranslation(GameCulture.Chinese, "如果你在什么地方见过纸管, 把它带给我, 我会为你解锁一些东西.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryT4");
            text.SetDefault("As you will progress through the world, you may found more valueable things. Counting blueprints for creating rarer accessories.");
            text.AddTranslation(GameCulture.Russian, "По мере твоего продвижения по миру, ты можешь найти всё более ценные вещи. В том числе и чертежи для создания более редких аксессуаров.");
            text.AddTranslation(GameCulture.Chinese, "随着进度的推进, 你可能会发现更有价值的东西. 攒些蓝图来制作更稀有的饰品.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryT5");
            text.SetDefault("You never know where you may get really rare or valueable things. So explore every possible corner with patience.");
            text.AddTranslation(GameCulture.Russian, "Никогда не знаешь, где ты можешь заполучить что-то действительно редкое или ценное. Поэтому исследуй каждый доступный угол со всем возможным терпением.");
            text.AddTranslation(GameCulture.Chinese, "你永远不会知道在哪里可以得到真正珍贵的东西. 所以耐心探索每一个可能的角落吧.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryT6");
            text.SetDefault("If you wil collect every single blueprint, I will give you the special reward.");
            text.AddTranslation(GameCulture.Russian, "Если ты соберешь все до единого чертежи, я выдам тебе специальную награду.");
            text.AddTranslation(GameCulture.Chinese, "如果你能收集每一张蓝图, 我会给你一个特别的奖励.");
            mod.AddTranslation(text);

			text = mod.CreateTranslation("TubePresentChat1");
            text.SetDefault("You don't have any Paper Tubes for selling right now. Go and get some!");
            text.AddTranslation(GameCulture.Chinese, "你没有任何可以递给我的蓝图纸管. 去弄些来!");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("TubePresentChat2");
            text.SetDefault("Here is some money, take it.");
            text.AddTranslation(GameCulture.Chinese, "这里, 钱, 拿着");
            mod.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 40;
            npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss1){return AlchemistNPC.modConfiguration.TinkererSpawn;}
			return false;
		}
 
 
        public override string TownNPCName()
        {
            string Alexander = Language.GetTextValue("Mods.AlchemistNPC.Alexander");
			string Peter = Language.GetTextValue("Mods.AlchemistNPC.Peter");
			switch (WorldGen.genRand.Next(1))
            {
                case 0:
                    return Alexander;
                default:
                    return Peter;
            }
        }
 
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 14;
			attackDelay = 5;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 16f;
		}
 
		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			closeness = 2;
			item = 95;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
			string EntryT1 = Language.GetTextValue("Mods.AlchemistNPC.EntryT1");
			string EntryT2 = Language.GetTextValue("Mods.AlchemistNPC.EntryT2");
			string EntryT3 = Language.GetTextValue("Mods.AlchemistNPC.EntryT3");
			string EntryT4 = Language.GetTextValue("Mods.AlchemistNPC.EntryT4");
			string EntryT5 = Language.GetTextValue("Mods.AlchemistNPC.EntryT5");
            switch (Main.rand.Next(5))
            {
                case 0:                                     
				return EntryT1;
                case 1:
				return EntryT2;
                case 2:                                                      
				return EntryT3;
                case 3:
				return EntryT4;
                default:
				return EntryT5;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("Mods.AlchemistNPC.TinkererButton1");
			button2 = Language.GetTextValue("Mods.AlchemistNPC.TinkererButton2");
			Player player = Main.player[Main.myPlayer];
			if (player.active)
			{
				for (int j = 0; j < player.inventory.Length; j++)
				{
					if (player.inventory[j].type == mod.ItemType("PaperTube"))
					{
						TubePresent = true;
					}
					if (player.inventory[j].type == mod.ItemType("PaperTube2"))
					{
						TubePresent2 = true;
					}
					if (player.inventory[j].type == mod.ItemType("PaperTube3"))
					{
						TubePresent3 = true;
					}
				}
			}
			if (NPC.downedMoonlord && !AlchemistNPCWorld.foundMP7 && AlchemistNPCWorld.foundT1 && AlchemistNPCWorld.foundT2 && AlchemistNPCWorld.foundT3)
			{
				button = Language.GetTextValue("Mods.AlchemistNPC.TinkererButton3");
			}
        }
 
		public void SyncWorldstate(Player player)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.SyncWorldstate);
			packet.Write((byte)player.whoAmI);
			packet.Write(AlchemistNPCWorld.foundMP7);
			packet.Send();
		}
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
				if (!TubePresent && !TubePresent2 && !TubePresent3)
				{
					Main.npcChatText = Language.GetTextValue("Mods.AlchemistNPC.TubePresentChat1");
				}
				if (NPC.downedMoonlord && !AlchemistNPCWorld.foundMP7 && AlchemistNPCWorld.foundT1 && AlchemistNPCWorld.foundT2 && AlchemistNPCWorld.foundT3)
				{
					Player player = Main.player[Main.myPlayer];
					player.QuickSpawnItem(mod.ItemType("MP7"));
					AlchemistNPCWorld.foundMP7 = true;
					if (Main.netMode == 2) SyncWorldstate(player);
				}
				else if (AlchemistNPCWorld.foundT1 || AlchemistNPCWorld.foundT2 || AlchemistNPCWorld.foundT3)
				{
					Item[] inventory = Main.player[Main.myPlayer].inventory;
					for (int k = 0; k < inventory.Length; k++)
					{
						if (TubePresent && AlchemistNPCWorld.foundT1)
						{
							if (inventory[k].type == mod.ItemType("PaperTube"))
							{
								TubePresent = false;
								TubePresent2 = false;
								TubePresent3 = false;
								inventory[k].stack--;
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.npcChatText = Language.GetTextValue("Mods.AlchemistNPC.TubePresentChat2");
							}
						}
						else if (TubePresent2 && AlchemistNPCWorld.foundT2)
						{
							if (inventory[k].type == mod.ItemType("PaperTube2"))
							{
								TubePresent = false;
								TubePresent2 = false;
								TubePresent3 = false;
								inventory[k].stack--;
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.npcChatText = Language.GetTextValue("Mods.AlchemistNPC.TubePresentChat2");
							}
						}
						else if (TubePresent3 && AlchemistNPCWorld.foundT3)
						{
							if (inventory[k].type == mod.ItemType("PaperTube3"))
							{
								TubePresent = false;
								TubePresent2 = false;
								TubePresent3 = false;
								inventory[k].stack--;
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.player[Main.myPlayer].QuickSpawnItem(ItemID.GoldCoin);
								Main.npcChatText = Language.GetTextValue("Mods.AlchemistNPC.TubePresentChat2");
							}
						}
					}
				}
			}
			else
			{
				ShopChangeUIT.visible = true;
			}
		}
 
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (Shop == 1){
			if (AlchemistNPCWorld.foundAglet)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Aglet);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundAnklet)
			{
				shop.item[nextSlot].SetDefaults (ItemID.AnkletoftheWind);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundClimbingClaws)
			{
				shop.item[nextSlot].SetDefaults (ItemID.ClimbingClaws);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundShoeSpikes)
			{
				shop.item[nextSlot].SetDefaults (ItemID.ShoeSpikes);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundHermesBoots)
			{
				shop.item[nextSlot].SetDefaults (ItemID.HermesBoots);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundWWB)
			{
				shop.item[nextSlot].SetDefaults (ItemID.WaterWalkingBoots);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFlowerBoots)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FlowerBoots);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundIceSkates)
			{
				shop.item[nextSlot].SetDefaults (ItemID.IceSkates);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFlyingCarpet)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FlyingCarpet);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundTabi)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Tabi);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFrogLeg)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FrogLeg);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundJFNeck)
			{
				shop.item[nextSlot].SetDefaults (ItemID.JellyfishNecklace);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFlippers)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Flipper);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundNeptuneShell)
			{
				shop.item[nextSlot].SetDefaults (ItemID.NeptunesShell);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundHorseshoe)
			{
				shop.item[nextSlot].SetDefaults (ItemID.LuckyHorseshoe);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundBalloon)
			{
				shop.item[nextSlot].SetDefaults (ItemID.ShinyRedBalloon);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundCloud)
			{
				shop.item[nextSlot].SetDefaults (ItemID.CloudinaBottle);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundBlizzard)
			{
				shop.item[nextSlot].SetDefaults (ItemID.BlizzardinaBottle);
				shop.item[nextSlot].shopCustomPrice = 40000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundSandstorm)
			{
				shop.item[nextSlot].SetDefaults (ItemID.SandstorminaBottle);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPuffer)
			{
				shop.item[nextSlot].SetDefaults (ItemID.BalloonPufferfish);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundTsunami)
			{
				shop.item[nextSlot].SetDefaults (ItemID.TsunamiInABottle);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundLavaCharm)
			{
				shop.item[nextSlot].SetDefaults (ItemID.LavaCharm);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundCMagnet)
			{
				shop.item[nextSlot].SetDefaults (ItemID.CelestialMagnet);
				shop.item[nextSlot].shopCustomPrice = 200000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPStone)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PhilosophersStone);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundHTFL)
			{
				shop.item[nextSlot].SetDefaults (ItemID.HighTestFishingLine);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundAnglerEarring)
			{
				shop.item[nextSlot].SetDefaults (ItemID.AnglerEarring);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundTackleBox)
			{
				shop.item[nextSlot].SetDefaults (ItemID.TackleBox);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundGoldRing)
			{
				shop.item[nextSlot].SetDefaults (ItemID.GoldRing);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundLuckyCoin)
			{
				shop.item[nextSlot].SetDefaults (ItemID.LuckyCoin);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundDiscountCard)
			{
				shop.item[nextSlot].SetDefaults (ItemID.DiscountCard);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			}
			if (Shop == 2){
			if (AlchemistNPCWorld.foundString)
			{
				shop.item[nextSlot].SetDefaults (ItemID.WhiteString);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundGreenCW)
			{
				shop.item[nextSlot].SetDefaults (ItemID.GreenCounterweight);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundYoyoGlove)
			{
				shop.item[nextSlot].SetDefaults (ItemID.YoYoGlove);
				shop.item[nextSlot].shopCustomPrice = 500000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundBlindfold)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Blindfold);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundArmorPolish)
			{
				shop.item[nextSlot].SetDefaults (ItemID.ArmorPolish);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundVitamins)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Vitamins);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundBezoar)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Bezoar);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundAdhesiveBandage)
			{
				shop.item[nextSlot].SetDefaults (ItemID.AdhesiveBandage);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFastClock)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FastClock);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundTrifoldMap)
			{
				shop.item[nextSlot].SetDefaults (ItemID.TrifoldMap);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundMegaphone)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Megaphone);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundNazar)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Nazar);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundSorcE)
			{
				shop.item[nextSlot].SetDefaults (ItemID.SorcererEmblem);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundWE)
			{
				shop.item[nextSlot].SetDefaults (ItemID.WarriorEmblem);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundRE)
			{
				shop.item[nextSlot].SetDefaults (ItemID.RangerEmblem);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundSumE)
			{
				shop.item[nextSlot].SetDefaults (ItemID.SummonerEmblem);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFeralClaw)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FeralClaws);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundTitanGlove)
			{
				shop.item[nextSlot].SetDefaults (ItemID.TitanGlove);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundMagmaStone)
			{
				shop.item[nextSlot].SetDefaults (ItemID.MagmaStone);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundSharkTooth)
			{
				shop.item[nextSlot].SetDefaults (ItemID.SharkToothNecklace);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundBlackBelt)
			{
				shop.item[nextSlot].SetDefaults (ItemID.BlackBelt);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundMoonCharm)
			{
				shop.item[nextSlot].SetDefaults (ItemID.MoonCharm);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundSunStone)
			{
				shop.item[nextSlot].SetDefaults (ItemID.SunStone);
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundMoonStone)
			{
				shop.item[nextSlot].SetDefaults (ItemID.MoonStone);
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundRifleScope)
			{
				shop.item[nextSlot].SetDefaults (ItemID.RifleScope);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundCobaltShield)
			{
				shop.item[nextSlot].SetDefaults (ItemID.CobaltShield);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPaladinShield)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PaladinsShield);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFrozenTurtleShell)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FrozenTurtleShell);
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPutridScent)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PutridScent);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundFleshKnuckles)
			{
				shop.item[nextSlot].SetDefaults (ItemID.FleshKnuckles);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundMagicQuiver)
			{
				shop.item[nextSlot].SetDefaults (ItemID.MagicQuiver);
				shop.item[nextSlot].shopCustomPrice = 200000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPanicNecklace)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PanicNecklace);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundCrossNecklace)
			{
				shop.item[nextSlot].SetDefaults (ItemID.CrossNecklace);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundStarCloak)
			{
				shop.item[nextSlot].SetDefaults (ItemID.StarCloak);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundObsidianRose)
			{
				shop.item[nextSlot].SetDefaults (ItemID.ObsidianRose);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundShackle)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Shackle);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundHerculesBeetle)
			{
				shop.item[nextSlot].SetDefaults (ItemID.HerculesBeetle);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundPygmyNecklace)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PygmyNecklace);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			if (AlchemistNPCWorld.foundNecromanticScroll)
			{
				shop.item[nextSlot].SetDefaults (ItemID.NecromanticScroll);
				shop.item[nextSlot].shopCustomPrice = 330000;
				nextSlot++;
			}
			}
			if (Shop == 3){
				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults (mod.ItemType("MenacingToken"));
					nextSlot++;
					shop.item[nextSlot].SetDefaults (mod.ItemType("LuckyToken"));
					nextSlot++;
					shop.item[nextSlot].SetDefaults (mod.ItemType("ViolentToken"));
					nextSlot++;
					shop.item[nextSlot].SetDefaults (mod.ItemType("WardingToken"));
					nextSlot++;
				}
			}
		}
	}
}
