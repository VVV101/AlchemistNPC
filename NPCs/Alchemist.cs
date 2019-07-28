using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Alchemist : ModNPC
	{
		public static bool baseShop = true;
		public static bool tremorShop = false;
		public static bool PS = false;
		public static bool AB = false;
		public static bool LE = false;
		public static bool Tantrum = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Alchemist";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Alchemist";
			return AlchemistNPC.modConfiguration.AlchemistSpawn;
		}
		
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Alchemist");
            DisplayName.AddTranslation(GameCulture.Russian, "Алхимик");
            DisplayName.AddTranslation(GameCulture.Chinese, "炼金师");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 22;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -4;

            ModTranslation text = mod.CreateTranslation("TremorShop");
            text.SetDefault("Tremor Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин Тремор мода");
            text.AddTranslation(GameCulture.Chinese, "震颤商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("GetCharm");
            text.SetDefault("Get Charm");
            text.AddTranslation(GameCulture.Russian, "Получить талисман");
			text.AddTranslation(GameCulture.Chinese, "获得符咒");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Edward");
            text.SetDefault("Edward");
            text.AddTranslation(GameCulture.Russian, "Эдвард");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Severus");
            text.SetDefault("Severus");
            text.AddTranslation(GameCulture.Russian, "Северус");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Horace");
            text.SetDefault("Horace");
            text.AddTranslation(GameCulture.Russian, "Гораций");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Tilyorn");
            text.SetDefault("Tilyorn");
            text.AddTranslation(GameCulture.Russian, "Тильорн");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Nicolas");
            text.SetDefault("Nicolas");
            text.AddTranslation(GameCulture.Russian, "Николас");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Gregg");
            text.SetDefault("Gregg");
            text.AddTranslation(GameCulture.Russian, "Грег");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA1");
            text.SetDefault("My Healing potions will cure your deepest wounds.");
            text.AddTranslation(GameCulture.Russian, "Мои лечебные зелья излечат твои глубочайшие раны.");
            text.AddTranslation(GameCulture.Chinese, "我的生命药水可以治疗你的伤口.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA2");
            text.SetDefault("My Mana potions will restore your magic power.");
            text.AddTranslation(GameCulture.Russian, "Мои зелья маны восстановят твою магическую силу.");
            text.AddTranslation(GameCulture.Chinese, "我的魔法药水可以回复你的魔力.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA3");
            text.SetDefault("Restoration potions... I'm not sure if I trust them...");
            text.AddTranslation(GameCulture.Russian, "Зелья Восстановления... Не уверен, могу ли я доверять им...");
            text.AddTranslation(GameCulture.Chinese, "再生药剂...不知道它们是好是坏...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA4");
            text.SetDefault("There's a legendary yoyo known as the Sasscade.");
            text.AddTranslation(GameCulture.Russian, "Существует Легендарное Йо-йо, известное как Сасскад.");
            text.AddTranslation(GameCulture.Chinese, "有一个传说中的悠悠球被称为萨斯卡德.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA5");
            text.SetDefault("The Strange Brew I bought from the Skeleton Merchant smells awful, but its Mana Restoration effect is awesome!");
            text.AddTranslation(GameCulture.Russian, "Странное Варево, что я купил у Скелета-торговца пахнет просто ужасно, но его эффект восстановления маны потрясает.");
            text.AddTranslation(GameCulture.Chinese, "来自骷髅商人的奇异啤酒气味真的很糟糕,但法力恢复效果非常棒!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA6");
            text.SetDefault("Hi, *cough*... That definitely wasn't a Teleporation potion.");
            text.AddTranslation(GameCulture.Russian, "Привет, *кашель*... Это определённо было не зелье Телепортации.");
            text.AddTranslation(GameCulture.Chinese, "嗨, *咳咳*.. 那绝对不是柠檬茶.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA7");
            text.SetDefault("Have you seen any Mechanical Skulls around?");
            text.AddTranslation(GameCulture.Russian, "Ты не видел Механических Черепов поблизости?");
            text.AddTranslation(GameCulture.Chinese, "你有在周围看到一个机械骷髅王吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA8");
            text.SetDefault("Have you ever heard of Ultra Mushroom? If you find one, I do believe I got some stuff to aid you in boosting that thing.");
            text.AddTranslation(GameCulture.Russian, "Ты слышал об Ультра Грибах? Если ты найдёшь такой, я уверен что я смогу помочь тебе его усилить.");
            text.AddTranslation(GameCulture.Chinese, "你有听说过极限蘑菇吗？如果你找到了一个，我相信我能研究出一种可以帮助你的材料.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA9");
            text.SetDefault("I asked ");
            text.AddTranslation(GameCulture.Russian, "Я попросил у ");
            text.AddTranslation(GameCulture.Chinese, "我向 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA10");
            text.SetDefault(" if I could buy the recipe for the Potent Extract. He said no because, and I quote, ''Even an idiot would figure it out.''");
            text.AddTranslation(GameCulture.Russian, " рецепт Кактусового Экстракта. Он ответил нет, поскольку, я процитирую ''Даже идиот догадается.''");
            text.AddTranslation(GameCulture.Chinese, " 购买高效萃取配方，因为他说不，然后我就说‘即使是傻子也能研究出那个配方’.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA11");
            text.SetDefault("And to think, she's getting the potions and not me... but I can't argue there.");
            text.AddTranslation(GameCulture.Russian, "И только подумать... Она выбрала зелья, а не меня. Хотя тут и не поспоришь.");
            text.AddTranslation(GameCulture.Chinese, "想想看, 她正在得到那些药水而我没有...但我对此却又无法反驳.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA12");
            text.SetDefault("What is his name? ");
            text.AddTranslation(GameCulture.Russian, "Как его зовут? ");
            text.AddTranslation(GameCulture.Chinese, "他叫什么来着? ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA13");
            text.SetDefault("? So... Teacher's here? Better step up my game!");
            text.AddTranslation(GameCulture.Russian, "? Так... Учитель здесь? Лучше отойди с дороги!");
            text.AddTranslation(GameCulture.Chinese, "? 所以... 老师在这儿? 我最好加快脚步!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA14");
            text.SetDefault("Thank goodness I got those pieces from Skeletron. Want to check it out?");
            text.AddTranslation(GameCulture.Russian, "Слава богу, что я добыл эти кусочки из Скелетрона? Не желаешь посмотреть?");
            text.AddTranslation(GameCulture.Chinese, "感谢上帝，我从骷髅王那里拿到了这些碎片，想要看看吗？");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA15");
            text.SetDefault("Can you please ask ");
            text.AddTranslation(GameCulture.Russian, "Можешь попросить ");
            text.AddTranslation(GameCulture.Chinese, "你能不能拜托 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA16");
            text.SetDefault(" to stop mocking me? I know my potions can't make you stronger, but at least they aren't as dangerous to drink.");
            text.AddTranslation(GameCulture.Russian, " перестать дразнить меня? Я знаю, что мои зелья не сделают тебя сильнее, но их хотя бы не столь опасно пить.");
            text.AddTranslation(GameCulture.Chinese, " 别再嘲笑我?我知道我的药剂不能让你变强,但是至少他们喝起来不危险.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA17");
            text.SetDefault("These goblins are so annoying... Thankfully, they cannot stay here for too long.");
            text.AddTranslation(GameCulture.Russian, "Эти гоблины такие раздражающие... Хорошо, что они не останутся здесь надолго.");
            text.AddTranslation(GameCulture.Chinese, "这些哥布林是如此的愤怒...幸好，他们在这里的时间不会很久.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA18");
            text.SetDefault("You better deal with Pirates as fast, as you can. I can't wait to talk with Captain! Haven't seen him for years!");
            text.AddTranslation(GameCulture.Russian, "Постарайся справиться с Пиратами как можно быстрее. Не могу дождаться возвращения Капитана! Я не видел его уже много лет!");
            text.AddTranslation(GameCulture.Chinese, "你最好以最快的速度解决这些海盗先，我忍不住想和船长说几句话，好些年没见到过他咯!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA19");
            text.SetDefault("I hope that you will not let them into my house, will you?");
            text.AddTranslation(GameCulture.Russian, "Я надеюсь, ты не пустишь их в мой дом, правда?");
            text.AddTranslation(GameCulture.Chinese, "我觉得你不会让他们进我的屋子的，是吧?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA20");
            text.SetDefault("Perhaps there are better things for you to do, rather than talking to me, at the moment. I don't know... maybe defend us?!");
            text.AddTranslation(GameCulture.Russian, "Может у тебя найдётся занятие получше, чем говорить со мной сейчас? Ну например... Охранять нас?!");
            text.AddTranslation(GameCulture.Chinese, "也许在这个时候你有比和我说话更重要的事情要做? 有个血红色的月亮挂在天上哎!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA21");
            text.SetDefault("...My friend, the best thing to do in this case is not bother me during this time.");
            text.AddTranslation(GameCulture.Russian, "...Мой друг, лучшее, что ты можешь сделать - это не беспокоить меня сейчас.");
            text.AddTranslation(GameCulture.Chinese, "...我的朋友，在这个时刻最好的事情就是别来打扰我!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA22");
            text.SetDefault("I have an explosive flask. You do NOT want to know what it tastes like.");
            text.AddTranslation(GameCulture.Russian, "У меня есть взрывная колба. Ты точно НЕ хочешь узнать, какова она на вкус.");
            text.AddTranslation(GameCulture.Chinese, "我有一个爆炸烧瓶，你不会想知道它尝起来是什么味道的.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA23");
            text.SetDefault("How can ");
            text.AddTranslation(GameCulture.Russian, "Как ");
            text.AddTranslation(GameCulture.Chinese, "所以 ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryA24");
            text.SetDefault(" stay calm in a time like this? I want to know, NOW.");
            text.AddTranslation(GameCulture.Russian, "может оставаться спокойной в такое время? Я ХОЧУ это узнать.");
            text.AddTranslation(GameCulture.Chinese, " 是怎么在这种时候保持冷静的? 我现在就想知道, 现在!");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryA25");
            text.SetDefault("Don't let the dark one that came from the Jungle fool you with charming wisdom. Me and ");
            text.AddTranslation(GameCulture.Russian, "Не позволяй тёмному, пришедшему из Джунглей, одурачить тебя чарующей мудростью. Я и ");
            text.AddTranslation(GameCulture.Chinese, "不要让来自丛林的黑暗法师用魅惑的智慧欺骗你。我和");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryA26");
            text.SetDefault(" were once his apprentices. I quit when his lessons turned too dark but ");
            text.AddTranslation(GameCulture.Russian, " однажды были его ассистентами. Я ушёл, когда его уроки стали слишком тёмными, но интерес ");
            text.AddTranslation(GameCulture.Chinese, "曾经是他的学徒。当他的课程变得过于黑暗时我退出了，但是");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryA27");
            text.SetDefault(" interest in occult Alchemy did nothing but grow.");
            text.AddTranslation(GameCulture.Russian, " в оккультной алхимии только вырос.");
            text.AddTranslation(GameCulture.Chinese, "对神秘学炼金术的兴趣却在不断增长");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("BrewElixir");
            text.SetDefault("Brew Life Elixir");
            text.AddTranslation(GameCulture.Chinese, "炼制仙丹");
            text.AddTranslation(GameCulture.Russian, "Сварить Эликсир Жизни");
            mod.AddTranslation(text);
        }

		public override void ResetEffects()
		{
		PS = false;
		AB = false;
		LE = false;
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
			animationType = NPCID.Clothier;
		}
		
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss1 && AlchemistNPC.modConfiguration.AlchemistSpawn)
			{
			return true;
			}
			return false;
		}
 
        public override string TownNPCName()
        {                                       //NPC names
            string Edward = Language.GetTextValue("Mods.AlchemistNPC.Edward");
			string Severus = Language.GetTextValue("Mods.AlchemistNPC.Severus");
			string Horace = Language.GetTextValue("Mods.AlchemistNPC.Horace");
			string Tilyorn = Language.GetTextValue("Mods.AlchemistNPC.Tilyorn");
			string Nicolas = Language.GetTextValue("Mods.AlchemistNPC.Nicolas");
			string Gregg = Language.GetTextValue("Mods.AlchemistNPC.Gregg");
			switch (WorldGen.genRand.Next(6))
            {
            case 0:
            return Edward;
            case 1:
            return Severus;
            case 2:
            return Horace;
            case 3:
            return Tilyorn;
			case 4:
            return Nicolas;
            default:
            return Gregg;
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
         string EntryA1 = Language.GetTextValue("Mods.AlchemistNPC.EntryA1");
		 string EntryA2 = Language.GetTextValue("Mods.AlchemistNPC.EntryA2");
		 string EntryA3 = Language.GetTextValue("Mods.AlchemistNPC.EntryA3");
		 string EntryA4 = Language.GetTextValue("Mods.AlchemistNPC.EntryA4");
		 string EntryA5 = Language.GetTextValue("Mods.AlchemistNPC.EntryA5");
		 string EntryA6 = Language.GetTextValue("Mods.AlchemistNPC.EntryA6");
		 string EntryA7 = Language.GetTextValue("Mods.AlchemistNPC.EntryA7");
		 string EntryA8 = Language.GetTextValue("Mods.AlchemistNPC.EntryA8");
		 string EntryA9 = Language.GetTextValue("Mods.AlchemistNPC.EntryA9");
		 string EntryA10 = Language.GetTextValue("Mods.AlchemistNPC.EntryA10");
		 string EntryA11 = Language.GetTextValue("Mods.AlchemistNPC.EntryA11");
		 string EntryA12 = Language.GetTextValue("Mods.AlchemistNPC.EntryA12");
		 string EntryA13 = Language.GetTextValue("Mods.AlchemistNPC.EntryA13");
		 string EntryA14 = Language.GetTextValue("Mods.AlchemistNPC.EntryA14");
		 string EntryA15 = Language.GetTextValue("Mods.AlchemistNPC.EntryA15");
		 string EntryA16 = Language.GetTextValue("Mods.AlchemistNPC.EntryA16");
		 string EntryA17 = Language.GetTextValue("Mods.AlchemistNPC.EntryA17");
		 string EntryA18 = Language.GetTextValue("Mods.AlchemistNPC.EntryA18");
		 string EntryA19 = Language.GetTextValue("Mods.AlchemistNPC.EntryA19");
		 string EntryA20 = Language.GetTextValue("Mods.AlchemistNPC.EntryA20");
		 string EntryA21 = Language.GetTextValue("Mods.AlchemistNPC.EntryA21");
		 string EntryA22 = Language.GetTextValue("Mods.AlchemistNPC.EntryA22");
		 string EntryA23 = Language.GetTextValue("Mods.AlchemistNPC.EntryA23");
		 string EntryA24 = Language.GetTextValue("Mods.AlchemistNPC.EntryA24");
		 string EntryA25 = Language.GetTextValue("Mods.AlchemistNPC.EntryA25");
		 string EntryA26 = Language.GetTextValue("Mods.AlchemistNPC.EntryA26");
		 string EntryA27 = Language.GetTextValue("Mods.AlchemistNPC.EntryA27");
		 int Brewer = NPC.FindFirstNPC(mod.NPCType("Brewer"));
		 int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
		 int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			if (Main.bloodMoon && partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
			return EntryA23 + Main.npc[partyGirl].GivenName + EntryA24;
			}
			if (Main.bloodMoon)
			{
				switch (Main.rand.Next(3))
				{
				case 0:
				return EntryA20;
				case 1:
				return EntryA21;
				case 2:
				return EntryA22;
				}
			}
			if (Main.invasionType == 1)
			{
				return EntryA17;
			}
			if (Main.invasionType == 3)
			{
				return EntryA18;
			}
			if (Main.invasionType == 4)
			{
				return EntryA19;
			}
			if (witchDoctor >= 0 && Main.rand.Next(7) == 0)
			{
			return EntryA25 + Main.npc[Brewer].GivenName + EntryA26 + Main.npc[Brewer].GivenName + EntryA27;
			}
			if (Brewer >= 0 && Main.rand.Next(5) == 0)
			{
				return EntryA15 + Main.npc[Brewer].GivenName + EntryA16;
			}
			if (ModLoader.GetMod("Tremor") != null)
			{
				int Alch = NPC.FindFirstNPC(ModLoader.GetMod("Tremor").NPCType("Alchemist"));
				if (Alch >= 0 && Main.rand.Next(4) == 0)
				{
				return EntryA12 + Main.npc[Alch].GivenName + EntryA13;
				}
			}
			if (ModLoader.GetMod("Tremor") != null)
			{
				if (NPC.downedBoss3 && Main.rand.Next(6) == 0)
				{
				return EntryA14;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				int DA = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("DesertTraveler"));
				if (DA >= 0 && Main.rand.Next(7) == 0)
				{
				return EntryA9 + Main.npc[DA].GivenName +  EntryA10;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				int DA = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("DesertTraveler"));
				if (DA >= 0 && Brewer >=0 && Main.rand.Next(8) == 0)
				{
				return EntryA11;
				}
			}
			if (ModLoader.GetMod("Peculiarity") != null && Main.rand.Next(5) == 0)
			{
			return EntryA8;
			}
            switch (Main.rand.Next(7))
            {
                case 0:                                     
				return EntryA1;
                case 1:
				return EntryA2;
                case 2:                                                      
				return EntryA3;
                case 3:
				return EntryA4;
                case 4:                                     
				return EntryA5;
                case 5:
				return EntryA6;
                default:
				return EntryA7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
			string TremorShop = Language.GetTextValue("Mods.AlchemistNPC.TremorShop");
			string BrewElixir = Language.GetTextValue("Mods.AlchemistNPC.BrewElixir");
			string GetCharm = Language.GetTextValue("Mods.AlchemistNPC.GetCharm");
			string Gregg = Language.GetTextValue("Mods.AlchemistNPC.Gregg");
            button = Language.GetTextValue("LegacyInterface.28");
			Player player = Main.player[Main.myPlayer];
			if (player.active)
			{
				for (int j = 0; j < player.inventory.Length; j++)
				{
					if (player.inventory[j].type == mod.ItemType("LifeElixir"))
					{
						LE = true;
					}
					if (player.inventory[j].type == ItemID.PhilosophersStone)
					{
						PS = true;
					}
					if (player.inventory[j].type == mod.ItemType("AlchemicalBundle"))
					{
						AB = true;
					}
				}
			}
			
			if (PS && AB)
			{
			button2 = BrewElixir;
			}
			
			if (ModLoader.GetMod("Tremor") != null && (!PS || !AB))
			{
			button2 = TremorShop;
			}
			
			int Alchemist = NPC.FindFirstNPC(mod.NPCType("Alchemist"));
			if (player.name == "Gregg" && Main.npc[Alchemist].GivenName == Gregg && NPC.downedMoonlord && !Tantrum)
			{
				button2 = "Secret";
			}
			
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier1 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 == false)
			{
				button2 = GetCharm;
			}
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
		if (firstButton)
		{
		baseShop = true;
		tremorShop = false;
		shop = true;
		}
		else
			{
				Player player = Main.player[Main.myPlayer];
				if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier1 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier2 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier3 == false && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).AlchemistCharmTier4 == false)
				{
					player.QuickSpawnItem(mod.ItemType("AlchemistCharmTier1"));
				}
				if (ModLoader.GetMod("Tremor") != null && (!PS || !AB))
				{
				baseShop = false;
				tremorShop = true;
				shop = true;
				}
				if (PS && AB)
				{
					if (Main.player[Main.myPlayer].HasItem(ItemID.PhilosophersStone))
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("AlchemicalBundle"))
							{
								inventory[k].stack--;
							}
						}
					}
					player.QuickSpawnItem(mod.ItemType("LifeElixir"));
				}
				if (player.name == "Gregg" && NPC.downedMoonlord)
				{
				Tantrum = true;
				player.QuickSpawnItem(mod.ItemType("LastTantrum"));
				}
			}
		}
 
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.World.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.World.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.World.CalamityWorld.downedDoG; }
		}
 
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
		if (baseShop){
		shop.item[nextSlot].SetDefaults (ItemID.LesserHealingPotion);
		shop.item[nextSlot].shopCustomPrice = 1000;
		nextSlot++;
		if (NPC.downedBoss2)
		{
		shop.item[nextSlot].SetDefaults (ItemID.HealingPotion);
		shop.item[nextSlot].shopCustomPrice = 2500;
		nextSlot++;
		}
		if (Main.hardMode)
		{
		shop.item[nextSlot].SetDefaults (ItemID.GreaterHealingPotion);
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		}
		if (NPC.downedMoonlord)
		{
		shop.item[nextSlot].SetDefaults (ItemID.SuperHealingPotion);
		shop.item[nextSlot].shopCustomPrice = 25000;
		nextSlot++;
		}
		if (ModLoader.GetMod("CalamityMod") != null)
		{
			if(CalamityModDownedGuardian && !CalamityModDownedDOG)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SupremeHealingPotion"));
			shop.item[nextSlot].shopCustomPrice = 500000;
			nextSlot++;
			}
			if(CalamityModDownedDOG)
			{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("OmegaHealingPotion"));
			shop.item[nextSlot].shopCustomPrice = 2000000;
			nextSlot++;
			}
		}
		shop.item[nextSlot].SetDefaults (ItemID.LesserManaPotion);
		nextSlot++;
		if (NPC.downedBoss2)
		{
		shop.item[nextSlot].SetDefaults (ItemID.ManaPotion);
		nextSlot++;
		}
		if (Main.hardMode)
		{
		shop.item[nextSlot].SetDefaults (ItemID.GreaterManaPotion);
		nextSlot++;		
		}
		if (Main.hardMode && NPC.downedMechBoss1 && (NPC.downedMechBoss2 && NPC.downedMechBoss3))
		{
		shop.item[nextSlot].SetDefaults (ItemID.SuperManaPotion);
		nextSlot++;	
		}
		shop.item[nextSlot].SetDefaults (ItemID.RecallPotion);
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.WormholePotion);
		nextSlot++;
		if (Main.hardMode)
		{
		shop.item[nextSlot].SetDefaults (ItemID.TeleportationPotion);
		shop.item[nextSlot].shopCustomPrice = 7500;
		nextSlot++;	
		}
		if (ModLoader.GetMod("imkSushisMod") != null)
		{
		shop.item[nextSlot].SetDefaults(ModLoader.GetMod("imkSushisMod").ItemType("BaseSummoningPotion"));
		shop.item[nextSlot].shopCustomPrice = 2500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults(ModLoader.GetMod("imkSushisMod").ItemType("AnglerAmnesiaPotion"));
		shop.item[nextSlot].shopCustomPrice = 10000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults(ModLoader.GetMod("imkSushisMod").ItemType("MeteoritePotion"));
		shop.item[nextSlot].shopCustomPrice = 50000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults(ModLoader.GetMod("imkSushisMod").ItemType("ResurrectionPotion"));
		shop.item[nextSlot].shopCustomPrice = 25000;
		nextSlot++;
		}
		if (NPC.downedBoss2)
		{
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BeachTeleporterPotion"));
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
		}
		if (NPC.downedBoss3)
		{
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("OceanTeleporterPotion"));
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("DungeonTeleportationPotion"));
		shop.item[nextSlot].shopCustomPrice = 25000;
		nextSlot++;
		}
		if (Main.hardMode)
		{
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("UnderworldTeleportationPotion"));
		shop.item[nextSlot].shopCustomPrice = 50000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("JungleTeleporterPotion"));
		shop.item[nextSlot].shopCustomPrice = 50000;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BeaconTeleportator"));
		shop.item[nextSlot].shopCustomPrice = 25000;
		nextSlot++;
		}
		if (NPC.downedPlantBoss)
		{
		shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("TempleTeleportationPotion"));
		shop.item[nextSlot].shopCustomPrice = 100000;
		nextSlot++;
		}
		shop.item[nextSlot].SetDefaults (ItemID.Bottle);
		shop.item[nextSlot].shopCustomPrice = 100;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.BottledWater);
		shop.item[nextSlot].shopCustomPrice = 500;
		nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.Mushroom);
		shop.item[nextSlot].shopCustomPrice = 500;
		nextSlot++;			
		shop.item[nextSlot].SetDefaults (ItemID.GlowingMushroom);
		shop.item[nextSlot].shopCustomPrice = 1000;
		nextSlot++;
			if (NPC.downedBoss2)
			{
			shop.item[nextSlot].SetDefaults (ItemID.VileMushroom);
			shop.item[nextSlot].shopCustomPrice = 1000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.ViciousMushroom);
			shop.item[nextSlot].shopCustomPrice = 1000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.FallenStar);
			nextSlot++;
			}
			shop.item[nextSlot].SetDefaults (ItemID.Gel);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
			if (NPC.downedBoss2)
			{
			shop.item[nextSlot].SetDefaults (ItemID.PinkGel);
			shop.item[nextSlot].shopCustomPrice = 1000;
			nextSlot++;
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
				{
				if (NPC.downedBoss2)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("WaterChestnut"));
						shop.item[nextSlot].shopCustomPrice = 3500;
						nextSlot++;
						}
					if (NPC.downedBoss3)
						{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("Jelly"));
						shop.item[nextSlot].shopCustomPrice = 7500;
						nextSlot++;
						}
				}
			if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults (ItemID.PixieDust);
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.CrystalShard);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.UnicornHorn);
				shop.item[nextSlot].shopCustomPrice = 15000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.CursedFlame);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Ichor);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				}	
				bool OA = false;
				for (int k = 0; k < 255; k++)
				{
					Player player = Main.player[k];
					if (player.active)
					{
						for (int j = 0; j < player.inventory.Length; j++)
						{
							if (player.inventory[j].type == mod.ItemType("OtherworldlyAmulet"))
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("EmagledFragmentation"));
							shop.item[nextSlot].shopCustomPrice = 100000;
							nextSlot++;
							OA = true;
							}
							if (player.inventory[j].type == mod.ItemType("Autoinjector") && !OA)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("EmagledFragmentation"));
							shop.item[nextSlot].shopCustomPrice = 100000;
							nextSlot++;
							}
						}
					}
				}
		}
		if (tremorShop)
		{
			if (ModLoader.GetMod("Tremor") != null)
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BasicFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("FrostLiquidFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LesserHealingFlack"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BigHealingFlack"));
				nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LesserManaFlask"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BigManaFlask"));
				nextSlot++;
				}
				if (NPC.downedMoonlord)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("SuperManaFlask"));
				nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LesserPoisonFlask"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BigPoisonFlask"));
				nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BoomFlask"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ExtendedBoomFlask"));
				nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("FreezeFlask"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ExtendedFreezeFlask"));
				nextSlot++;
				}
				if (NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GoldFlask"));
				nextSlot++;
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BurningFlask"));
				nextSlot++;
				if (Main.hardMode)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ExtendedBurningFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("HealthSupportFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ManaSupportFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LesserVenomFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("BigVenomFlask"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CrystalFlask"));
				shop.item[nextSlot].shopCustomPrice = 150;
				nextSlot++;
				if (NPC.downedPlantBoss)
		{
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("PhantomFlask"));
				nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("PlagueFlask"));
				nextSlot++;
			shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("SparkingFlask"));
				nextSlot++;
		}
		if (NPC.downedMoonlord)
				{
	shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MoonDustFlask"));
	shop.item[nextSlot].shopCustomPrice = 250;
				nextSlot++;
	shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ClusterFlask"));
	shop.item[nextSlot].shopCustomPrice = 300;
				nextSlot++;
				}
				}
			if (NPC.downedBoss3)
		{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Gloomstone"));
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("UntreatedFlesh"));
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LightBulb"));
				shop.item[nextSlot].shopCustomPrice = 500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AtisBlood"));
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("TearsofDeath"));
				shop.item[nextSlot].shopCustomPrice = 2500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("TornPapyrus"));
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("PhantomSoul"));
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("TheRib"));
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
		}	
			}
		}
		}
	}
}
