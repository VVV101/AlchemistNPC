using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC.Interface;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Musician : ModNPC
	{
		public static bool S1 = true;
		public static bool S2 = false;
		public static bool S3 = false;
		public override string Texture
		{
			get
			{
				return "AlchemistNPC/NPCs/Musician";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Musician";
			return AlchemistNPC.modConfiguration.MusicianSpawn;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musician");
			DisplayName.AddTranslation(GameCulture.Russian, "Музыкант");
			DisplayName.AddTranslation(GameCulture.Chinese, "音乐家");
            Main.npcFrameCount[npc.type] = 25;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -2;

            ModTranslation text = mod.CreateTranslation("Shop2");
            text.SetDefault("2nd shop");
            text.AddTranslation(GameCulture.Russian, "2-ой магазин");
			text.AddTranslation(GameCulture.Chinese, "第2商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("Shop3");
            text.SetDefault("3rd shop");
            text.AddTranslation(GameCulture.Russian, "3-ий магазин");
			text.AddTranslation(GameCulture.Chinese, "第3商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("ShopChanger");
            text.SetDefault("Shop Changer");
            text.AddTranslation(GameCulture.Russian, "Сменить магазин");
            text.AddTranslation(GameCulture.Chinese, "切换商店");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Beethoven");
            text.SetDefault("Beethoven");
            text.AddTranslation(GameCulture.Russian, "Бетховен");
			text.AddTranslation(GameCulture.Chinese, "贝多芬");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Bach");
            text.SetDefault("Bach");
            text.AddTranslation(GameCulture.Russian, "Бах");
			text.AddTranslation(GameCulture.Chinese, "巴赫");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Johan");
            text.SetDefault("Johan");
            text.AddTranslation(GameCulture.Russian, "Иоганн");
			text.AddTranslation(GameCulture.Chinese, "约翰");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Edison");
            text.SetDefault("Edison");
            text.AddTranslation(GameCulture.Russian, "Эдисон");
			text.AddTranslation(GameCulture.Chinese, "爱迪生");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Scott");
            text.SetDefault("Scott");
            text.AddTranslation(GameCulture.Russian, "Скотт");
			text.AddTranslation(GameCulture.Chinese, "斯科特");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Lloyd");
            text.SetDefault("Lloyd");
            text.AddTranslation(GameCulture.Russian, "Ллойд");
			text.AddTranslation(GameCulture.Chinese, "劳埃德");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("Gamma");
            text.SetDefault("Gamma");
            text.AddTranslation(GameCulture.Russian, "Гамма");
			text.AddTranslation(GameCulture.Chinese, "伽马");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM1");
            text.SetDefault("I would wear headphones, but I'm not sure if Terrarians even have ears...");
            text.AddTranslation(GameCulture.Russian, "Я бы носил наушники, но я не уверен, что обитатели Террарии вообще имеют уши...");
            text.AddTranslation(GameCulture.Chinese, "我会戴耳机，但我不确定泰拉人能不能听见…");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM2");
            text.SetDefault("I have to wonder why Boss 1 and Boss 2 didn't get better names in the OST. Those names are soooo bland.");
            text.AddTranslation(GameCulture.Russian, "Интересно, почему Босс 1 и Босс 2 не имеют имён получше в саундтреке. Эти имена слишком обычные.");
            text.AddTranslation(GameCulture.Chinese, "我想知道为什么Boss1和Boss2在OST中没有更好的名字。那些名字很很很很平淡。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM3");
            text.SetDefault("Look, the Cyborg may have my name, but I've still got the better job here.");
            text.AddTranslation(GameCulture.Russian, "Хотя у Киборга может быть моё имя, но у меня здесь всё равно работа получше.");
            text.AddTranslation(GameCulture.Chinese, "听着，电子人可能有我的名字，但我在这里还有更好的工作。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM4");
            text.SetDefault("Shhhhh! You'll ruin my recording!");
            text.AddTranslation(GameCulture.Russian, "Шшш! Ты испортишь мою запись!");
	    text.AddTranslation(GameCulture.Chinese, "嘘！！！！！你会毁了我的录音！");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM5");
            text.SetDefault("I swear, if one more person asks me to sell them a ''Megalovania'' music box....");
            text.AddTranslation(GameCulture.Russian, "Не дай бог ещё кто-нибудь попросит меня продать ему музыкальную шкатулку с Мегалованией...");
            text.AddTranslation(GameCulture.Chinese, "我发誓，如果有人再让我卖给他们一个“Megalovania”八音盒的话…");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM6");
            text.SetDefault("Look, your enthusiasm is awesome, but could you maybe record the next boss track yourself? I don't really want to risk my life for some tunes.");
            text.AddTranslation(GameCulture.Russian, "Послушай, твой энтузиазм просто потрясающий, но может ты запишешь мелодию следующего босса сам? Мне не очень хочется рисковать жизнью из-за некоторых мелодий.");
            text.AddTranslation(GameCulture.Chinese, "听着，你这么热心真是太好了，但是你能不能把下一个Boss的音乐记录下来？我真的不想为了一些曲调而冒自己的生命危险。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM7");
            text.SetDefault("Ah, I see you were able to save the Explorer! Well done! Perhaps my next song is going to be about your triumph.");
            text.AddTranslation(GameCulture.Russian, "Я вижу ты спас Исследовательницу! Отличная работа! Может быть моя следующая песня будет о твоём триумфе.");
            text.AddTranslation(GameCulture.Chinese, "啊，我看到你救了探险家！做得好！也许我的下一首歌是关于你的胜利。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM8");
            text.SetDefault("You know, ");
            text.AddTranslation(GameCulture.Russian, "Ты знаешь, ");
            text.AddTranslation(GameCulture.Chinese, "你知道，");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM9");
            text.SetDefault(" has been really helpful while I've been setting up this sound system. Wires are key!");
            text.AddTranslation(GameCulture.Russian, " была очень полезна, когда я устанавливал здесь звуковую систему. Провода рулят!");
            text.AddTranslation(GameCulture.Chinese, "对我安装这个音响系统真的很有帮助。电线是关键！");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM10");
            text.SetDefault("If you run into ");
            text.AddTranslation(GameCulture.Chinese, "如果你遇到");
	    text.AddTranslation(GameCulture.Russian, "Если как-нибудь зайдёшь к ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM11");
            text.SetDefault(", let him know he still owes me for those music boxes I sold him.");
            text.AddTranslation(GameCulture.Russian, ", то передай ему, что он всё ещё должен мне за те музыкальные шкатулки, что я продал ему.");
            text.AddTranslation(GameCulture.Chinese, "，让他知道他还欠我卖给他的那些八音盒钱。");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM12");
            text.SetDefault("I'll be honest, I'm not sure if I trust ");
            text.AddTranslation(GameCulture.Russian, "Буду честен, я не уверен, что я доверяю ");
	    text.AddTranslation(GameCulture.Chinese, "老实说，我不确定我是否相信");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM13");
            text.SetDefault(". He claims to not be possessed, and yet he still is using skulls to fight... I'm getting mixed messages here.");
            text.AddTranslation(GameCulture.Russian, ". Он вроде бы больше не одержим, но все еще использует черепа для битвы... У меня смешанные чувства.");
            text.AddTranslation(GameCulture.Chinese, "。他声称没有被附身，但他仍在用头骨战斗…我收到的信息混杂不一。");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM14");
            text.SetDefault("Man, my mixtape is so much better than this, but I can't sell you that due to copyright.");
            text.AddTranslation(GameCulture.Russian, "Чувак, мои записи значительно лучше всего этого, но я не могу продать их тебе из-за авторских прав.");
            text.AddTranslation(GameCulture.Chinese, "伙计，我的混音带比这个好得多，但由于版权问题，我不能卖给你。");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM15");
            text.SetDefault("No, I don't have an ''All Star'' music box. Code it in yourself.");
            text.AddTranslation(GameCulture.Russian, "Нет, я меня нет музыкальной шкатулки ''Со Всеми''. Закодируй её сам.");
           text.AddTranslation(GameCulture.Chinese, "不，我没有“全明星”八音盒。用你自己的代码。");
	   mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM16");
            text.SetDefault("Wait, NPC? I thought I was the protagonist!");
            text.AddTranslation(GameCulture.Russian, "Погоди-ка, НИП? Я думал, что я протагонист!");
	    text.AddTranslation(GameCulture.Chinese, "等等，NPC？我以为我是主角！");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM17");
            text.SetDefault("Never thought I'd be selling a music box with lyrics... DM DOKURO, you're a madman and I love it!");
            text.AddTranslation(GameCulture.Russian, "Никогда не думал, что я буду продавать музыкальные шкатулки с песнями... DM DOKURO, ты безумец и мне это нравится!");
            text.AddTranslation(GameCulture.Chinese, "没想到我会卖一个带歌词的八音盒…DM DOKURO，是个疯狂的人，我喜欢！");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM18");
            text.SetDefault("A whole music based class? That sounds amazing! Too bad I don't have any gear for that, huh?");
            text.AddTranslation(GameCulture.Russian, "Целый класс, основанный на музыке? Звучит потрясающе! Жаль, что у меня нет ничего подходящего для него...");
            text.AddTranslation(GameCulture.Chinese, "整个基础音乐系列？听起来太棒了！很糟糕，我没有装备，嗯？");
	    mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryM19");
            text.SetDefault("This is your fault. GET. OUT.");
            text.AddTranslation(GameCulture.Russian, "Это твоя вина. УБИРАЙСЯ. ОТСЮДА.");
            text.AddTranslation(GameCulture.Chinese, "这是你的错。出。去。");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM20");
            text.SetDefault("Ah, this takes me back! I remember when this song used to play in the dungeon and the underworld... good times!");
            text.AddTranslation(GameCulture.Russian, "Эх, ностальгия! Я помню, когда эта мелодия играла в Подземелье и в Преисподней... хорошие времена!");
            text.AddTranslation(GameCulture.Chinese, "啊，我回来了！我记得这首歌曾经在地牢和地下演奏…真是好时光！");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM21");
            text.SetDefault("Is there a name for the fear of being spied by a cake?");
            text.AddTranslation(GameCulture.Russian, "Если ли имя у страха того, что за тобой шпионят с помощью торта?");
            text.AddTranslation(GameCulture.Chinese, "有没有一个名字是因为害怕被蛋糕监视？");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryM22");
            text.SetDefault("You are hurting my ears! Turn it down!");
            text.AddTranslation(GameCulture.Russian, "У меня уже болят уши! Сделай потише!");
			text.AddTranslation(GameCulture.Chinese, "你在伤害我的耳朵! 把它给我关了! ");
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
            npc.defense = 50;
            npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss3 && AlchemistNPC.modConfiguration.MusicianSpawn)
			{
			return true;
			}
			return false;
		}
 
 
 
        public override string TownNPCName()
        {                                       //NPC names
            string Beethoven = Language.GetTextValue("Mods.AlchemistNPC.Beethoven");
			string Bach = Language.GetTextValue("Mods.AlchemistNPC.Bach");
			string Johan = Language.GetTextValue("Mods.AlchemistNPC.Johan");
			string Edison = Language.GetTextValue("Mods.AlchemistNPC.Edison");
			string Scott = Language.GetTextValue("Mods.AlchemistNPC.Scott");
			string Lloyd = Language.GetTextValue("Mods.AlchemistNPC.Lloyd");
			string Gamma = Language.GetTextValue("Mods.AlchemistNPC.Gamma");
			switch (WorldGen.genRand.Next(7))
            {
                case 0:
                    return Beethoven;
                case 1:
                    return Bach;
                case 2:
                    return Johan;
                case 3:
                    return Edison;
				case 4:
                    return Scott;
				case 5:
                    return Lloyd;
				case 6:
                    return Gamma;
				default:
                    return Gamma;
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
			cooldown = 5;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			attackDelay = 3;
			switch (Main.rand.Next(3))
			{
				case 0: 
				projType = 76;
				break;
				case 1: 
				projType = 77;
				break;
				case 2: 
				projType = 78;
				break;
			}
			
			
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 6f;
			randomOffset = 0f;
		}
 
 
        public override string GetChat()
        {
        string EntryM1 = Language.GetTextValue("Mods.AlchemistNPC.EntryM1");
		string EntryM2 = Language.GetTextValue("Mods.AlchemistNPC.EntryM2");
		string EntryM3 = Language.GetTextValue("Mods.AlchemistNPC.EntryM3");
		string EntryM4 = Language.GetTextValue("Mods.AlchemistNPC.EntryM4");
		string EntryM5 = Language.GetTextValue("Mods.AlchemistNPC.EntryM5");
		string EntryM6 = Language.GetTextValue("Mods.AlchemistNPC.EntryM6");
		string EntryM7 = Language.GetTextValue("Mods.AlchemistNPC.EntryM7");
		string EntryM8 = Language.GetTextValue("Mods.AlchemistNPC.EntryM8");
		string EntryM9 = Language.GetTextValue("Mods.AlchemistNPC.EntryM9");
		string EntryM10 = Language.GetTextValue("Mods.AlchemistNPC.EntryM10");
		string EntryM11 = Language.GetTextValue("Mods.AlchemistNPC.EntryM11");
		string EntryM12 = Language.GetTextValue("Mods.AlchemistNPC.EntryM12");
		string EntryM13 = Language.GetTextValue("Mods.AlchemistNPC.EntryM13");
		string EntryM14 = Language.GetTextValue("Mods.AlchemistNPC.EntryM14");
		string EntryM15 = Language.GetTextValue("Mods.AlchemistNPC.EntryM15");
		string EntryM16 = Language.GetTextValue("Mods.AlchemistNPC.EntryM16");
		string EntryM17 = Language.GetTextValue("Mods.AlchemistNPC.EntryM17");
		string EntryM18 = Language.GetTextValue("Mods.AlchemistNPC.EntryM18");
		string EntryM19 = Language.GetTextValue("Mods.AlchemistNPC.EntryM19");
		string EntryM20 = Language.GetTextValue("Mods.AlchemistNPC.EntryM20");
		string EntryM21 = Language.GetTextValue("Mods.AlchemistNPC.EntryM21");
		string EntryM22 = Language.GetTextValue("Mods.AlchemistNPC.EntryM22");
		string Gamma = Language.GetTextValue("Mods.AlchemistNPC.Gamma");
		int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
		int Mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
		int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
		int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
		int Explorer = NPC.FindFirstNPC(mod.NPCType("Explorer"));
		int Musician = NPC.FindFirstNPC(mod.NPCType("Musician"));
			if (Main.musicVolume == 0)
			{
				return EntryM19;
			}
			if (Main.musicVolume == 100)
			{
				return EntryM22;
			}
			if (Main.bloodMoon)
			{
				return EntryM20;
			}
			if (Cyborg >= 0 && Main.npc[Cyborg].GivenName == "Gamma" && Main.npc[Musician].GivenName == Gamma && Main.rand.Next(15) == 0)
			{
				return EntryM3;
			}
			if (Explorer >= 0 && Main.rand.Next(20) == 0)
			{
				return EntryM7;
			}
			if (Mechanic >= 0 && Main.rand.Next(20) == 0)
			{
				return EntryM8 + Main.npc[Mechanic].GivenName + EntryM9;
			}
			if (Wizard >= 0 && Main.rand.Next(20) == 0)
			{
				return EntryM10 + Main.npc[Wizard].GivenName + EntryM11;
			}
			if (Clothier >= 0 && Main.rand.Next(20) == 0)
			{
				return EntryM12 + Main.npc[Clothier].GivenName + EntryM13;
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (Main.rand.Next(15) == 0)
				{
				return EntryM18;
				}
			}
			if (ModLoader.GetMod("CalamityModMusic") != null)
			{
				if (Main.rand.Next(15) == 0)
				{
				return EntryM17;
				}
			}
            switch (Main.rand.Next(9))
            {
                case 0:                                     
				return EntryM1;
                case 1:                                                      
				return EntryM2;
                case 2:                                     
				return EntryM4;
				case 3:                                     
				return EntryM5;
				case 4:                                     
				return EntryM6;
				case 5:                                     
				return EntryM14;
				case 6:                                     
				return EntryM15;
				case 7:                                     
				return EntryM16;
				case 8:                                     
				return EntryM21;
                default:
				return EntryM1;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Shop2 = Language.GetTextValue("Mods.AlchemistNPC.Shop2");
			string Shop3 = Language.GetTextValue("Mods.AlchemistNPC.Shop3");
			string ShopChanger = Language.GetTextValue("Mods.AlchemistNPC.ShopChanger");
			if (S1)
			{
				button = Language.GetTextValue("LegacyInterface.28");
			}
			if (S2)
			{
				button = Shop2;
			}
			if (S3)
			{
				button = Shop3;
			}
			button2 = ShopChanger;
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
				ShopChangeUIM.visible = false;
			}
			else
			{
				ShopChangeUIM.visible = true;
			}
		}

		public bool ThoriumModDownedGTBird
        {
        get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
		public bool ThoriumModDownedViscount
        {
        get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
        get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
        get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedAbyssion
        {
        get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
		
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			if (S1)
			{
				if (!NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults (576);
					nextSlot++;
				}
				if (NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults (562);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (563);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (564);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (565);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (566);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (568);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (569);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (570);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (571);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (573);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1596);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1597);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1598);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1600);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1601);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1602);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1603);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1604);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1605);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1608);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1610);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (1964);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (2742);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (3237);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (3796);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (567);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (572);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (574);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						if (NPC.downedQueenBee)
						{
						shop.item[nextSlot].SetDefaults (1599);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedGolemBoss)
						{
						shop.item[nextSlot].SetDefaults (1607);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						shop.item[nextSlot].SetDefaults (1606);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						if (NPC.downedMoonlord)
						{
						shop.item[nextSlot].SetDefaults (3044);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedGoblins)
						{
						shop.item[nextSlot].SetDefaults (3371);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedPirates)
						{
						shop.item[nextSlot].SetDefaults (3236);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (DD2Event.DownedInvasionT1)
						{
						shop.item[nextSlot].SetDefaults (3869);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						shop.item[nextSlot].SetDefaults (1609);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						if (NPC.downedHalloweenKing)
						{
						shop.item[nextSlot].SetDefaults (1963);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedChristmasIceQueen)
						{
						shop.item[nextSlot].SetDefaults (1965);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedMartians)
						{
						shop.item[nextSlot].SetDefaults (3235);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
						if (NPC.downedMoonlord)
						{
						shop.item[nextSlot].SetDefaults (3370);
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						}
					}
				}
			}
			if (S2)
			{
				Mod Calamity = ModLoader.GetMod("CalamityMod");
				Mod CalamityMusic = ModLoader.GetMod("CalamityModMusic");
				if (Calamity != null && CalamityMusic != null)
				{
					if ((bool)Calamity.Call("Downed", "desert scourge"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("DesertScourgeMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SunkenSeaMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "crabulon"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CrabulonMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "hive mind"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("HiveMindMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "perforators"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("PerforatorMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "slime god"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SlimeGodMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CragMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SirenIdleMusicbox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SulphurousMusicbox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("HigherAbyssMusicbox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("AbyssLowerMusicbox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("VoidMusicbox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					if ((bool)Calamity.Call("Downed", "cryogen"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CryogenMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "aquatic scourge"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("AquaticScourgeMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "brimstone elemental"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("BrimmyMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CalamitasMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CalamityMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "leviathan"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SirenMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("LeviathanMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "astrum aureus"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("AstralMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("AstrageldonMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "astrum deus"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("AstrumDeusMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "plaguebringer goliath"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("PlaguebringerMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "ravager"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("RavagerMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "profaned guardians"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("ProfanedGuardianMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "providence"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("ProvidenceMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 250000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("StormWeaverMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("CeaselessVoidMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SignusMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "polterghast"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("PolterghastMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 300000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "dog"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("DoGMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("DoGP2Musicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "yharon"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("Yharon1Musicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("Yharon2Musicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("Yharon3Musicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
					}
					if ((bool)Calamity.Call("Downed", "supreme calamitas"))
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SCalGMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SCalLMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SCalEMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityModMusic").ItemType("SCalAMusicbox"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
					}
				}
			}
			if (S3)
			{
				shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("BoomBox"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("FieldsMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 400000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("SheamMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("ChaosKingMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AlchemistNPC").ItemType("TheWorldRevolvingMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					if (ThoriumModDownedGTBird)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (ThoriumModDownedViscount)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ViscountMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (ThoriumModDownedBoreanStrider)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoreanStriderMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (ThoriumModDownedFallenBeholder)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("FallenBeholderMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (ThoriumModDownedAbyssion)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DepthsMusicBox"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
				}
			}
		}
	}
}
