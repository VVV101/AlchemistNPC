using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Jeweler : ModNPC
	{
		public static bool OH = false;
		public static bool SN = false;
		public static bool SN2 = false;
		public static bool SN3 = false;
		public static bool AS = false;
		public static bool TN1 = false;
		public static bool TN2 = false;
		public static bool TN3 = false;
		public static bool TN4 = false;
		public static bool TN5 = false;
		public static bool TN6 = false;
		public static bool TN7 = false;
		public static bool TN8 = false;
		public static bool TN9 = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Jeweler";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Jeweler";
			return Config.JewelerSpawn;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jeweler");
			DisplayName.AddTranslation(GameCulture.Russian, "Ювелир");
            DisplayName.AddTranslation(GameCulture.Chinese, "珠宝师");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -2;

            ModTranslation text = mod.CreateTranslation("ArenaShop");
            text.SetDefault("Arena Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин Арены");
            text.AddTranslation(GameCulture.Chinese, "阿瑞娜商店");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Carl");
            text.SetDefault("Carl");
            text.AddTranslation(GameCulture.Russian, "Карл");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("John");
            text.SetDefault("John");
            text.AddTranslation(GameCulture.Russian, "Джон");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("JanMare");
            text.SetDefault("JanMare");
            text.AddTranslation(GameCulture.Russian, "Жан-Маре");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("LuiFransua");
            text.SetDefault("LuiFransua");
            text.AddTranslation(GameCulture.Russian, "Луи-Франсуа");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Daniel");
            text.SetDefault("Daniel");
            text.AddTranslation(GameCulture.Russian, "Дэниел");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Charley");
            text.SetDefault("Charley");
            text.AddTranslation(GameCulture.Russian, "Чарли");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ1");
            text.SetDefault("I found some gems for selling. Would you check them?");
            text.AddTranslation(GameCulture.Russian, "Я собрал немного драгоценных камней на продажу. Посмотришь?");
            text.AddTranslation(GameCulture.Chinese, "我找到一些珠宝, 你想看看吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ2");
            text.SetDefault("Magic rings are not as powerful as Legendary Emblems, but still can give you some advantage against powerful creatures.");
            text.AddTranslation(GameCulture.Russian, "Волшебные кольца не так могущественны, как Легендарные Эмблемы, но всё ещё могут дать преимущество против могущественных созданий.");
            text.AddTranslation(GameCulture.Chinese, "魔法戒指并不像传说中的那样强大,但它仍然能给你对抗强大生物的力量");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ3");
            text.SetDefault("Ouch... what do you want, my friend?");
            text.AddTranslation(GameCulture.Russian, "Ай... Чего желаешь, мой друг?");
            text.AddTranslation(GameCulture.Chinese, "呦... 你想要什么,我的朋友?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ4");
            text.SetDefault("I can make a Diamond Ring for you.");
            text.AddTranslation(GameCulture.Russian, "Я могу сделать для тебя Бриллиантовое Кольцо.");
            text.AddTranslation(GameCulture.Chinese, "我可以为你做钻石戒指.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ5");
            text.SetDefault("No, I don't think that I'm somehow related to Skeleton Merchant.");
            text.AddTranslation(GameCulture.Russian, "Нет, я не думаю что хоть как-то связан со Скелетом-торговцем.");
            text.AddTranslation(GameCulture.Chinese, "不,不要认为我和骷髅商人有关系.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ6");
            text.SetDefault("If you somehow find all Magic Rings,then you could make the Omniring.");
            text.AddTranslation(GameCulture.Russian, "Если ты каким-то образом соберёшь все Магические кольца, то ты сможешь сделать Единое Кольцо.");
            text.AddTranslation(GameCulture.Chinese, "如果你找到了所有的魔法戒指,你可以制造欧姆尼戒指.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ7");
            text.SetDefault("Have you seen Mechanical Creatures?");
            text.AddTranslation(GameCulture.Russian, "Ты видел где-нибудь Механических Созданий?");
            text.AddTranslation(GameCulture.Chinese, "你在周围看到机械生物了吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ8");
            text.SetDefault("Did you notice that ");
            text.AddTranslation(GameCulture.Russian, "Ты замечал, что ");
            text.AddTranslation(GameCulture.Chinese, "你有没有注意到到我和 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryJ9");
            text.SetDefault(" and I look almost the same? It's because we're twin brothers.");
            text.AddTranslation(GameCulture.Russian, " и я очень похожи? Это потому что мы близнецы.");
            text.AddTranslation(GameCulture.Chinese, " 长得几乎一毛一样?这是因为我们是兄弟.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Combine");
            text.SetDefault("Combine notes");
            text.AddTranslation(GameCulture.Russian, "Соединить записки");
            text.AddTranslation(GameCulture.Chinese, "黏合笔记");
            mod.AddTranslation(text);
        }

		public override void ResetEffects()
		{
		SN = false;
		SN2 = false;
		SN3 = false;
		AS = false;
		TN1 = false;
		TN2 = false;
		TN3 = false;
		TN4 = false;
		TN5 = false;
		TN6 = false;
		TN7 = false;
		TN8 = false;
		TN9 = false;
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
            npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss1 && Config.JewelerSpawn)
			{
			return true;
			}
			return false;
		}
 
 
 
        public override string TownNPCName()
        {                                       //NPC names
            string Carl = Language.GetTextValue("Mods.AlchemistNPC.Carl");
			string John = Language.GetTextValue("Mods.AlchemistNPC.John");
			string JanMare = Language.GetTextValue("Mods.AlchemistNPC.JanMare");
			string LuiFransua = Language.GetTextValue("Mods.AlchemistNPC.LuiFransua");
			string Daniel = Language.GetTextValue("Mods.AlchemistNPC.Daniel");
			string Charley = Language.GetTextValue("Mods.AlchemistNPC.Charley");
			switch (WorldGen.genRand.Next(5))
            {
                case 0:
                    return Carl;
                case 1:
                    return John;
                case 2:
                    return JanMare;
                case 3:
                    return LuiFransua;
				case 4:
                    return Daniel;
                default:
                    return Charley;
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
			damage = 100;
			}
			if (NPC.downedMoonlord)
			{
			damage = 1000;
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
			projType = mod.ProjectileType("Gemstone");
			attackDelay = 3;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 0f;
		}
 
 
        public override string GetChat()
        {                                           //npc chat
         string EntryJ1 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ1");
		 string EntryJ2 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ2");
		 string EntryJ3 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ3");
		 string EntryJ4 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ4");
		 string EntryJ5 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ5");
		 string EntryJ6 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ6");
		 string EntryJ7 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ7");
		 string EntryJ8 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ8");
		 string EntryJ9 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ9");
		 int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
			if (Merchant >= 0 && Main.rand.Next(4) == 0)
			{
				return EntryJ8 + Main.npc[Merchant].GivenName + EntryJ9;
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				switch (Main.rand.Next(2))
				{
				case 0:
				return EntryJ2;
				case 1:
				return EntryJ6;
				}
			} 
            switch (Main.rand.Next(5))
            {
                case 0:                                     
				return EntryJ1;
                case 1:                                                      
				return EntryJ3;
                case 2:
				return EntryJ4;
                case 3:                                     
				return EntryJ5;
                default:
				return EntryJ7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ArenaShop = Language.GetTextValue("Mods.AlchemistNPC.ArenaShop");
			string Combine = Language.GetTextValue("Mods.AlchemistNPC.Combine");
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = ArenaShop;
			Player player = Main.player[Main.myPlayer];
			if (player.active)
			{
				for (int j = 0; j < player.inventory.Length; j++)
				{
					if (player.inventory[j].type == mod.ItemType("SecretNote"))
					{
						SN = true;
					}
					if (player.inventory[j].type == mod.ItemType("SecretNote2"))
					{
						SN2 = true;
					}
					if (player.inventory[j].type == mod.ItemType("SecretNote3"))
					{
						SN3 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote1"))
					{
						TN1 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote2"))
					{
						TN2 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote3"))
					{
						TN3 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote4"))
					{
						TN4 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote5"))
					{
						TN5 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote6"))
					{
						TN6 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote7"))
					{
						TN7 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote8"))
					{
						TN8 = true;
					}
					if (player.inventory[j].type == mod.ItemType("TornNote9"))
					{
						TN9 = true;
					}
				}
			}
			if (TN1 && TN2 && TN3 && !SN)
			{
			button2 = Combine;
			}
			if (TN4 && TN5 && TN6 && !SN2)
			{
			button2 = Combine;
			}
			if (TN7 && TN8 && TN9 && !SN3)
			{
			button2 = Combine;
			}
			if (SN && SN2 && SN3)
			{
			button2 = Combine;
			}
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				OH = true;
				AS = false;
				shop = true;
			}
		else
			{
				Player player = Main.player[Main.myPlayer];
				if (TN1 && TN2 && TN3 && !SN)
				{
					player.QuickSpawnItem(mod.ItemType("SecretNote"));
					shop = false;
					if (Main.player[Main.myPlayer].HasItem(mod.ItemType("TornNote1")))
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("TornNote1"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote2"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote3"))
							{
								inventory[k].stack--;
							}
						}
					}
				}
				if (TN4 && TN5 && TN6 && !SN2)
				{
					player.QuickSpawnItem(mod.ItemType("SecretNote2"));
					shop = false;
					if (Main.player[Main.myPlayer].HasItem(mod.ItemType("TornNote4")))
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("TornNote4"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote5"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote6"))
							{
								inventory[k].stack--;
							}
						}
					}
				}
				if (TN7 && TN8 && TN9 && !SN3)
				{
					player.QuickSpawnItem(mod.ItemType("SecretNote3"));
					shop = false;
					if (Main.player[Main.myPlayer].HasItem(mod.ItemType("TornNote7")))
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("TornNote7"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote8"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("TornNote9"))
							{
								inventory[k].stack--;
							}
						}
					}
				}
				if (SN && SN2 && SN3)
				{
					player.QuickSpawnItem(mod.ItemType("NotesBook"));
					shop = false;
					if (Main.player[Main.myPlayer].HasItem(mod.ItemType("SecretNote")))
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("SecretNote"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("SecretNote2"))
							{
								inventory[k].stack--;
							}
							if (inventory[k].type == mod.ItemType("SecretNote3"))
							{
								inventory[k].stack--;
							}
						}
					}
				}
				OH = false;
				AS = true;
				shop = true;
			}
		}
 
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
		if (OH)
		{
		shop.item[nextSlot].SetDefaults (ItemID.Amethyst);
		shop.item[nextSlot].shopCustomPrice = 1000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.Topaz);
		shop.item[nextSlot].shopCustomPrice = 1000;
		nextSlot++;
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Sapphire);
				shop.item[nextSlot].shopCustomPrice = 3000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Emerald);
				shop.item[nextSlot].shopCustomPrice = 3000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Amber);
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FossilOre);
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Opal"));
					shop.item[nextSlot].shopCustomPrice = 5000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Onyx"));
					shop.item[nextSlot].shopCustomPrice = 5000;
					nextSlot++;	
					}
				shop.item[nextSlot].SetDefaults (ItemID.BandofStarpower);
				shop.item[nextSlot].shopCustomPrice = 30000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.BandofRegeneration);
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				if (Main.netMode == 1 || Main.netMode == 2)
				{
				shop.item[nextSlot].SetDefaults (ItemID.LifeCrystal);
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
					if (NPC.downedGolemBoss)
					{
					shop.item[nextSlot].SetDefaults (ItemID.LifeFruit);
					shop.item[nextSlot].shopCustomPrice = 200000;
					nextSlot++;
					}
				}
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Ruby);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Diamond);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.DiamondRing);
				shop.item[nextSlot].shopCustomPrice = 2000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HorrifyingSkull"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				if (ModLoader.GetLoadedMods().Contains("Tremor"))
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Rupicide"));
					shop.item[nextSlot].shopCustomPrice = 5000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Opal"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					if (Main.hardMode)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MagiumShard"));
					shop.item[nextSlot].shopCustomPrice = 7500;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RuneBar"));
					shop.item[nextSlot].shopCustomPrice = 7500;
					nextSlot++;
					}
					if (NPC.downedMoonlord)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LapisLazuli"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						}
							}
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteEnergyCore"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;	
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BronzeFragments"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;	
						}
				if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("GraniteChunk"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;	
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("MarbleChunk"));
						shop.item[nextSlot].shopCustomPrice = 10000;
						nextSlot++;	
						}
			if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("AlchemistHorcrux"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("BrewerHorcrux"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("JewelerHorcrux"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ArchitectHorcrux"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("MusicianHorcrux"));
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
				}
			}
		}
		if (AS)
		{
		shop.item[nextSlot].SetDefaults (ItemID.Campfire);
		shop.item[nextSlot].shopCustomPrice = 5000;
		nextSlot++;
			if (NPC.downedBoss2)
			{
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Mistletoe"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;	
				}
			}
		if (NPC.downedBoss3)
			{
			shop.item[nextSlot].SetDefaults (ItemID.WaterBucket);
			shop.item[nextSlot].shopCustomPrice = 15000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.HoneyBucket);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.LavaBucket);
			shop.item[nextSlot].shopCustomPrice = 50000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.HeartLantern);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.StarinaBottle);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WaterCandle);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.PeaceCandle);
			shop.item[nextSlot].shopCustomPrice = 50000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Spike);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.DartTrap);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.GeyserTrap);
			shop.item[nextSlot].shopCustomPrice = 100000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SharpeningStation);
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (ItemID.BewitchingTable);
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.AmmoBox);
			shop.item[nextSlot].shopCustomPrice = 250000;
			nextSlot++;
if (Main.hardMode)
	{
			shop.item[nextSlot].SetDefaults (ItemID.CrystalBall);
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++; 
	}
if (NPC.downedGolemBoss)
	{
			shop.item[nextSlot].SetDefaults (ItemID.WoodenSpike);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SpearTrap);
			shop.item[nextSlot].shopCustomPrice = 50000;
			nextSlot++; 
			shop.item[nextSlot].SetDefaults (ItemID.SpikyBallTrap);
			shop.item[nextSlot].shopCustomPrice = 50000;
			nextSlot++; 
			shop.item[nextSlot].SetDefaults (ItemID.SuperDartTrap);
			shop.item[nextSlot].shopCustomPrice = 750000;
			nextSlot++; 
			shop.item[nextSlot].SetDefaults (ItemID.FlameTrap);
			shop.item[nextSlot].shopCustomPrice = 100000;
			nextSlot++; 
	}		
			}
		}
		}
	}
}
