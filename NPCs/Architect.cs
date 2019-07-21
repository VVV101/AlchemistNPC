using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC.NPCs;
using AlchemistNPC.Interface;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Architect : ModNPC
	{
		public static int Shop = 1;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Architect";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Architect";
			return AlchemistNPC.modConfiguration.ArchitectSpawn;
		}

		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Architect");
            DisplayName.AddTranslation(GameCulture.Chinese, "建筑师");
            Main.npcFrameCount[npc.type] = 26;   
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 100;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 35;
			NPCID.Sets.AttackAverageChance[npc.type] = 50;
			NPCID.Sets.HatOffsetY[npc.type] = -4;

            ModTranslation text = mod.CreateTranslation("Joe");
            text.SetDefault("Joe");
            text.AddTranslation(GameCulture.Russian, "Джо");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Mark");
            text.SetDefault("Mark");
            text.AddTranslation(GameCulture.Russian, "Марк");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Walter");
            text.SetDefault("Walter");
            text.AddTranslation(GameCulture.Russian, "Вальтер");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Archer");
            text.SetDefault("Archer");
            text.AddTranslation(GameCulture.Russian, "Арчер");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Frido");
            text.SetDefault("Frido");
            text.AddTranslation(GameCulture.Russian, "Фридо");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Li");
            text.SetDefault("Li");
            text.AddTranslation(GameCulture.Russian, "Ли");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("Bob");
            text.SetDefault("Bob");
            text.AddTranslation(GameCulture.Russian, "Боб");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A1");
            text.SetDefault("If this dastardly ");
            text.AddTranslation(GameCulture.Russian, "Если эта трусливая ");
            text.AddTranslation(GameCulture.Chinese, "如果这个卑鄙的 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A2");
            text.SetDefault(" isn't going to shut up, I'm letting ");
            text.AddTranslation(GameCulture.Russian, " не замолчит, я позволю ");
            text.AddTranslation(GameCulture.Chinese, " 再不住口的话, 我会让 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A3");
            text.SetDefault(" bite her.");
            text.AddTranslation(GameCulture.Russian, " укусить её.");
            text.AddTranslation(GameCulture.Chinese, " 咬她.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A4");
            text.SetDefault("KILL THE ZOMBIES! KILL THE BUNNIES! IN THE NAME OF THE BLOO- oh sorry I didn't notice you here.");
            text.AddTranslation(GameCulture.Russian, "УБИВАЙ ЗОМБИ! УБИВАЙ КРОЛИКОВ! ВО ИМЯ КРОВ-- Ой прости, я не заметил, что ты здесь.");
            text.AddTranslation(GameCulture.Chinese, "杀掉那个僵尸! 杀掉那个兔子! 那个名字是血- 哦, 抱歉, 我没注意到你在这里.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A5");
            text.SetDefault("Why hello there I'm just getting some blood buckets for a lake I'm making pleasedontaskanymorequestions");
            text.AddTranslation(GameCulture.Russian, "Привет. Я просто собираю несколько вёдер крови для озера. Пожалуйста, большеничегонеспрашивай.");
            text.AddTranslation(GameCulture.Chinese, "哦嗨你好我正在为一个湖收集一些装满血的水桶我很开心所以别问我更多问题了再见.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A6");
            text.SetDefault("I like it when there is a gigantic horde of zombies behind our doors. But I HATE WHEN THEY BREAK MY DOORS!");
            text.AddTranslation(GameCulture.Russian, "Я люблю, когда за нашими дверями огромная орда зомби. Но Я НЕНАВИЖУ КОГДА ОНИ ИХ ЛОМАЮТ!");
            text.AddTranslation(GameCulture.Chinese, "当有一大堆僵尸在我的门后面时我很喜欢它，但是当它们打破我的门时我恨它!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A7");
            text.SetDefault("Ah, the feeling that I'm not safe, the paranoia is embraced the moment the bloodmoon rises up in the sky.");
            text.AddTranslation(GameCulture.Russian, "Ах, это чувство отсутствия безопасности, паранойя, которая подчёркивается моментом, когда кровавая луна восходит на небосводе.");
            text.AddTranslation(GameCulture.Chinese, "啊哈, 这种不安全的感觉, 偏执狂热爱这种血月在空中的感觉.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A8");
            text.SetDefault("Are you interested in my religion? It invloves sacrifices to the bloody moon.");
            text.AddTranslation(GameCulture.Russian, "Ты заинтересован в моей религии? У нас есть жертвы Кровавой Луне.");
            text.AddTranslation(GameCulture.Chinese, "你对我的信仰感兴趣吗? 它涉及对血月的牺牲.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A9");
            text.SetDefault("Do you know why I hate these goblins? They are mildly annoying.");
            text.AddTranslation(GameCulture.Russian, "Знаешь, почему я ненавижу этих гоблинов? Они ужасно раздражающие.");
            text.AddTranslation(GameCulture.Chinese, "你知道为毛我恨这些哥布林嘛? 他们太鸡儿吵了.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A10");
            text.SetDefault("Hooray to pirates! They supply me with my golden furniture!");
            text.AddTranslation(GameCulture.Russian, "Ура пиратам! Они привозят мне золотую мебель!");
            text.AddTranslation(GameCulture.Chinese, "海盗万岁! 他们给我供应金家具!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A11");
            text.SetDefault("Ah! Finally some proper plating to finish off my roof!");
            text.AddTranslation(GameCulture.Russian, "Ах! Наконец-то хорошое покрытие для моей крыши готово!");
            text.AddTranslation(GameCulture.Chinese, "啊哈! 最后进行一些适当的电镀来完成我的屋顶!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A12");
            text.SetDefault("No explosives please, ");
            text.AddTranslation(GameCulture.Russian, "Никакой взрывчатки, пожалуйста, ");
            text.AddTranslation(GameCulture.Chinese, "请不要乱炸OK? ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A13");
            text.SetDefault(" is already annoying me enough.");
            text.AddTranslation(GameCulture.Russian, " и так достаточно раздражает меня.");
            text.AddTranslation(GameCulture.Chinese, " 已经够烦了.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A14");
            text.SetDefault("BUILDER POTIONS FREE FOR EVERYONE but you.");
            text.AddTranslation(GameCulture.Russian, "БЕСПЛАТНЫЕ ЗЕЛЬЯ СТРОИТЕЛЯ ДЛЯ ВСЕХ кроме тебя.");
            text.AddTranslation(GameCulture.Chinese, "建筑药水对所有人免费, 除了你.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A15");
            text.SetDefault("What? Where I got my architect degree? There's an architect degree?");
            text.AddTranslation(GameCulture.Russian, "Что? Где я получил диплом архитектора? Такие вообще существуют?");
            text.AddTranslation(GameCulture.Chinese, "什么玩意儿? 我去哪里搞到我的建筑师学位? 有建筑师学位吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A16");
            text.SetDefault("Did'ja know that wood somehow doesn't burn? Though under certain circumstances it does. Weird...");
            text.AddTranslation(GameCulture.Russian, "Ты знаешь, что дерево каким-то образом не горит? Хотя при некоторых условиях оно может. Странно...");
            text.AddTranslation(GameCulture.Chinese, "你知道木头怎么才不会烧着吗? 经过一系列操作之后的确不会. 真的怪...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A17");
            text.SetDefault("No, I am not the guy. I'm the dude.");
            text.AddTranslation(GameCulture.Russian, "Нет, я не парень. Я чувак.");
            text.AddTranslation(GameCulture.Chinese, "不, 我不是家伙(guy). 我是老兄(dude).");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A18");
            text.SetDefault("Well, the one you recently made was ALMOST impressive. (not really)");
            text.AddTranslation(GameCulture.Russian, "Ну, то, что ты недавно построил было почти впечатляющим. (на самом деле НЕТ)");
            text.AddTranslation(GameCulture.Chinese, "嗯, 你最近做的一件事情几乎让人印象深刻. (不存在的)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A19");
            text.SetDefault("So, you say that chests are furniture too. I reply: Screw you.");
            text.AddTranslation(GameCulture.Russian, "Так ты утверждаешь, что сундуки - это тоже мебель. Я тебе отвечу: Пошёл ты.");
            text.AddTranslation(GameCulture.Chinese, "所以, 你说箱子也是家具. 我表示: 去你丫的.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("A20");
            text.SetDefault("I saw your buildings but I am still not impressed");
            text.AddTranslation(GameCulture.Russian, "Я видел твои постройки, но я всё ещё не впечатлён.");
            text.AddTranslation(GameCulture.Chinese, "我看了你的建筑, 但是我仍然觉得不怎么样.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("A21");
            text.SetDefault("Have you heard 'bout that FuryForged guy? I taught him all he knows!");
            text.AddTranslation(GameCulture.Russian, "Ты слышал об этом FuryForged? Я научил его всему, что он знает!");
            text.AddTranslation(GameCulture.Chinese, "你听说过一个叫FuryForged的家伙吗?他的一切东西都是我教的");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("A22");
            text.SetDefault("I was once hired by a certain company to build a supermassive hi-tech, hi-security installation. Lemme tell ya its my magnum opus in terms of security and containment.");
            text.AddTranslation(GameCulture.Russian, "Как-то раз я был нанят одной компанией, чтобы построить огромный высокотехнологичный комплекс с высочайщей степенью безопасности. Это была моя самая лучшая работа в плане сдерживания и безопасности.");
            text.AddTranslation(GameCulture.Chinese, "我曾经被一家公司雇用来建造一个超大规模的高科技，高安全性装置。 让我告诉你我在安全性和阻挡入侵方面我的巨大建树。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("AS1");
            text.SetDefault("1st shop (Filler Blocks)       ");
            text.AddTranslation(GameCulture.Russian, "1-ый магазин (Обычные Блоки)");
            text.AddTranslation(GameCulture.Chinese, "第一商店 (填充方块)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS2");
            text.SetDefault("2nd shop (Building Blocks)     ");
            text.AddTranslation(GameCulture.Russian, "2-ой магазин (Строительные Блоки)");
            text.AddTranslation(GameCulture.Chinese, "第二商店 (建筑方块)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS3");
            text.SetDefault("3rd shop (Basic Furniture)     ");
            text.AddTranslation(GameCulture.Russian, "3-ий магазин (Базовая мебель)");
            text.AddTranslation(GameCulture.Chinese, "第三商店 (基础家具)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS4");
            text.SetDefault("4th shop (Advanced Furniture)  ");
            text.AddTranslation(GameCulture.Russian, "4-ый магазин (Продвинутая мебель)");
            text.AddTranslation(GameCulture.Chinese, "第四商店 (高级家具)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS5");
            text.SetDefault("5th shop (Torches)             ");
            text.AddTranslation(GameCulture.Russian, "5-ый магазин (Факелы)");
            text.AddTranslation(GameCulture.Chinese, "第五商店 (火把)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS6");
            text.SetDefault("6th shop (Candles)             ");
            text.AddTranslation(GameCulture.Russian, "6-ый магазин (Свечи)");
            text.AddTranslation(GameCulture.Chinese, "第六商店 (蜡烛)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS7");
            text.SetDefault("7th shop (Lamps)               ");
            text.AddTranslation(GameCulture.Russian, "7-ой магазин (Лампы)");
            text.AddTranslation(GameCulture.Chinese, "第七商店 (台灯)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS8");
            text.SetDefault("8th shop (Lanterns)            ");
            text.AddTranslation(GameCulture.Russian, "8-ой магазин (Фонари)");
            text.AddTranslation(GameCulture.Chinese, "第八商店 (灯笼)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS9");
            text.SetDefault("9th shop (Chandeliers)         ");
            text.AddTranslation(GameCulture.Russian, "9-ый магазин (Люстры)");
            text.AddTranslation(GameCulture.Chinese, "第九商店 (吊灯)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("AS10");
            text.SetDefault("10th shop (Candelabras)        ");
            text.AddTranslation(GameCulture.Russian, "10-ый магазин (Канделябры)");
            text.AddTranslation(GameCulture.Chinese, "第十商店 (烛台)");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ShopsChanger");
            text.SetDefault("Shops Changer");
            text.AddTranslation(GameCulture.Russian, "Смена магазина");
            text.AddTranslation(GameCulture.Chinese, "切换商店");
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
			animationType = NPCID.Guide;
        }
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (numTownNPCs >= 5 && NPC.downedBoss2 && AlchemistNPC.modConfiguration.ArchitectSpawn)
                {
                 return true;
                }
            return false;
        }

 
        public override string TownNPCName()
        {                                       //NPC names
            string Joe = Language.GetTextValue("Mods.AlchemistNPC.Joe");
			string Mark = Language.GetTextValue("Mods.AlchemistNPC.Mark");
			string Walter = Language.GetTextValue("Mods.AlchemistNPC.Walter");
			string Archer = Language.GetTextValue("Mods.AlchemistNPC.Archer");
			string Frido = Language.GetTextValue("Mods.AlchemistNPC.Frido");
			string Bob = Language.GetTextValue("Mods.AlchemistNPC.Bob");
			string Li = Language.GetTextValue("Mods.AlchemistNPC.Li");
			switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    return Joe;
                case 1:
                    return Mark;
                case 2:
                    return Walter;
                case 3:
                    return Archer;
				case 4:
                    return Frido;
				case 5:
                    return Bob;
                default:
                    return Li;
            }
        }
 
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 10;
			knockback = 8f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). ItemType is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
		{
			scale = 1f;
			item = Main.itemTexture[ItemID.IronHammer]; //this defines the item that this npc will use
			itemSize = 40;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
		{
			itemWidth = 50;
			itemHeight = 50;
		}
 
        public override string GetChat()
        {                                          //npc chat
			string A1 = Language.GetTextValue("Mods.AlchemistNPC.A1");
			string A2 = Language.GetTextValue("Mods.AlchemistNPC.A2");
			string A3 = Language.GetTextValue("Mods.AlchemistNPC.A3");	
			string A4 = Language.GetTextValue("Mods.AlchemistNPC.A4");	
			string A5 = Language.GetTextValue("Mods.AlchemistNPC.A5");	
			string A6 = Language.GetTextValue("Mods.AlchemistNPC.A6");	
			string A7 = Language.GetTextValue("Mods.AlchemistNPC.A7");	
			string A8 = Language.GetTextValue("Mods.AlchemistNPC.A8");	
			string A9 = Language.GetTextValue("Mods.AlchemistNPC.A9");	
			string A10 = Language.GetTextValue("Mods.AlchemistNPC.A10");	
			string A11 = Language.GetTextValue("Mods.AlchemistNPC.A11");	
			string A12 = Language.GetTextValue("Mods.AlchemistNPC.A12");	
			string A13 = Language.GetTextValue("Mods.AlchemistNPC.A13");	
			string A14 = Language.GetTextValue("Mods.AlchemistNPC.A14");	
			string A15 = Language.GetTextValue("Mods.AlchemistNPC.A15");	
			string A16 = Language.GetTextValue("Mods.AlchemistNPC.A16");	
			string A17 = Language.GetTextValue("Mods.AlchemistNPC.A17");	
			string A18 = Language.GetTextValue("Mods.AlchemistNPC.A18");	
			string A19 = Language.GetTextValue("Mods.AlchemistNPC.A19");
			string A20 = Language.GetTextValue("Mods.AlchemistNPC.A20");
			string A21 = Language.GetTextValue("Mods.AlchemistNPC.A21");
			string A22 = Language.GetTextValue("Mods.AlchemistNPC.A22");				
			
			int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
			int Operator = NPC.FindFirstNPC(mod.NPCType("Operator"));
			if (Main.bloodMoon && partyGirl >= 0 && goblinTinkerer >=0 && Main.rand.Next(4) == 0)
			{
			return A1 + Main.npc[partyGirl].GivenName + A2 + Main.npc[goblinTinkerer].GivenName + A3;
			}
			if (Main.bloodMoon)
			{
				switch (Main.rand.Next(4))
				{
				case 0:
				return A4;
                case 1:
				return A5;
				case 2:
				return A6;
				case 3:
				return A7;
				case 4:
				return A8;
				}
			}
			if (Main.invasionType == 1)
			{
				return A9;
			}
			if (Main.invasionType == 3)
			{
				return A10;
			}
			if (Main.invasionType == 4)
			{
				return A11;
			}
            if (demolitionist >= 0 && Main.rand.Next(5) == 0)
			{
			return A12 + Main.npc[demolitionist].GivenName + A13;
			}
			if (Operator >= 0 && Main.rand.Next(7) == 0)
			{
			return A21;
			}
            switch (Main.rand.Next(8))
            {                
                case 0:
				return A14;
                case 1:
				return A15;
                case 2:
				return A16;
                case 3:
				return A17;
                case 4:
				return A18;
				case 5:
				return A19;
				case 6:
				return A21;
                default:
				return A20;
            }
	}
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
			string AS1 = Language.GetTextValue("Mods.AlchemistNPC.AS1");
			string AS2 = Language.GetTextValue("Mods.AlchemistNPC.AS2");
			string AS3 = Language.GetTextValue("Mods.AlchemistNPC.AS3");
			string AS4 = Language.GetTextValue("Mods.AlchemistNPC.AS4");
			string AS5 = Language.GetTextValue("Mods.AlchemistNPC.AS5");
			string AS6 = Language.GetTextValue("Mods.AlchemistNPC.AS6");
			string AS7 = Language.GetTextValue("Mods.AlchemistNPC.AS7");
			string AS8 = Language.GetTextValue("Mods.AlchemistNPC.AS8");
			string AS9 = Language.GetTextValue("Mods.AlchemistNPC.AS9");
			string AS10 = Language.GetTextValue("Mods.AlchemistNPC.AS10");
			string ShopsChanger = Language.GetTextValue("Mods.AlchemistNPC.ShopsChanger");
			if (Shop == 1)
			{
			button = AS1;
			}
			if (Shop == 2)
			{
			button = AS2;
			}
			if (Shop == 3)
			{
			button = AS3;
			}
			if (Shop == 4)
			{
			button = AS4;
			}
			if (Shop == 5)
			{
			button = AS5;
			}
			if (Shop == 6)
			{
			button = AS6;
			}
			if (Shop == 7)
			{
			button = AS7;
			}
			if (Shop == 8)
			{
			button = AS8;
			}
			if (Shop == 9)
			{
			button = AS9;
			}
			if (Shop == 10)
			{
			button = AS10;
			}
			button2 = ShopsChanger;
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop) 
		{
		if (firstButton)
            {
                shop = true;
				ShopChangeUIA.visible = false;
            }
		else
			{
				ShopChangeUIA.visible = true;
			}
		}

        Mod chadsfurniture = ModLoader.GetMod("chadsfurni");

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (Shop == 1)
			{
				shop.item[nextSlot].SetDefaults (ItemID.DirtBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.ClayBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.StoneBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.EbonstoneBlock);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.CrimstoneBlock);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				if (NPC.downedQueenBee)
				{
					shop.item[nextSlot].SetDefaults (ItemID.Hive);
					shop.item[nextSlot].shopCustomPrice = 10;
					nextSlot++;
				}
				shop.item[nextSlot].SetDefaults (ItemID.SandBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.EbonsandBlock);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.CrimsandBlock);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Sandstone);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.HardenedSand);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.MudBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.DesertFossil);
				shop.item[nextSlot].shopCustomPrice = 1000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Obsidian);
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.AshBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.SiltBlock);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.SnowBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.IceBlock);
				shop.item[nextSlot].shopCustomPrice = 1;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Marble);
				shop.item[nextSlot].shopCustomPrice = 50;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Granite);
				shop.item[nextSlot].shopCustomPrice = 50;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Cloud);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.RainCloud);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				if (Main.hardMode)
				{		
					shop.item[nextSlot].SetDefaults (ItemID.PearlstoneBlock);
					shop.item[nextSlot].shopCustomPrice = 25;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.PearlsandBlock);
					shop.item[nextSlot].shopCustomPrice = 25;
					nextSlot++;
				}
			}
			if (Shop == 2)
			{
				shop.item[nextSlot].SetDefaults (ItemID.RedBrick);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Wood);
				shop.item[nextSlot].shopCustomPrice = 5;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Ebonwood);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Shadewood);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.BorealWood);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.PalmWood);
				shop.item[nextSlot].shopCustomPrice = 15;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.RichMahogany);
				shop.item[nextSlot].shopCustomPrice = 15;
				nextSlot++;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (NPC.downedGoblins)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("YewWood"));
					shop.item[nextSlot].shopCustomPrice = 500;
					nextSlot++;
				}
			}
			shop.item[nextSlot].SetDefaults (ItemID.DynastyWood);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.RedDynastyShingles);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.BlueDynastyShingles);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.Pearlwood);
			shop.item[nextSlot].shopCustomPrice = 25;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (ItemID.GrayBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Glass);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.MeteoriteBrick);
			shop.item[nextSlot].shopCustomPrice = 4;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.ObsidianBrick);
			shop.item[nextSlot].shopCustomPrice = 5;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.IridescentBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SnowBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SandstoneBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.EbonstoneBrick);
			shop.item[nextSlot].shopCustomPrice = 10;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.IceBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FleshBlock);
			shop.item[nextSlot].shopCustomPrice = 10;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.StoneSlab);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SandstoneSlab);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.MarbleBlock);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.GraniteBlock);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			if (NPC.downedQueenBee)
			{
				shop.item[nextSlot].SetDefaults (ItemID.HoneyBlock);
				shop.item[nextSlot].shopCustomPrice = 5;
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults (ItemID.CrystalBlock);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (ItemID.SunplateBlock);
			shop.item[nextSlot].shopCustomPrice = 25;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Pumpkin);
			shop.item[nextSlot].shopCustomPrice = 125;
			nextSlot++;
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PinkBrick);
				shop.item[nextSlot].shopCustomPrice = 50;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.GreenBrick);
				shop.item[nextSlot].shopCustomPrice = 50;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.BlueBrick);
				shop.item[nextSlot].shopCustomPrice = 50;
				nextSlot++;
			}
			if (NPC.downedMechBossAny)
			{
				shop.item[nextSlot].SetDefaults (ItemID.AsphaltBlock);
				shop.item[nextSlot].shopCustomPrice = 2;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.FleshBlock);
				shop.item[nextSlot].shopCustomPrice = 10;
           		nextSlot++;		
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults (ItemID.PearlstoneBrick);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.RainbowBrick);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot].SetDefaults (ItemID.LihzahrdBrick);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
			}
			if (NPC.downedMartians)
			{
				shop.item[nextSlot].SetDefaults (ItemID.MartianConduitPlating);
				shop.item[nextSlot].shopCustomPrice = 25;
				nextSlot++;
			}
			}
			if (Shop == 3)
			{
			shop.item[nextSlot].SetDefaults (ItemID.Candle);
			shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.GoldChandelier);
			shop.item[nextSlot].shopCustomPrice = 250;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.ChainLantern);
			shop.item[nextSlot].shopCustomPrice = 200;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Mannequin);
			shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Womannquin);
			shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Cobweb);
			shop.item[nextSlot].shopCustomPrice = 20;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WorkBench);
			shop.item[nextSlot].shopCustomPrice = 2000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WoodenTable);
			shop.item[nextSlot].shopCustomPrice = 2000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WoodenChair);
			shop.item[nextSlot].shopCustomPrice = 2000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WoodenDoor);
			shop.item[nextSlot].shopCustomPrice = 2000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.WoodenBeam);
			shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Book);
			shop.item[nextSlot].shopCustomPrice = 250;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Fireplace);
			shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Chimney);
			shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Furnace);
			shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.BanquetTable);
			shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.HeavyWorkBench);
			shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
			
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (ItemID.BrickLayer);
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.PortableCementMixer);
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.PaintSprayer);
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.ExtendoGrip);
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (3624);
			shop.item[nextSlot].shopCustomPrice = 150000;
            nextSlot++;
			}
			if (NPC.downedBoss3)
			{
			shop.item[nextSlot].SetDefaults (ItemID.Ruler);
			shop.item[nextSlot].shopCustomPrice = 25000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.EngineeringHelmet);
			shop.item[nextSlot].shopCustomPrice = 50000;
            nextSlot++;	
			}
		}
		if (Shop == 4)
		{
				shop.item[nextSlot].SetDefaults (ItemID.LivingLoom);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
			if (NPC.downedBoss3)
			{	
				shop.item[nextSlot].SetDefaults (ItemID.AlchemyTable);
				shop.item[nextSlot].shopCustomPrice = 33000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BoneWelder);
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				if (chadsfurniture != null)
				{
					shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("printer"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("printer3"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("wallomatic"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
				}
			}
			shop.item[nextSlot].SetDefaults(ItemID.GlassKiln);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.SkyMill);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.IceMachine);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			if (NPC.downedQueenBee)
			{
			shop.item[nextSlot].SetDefaults (ItemID.HoneyDispenser);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (ItemID.Sawmill);
			shop.item[nextSlot].shopCustomPrice = 2000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Loom);
			shop.item[nextSlot].shopCustomPrice = 2000;
			nextSlot++;
                if (Main.hardMode)
                {
                    if (chadsfurniture != null)
                    {
                        shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("RimpelstiltskinsLoom"));
                        shop.item[nextSlot].shopCustomPrice = 200000;
                        nextSlot++;
                    }
					shop.item[nextSlot].SetDefaults (ItemID.MeatGrinder);
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
                }
			if (NPC.downedMechBossAny)
			{
			shop.item[nextSlot].SetDefaults (ItemID.FleshCloningVaat);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
			shop.item[nextSlot].SetDefaults (ItemID.LihzahrdFurnace);
			shop.item[nextSlot].shopCustomPrice = 20000;
			nextSlot++;
			}
		}
		if (Shop == 5)
            {
			shop.item[nextSlot].SetDefaults (ItemID.Torch);
			shop.item[nextSlot].shopCustomPrice = 50;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.TikiTorch);
			shop.item[nextSlot].shopCustomPrice = 250;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (974);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (427);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (428);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1245);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (429);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (430);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (431);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (432);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (433);
			shop.item[nextSlot].shopCustomPrice = 300;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (523);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1333);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2274);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3004);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3045);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3114);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
		if (Shop == 6)
            {
			shop.item[nextSlot].SetDefaults (105);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (713);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1405);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1406);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1407);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2045);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2046);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2047);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2048);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2049);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2050);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (2051);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (2052);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2153);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2154);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2155);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2236);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2523);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2542);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2556);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2571);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2648);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2649);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2650);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2651);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			if (NPC.downedMartians)
			{
			shop.item[nextSlot].SetDefaults (2818);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
			shop.item[nextSlot].SetDefaults (3171);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3172);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (3173);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (3890);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
			}
		if (Shop == 7)
            {
			shop.item[nextSlot].SetDefaults (341);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2082);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2083);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2084);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2085);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2086);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2087);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (2088);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (2089);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2090);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2091);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2129);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2130);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2131);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2132);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2133);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2134);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2225);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2533);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2547);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2563);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2578);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2643);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2644);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2645);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2646);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2647);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			if (NPC.downedMartians)
			{
			shop.item[nextSlot].SetDefaults (2819);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2820);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (3135);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (3136);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3137);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (3892);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
			}
		if (Shop == 8)
            {
			shop.item[nextSlot].SetDefaults (136);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (344);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (347);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1390);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1391);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1392);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1393);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1394);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (1808);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2032);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2033);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2034);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2035);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2036);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2037);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2038);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (2039);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (2040);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2041);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2042);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2043);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2145);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2146);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2147);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2148);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2226);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2530);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2546);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2564);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2579);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2641);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2642);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2820);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3138);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (3139);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3140);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (3891);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
			}
		if (Shop == 9)
            {
			shop.item[nextSlot].SetDefaults (106);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (107);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (108);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (710);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (711);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (712);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2055);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2056);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2057);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2058);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2059);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2060);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (2061);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (2062);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2063);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2064);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2065);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2141);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2142);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2143);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2144);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2224);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2525);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2543);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2558);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2573);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2652);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2653);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2654);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2655);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2656);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2657);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (NPC.downedMartians)
			{
			shop.item[nextSlot].SetDefaults (2813);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			}
			shop.item[nextSlot].SetDefaults (3177);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3178);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (3179);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (3894);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			}
		if (Shop == 10)
            {
			shop.item[nextSlot].SetDefaults (349);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (714);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2092);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2093);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2094);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2095);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2096);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2097);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2098);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (2099);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (2100);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2101);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2102);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2103);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2149);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2150);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2151);
			shop.item[nextSlot].shopCustomPrice = 30000;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2152);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2227);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2522);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2541);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2555);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2570);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2664);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2665);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2666);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			shop.item[nextSlot].SetDefaults (2667);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (2668);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			if (NPC.downedMartians)
			{
			shop.item[nextSlot].SetDefaults (2825);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (3168);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3169);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (3170);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;	
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults (3893);
			shop.item[nextSlot].shopCustomPrice = 500;
			nextSlot++;
			}
			}
		}
	}
}
