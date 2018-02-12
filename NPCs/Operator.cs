using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.World.Generation;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Operator : ModNPC
	{
		public static bool OA = false;
		public static bool Shop1 = true;
		public static bool Shop2 = false;
		public static bool Shop3 = false;
		public static bool S1A = false;
		public static bool S2A = false;
		public static bool S3A = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Operator";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Operator";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Operator");
			DisplayName.AddTranslation(GameCulture.Russian, "Оператор");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -6;
		
		ModTranslation text = mod.CreateTranslation("EGOShop");
		text.SetDefault("EGO shop");
		text.AddTranslation(GameCulture.Russian, "Магазин Э.П.О.С");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("BossDropsShop");
		text.SetDefault("Boss Drops Shop");
		text.AddTranslation(GameCulture.Russian, "Магазин лута Боссов");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("TreasureBagsShop");
		text.SetDefault("Treasure Bags Shop");
		text.AddTranslation(GameCulture.Russian, "Магазин сумок Боссов");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("CycleShopO");
		text.SetDefault("Cycle shop");
		text.AddTranslation(GameCulture.Russian, "Сменить магазин");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("Angela");
		text.SetDefault("Angela");
		text.AddTranslation(GameCulture.Russian, "Анджела");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO1");
		text.SetDefault("How are you day, Manager? Can I help you?");
		text.AddTranslation(GameCulture.Russian, "Как ваш день, Управляющий? Могу я помочь вам?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO2");
		text.SetDefault("That 'The Great Thunder Bird' doesn't seems so dangerous. I am only hoping it is not the part of Apocalypse Bird...");
		text.AddTranslation(GameCulture.Russian, "Эта 'Великая Птица-Гром' не кажется такой уж опасной. Я только надеюсь, что она не является частью Птицы Апокалипсиса.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO3");
		text.SetDefault("Hello, Manager! Isn't this day silent, does it?");
		text.AddTranslation(GameCulture.Russian, "Приветствую, Управляющий! Тихий сегодня денёк, не правда ли?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO4");
		text.SetDefault("Do you want anything special, Manager?");
		text.AddTranslation(GameCulture.Russian, "Вам нужно что-нибудь особенное, Управляющий?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO5");
		text.SetDefault("Eater of Worlds is Abnomality with risk class TETH. And now it is contained. Do you need something from it?");
		text.AddTranslation(GameCulture.Russian, "Пожиратель Миров - это аномалия с уровнем угрозы TETH. Теперь он захвачен. Нужно ли вам что-нибудь от него?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO6");
		text.SetDefault("If you manage to supress Ragnarok, then you could do everything imaginable.");
		text.AddTranslation(GameCulture.Russian, "Если тебе удастся одолеть Рагнарёк, то тогда ты способен на всё, что угодно.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO7");
		text.SetDefault("Eye of Cthtulhu is pretty strange creature. It seems like it is just a small part of something really dangerous. It would be better for us if it never escapes.");
		text.AddTranslation(GameCulture.Russian, "Глаз Ктулху - довольно странное создание. Похоже, что он является малой частью чего-то по настоящему опасного. Лучше никогда не позволяйте ему сбежать.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO8");
		text.SetDefault("Brain of Cthulhu may look horrifying, but without its minions it can do literally nothing.");
		text.AddTranslation(GameCulture.Russian, "Мозг Ктулху может выглядеть пугающе, но без своих прислужников он не способен ни на что");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO9");
		text.SetDefault("Something changed in this world, Manager. Evil is spreading even wider, but at the same time, my sensors systems fixed birth of new biome, called Hallowed.");
		text.AddTranslation(GameCulture.Russian, "Что-то изменилось в этом мире, Управляющий. Зло разрастается ещё шире, но в то же время мои сенсоры зафиксировали рождение нового биома, называющегося Святым.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO10");
		text.SetDefault("All these Mechanical Bosses... They definetly could have Trauma origin. What classification numbers will they get? I think they would be started as T-05-...");
		text.AddTranslation(GameCulture.Russian, "Все эти Механические Боссы... Они определённо могут иметь происхождение от Траумы. Какие классификационные номера они получат? Я полагаю, они будут начинаться с T-05-...");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO11");
		text.SetDefault("Goblins... Such a pathetic creatures. And the only useful things from them are just Spiky Balls and Harpoon.");
		text.AddTranslation(GameCulture.Russian, "Гоблины... Какие же жалкие создания. Единственные полезные вещи с них - это шипастые шары и Гарпун.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO12");
		text.SetDefault("Pretty strange Abnormal event... They all look as living creatures, but their 'Flying Dutchman' is definetly a ghost with HE risk class.");
		text.AddTranslation(GameCulture.Russian, "Довольно странное событие... Они все выглядят как живые существа, но вот их 'Летучий Голландец' - определённо призрак класса опасности HE.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO13");
		text.SetDefault("Martians come again. Last time they came, several big towns were destroyed. But, in our excuses, we could say that we weren't as ready, as now.");
		text.AddTranslation(GameCulture.Russian, "Марсиане прибыли вновь. Последний раз когда они прибыли, было разрушено несколько крупных городов. Но, в наше оправдание можно сказать, что мы не были так готовы, как сейчас.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO14");
		text.SetDefault("Blood Moon? Isn't IT should happen one time in 666 years?");
		text.AddTranslation(GameCulture.Russian, "Кровавая Луна? Разве она не должна случаться один раз в 666 лет?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO15");
		text.SetDefault("All these strange cratures just keep coming and coming to this 'Beacon'... Hope we all will survive until Dawn.");
		text.AddTranslation(GameCulture.Russian, "Все эти странные существа продолжают прибывать и прибывать на этот 'Маяк'... Надеюсь, мы все доживём до рассвета.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO16");
		text.SetDefault("Anyway, there are some reasons for optimism. Blood Moon attracks some creatures, which cannot be seen in normal conditions.");
		text.AddTranslation(GameCulture.Russian, "Как бы то ни было, есть некоторые причины для оптимизма. Кровавая Луна привлекает некоторых созданий, которых нельзя увидеть при обычных условиях.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO17");
		text.SetDefault("I read a few manuscripts about creature, named Slime God. They say that he is one of the first creatures in this world.");
		text.AddTranslation(GameCulture.Russian, "Я прочитала несколько манускриптов о существе, именуемом Бог Слизней. В них говорится, что он является одним из первых созданий этого мира");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("EntryO18");
		text.SetDefault("Yharim... I am pretty sure I heard that name before. But my memory data is corrupted. Try asking Calamitas about him...");
		text.AddTranslation(GameCulture.Russian, "Ярим... Я уверена, что слышала это имя раньше. Но моя память повреждена. Попробуй узнать у Каламитас что-нибудь о нём...");
		mod.AddTranslation(text);
		}

		public override void ResetEffects()
		{
		OA = false;
		S1A = false;
		S2A = false;
		S3A = false;
		}
		
		public override void SetDefaults()
		{
			npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 50;
            npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Steampunker;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss2)
			{
			return true;
			}
			return false;
		}
 
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			for (int x = left; x <= right; x++)
			{
				for (int y = top; y <= bottom; y++)
				{
					int type = Main.tile[x, y].type;
					if (type == mod.TileType("WingoftheWorld"))
					{
						score++;
					}
				}
			}
			return score > 0;
		}
 
        public override string TownNPCName()
        {
            string Angela = Language.GetTextValue("Mods.AlchemistNPC.Angela");
			switch (WorldGen.genRand.Next(1))
            {
                case 0:
                    return Angela;
                default:
                    return Angela;
            }
        }
 
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (!Main.hardMode)
			{
			damage = 20;
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			damage = 75;
			}
			if (NPC.downedMoonlord)
			{
			damage = 500;
			}
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			attackDelay = 10;
			if (!Main.hardMode)
			{
			projType = mod.ProjectileType("BB");
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			projType = mod.ProjectileType("FDB");
			}
			if (NPC.downedMoonlord)
			{
			projType = mod.ProjectileType("MB");
			}
			
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			closeness = 20;
			if (!Main.hardMode)
			{
			item = mod.ItemType("TheBeak");
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			item = mod.ItemType("FuneralofDeadButterflies");
			}
			if (NPC.downedMoonlord)
			{
			item = mod.ItemType("MagicBullet");
			}
		}
		
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
         string EntryO1 = Language.GetTextValue("Mods.AlchemistNPC.EntryO1");
		 string EntryO2 = Language.GetTextValue("Mods.AlchemistNPC.EntryO2");
		 string EntryO3 = Language.GetTextValue("Mods.AlchemistNPC.EntryO3");
		 string EntryO4 = Language.GetTextValue("Mods.AlchemistNPC.EntryO4");
		 string EntryO5 = Language.GetTextValue("Mods.AlchemistNPC.EntryO5");
		 string EntryO6 = Language.GetTextValue("Mods.AlchemistNPC.EntryO6");
		 string EntryO7 = Language.GetTextValue("Mods.AlchemistNPC.EntryO7");
		 string EntryO8 = Language.GetTextValue("Mods.AlchemistNPC.EntryO8");
		 string EntryO9 = Language.GetTextValue("Mods.AlchemistNPC.EntryO9");
		 string EntryO10 = Language.GetTextValue("Mods.AlchemistNPC.EntryO10");
		 string EntryO11 = Language.GetTextValue("Mods.AlchemistNPC.EntryO11");
		 string EntryO12 = Language.GetTextValue("Mods.AlchemistNPC.EntryO12");
		 string EntryO13 = Language.GetTextValue("Mods.AlchemistNPC.EntryO13");
		 string EntryO14 = Language.GetTextValue("Mods.AlchemistNPC.EntryO14");
		 string EntryO15 = Language.GetTextValue("Mods.AlchemistNPC.EntryO15");
		 string EntryO16 = Language.GetTextValue("Mods.AlchemistNPC.EntryO16");
		 string EntryO17 = Language.GetTextValue("Mods.AlchemistNPC.EntryO17");
		 string EntryO18 = Language.GetTextValue("Mods.AlchemistNPC.EntryO18");
		if (Main.bloodMoon)
			{
				switch (Main.rand.Next(3))
				{
				case 0:
				return EntryO14;
				case 1:
				return EntryO15;
				case 2:
				return EntryO16;
				}
			}
		if (Main.invasionType == 1)
			{
				return EntryO11;
			}
			if (Main.invasionType == 3)
			{
				return EntryO12;
			}
			if (Main.invasionType == 4)
			{
				return EntryO13;
			}
		if (Main.rand.Next(5) == 0)
		{
			if (!WorldGen.crimson)
			{
			return EntryO5;
			}
			if (WorldGen.crimson)
			{                
			return EntryO8;
			}
		}
		if (ModLoader.GetLoadedMods().Contains("CalamityMod") && NPC.downedBoss3)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO17;
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("CalamityMod") && NPC.downedMoonlord)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO18;
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
		{
			if (Main.rand.Next(6) == 0)
			{
				return EntryO2;
				
			} 
		}
		if (ModLoader.GetLoadedMods().Contains("ThoriumMod") && Main.hardMode)
		{
			if (Main.rand.Next(6) == 0)
			{
			return EntryO6;
			}
		}
		if (Main.rand.Next(5) == 0 && Main.hardMode)
			{
				switch (Main.rand.Next(2))
				{
                case 0:                                     
				return EntryO9;
                case 1:                                                      
				return EntryO10;
				}
			}
            switch (Main.rand.Next(4))
            {
                case 0:                                     
				return EntryO1;
                case 1:                                                      
				return EntryO3;
                case 2:
				return EntryO4;
                default:
				return EntryO7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string EGOShop = Language.GetTextValue("Mods.AlchemistNPC.EGOShop");
			string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPC.BossDropsShop");
			string TreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPC.TreasureBagsShop");
			string CycleShopO = Language.GetTextValue("Mods.AlchemistNPC.CycleShopO");
			if (Config.TS && Main.expertMode)
		{
			if (Shop1)
			{
			button = BossDropsShop;
			S3A = false;
			S1A = true;
			}
			if (Shop2)
			{
			button = EGOShop;
			S1A = false;
			S2A = true;
			}
			if (Shop3)
			{
			button = TreasureBagsShop;
			S2A = false;
			S3A = true;
			}
			button2 = CycleShopO;
		}
			if (!Config.TS || !Main.expertMode)
			{
			button = BossDropsShop;
			button2 = EGOShop;
			}
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				if (!Config.TS || !Main.expertMode)
					{
					Shop1 = true;
					Shop2 = false;
					shop = true;
					}
				if (Config.TS && Main.expertMode)
					{
					shop = true;
					}
			}
			else
			{
				if (Config.TS && Main.expertMode)
				{
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
						Shop1 = true;
						Shop3 = false;
						}
				}
				if (!Config.TS || !Main.expertMode)
					{
					Shop2 = true;
					Shop1 = false;
					shop = true;
					}
			}
		}
 
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.CalamityWorld.downedGuardians; }
		}
 
    public override void SetupShop(Chest shop, ref int nextSlot)
    {
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("OtherworldlyAmulet"))
						{
						OA = true;
						}
					}
				}
			}
			if (Shop1)
			{
				if (!WorldGen.crimson)
				{
				shop.item[nextSlot].SetDefaults (ItemID.DemoniteOre);
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.ShadowScale);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				}
				if (WorldGen.crimson)
				{
				shop.item[nextSlot].SetDefaults (ItemID.CrimtaneOre);
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.TissueSample);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				}
				if (NPC.downedQueenBee)
				{
				shop.item[nextSlot].SetDefaults (ItemID.BeeWax);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				}
				if (NPC.downedMechBossAny)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofLight);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.SoulofNight);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("DivineLava"));
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("CursedIce"));
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				}
				if (NPC.downedMechBoss1)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofMight);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				}
				if (NPC.downedMechBoss2)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofSight);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				}
				if (NPC.downedMechBoss3)
				{
				shop.item[nextSlot].SetDefaults (ItemID.SoulofFright);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
				{
				shop.item[nextSlot].SetDefaults (ItemID.HallowedBar);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				}
				if (NPC.downedGolemBoss)
				{
				shop.item[nextSlot].SetDefaults (ItemID.ShinyStone);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.BeetleHusk);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				}
				if (NPC.downedMoonlord && OA)
				{
				shop.item[nextSlot].SetDefaults (ItemID.FragmentSolar);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentNebula);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentVortex);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FragmentStardust);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				}
	}
		if (Shop2)
		{
		if (NPC.downedBoss3)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("TheBeak"));
			shop.item[nextSlot].shopCustomPrice = 200000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaRibbon"));
			shop.item[nextSlot].shopCustomPrice = 100000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaCoat"));
			shop.item[nextSlot].shopCustomPrice = 200000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaLeggings"));
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++;
			}
		if (NPC.downedMechBossAny)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("FuneralofDeadButterflies"));
			shop.item[nextSlot].shopCustomPrice = 350000;
			nextSlot++;
			}
		if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaGift"));
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				}
		if (NPC.downedPlantBoss)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("BigBirdLamp"));
			shop.item[nextSlot].shopCustomPrice = 750000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("GrinderMK4"));
			shop.item[nextSlot].shopCustomPrice = 500000;
			nextSlot++;
			}
		if (NPC.downedGolemBoss)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Spore"));
			shop.item[nextSlot].shopCustomPrice = 1000000;
			nextSlot++;
			}
		}
		if (Shop3)
		{
			if (NPC.downedBoss3 && Main.expertMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.KingSlimeBossBag);
			shop.item[nextSlot].shopCustomPrice = 250000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.EyeOfCthulhuBossBag);
			shop.item[nextSlot].shopCustomPrice = 500000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.EaterOfWorldsBossBag);
			shop.item[nextSlot].shopCustomPrice = 750000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.BrainOfCthulhuBossBag);
			shop.item[nextSlot].shopCustomPrice = 750000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.QueenBeeBossBag);
			shop.item[nextSlot].shopCustomPrice = 1000000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SkeletronBossBag);
			shop.item[nextSlot].shopCustomPrice = 1500000;
			nextSlot++;
			}
			if (Main.hardMode && Main.expertMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.WallOfFleshBossBag);
			shop.item[nextSlot].shopCustomPrice = 2000000;
			nextSlot++;
			}
			if (NPC.downedPlantBoss && Main.expertMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.DestroyerBossBag);
			shop.item[nextSlot].shopCustomPrice = 2000000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.TwinsBossBag);
			shop.item[nextSlot].shopCustomPrice = 2000000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SkeletronPrimeBossBag);
			shop.item[nextSlot].shopCustomPrice = 2000000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.PlanteraBossBag);
			shop.item[nextSlot].shopCustomPrice = 3000000;
			nextSlot++;
			}
			if (NPC.downedMoonlord && Main.expertMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.GolemBossBag);
			shop.item[nextSlot].shopCustomPrice = 3000000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FishronBossBag);
			shop.item[nextSlot].shopCustomPrice = 4000000;
			nextSlot++;
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
						if(CalamityModDownedGuardian)
						{
						shop.item[nextSlot].SetDefaults (ItemID.MoonLordBossBag);
						shop.item[nextSlot].shopCustomPrice = 7500000;
						nextSlot++;
						}
					}
		}
	}
}
}