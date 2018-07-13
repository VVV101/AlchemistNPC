using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using AlchemistNPC.NPCs;
using AlchemistNPC;
using Terraria.Localization;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Brewer : ModNPC
	{
		public static bool Shop1 = true;
		public static bool Shop2 = false;
		public static bool Shop3 = false;
		public static bool Shop4 = false;
		public static bool Shop5 = false;
		public static bool S1A = false;
		public static bool S2A = false;
		public static bool S3A = false;
		public static bool S4A = false;
		public static bool S5A = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Brewer";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Brewer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brewer");
			DisplayName.AddTranslation(GameCulture.Russian, "Варщица Зелий");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -4;
		
		ModTranslation text = mod.CreateTranslation("ShopB1");
		text.SetDefault("1st shop (Vanilla)                     ");
		text.AddTranslation(GameCulture.Russian, "1-ый магазин (без модовоых)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("ShopB2");
		text.SetDefault("2nd shop (Mod/Thorium/Calamity/RG)");
		text.AddTranslation(GameCulture.Russian, "2-ой магазин (Mod/Thorium/Calamity/RG)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("ShopB3");
		text.SetDefault("3rd shop (MorePotions)              ");
		text.AddTranslation(GameCulture.Russian, "3-ий магазин (MorePotions)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("ShopB4");
		text.SetDefault("4th shop (UnuBattleRods/Tacklebox/Tremor) ");
		text.AddTranslation(GameCulture.Russian, "4-ый магазин (UnuBattleRods/Tacklebox/Tremor)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("ShopB5");
		text.SetDefault("5th shop (Wildlife/Sacred/Spirit/Cristilium/ExpSentr)");
		text.AddTranslation(GameCulture.Russian, "5-ый магазин (Wildlife/Sacred/Spirit/Cristilium/ExpSentr)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("CycleShop");
		text.SetDefault("Cycle Shop");
		text.AddTranslation(GameCulture.Russian, "Смена магазина");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Lillian");
		text.SetDefault("Lillian");
		text.AddTranslation(GameCulture.Russian, "Лилиан");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Lucy");
		text.SetDefault("Lucy");
		text.AddTranslation(GameCulture.Russian, "Люси");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Alice");
		text.SetDefault("Alice");
		text.AddTranslation(GameCulture.Russian, "Алиса");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Rocksahn");
		text.SetDefault("Rocksahn");
		text.AddTranslation(GameCulture.Russian, "Роксанна");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Agness");
		text.SetDefault("Agness");
		text.AddTranslation(GameCulture.Russian, "Агнесс");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Mary");
		text.SetDefault("Mary");
		text.AddTranslation(GameCulture.Russian, "Мария");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB1");
		text.SetDefault("Care to try this potion? It's supposed to grant wings.");
		text.AddTranslation(GameCulture.Russian, "Хочешь попробовать это зелье? Оно должно дать тебе крылья.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB2");
		text.SetDefault("I don't think that was a Spelunker potion...");
		text.AddTranslation(GameCulture.Russian, "Не думаю, что это было зелье Шахтера...");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB3");
		text.SetDefault("I got my degrees from Riddle University.");
		text.AddTranslation(GameCulture.Russian, "Я получила своё образование в Университете Загадок.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB4");
		text.SetDefault("There's a legendary yoyo known as the Sasscade.");
		text.AddTranslation(GameCulture.Russian, "Существует Легендарное Йо-йо, известное как Сасскад.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB5");
		text.SetDefault("Aww, bread crumbs and beaver spit!");
		text.AddTranslation(GameCulture.Russian, "Ох, хлебные крошки и слюни бобра!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB6");
		text.SetDefault("Hi, *cough* that wasn't an inferno potion!");
		text.AddTranslation(GameCulture.Russian, "Привет, *кашель* это точно не было зельем Инферно!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB7");
		text.SetDefault("Have you seen two mechanical eyes around?");
		text.AddTranslation(GameCulture.Russian, "Ты не видел двух Механических Глаз поблизости?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB8");
		text.SetDefault("That silly goose ");
		text.AddTranslation(GameCulture.Russian, "Этот трусливый гусь ");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB9");
		text.SetDefault(" is too afraid of using occult powers in Alchemy. And so his potions are just an useless water.");
		text.AddTranslation(GameCulture.Russian, " слишком боится использовать оккультные силы в Алхимии. И поэтому его зелья лишь бесполезная водичка.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB10");
		text.SetDefault("*sneezes* Eww... I am always sneezing while these Goblins are around!");
		text.AddTranslation(GameCulture.Russian, "*чихает* Фуу... Я всегда чихаю, когда эти Гоблины поблизости!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB11");
		text.SetDefault("Just don't let them in my house... There are so many needed supplies and instruments.");
		text.AddTranslation(GameCulture.Russian, "Просто не пускай их в мой дом. Там очень много нужных материалов и инструментов.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB12");
		text.SetDefault("Is this a Martians Invasion? Are they going to enslave us all? Or they want to destroy us all? No one knows the answer...");
		text.AddTranslation(GameCulture.Russian, "Это вторжение Марсиан? Она пришли чтобы поработить нас всех? Или они хотят нас уничтожить? Никто не знает ответа...");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB13");
		text.SetDefault("Is it Blood Moon in the sky? I love it! It is so beautiful!");
		text.AddTranslation(GameCulture.Russian, "Это Кровавая Луна в небесах? Я люблю её! Она так красива!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB14");
		text.SetDefault("I was born under the light of Blood Moon. I am always so excited while IT rises in the sky!");
		text.AddTranslation(GameCulture.Russian, "Я была рождена под светом Кровавой Луны. Я всегда так взволнована когда ОНА восходит на небе!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB15");
		text.SetDefault("Yeah, I can understand why the other girls are annoyed, but that's not stopping my joy!");
		text.AddTranslation(GameCulture.Russian, "Да, я понимаю, почему другие девушки раздражены, но это не прекращает моего веселья!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB16");
		text.SetDefault("As happy as I am, I'm not giving discounts - I'm not dumb.");
		text.AddTranslation(GameCulture.Russian, "Насколько бы счастлива я не была, я не даю скидок - я ведь не глупая.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB17");
		text.SetDefault("Normally I'm confused with how ");
		text.AddTranslation(GameCulture.Russian, "Обычно я бываю озадачена тем, как.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryB18");
		text.SetDefault(" is just as calm as I am, but then I remember ");
		text.AddTranslation(GameCulture.Russian, " может быть так же спокойна, как я, но потом я вспоминаю ");
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
            npc.defense = 100;
            npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Mechanic;
        }
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss1)
			{
			return true;
			}
			return false;
		}
 
        public override string TownNPCName()
        {                                       //NPC names
            string Lillian = Language.GetTextValue("Mods.AlchemistNPC.Lillian");
			string Lucy = Language.GetTextValue("Mods.AlchemistNPC.Lucy");
			string Alice = Language.GetTextValue("Mods.AlchemistNPC.Alice");
			string Agness = Language.GetTextValue("Mods.AlchemistNPC.Agness");
			string Rocksahn = Language.GetTextValue("Mods.AlchemistNPC.Rocksahn");
			string Mary = Language.GetTextValue("Mods.AlchemistNPC.Mary");
			switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    return Lillian;
                case 1:
                    return Lucy;
                case 2:
                    return Alice;
                case 3:
                    return Rocksahn;
				case 4:
                    return Agness;
                default:
                    return Mary;
            }
        }
 
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (!Main.hardMode)
			{
			damage = 10;
			}
			if (!NPC.downedMoonlord && Main.hardMode)
			{
			damage = 25;
			}
			if (NPC.downedMoonlord)
			{
			damage = 100;
			}
			knockback = 8f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (NPC.downedMoonlord)
			{
			projType = mod.ProjectileType("CorrosiveFlask");
			}
			else
			{
			projType = ProjectileID.ToxicFlask;
			}
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 1f;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
                string EntryB1 = Language.GetTextValue("Mods.AlchemistNPC.EntryB1");
				string EntryB2 = Language.GetTextValue("Mods.AlchemistNPC.EntryB2");
				string EntryB3 = Language.GetTextValue("Mods.AlchemistNPC.EntryB3");
				string EntryB4 = Language.GetTextValue("Mods.AlchemistNPC.EntryB4");
				string EntryB5 = Language.GetTextValue("Mods.AlchemistNPC.EntryB5");
				string EntryB6 = Language.GetTextValue("Mods.AlchemistNPC.EntryB6");
				string EntryB7 = Language.GetTextValue("Mods.AlchemistNPC.EntryB7");
				string EntryB8 = Language.GetTextValue("Mods.AlchemistNPC.EntryB8");
				string EntryB9 = Language.GetTextValue("Mods.AlchemistNPC.EntryB9");
				string EntryB10 = Language.GetTextValue("Mods.AlchemistNPC.EntryB10");
				string EntryB11 = Language.GetTextValue("Mods.AlchemistNPC.EntryB11");
				string EntryB12 = Language.GetTextValue("Mods.AlchemistNPC.EntryB12");
				string EntryB13 = Language.GetTextValue("Mods.AlchemistNPC.EntryB13");
				string EntryB14 = Language.GetTextValue("Mods.AlchemistNPC.EntryB14");
				string EntryB15 = Language.GetTextValue("Mods.AlchemistNPC.EntryB15");
				string EntryB16 = Language.GetTextValue("Mods.AlchemistNPC.EntryB16");
				string EntryB17 = Language.GetTextValue("Mods.AlchemistNPC.EntryB17");
				string EntryB18 = Language.GetTextValue("Mods.AlchemistNPC.EntryB18");
				int Alchemist = NPC.FindFirstNPC(mod.NPCType("Alchemist"));
				int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (Main.bloodMoon && partyGirl >= 0 && Alchemist >=0 && Main.rand.Next(4) == 0)
			{
			return EntryB17 + Main.npc[partyGirl].GivenName + EntryB18 + Main.npc[Alchemist].GivenName + ".";
			}
			if (Main.bloodMoon)
			{
				switch (Main.rand.Next(4))
				{
				case 0:
				return EntryB13;
                case 1:
				return EntryB14;
				case 2:
				return EntryB15;
				case 3:
				return EntryB16;
				}
			}
			if (Main.invasionType == 1)
			{
				return EntryB10;
			}
			if (Main.invasionType == 3)
			{
				return EntryB11;
			}
			if (Main.invasionType == 4)
			{
				return EntryB12;
			}
			if (Alchemist >= 0 && Main.rand.Next(4) == 0)
			{
				return EntryB8 + Main.npc[Alchemist].GivenName + EntryB9;
			}
            switch (Main.rand.Next(7))
            {
                case 0:                                     
				return EntryB1;
                case 1:
				return EntryB2;
                case 2:                                                      
				return EntryB3;
                case 3:
				return EntryB4;
                case 4:                                     
				return EntryB5;
                case 5:
				return EntryB6;
                default:
				return EntryB7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ShopB1 = Language.GetTextValue("Mods.AlchemistNPC.ShopB1");
			string ShopB2 = Language.GetTextValue("Mods.AlchemistNPC.ShopB2");
			string ShopB3 = Language.GetTextValue("Mods.AlchemistNPC.ShopB3");
			string ShopB4 = Language.GetTextValue("Mods.AlchemistNPC.ShopB4");
			string ShopB5 = Language.GetTextValue("Mods.AlchemistNPC.ShopB5");
			string CycleShop = Language.GetTextValue("Mods.AlchemistNPC.CycleShop");
			if (Shop1)
			{
			button = ShopB1;
			S5A = false;
			S1A = true;
			}
			if (Shop2)
			{
			button = ShopB2;
			S1A = false;
			S2A = true;
			}
			if (Shop3)
			{
			button = ShopB3;
			S2A = false;
			S3A = true;
			}
			if (Shop4)
			{
			button = ShopB4;
			S3A = false;
			S4A = true;
			}
			if (Shop5)
			{
			button = ShopB5;
			S4A = false;
			S5A = true;
			}
			if (npc.FindBuffIndex(119) >= 0 && NPC.AnyNPCs(mod.NPCType("Alchemist")) && !NPC.AnyNPCs(mod.NPCType("Young Brewer")))
			{
				button2 = "???";
			}
			else
			{
			button2 = CycleShop;
			}
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop) 
		{
		if (firstButton)
            {
                shop = true;
            }
		else
				{
					if (npc.FindBuffIndex(119) >= 0 && NPC.AnyNPCs(mod.NPCType("Alchemist")) && !NPC.AnyNPCs(mod.NPCType("Young Brewer")))
					{
					Main.NewText("Young Brewer is spawned.", 255, 255, 255);
					NPC.NewNPC((int)npc.Center.X+2, (int)npc.Center.Y, mod.NPCType("Young Brewer"));
					}
			if (Shop1 && S1A)
						{
						Shop2 = true;
						Shop1 = false;
						}
			if (Shop2 && S2A)
						{
						Shop3 = true;
						Shop2 = false;
						}
			if (Shop3 && S3A)
						{
						Shop4 = true;
						Shop3 = false;
						}
			if (Shop4 && S4A)
						{
						Shop5 = true;
						Shop4 = false;
						}
			if (Shop5 && S5A)
						{
						Shop1 = true;
						Shop5 = false;
						}
				}
		}
 
		public bool SacredToolsDownedAbaddon
		{
		get { return SacredTools.ModdedWorld.OblivionSpawns; }
		}
		
		public bool SacredToolsDownedSerpent
		{
		get { return SacredTools.ModdedWorld.FlariumSpawns; }
		}
		
		public bool SacredToolsDownedLunarians
		{
		get { return SacredTools.ModdedWorld.downedLunarians; }
		}
 
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
		if (Shop1)
		{
		shop.item[nextSlot].SetDefaults (ItemID.SwiftnessPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.IronskinPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.RegenerationPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.MiningPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.BuilderPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.ArcheryPotion);
		shop.item[nextSlot].shopCustomPrice = 15000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.SummoningPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.EndurancePotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.HeartreachPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.AmmoReservationPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.ThornsPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.ShinePotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.NightOwlPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.WarmthPotion);
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.SpelunkerPotion);
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.HunterPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.TrapsightPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.FlipperPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.GillsPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.InvisibilityPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.WaterWalkingPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.ObsidianSkinPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.FeatherfallPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.GravitationPotion);
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.MagicPowerPotion);
		shop.item[nextSlot].shopCustomPrice = 15000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.ManaRegenerationPotion);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.TitanPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.BattlePotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.CalmingPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;			
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.LifeforcePotion);
			shop.item[nextSlot].shopCustomPrice = 25000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.InfernoPotion);
			shop.item[nextSlot].shopCustomPrice = 15000;
			nextSlot++;
			}
			if (NPC.downedBoss3)
			{
			shop.item[nextSlot].SetDefaults (ItemID.WrathPotion);
			shop.item[nextSlot].shopCustomPrice = 25000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.RagePotion);
			shop.item[nextSlot].shopCustomPrice = 25000;
            nextSlot++;
			}
		shop.item[nextSlot].SetDefaults (ItemID.StinkPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
			if (Main.hardMode)
			{	
			shop.item[nextSlot].SetDefaults (ItemID.LovePotion);
			shop.item[nextSlot].shopCustomPrice = 7500;
			nextSlot++;
			}
			if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
			{
			shop.item[nextSlot].SetDefaults (ItemID.FishingPotion);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SonarPotion);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.CratePotion);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			}
		shop.item[nextSlot].SetDefaults (ItemID.GenderChangePotion);
		shop.item[nextSlot].shopCustomPrice = 100000;
		nextSlot++;			
		}
		if (Shop2)
		{
		if (NPC.downedBoss1)
		{
		shop.item[nextSlot].SetDefaults (ItemID.LesserRestorationPotion);
		shop.item[nextSlot].shopCustomPrice = 3500;
		nextSlot++;
		}
		if (NPC.downedBoss2)
		{
		shop.item[nextSlot].SetDefaults (ItemID.RestorationPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.StrangeBrew);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		}
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("SunshinePotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
		if (NPC.downedBoss3)
			{
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BewitchingPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("FortitudePotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
		if (Main.hardMode)
				{		
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("InvincibilityPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("TitanSkinPotion"));
			shop.item[nextSlot].shopCustomPrice = 50000;
            nextSlot++;
		if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
					{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BlurringPotion"));
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
		if (NPC.downedPlantBoss)
						{
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("NinjaPotion"));
			shop.item[nextSlot].shopCustomPrice = 75000;
            nextSlot++;
						}
					}
				}
			}
		if (ModLoader.GetLoadedMods().Contains("ReducedGrinding"))
			{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ReducedGrinding").ItemType("War_Potion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ReducedGrinding").ItemType("Time_Potion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ReducedGrinding").ItemType("Expert_Change_Potion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ReducedGrinding").ItemType("Rain_Potion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ReducedGrinding").ItemType("Slime_Rain_Potion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
		{
				if (NPC.downedBoss3)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FrostCoatingItem"));
			shop.item[nextSlot].shopCustomPrice = 5000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ExplosiveCoatingItem"));
			shop.item[nextSlot].shopCustomPrice = 5000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GorganCoatingItem"));
			shop.item[nextSlot].shopCustomPrice = 5000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LifeLeechCoatingItem"));
			shop.item[nextSlot].shopCustomPrice = 5000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ToxicCoatingItem"));
			shop.item[nextSlot].shopCustomPrice = 2500;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CreativityPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("EarwormPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
				}
			if (Main.hardMode)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("InspirationReachPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
				}
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GlowingPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HolyPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
				}
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AccuracyPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BloodPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CombatPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ConflagrationPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("SilverTonguePotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AquaPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FrenzyPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
		}
if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if (NPC.downedBoss3)
						{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PotionofOmniscience"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ZergPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ZenPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("YharimsStimulants"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			if (Main.hardMode)
							{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CadencePotion"));
			shop.item[nextSlot].shopCustomPrice = 50000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("FabsolsVodka"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			if (NPC.downedGolemBoss)
								{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TitanScalePotion"));
			shop.item[nextSlot].shopCustomPrice = 50000;
            nextSlot++;
								}
							}
						}
					}
		}
		if (Shop3)
		{
			if (ModLoader.GetLoadedMods().Contains("MorePotions"))
			{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("HeavyRootsPotion"));
			shop.item[nextSlot].shopCustomPrice = 7500;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("NaturesBlessingPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("HoneyPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("JellySolesPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("JumpPotion"));
			shop.item[nextSlot].shopCustomPrice = 7500;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("PenetrationPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("WarriorsDroughtPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("RangersDroughtPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SummonersDroughtPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("GladiatorsPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("OlympiansPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SwiftHandsPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SpeedPotion"));
			shop.item[nextSlot].shopCustomPrice = 7500;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("StarlightPotion"));
			shop.item[nextSlot].shopCustomPrice = 7500;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("GoldenPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;	
				if (Main.hardMode)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("DiamondSkinPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("ManashieldPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("ReactiveArmorPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("VengeancePotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("EnhancedRegenerationPotion"));
			shop.item[nextSlot].shopCustomPrice = 15000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("HolyElixerPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SoulbindingElixerPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("ManaforcePotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("CouragePotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("DelvingPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("ForbiddenPotion"));
			shop.item[nextSlot].shopCustomPrice = 50000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("VenomousCoatingPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("GoldCoatingPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("IchorousCoatingPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("CursedCoatingPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
	{
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("LeafCrystalPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
	}
if (NPC.downedPlantBoss)
		{
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("LifestealPotion"));
			shop.item[nextSlot].shopCustomPrice = 75000;
            nextSlot++;
		}
if (NPC.downedGolemBoss)
	{
shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SuperRegenerationPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
	}
if (NPC.downedMoonlord)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("SolarPotion"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("NebulaPotion"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("VortexPotion"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("StardustPotion"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("MorePotions").ItemType("TerrariansWrathPotion"));
			shop.item[nextSlot].shopCustomPrice = 250000;
            nextSlot++;
				}
}	
}			
		}
		if (Shop4)
		{
		if (ModLoader.GetLoadedMods().Contains("UnuBattleRods"))
			{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("UnuBattleRods").ItemType("BobEscalationPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("UnuBattleRods").ItemType("BobSpeedingPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("UnuBattleRods").ItemType("FasterEscalationPotion"));
			shop.item[nextSlot].shopCustomPrice = 25000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("UnuBattleRods").ItemType("FurtherEscalationPotion"));
			shop.item[nextSlot].shopCustomPrice = 35000;
            nextSlot++;
			if (NPC.downedBoss3)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("UnuBattleRods").ItemType("MaximumEscalationPotion"));
			shop.item[nextSlot].shopCustomPrice = 110000;
            nextSlot++;
				}
			}
		if (ModLoader.GetLoadedMods().Contains("Tacklebox"))
		{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("FrogPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("DivingPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("UltrabrightPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
			{
			if (NPC.downedBoss3)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("AnglerPotion"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("SuperAngler"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("SuperCrate"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tacklebox").ItemType("SuperFishing"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
				}
			}
		}
		if (ModLoader.GetLoadedMods().Contains("Tremor"))
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("InspirationPotion"));
			shop.item[nextSlot].shopCustomPrice = 20000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("RockClimberPotion"));
			shop.item[nextSlot].shopCustomPrice = 10000;
            nextSlot++;
				if (Main.hardMode)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("BloodmoonPotion"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					}
					if (NPC.downedMoonlord)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("ParadoxPotion"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("SunfuryPotion"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("MidnightPotion"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("ScamperPotion"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("SavingPotion"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Tremor").ItemType("GlassPotion"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					}						
				}
		}
		if (Shop5)
		{
			if (ModLoader.GetLoadedMods().Contains("Wildlife"))
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("BouncePotion"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("FluxglowPotion"));
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("DeerBlood"));
					shop.item[nextSlot].shopCustomPrice = 5000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("TortoisePotion"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("MoltenPotion"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
				}
					if (Main.hardMode)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("FairyBottleB"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("FairyBottleG"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("FairyBottleP"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("AscensionPotion"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("GlitchhopPotion"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Wildlife").ItemType("SparkPotion"));
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
					}
				}
				if (ModLoader.GetLoadedMods().Contains("SacredTools"))
					{
						if (NPC.downedBoss1)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("ThrownPotion"));
						shop.item[nextSlot].value = 30000;
						nextSlot++;
						}
						if (Main.hardMode)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("SandPotion"));
						shop.item[nextSlot].value = 30000;
						nextSlot++;
						}
					if(SacredToolsDownedAbaddon)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("NightmarePotion"));
						shop.item[nextSlot].value = 250000;
						nextSlot++;
						}
					if(SacredToolsDownedSerpent)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("BurnCure"));
						shop.item[nextSlot].value = 250000;
						nextSlot++;
						}
					if(SacredToolsDownedLunarians)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("MoonlightPotion"));
						shop.item[nextSlot].value = 250000;
						nextSlot++;
						}
					}
				if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("BismitePotion"));
					shop.item[nextSlot].value = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("PinkPotion"));
					shop.item[nextSlot].value = 10000;
					nextSlot++;
					if (NPC.downedMechBossAny)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SoulPotion"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("RunePotion"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SpiritPotion"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StarPotion"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("TurtlePotion"));
					shop.item[nextSlot].value = 100000;
					nextSlot++;
					}
					if (NPC.downedPlantBoss)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("DungeonSpirit"));
					shop.item[nextSlot].value = 30000;
					nextSlot++;
					}
				}
				if (ModLoader.GetLoadedMods().Contains("CrystiliumMod"))
				{
				if (Main.hardMode)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrystalPotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("DragonWine"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("DustbreakPotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("GranitePotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("MarblePotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("ThrowingBoostPotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("TwilightPotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					}
				}
				if (ModLoader.GetLoadedMods().Contains("ExpandedSentries"))
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ExpandedSentries").ItemType("SentryPotion"));
				shop.item[nextSlot].value = 30000;
				nextSlot++;
					if (NPC.downedBoss3)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ExpandedSentries").ItemType("DefenderPotion"));
					shop.item[nextSlot].value = 20000;
					nextSlot++;
					}
				}
			}
		}
	}
}