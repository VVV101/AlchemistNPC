using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class YoungBrewer : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/YoungBrewer";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Young Brewer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Young Brewer");
			DisplayName.AddTranslation(GameCulture.Russian, "Юный зельевар");
            DisplayName.AddTranslation(GameCulture.Chinese, "年轻药剂师");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 20;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 2;

            ModTranslation text = mod.CreateTranslation("Harold");
            text.SetDefault("Harold");
            text.AddTranslation(GameCulture.Russian, "Гарольд");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Charles");
            text.SetDefault("Charles");
            text.AddTranslation(GameCulture.Russian, "Чарльз");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Monty");
            text.SetDefault("Monty");
            text.AddTranslation(GameCulture.Russian, "Монти");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Lucas");
            text.SetDefault("Lucas");
            text.AddTranslation(GameCulture.Russian, "Лукас");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Porky");
            text.SetDefault("Porky");
            text.AddTranslation(GameCulture.Russian, "Порки");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Leeland");
            text.SetDefault("Leeland");
            text.AddTranslation(GameCulture.Russian, "Леланд");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry1");
            text.SetDefault("I'm trading potions which were made by my parents.");
            text.AddTranslation(GameCulture.Russian, "Я продаю зелья, которые были сделаны моими родителями.");
            text.AddTranslation(GameCulture.Chinese, "我出售我父母做的药剂.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry2");
            text.SetDefault("I have some potions I can sell to you.");
            text.AddTranslation(GameCulture.Russian, "У есть несколько зелий, которые я могу продать тебе.");
            text.AddTranslation(GameCulture.Chinese, "我有一些药水可以卖给你");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry3");
            text.SetDefault("Although, the Battle Combination was my idea.");
            text.AddTranslation(GameCulture.Russian, "Так или иначе, это я придумал Боевую Комбинацию.");
            text.AddTranslation(GameCulture.Chinese, "战斗药剂包是我的主意.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry4");
            text.SetDefault("There's a legendary yoyo known as the Sasscade.");
            text.AddTranslation(GameCulture.Russian, "Существует Легендарное Йо-йо, известное как Сасскад.");
            text.AddTranslation(GameCulture.Chinese, "有一个传说中的溜溜球被称为Sasscadee.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry5");
            text.SetDefault("Strange Brew from Skeleton Merchant smells really terrible, but Mana Restoration effect is awesome.");
            text.AddTranslation(GameCulture.Russian, "Странное варево от Торговца-Скелета пахнет просто ужасно, но оно потрясающе восстанавливает ману.");
            text.AddTranslation(GameCulture.Chinese, "来自骷髅商人的奇异啤酒气味真的很糟糕，但法力恢复效果是可怕的.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry6");
            text.SetDefault("Hi, *cough*.. That definetly wasn't a lemonade.");
            text.AddTranslation(GameCulture.Russian, "Привет, *кашель*.. Это определённо был не лимонад.");
            text.AddTranslation(GameCulture.Chinese, "嗨, *咳咳*.. 那绝对不是柠檬茶.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry7");
            text.SetDefault("Have you seen a Mechanical Worm around?");
            text.AddTranslation(GameCulture.Russian, "Ты не видел Механического Червя поблизости?");
            text.AddTranslation(GameCulture.Chinese, "你有在附近见到钢铁破坏者吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry8");
            text.SetDefault("My mom, ");
            text.AddTranslation(GameCulture.Russian, "Разве моя мама, ");
            text.AddTranslation(GameCulture.Chinese, "我妈妈, ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Entry9");
            text.SetDefault(", is the coolest brewer ever, isn't she? She can brew the hardest potions with ease.");
            text.AddTranslation(GameCulture.Russian, ", не самая лучшая Зельеварщица на свете? Она может сварить любые сложнейшие зелья с лёгкостью!");
            text.AddTranslation(GameCulture.Chinese, " , 是最酷的药剂师, 不是吗? 她可以轻松酿造出难做的药剂.");
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
			animationType = NPCID.Angler;
		}
		
public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (Main.hardMode)
			{
				if (NPC.AnyNPCs(mod.NPCType("Brewer")))
				{
					if (NPC.AnyNPCs(mod.NPCType("Alchemist")))
					{
							return true;
					}
				}
			}
			return false;
		}
 
 
        public override string TownNPCName()
        {                                       //NPC names
            string Harold = Language.GetTextValue("Mods.AlchemistNPC.Harold");
			string Charles = Language.GetTextValue("Mods.AlchemistNPC.Charles");
			string Monty = Language.GetTextValue("Mods.AlchemistNPC.Monty");
			string Lucas = Language.GetTextValue("Mods.AlchemistNPC.Lucas");
			string Porky = Language.GetTextValue("Mods.AlchemistNPC.Porky");
			string Leeland = Language.GetTextValue("Mods.AlchemistNPC.Leeland");
			switch (WorldGen.genRand.Next(5))
            {
                case 0:
                    return Harold;
                case 1:
                    return Charles;
                case 2:
                    return Monty;
                case 3:
                    return Lucas;
				case 4:
                    return Porky;
                default:
                    return Leeland;
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
			randomOffset = 2f;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
        string Entry1 = Language.GetTextValue("Mods.AlchemistNPC.Entry1");
		string Entry2 = Language.GetTextValue("Mods.AlchemistNPC.Entry2");
		string Entry3 = Language.GetTextValue("Mods.AlchemistNPC.Entry3");
		string Entry4 = Language.GetTextValue("Mods.AlchemistNPC.Entry4");
		string Entry5 = Language.GetTextValue("Mods.AlchemistNPC.Entry5");
		string Entry6 = Language.GetTextValue("Mods.AlchemistNPC.Entry6");
		string Entry7 = Language.GetTextValue("Mods.AlchemistNPC.Entry7");
		string Entry8 = Language.GetTextValue("Mods.AlchemistNPC.Entry8");
		string Entry9 = Language.GetTextValue("Mods.AlchemistNPC.Entry9");
		int Brewer = NPC.FindFirstNPC(mod.NPCType("Brewer"));
			if (Brewer >= 0 && Main.rand.Next(4) == 0)
			{
				return Entry8 + Main.npc[Brewer].GivenName + Entry9;
			}
            switch (Main.rand.Next(7))
            {
                case 0:                                     
				return Entry1;
                case 1:
				return Entry2;
                case 2:                                                      
				return Entry3;
                case 3:
				return Entry4;
                case 4:                                     
				return Entry5;
                case 5:
				return Entry6;
                default:
				return Entry7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }
 
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("VanTankCombination"));
			shop.item[nextSlot].shopCustomPrice = 90000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("TankCombination"));
			shop.item[nextSlot].shopCustomPrice = 160000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BattleCombination"));
			shop.item[nextSlot].shopCustomPrice = 120000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("RangerCombination"));
			shop.item[nextSlot].shopCustomPrice = 75000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("MageCombination"));
			shop.item[nextSlot].shopCustomPrice = 90000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BuilderCombination"));
			shop.item[nextSlot].shopCustomPrice = 35000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("ExplorerCombination"));
			shop.item[nextSlot].shopCustomPrice = 80000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("SummonerCombination"));
			shop.item[nextSlot].shopCustomPrice = 30000;
            nextSlot++;
			if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
			{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("FishingCombination"));
			shop.item[nextSlot].shopCustomPrice = 100000;
            nextSlot++;
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (NPC.downedGolemBoss)
				{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("CalamityCombination"));
			shop.item[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
				}
			}
			if (NPC.downedMoonlord)
			{
			shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("UniversalCombination"));
			shop.item[nextSlot].shopCustomPrice = 500000;
			nextSlot++;
			}
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofPoison);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofFire);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofParty);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofGold);
			shop.item[nextSlot].shopCustomPrice = 15000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofIchor);
			shop.item[nextSlot].shopCustomPrice = 25000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofCursedFlames);
			shop.item[nextSlot].shopCustomPrice = 25000;
			nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofVenom);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FlaskofNanites);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;	
			}
			bool WA = false;
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("WatcherAmulet") && ModLoader.GetMod("AlchemistNPCContentDisabler") == null)
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("RainbowFlask"));
						shop.item[nextSlot].shopCustomPrice = 1000000;
						nextSlot++;
						WA = true;
						}
						if (player.inventory[j].type == mod.ItemType("Autoinjector") && !WA)
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("RainbowFlask"));
						shop.item[nextSlot].shopCustomPrice = 1000000;
						nextSlot++;
						}
					}
				}
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBrew"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
				}
			}
	if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GasContainer"));
				shop.item[nextSlot].shopCustomPrice = 200;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CorrosionBeaker"));
				shop.item[nextSlot].shopCustomPrice = 350;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CombustionFlask"));
				shop.item[nextSlot].shopCustomPrice = 350;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("NitrogenVial"));
				shop.item[nextSlot].shopCustomPrice = 350;
				nextSlot++;
				}	
			}
    }
}
}
