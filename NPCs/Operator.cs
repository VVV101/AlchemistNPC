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
	public class Operator : ModNPC
	{
		public static bool OA = false;
		public static bool Meteor = false;
		public static int Shop = 1;
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
			return AlchemistNPC.modConfiguration.OperatorSpawn;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Operator");
			DisplayName.AddTranslation(GameCulture.Russian, "Оператор");
            DisplayName.AddTranslation(GameCulture.Chinese, "操作员");
            Main.npcFrameCount[npc.type] = 23;   
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = -6;

            ModTranslation text = mod.CreateTranslation("EGOShop");
            text.SetDefault("EGO Equipment Shop        ");
            text.AddTranslation(GameCulture.Russian, "Магазин Э.П.О.С                ");
            text.AddTranslation(GameCulture.Chinese, "EGO 装备商店           ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("BossDropsShop");
            text.SetDefault("Vanilla Boss Drops & Materials Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин лута Боссов и материалов");
            text.AddTranslation(GameCulture.Chinese, "Boss掉落物&材料商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("BossDropsModsShop");
            text.SetDefault("Modded Boss Drops & Materials Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин модового лута Боссов и материалов");
            text.AddTranslation(GameCulture.Chinese, "Boss掉落物&材料商店");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("VanillaTreasureBagsShop");
            text.SetDefault("Vanilla Treasure Bags Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок стандарных Боссов");
            text.AddTranslation(GameCulture.Chinese, "原版宝藏袋商店    ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ModdedTreasureBagsShop");
            text.SetDefault("Modded Treasure Bags Shop");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок модовых Боссов");
            text.AddTranslation(GameCulture.Chinese, "模组宝藏袋商店    ");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("ModdedTreasureBagsShop2");
            text.SetDefault("Modded Treasure Bags Shop #2");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок модовых Боссов #2");
            text.AddTranslation(GameCulture.Chinese, "模组宝藏袋商店 #2    ");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("ModdedTreasureBagsShop3");
            text.SetDefault("Modded Treasure Bags Shop #3");
            text.AddTranslation(GameCulture.Russian, "Магазин сумок модовых Боссов #3");
            text.AddTranslation(GameCulture.Chinese, "模组宝藏袋商店 #3    ");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ShopChanger");
            text.SetDefault("Shop Changer");
            text.AddTranslation(GameCulture.Russian, "Сменить магазин");
            text.AddTranslation(GameCulture.Chinese, "切换商店");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("Meteorite");
            text.SetDefault("Meteorite");
            text.AddTranslation(GameCulture.Russian, "Метеорит");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("Angela");
            text.SetDefault("Angela");
            text.AddTranslation(GameCulture.Russian, "Анжела");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("Carmen");
            text.SetDefault("Carmen");
            text.AddTranslation(GameCulture.Russian, "Кармен");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO1");
            text.SetDefault("How is your day, Manager? Can I help you?");
            text.AddTranslation(GameCulture.Russian, "Как ваш день, Управляющий? Могу ли я вам помочь?");
            text.AddTranslation(GameCulture.Chinese, "您好吗, 主管, 我能为您做什么?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO2");
            text.SetDefault("That 'The Great Thunder Bird' doesn't seems so dangerous. I am only hoping that it isn't a part of Apocalypse Bird...");
            text.AddTranslation(GameCulture.Russian, "Эта 'Великая Птица-Гром' не кажется такой уж опасной. Я только надеюсь, что она не является частью Птицы Апокалипсиса.");
            text.AddTranslation(GameCulture.Chinese, "那个'大雷鸟'看起来并不怎么危险. 我只希望它不是天启鸟的一部分...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO3");
            text.SetDefault("Hello, Manager! Isn't this day silent, is it?");
            text.AddTranslation(GameCulture.Russian, "Приветствую, Управляющий! Тихий сегодня денёк, не правда ли?");
            text.AddTranslation(GameCulture.Chinese, "您好, 主管! 今天真安静, 不是么?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO4");
            text.SetDefault("Do you want anything special, Manager?");
            text.AddTranslation(GameCulture.Russian, "Вам нужно что-нибудь особенное, Управляющий?");
            text.AddTranslation(GameCulture.Chinese, "您想要什么特别的东西吗, 主管?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO5");
            text.SetDefault("Eater of Worlds is an Abnormality with risk class TETH. And now it is contained. Do you need something from it?");
            text.AddTranslation(GameCulture.Russian, "Пожиратель Миров - это аномалия с уровнем угрозы TETH. Теперь он захвачен. Нужно ли вам что-нибудь от него?");
            text.AddTranslation(GameCulture.Chinese, "世界吞噬者为异常, 危险等级: TETH. 现在它已经被写入了. 您需要些来自它的物品吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO6");
            text.SetDefault("If you manage to supress Ragnarok, then you could do everything imaginable.");
            text.AddTranslation(GameCulture.Russian, "Если тебе удастся подавить Рагнарёк, то тогда ты способен на всё, что угодно.");
            text.AddTranslation(GameCulture.Chinese, "如果您成功阻止诸神黄昏, 那么您可以做您想做的一切.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO7");
            text.SetDefault("Eye of Cthulhu is a pretty strange creature. It seems like it is just a small part of something really dangerous. It would be better for us if it never escapes.");
            text.AddTranslation(GameCulture.Russian, "Глаз Ктулху - довольно странное создание. Похоже, что он является малой частью чего-то по настоящему опасного. Будет лучше если он никогда не сможет сбежать.");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之眼是个特别奇怪的生物. 它看起来像是个十分危险的东西的一部分. 如果它没有逃跑对我们来说更好.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO8");
            text.SetDefault("Brain of Cthulhu may look horrifying, but without its minions it can't do anything.");
            text.AddTranslation(GameCulture.Russian, "Мозг Ктулху может выглядеть пугающе, но без своих прислужников он не способен ни на что.");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之脑也许看起来很吓人, 但是失去了它的爪牙它几乎什么都做不了.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO9");
            text.SetDefault("Something changed in this world, Manager. Evil is spreading even wider, but at the same time, my sensor system caught the birth of new biome, called Hallow.");
            text.AddTranslation(GameCulture.Russian, "Что-то изменилось в этом мире, Управляющий. Зло разрастается ещё шире, но в то же время мои сенсоры зафиксировали рождение нового биома, называющегося Святым.");
            text.AddTranslation(GameCulture.Chinese, "这个世界出现了某种变动, 主管. 邪恶正在扩张, 但是与此同时, 我的传感系统发现了一个新生物群落诞生了, 叫做神圣之地.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO10");
            text.SetDefault("All these Mechanical Bosses... They definitely could have Trauma origin. What classification numbers will they get? I think they would be started as T-05-...");
            text.AddTranslation(GameCulture.Russian, "Все эти Механические Боссы... Они определённо могут иметь происхождение от Траумы. Какие классификационные номера им дать? Я полагаю, они будут начинаться с T-05-...");
            text.AddTranslation(GameCulture.Chinese, "所有的这些机械Boss... 他们肯定有创伤来源. 他们会得到什么分类号码? 我觉得可以从 T-05- 开始...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO11");
            text.SetDefault("Goblins... Such a pathetic creatures. And the only useful things from them are just Spiky Balls and Harpoons.");
            text.AddTranslation(GameCulture.Russian, "Гоблины... Какие же жалкие создания. Единственные полезные вещи с них - это шипастые шары и Гарпуны.");
            text.AddTranslation(GameCulture.Chinese, "哥布林... 如此可怜的生物. 他们唯一有用的东西就是尖刺球和鱼叉链枪.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO12");
            text.SetDefault("Pretty strange Abnormal event... They all look as living creatures, but their 'Flying Dutchman' is definetly a ghost with HE risk class.");
            text.AddTranslation(GameCulture.Russian, "Довольно странное событие... Они все выглядят как живые существа, но вот их 'Летучий Голландец' - определённо призрак класса опасности HE.");
            text.AddTranslation(GameCulture.Chinese, "挺奇怪的异常事件... 他们都看起来像是活着的生物, 但是他们的 '飞翔荷兰人号' 的危险等级绝对有 HE.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO13");
            text.SetDefault("Martians came again. Last time they were here, several big towns were destroyed. But we could say as an excuse that we weren't as ready, as we were now.");
            text.AddTranslation(GameCulture.Russian, "Марсиане прибыли вновь. Последний раз когда они прибыли, было разрушено несколько крупных городов. Но, в наше оправдание можно сказать, что мы не были так готовы, как сейчас.");
            text.AddTranslation(GameCulture.Chinese, "火星人又来了. 上次他们来的时候, 几个大城镇被毁灭了. 但是, 恕我直言, 我们可以说我们现在还没有准备好.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO14");
            text.SetDefault("Blood Moon? Shouldn't it happen once in 666 years?");
            text.AddTranslation(GameCulture.Russian, "Кровавая Луна? Разве она не должна случаться один раз в 666 лет?");
            text.AddTranslation(GameCulture.Chinese, "血月? 这不应该每666年才发生一次吗?");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO15");
            text.SetDefault("All these strange cratures just keep coming and coming to this 'Beacon'... Hope we all will survive until Dawn.");
            text.AddTranslation(GameCulture.Russian, "Все эти странные существа продолжают прибывать и прибывать на этот 'Маяк'... Надеюсь, мы все доживём до рассвета.");
            text.AddTranslation(GameCulture.Chinese, "所有的这些奇怪生物一直冲过来, 冲向这个'信标'... 真希望我们能在黎明前活下来.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO16");
            text.SetDefault("Anyway, there are some reasons for optimism. Blood Moon attracts some creatures, which cannot be seen in normal conditions.");
            text.AddTranslation(GameCulture.Russian, "Управляющий, не вешайте нос, все не так плохо! Кровавая Луна привлекает некоторых существ, которые обычно не появляются.");
            text.AddTranslation(GameCulture.Chinese, "无论怎样, 都有一些乐观的理由. 血月带来了一些生物, 平时我们都见不到的生物.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO17");
            text.SetDefault("I read a few manuscripts about creature, named Slime God. They say that he is one of the first creatures in this world.");
            text.AddTranslation(GameCulture.Russian, "Я прочитала несколько манускриптов о существе, именуемом Бог Слизней. В них говорится, что он является одним из первых созданий этого мира");
            text.AddTranslation(GameCulture.Chinese, "我阅读了一些关于一个生物的手稿, 叫做史莱姆之神. 他们说这是世界上第一个生物之一.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO18");
            text.SetDefault("Yharim... I am pretty sure I heard that name before. But my memory data is corrupted. Try asking Calamitas about him...");
            text.AddTranslation(GameCulture.Russian, "Ярим... Я уверена, что слышала это имя раньше. Но моя память повреждена. Попробуй узнать у Каламитас что-нибудь о нём...");
            text.AddTranslation(GameCulture.Chinese, "Yharim... 我很确定我曾经听过这个名字. 但是我的记忆数据已损坏. 试着去问问大山猪关于它的事情吧...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO19");
            text.SetDefault("This carnivorous plant was really dangerous... Looks like it was at least HE Risk Class. Glad to see you again in one piece after all.");
            text.AddTranslation(GameCulture.Russian, "Этот плотоядный цветок был действительно опасен... Рада видеть, что ты не пострадал.");
            text.AddTranslation(GameCulture.Chinese, "这种肉食植物真的很危险...危险等级至少为 HE , 总之很高兴再次见到你平安归来");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO20");
            text.SetDefault("This ancient machine was holding celestial powers inside. With its death, world can change forever...");
            text.AddTranslation(GameCulture.Russian, "Эта древняя машина хранила в себе Небесные Силы. Её смерть может изменить мир навсегда.");
            text.AddTranslation(GameCulture.Chinese, "这古老的机器拥有着巨大的天界之力. 随着它的死亡, 世界也发生了永远的改变...");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO21");
            text.SetDefault("An insect the size of the Queen Bee defies current methods of classification. I propose insects of this size be given a new classification MI-XX. It is a wonder that nobody has used them for their own means, let us be the first.");
            text.AddTranslation(GameCulture.Russian, "Размеры насекомого с Королеву Пчёл бросают вызов текущим методам класификации. Я предлагаю дать насекомому таких размеров новую классификацию MI-XX. Удивительно, что ещё никто не использовал их для себя.");
            text.AddTranslation(GameCulture.Chinese, "一个蜂后那么大的昆虫是不符合现在的分类标准的. 我建议为他建立一个新的分类 MI-XX. 很奇怪还没有人为了自己的意愿驱使它们, 那么让我们成为第一个吧.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO22");
            text.SetDefault("It appears I was wrong about the queen bees. Their memory storage contains the ramblings of a scientist who was blinded by ambition and cruelly introduced the plague to them. Let us classify them as MP-0X.");
            text.AddTranslation(GameCulture.Russian, "Похоже, что я была неправа по поводу Королев Пчёл. Их память хранит бредовые мысли учёного, ослеплённого своими амбициями, того, кто жестоко заразил их чумой. Давайте классифицируем их как МР-0Х.");
			text.AddTranslation(GameCulture.Chinese, "看来我对蜂后的看法是错的. 它们的记忆中储存着一个被野心蒙蔽了双眼的科学家的漫谈, 他残酷地把瘟疫带给它们. 让我们把它们归类为MP-0X.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO23");
            text.SetDefault("According to my notes, this Coznix you speak of was a lesser Void Observer, classified as OB-V-01. There are greater threats waiting beyond the veil of reality.");
            text.AddTranslation(GameCulture.Russian, "Согласно моим записям, этот Козникс, о котором ты говорил, является малым Созерцателем Пустоты, классифицированном как OB-V-01. Похоже, что существуют ещё большие опасности за Границей Реальности.");
			text.AddTranslation(GameCulture.Chinese, "根据我的记录, 你所说的那个克兹尼格斯是一个较弱的虚空巡查者, 被归类为OB-V-01. 在现实的面纱后面有着更大的威胁在等待着.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO24");
            text.SetDefault("This flying scouter..... curious. From the memory banks stored in the wreckage, this looks to have been a scouting ship for the Martians, to determine how hospitable Terraria is. I fear the pilot's last moments have been transmitted to the main Martian command centre.");
			text.AddTranslation(GameCulture.Russian, "Эта летающая тарелка... интересно. Согласно носителям данных с места крушения, это корабль-разведчик Марсиан, целью которого является проверка того, насколько мир Террарии подходит для жизни. Боюсь, что последним, что успел сделать пилот этого корабля, была отправка сообщения в Главный Командный Центр Марсиан.");           
			text.AddTranslation(GameCulture.Chinese, "这个飞行侦察者.....好奇. 从储存在残骸中的数据库来看, 这似乎是一艘为火星人而设的侦察船, 用来确定地球人的居住环境. 我担心飞行员最后看到的已经被上传到中央火星指挥中心.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO25");
            text.SetDefault("Turning a mages' power in on himself and trapping him within it is no easy task, but to observe cruelty of such magnitude..... Permafrost, former lord of the Ice Castle, may you see peace.");
            text.AddTranslation(GameCulture.Russian, "Обращение силы мага против него самого и заключение его же в ней непростая задача, но видя такую жестокость... Вечный Хлад, бывший властелин Ледяного Замка, может ты теперь обретёшь покой.");
			text.AddTranslation(GameCulture.Chinese, "把一个法师的力量转移到自己身上并且用它困住他并非易事, 但是观察如此残酷的行为...永冻之土, 前冰堡之王, 愿你看到和平.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO26");
            text.SetDefault("The Starplate raider is a Genius Stardust Centipede, or a G-S-C3, popular with the Martian elite as lifelong companions and raiding partners. It must have wandered far from home, judging from the transmitter memory banks I recovered.");
            text.AddTranslation(GameCulture.Russian, "Звёздный Рейндер это Гениальная Сороконожка Звёздной Пыли или G-S-C3, известная среди Марсианской Элиты как долгоживущий компаньон и партнёр для рейдерских экспедиций. Похоже, она ушла очень далеко от дома, судя по блокам данных, что я смогла восстановить.");
			text.AddTranslation(GameCulture.Chinese, "星盘袭击者是个天才星尘蜈蚣, 或是G-S-C3, 作为终身伴侣和合作伙伴在火星精英中很受欢迎. 从我恢复出的巡航机的存储芯片来看, 他一定在离家很远的地方探索着");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO27");
            text.SetDefault("I took the time to analyze the remains of this incredible creature. Every time it attacked, the entire planet seemed to resonate against its will. I can do nothing but to worry about the consequences of its death. At least, you saved Terraria of certain doom..........again.");
            text.AddTranslation(GameCulture.Russian, "Я проанализировала останки этого невероятного существа. Каждый раз, когда оно атаковало, вся планета резонировала против его воли. Я не могу сделать ничего, кроме как волноваться о последствиях его смерти. Во всяком случае, ты спас Террарию от незавидной судьбы...... вновь.");
			text.AddTranslation(GameCulture.Chinese, "我花了时间对这个不可思议的生物的遗体进行了分析, 每次它攻击的时候, 整个星球似乎都在它的意愿中产生共鸣, 我除了担心它的死亡的后果之外, 什么都做不了, 至少你又一次从末日中拯救了Terraria...又一次");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO28");
            text.SetDefault("Such an ancient presence is worth documenting - the material of its plates can withstand temperatures equal to the core of the Terrarian Sun! This will revolutionize containment procedures for ARS-0N prisoners if we can make materials half as resistant to heat!");
            text.AddTranslation(GameCulture.Russian, "Столь древняя сущность заслуживает документирования. Материалы её пластин могут выдержать температуру, равную ядру Солнца Террарии! Это революционизирует методы сдерживания для ARS-0N узников если мы сможем создать материалы, которые будут иметь хотя бы половину подобной стойкости.");
			text.AddTranslation(GameCulture.Chinese, "这样一个古老的存在是值得记录的--它外表的材料可以承受与地球太阳核心的温度相等的温度!如果我们能使材料具有一半的耐热性, 这将彻底改变对 ARS-0N 囚犯的控制装置!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO29");
            text.SetDefault("Whoever made the Ravager deserves to be put in HI-MAX containment. All those tortured souls....... Well, at least you put them out of their misery.");
			text.AddTranslation(GameCulture.Russian, "Тот, кто создал Опустошителя, заслуживает быть заключённым в Камере Максимального Содержания. Все эти измученные души.... Ну, по крайней мере ты освободил их от бренного существования.");
			text.AddTranslation(GameCulture.Chinese, "那些制造毁灭魔像的人就应该被关进 HI-MAX 监狱中去. 这些可怜的灵魂受尽了折磨......好吧, 至少你将他们从痛苦之渊中解放出来");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO30");
            text.SetDefault("Interesting... those Bumblebirbs were actually meant to be clones of Yharon. I’m glad that experiment was a failure!");
            text.AddTranslation(GameCulture.Russian, "Интересно... Эти Птицешмели должны были быть клонами Ярона. Как я рада, что этот эксперимент провалился.");
			text.AddTranslation(GameCulture.Chinese, "有意思...那些癫痫鸟实际上是丛林龙犽戎的克隆体. 我很高兴看到那些实验都失败了!");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO31");
            text.SetDefault("You were lucky that thing got complacent and didn't open a portal to the Sun on our heads. The sheer strength and intelligence it exhibited means I need to make a whole new category for the classification of Worms.");
			text.AddTranslation(GameCulture.Russian, "Какое счастье, что ты не открыл портал на Солнце над нашими головами. Эта абсолютная сила и интеллект, что он продемонстрировал, означают, что мне потребуется создать совершенно новую категорию для классификации Червей.");           
			text.AddTranslation(GameCulture.Chinese, "你很幸运, 那东西膨胀了, 没有直接在你头上开个直通太阳的传送门. 他所展示出的力量和智慧, 意味着我要对蠕虫的类别做一个全新的分类");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO32");
            text.SetDefault("I have my theories about the origin of this being, frightening more than his soul (if he even has one)... Irradiates negative energy, experimentation shown how in darkness this ''oblivion energy'', irradiated light but in light places irradiated shadow. I don't know where he came from but I know that whatever it is, it must be contained at any cost!");
			text.AddTranslation(GameCulture.Russian, "У меня есть теории о происхождении этого существа, которые пугают меня даже больше, чем его душа (если она у него вообще есть)... Излучает негативную энергию, поглощает свет и создаёт тени. Не знаю, откуда он пришёл, но знаю, что кто бы он ни был, его нужно сдержать любой ценой!");           
			text.AddTranslation(GameCulture.Chinese, "对于这生物的起源我有些基本的猜测, 而不是单纯害怕他的灵魂(如果他有灵魂的话)...反辐射能量, 研究表明, 这种'湮灭能量'在黑暗中发出光芒, 在光明中辐射黑暗. 我不知道它是怎么来的, 但是我知道我们必须付出一切代价封印它.");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("EntryO33");
            text.SetDefault("Supreme Calamitas has been defeated but she speaks of a being even stronger than herself. We must hope that he hasn't taken notice of us yet.");
            text.AddTranslation(GameCulture.Russian, "Совершенная Каламитас была побеждена, но она говорила о существе, ещё более сильном, чем она сама. Мы можем лишь надеяться, что он ещё не обратил на нас внимания.");
			text.AddTranslation(GameCulture.Chinese, "至尊灾厄眼被击败了, 但是他说还有一个比他更为强大的存在, 我们必须祈祷他还没有注意到我们.");
            mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryO34");
            text.SetDefault("I’m honestly not sure why giant spinning skulls are the key to everything, but somehow they seem to contain the power of celestial beings within them...");
            text.AddTranslation(GameCulture.Russian, "Я на самом деле не уверена, почему гигантские вращающиеся черепа - ключ ко всему, но каким-то образом они хранят в себе мощь божественных созданий...");
            text.AddTranslation(GameCulture.Chinese, "老实说，我不知道为什么巨大的旋转头骨是一切的关键，但不知何故，它们似乎包含着天人的力量…");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryO35");
            text.SetDefault("Yeah, I know that we are the ones capturing and farming horrifying eldritch entities. But who the hell thought It was a good idea to put loot bags inside a giant monster?!?!");
            text.AddTranslation(GameCulture.Russian, "Да, я знаю, что мы те, кто захватывает и добывает материалы из сверхъестественных существ. Но кто чёрт возьми подумал, что будет хорошей идеей поместить сумку с ценностями внутрь гигантского чудовища?!?!");
            text.AddTranslation(GameCulture.Chinese, "是的，我知道我们是捕获和饲养恐怖的怪物的人。但谁会认为把宝藏袋放在一个巨大的怪物里面是个好主意呢？！？你看！");
	    mod.AddTranslation(text);
			text = mod.CreateTranslation("EntryO36");
            text.SetDefault("Кemember Manager, Treasure Bags are valuable but not everything comes inside them. That mutant man can help you get a boss's most elusive drops.");
            text.AddTranslation(GameCulture.Russian, "Помни, Управляющий, хотя Сумки с Сокровищами ценны, но не всё может найтись внутри. Мутант может помочь тебе добыть редчайший лут с боссов.");
            text.AddTranslation(GameCulture.Chinese, "КEmember经理，宝藏袋很值钱，但不是所有东西都在里面。那个变种人能帮你得到Boss的稀有掉落物。");
	    
	    mod.AddTranslation(text);
        }

		public override void ResetEffects()
		{
			OA = false;
			Meteor = false;
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
			if (NPC.downedBoss2 && AlchemistNPC.modConfiguration.OperatorSpawn)
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
            string Carmen = Language.GetTextValue("Mods.AlchemistNPC.Carmen");
			switch (WorldGen.genRand.Next(2))
            {
                case 0:
                    return Angela;
				case 1:
                    return Carmen;
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
		string EntryO19 = Language.GetTextValue("Mods.AlchemistNPC.EntryO19");
		string EntryO20 = Language.GetTextValue("Mods.AlchemistNPC.EntryO20");
		string EntryO21 = Language.GetTextValue("Mods.AlchemistNPC.EntryO21");
		string EntryO22 = Language.GetTextValue("Mods.AlchemistNPC.EntryO22");
		string EntryO23 = Language.GetTextValue("Mods.AlchemistNPC.EntryO23");
		string EntryO24 = Language.GetTextValue("Mods.AlchemistNPC.EntryO24");
		string EntryO25 = Language.GetTextValue("Mods.AlchemistNPC.EntryO25");
		string EntryO26 = Language.GetTextValue("Mods.AlchemistNPC.EntryO26");
		string EntryO27 = Language.GetTextValue("Mods.AlchemistNPC.EntryO27");
		string EntryO28 = Language.GetTextValue("Mods.AlchemistNPC.EntryO28");
		string EntryO29 = Language.GetTextValue("Mods.AlchemistNPC.EntryO29");
		string EntryO30 = Language.GetTextValue("Mods.AlchemistNPC.EntryO30");
		string EntryO31 = Language.GetTextValue("Mods.AlchemistNPC.EntryO31");
		string EntryO32 = Language.GetTextValue("Mods.AlchemistNPC.EntryO32");
		string EntryO33 = Language.GetTextValue("Mods.AlchemistNPC.EntryO33");
		string EntryO34 = Language.GetTextValue("Mods.AlchemistNPC.EntryO34");
		string EntryO35 = Language.GetTextValue("Mods.AlchemistNPC.EntryO35");
		string EntryO36 = Language.GetTextValue("Mods.AlchemistNPC.EntryO36");
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
		if (ModLoader.GetMod("CalamityMod") != null && NPC.downedBoss3)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO17;
			} 
		}
		if (NPC.downedPlantBoss)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO19;
			} 
		}
		if (NPC.downedGolemBoss)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO20;
			} 
		}
		if (ModLoader.GetMod("CalamityMod") != null && NPC.downedMoonlord)
		{
			if (Main.rand.Next(7) == 0)
			{
				return EntryO18;
			} 
		}
		if (ModLoader.GetMod("ThoriumMod") != null)
		{
			if (Main.rand.Next(6) == 0)
			{
				return EntryO2;
				
			} 
		}
		if (ModLoader.GetMod("ThoriumMod") != null && Main.hardMode)
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
		if (Main.rand.Next(5) == 0 && NPC.downedQueenBee)
			{                                                 
			return EntryO21;
			}
		if (ModLoader.GetMod("CalamityMod") != null && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && CalamityModDownedPlaguebringer)
				{                                                 
				return EntryO22;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedCryogen)
				{                                                 
				return EntryO25;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedProvidence)
				{                                                 
				return EntryO28;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedRavager)
				{                                                 
				return EntryO29;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedBirb)
				{                                                 
				return EntryO30;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedDOG)
				{                                                 
				return EntryO31;
				}
			if (Main.rand.Next(5) == 0 && CalamityModDownedSCal)
				{                                                 
				return EntryO33;
				}
		}
		if (ModLoader.GetMod("ThoriumMod") != null && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && ThoriumModDownedFallenBeholder)
				{                                                 
				return EntryO23;
				}
			if (Main.rand.Next(5) == 0 && ThoriumModDownedStarScout)
				{                                                 
				return EntryO24;
				}
		}
		if (ModLoader.GetMod("SacredTools") != null && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && SacredToolsDownedAbbadon)
				{                  
				return EntryO32;
				}
		}
		if (ModLoader.GetMod("SpiritMod") != null && Main.hardMode)
		{
			if (Main.rand.Next(5) == 0 && SpiritModDownedStarplateRaider)
				{                                                 
				return EntryO26;
				}
			if (Main.rand.Next(5) == 0 && SpiritModDownedOverseer)
				{                                                 
				return EntryO27;
				}
		}
		if (ModLoader.GetMod("Fargowiltas") != null)
		{
			if (Main.rand.Next(10) == 0)
				{                                                 
				return EntryO36;
				}
		}
            switch (Main.rand.Next(6))
            {
                case 0:                                     
				return EntryO1;
                case 1:                                                      
				return EntryO3;
                case 2:
				return EntryO4;
				case 3:
				return EntryO34;
				case 4:
				return EntryO35;
                default:
				return EntryO7;
            }
        }
 
        public override void SetChatButtons(ref string button, ref string button2)
        {
			string EGOShop = Language.GetTextValue("Mods.AlchemistNPC.EGOShop");
			string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPC.BossDropsShop");
			string BossDropsModsShop = Language.GetTextValue("Mods.AlchemistNPC.BossDropsModsShop");
			string VanillaTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPC.VanillaTreasureBagsShop");
			string ModdedTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPC.ModdedTreasureBagsShop");
			string ModdedTreasureBagsShop2 = Language.GetTextValue("Mods.AlchemistNPC.ModdedTreasureBagsShop2");
			string ModdedTreasureBagsShop3 = Language.GetTextValue("Mods.AlchemistNPC.ModdedTreasureBagsShop3");
			string ShopChanger = Language.GetTextValue("Mods.AlchemistNPC.ShopChanger");
			string Meteorite = Language.GetTextValue("Mods.AlchemistNPC.Meteorite");
			
			Player player = Main.player[Main.myPlayer];
			if (player.active)
			{
				for (int j = 0; j < player.inventory.Length; j++)
				{
					if (player.inventory[j].type == mod.ItemType("SymbioteMeteorite"))
					{
						Meteor = true;
					}
				}
			}
			
			if (Shop == 1)
			{
			button = BossDropsShop;
			}
			if (Shop == 11)
			{
			button = BossDropsModsShop;
			}
			if (Shop == 2)
			{
			button = EGOShop;
			}
			if (Shop == 3)
			{
			button = VanillaTreasureBagsShop;
			}
			if (Shop == 4)
			{
			button = ModdedTreasureBagsShop;
			}
			if (Shop == 5)
			{
			button = ModdedTreasureBagsShop2;
			}
			if (Shop == 6)
			{
			button = ModdedTreasureBagsShop3;
			}
			if (Meteor) button = Meteorite;
			button2 = ShopChanger;
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				if (Meteor)
				{
					Player player = Main.player[Main.myPlayer];
					player.QuickSpawnItem(mod.ItemType("Symbiote"));
					if (Main.player[Main.myPlayer].HasItem(mod.ItemType("SymbioteMeteorite")) && Meteor)
					{
						Item[] inventory = Main.player[Main.myPlayer].inventory;
						for (int k = 0; k < inventory.Length; k++)
						{
							if (inventory[k].type == mod.ItemType("SymbioteMeteorite") && Meteor)
							{
								inventory[k].stack--;
								Meteor = false;
							}
						}
					}
				}
				if (!AlchemistNPC.modConfiguration.TS || !Main.expertMode)
				{
					shop = true;
				}
				if (AlchemistNPC.modConfiguration.TS && Main.expertMode)
				{
					shop = true;
					ShopChangeUIO.visible = false;
				}
			}
			else
			{
				if (AlchemistNPC.modConfiguration.TS && Main.expertMode)
				{
					ShopChangeUIO.visible = true;
				}
				if (!AlchemistNPC.modConfiguration.TS || !Main.expertMode)
				{
					if (Shop == 1) Shop = 11;
					else if (Shop == 11) Shop = 2;
					else if (Shop == 2) Shop = 1;
				}
			}
		}
 
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.World.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedPlaguebringer
		{
		get { return CalamityMod.World.CalamityWorld.downedPlaguebringer; }
		}
		public bool CalamityModDownedRavager
		{
		get { return CalamityMod.World.CalamityWorld.downedScavenger; }
		}
		public bool CalamityModDownedBirb
		{
		get { return CalamityMod.World.CalamityWorld.downedBumble; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.World.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.World.CalamityWorld.downedDoG; }
		}
		public bool CalamityModDownedYharon
		{
		get { return CalamityMod.World.CalamityWorld.downedYharon; }
		}
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.World.CalamityWorld.downedSCal; }
		}
		public bool CalamityModDownedAstrum
		{
		get { return CalamityMod.World.CalamityWorld.downedStarGod; }
		}
		public bool CalamityModDownedSlimeGod
        {
        get { return CalamityMod.World.CalamityWorld.downedSlimeGod; }
        }
		public bool CalamityModDownedHiveMind
        {
        get { return CalamityMod.World.CalamityWorld.downedHiveMind; }
        }
        public bool CalamityModDownedPerforators
        {
        get { return CalamityMod.World.CalamityWorld.downedPerforator; }
        }
		public bool CalamityModDownedCalamitas
        {
        get { return CalamityMod.World.CalamityWorld.downedCalamitas; }
        }
		public bool CalamityModDownedProvidence
        {
        get { return CalamityMod.World.CalamityWorld.downedProvidence; }
        }
		public bool CalamityModDownedCryogen
		{
        get { return CalamityMod.World.CalamityWorld.downedCryogen; }
        }
		public bool CalamityModDownedLeviathan
        {
        get { return CalamityMod.World.CalamityWorld.downedLeviathan; }
        }
		public bool CalamityModDownedAstrageldon
        {
        get { return CalamityMod.World.CalamityWorld.downedAstrageldon; }
        }
		public bool CalamityModDownedCrabulon
        {
        get { return CalamityMod.World.CalamityWorld.downedCrabulon; }
        }
		public bool CalamityModDownedDesertScourge
        {
        get { return CalamityMod.World.CalamityWorld.downedDesertScourge; }
        }
		public bool CalamityModDownedAquaticScourge
        {
        get { return CalamityMod.World.CalamityWorld.downedAquaticScourge; }
        }
		public bool CalamityModDownedBrimstoneElemental
        {
        get { return CalamityMod.World.CalamityWorld.downedBrimstoneElemental; }
        }
		public bool CalamityModDownedMothron
        {
        get { return CalamityMod.World.CalamityWorld.downedBuffedMothron; }
        }
 
		public bool ThoriumModDownedGTBird
        {
        get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedQueenJelly
        {
        get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }
		public bool ThoriumModDownedViscount
        {
        get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedStorm
        {
        get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }
        public bool ThoriumModDownedChampion
        {
        get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }
        public bool ThoriumModDownedStarScout
        {
        get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
        get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
        get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedLich
        {
        get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        public bool ThoriumModDownedAbyssion
        {
        get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		
		public bool SacredToolsDownedDecree
		{
        get { return SacredTools.ModdedWorld.downedDecree; }
        }
		public bool SacredToolsDownedPumpkin
		{
        get { return SacredTools.ModdedWorld.downedPumpboi; }
        }
		public bool SacredToolsDownedHarpyPreHM
		{
        get { return SacredTools.ModdedWorld.downedHarpy; }
        }
		public bool SacredToolsDownedAraneas
		{
        get { return SacredTools.ModdedWorld.downedAraneas; }
        }
		public bool SacredToolsDownedHarpyHM
		{
        get { return SacredTools.ModdedWorld.downedRaynare; }
        }
		public bool SacredToolsDownedPrimordia
		{
        get { return SacredTools.ModdedWorld.downedPrimordia; }
        }
		public bool SacredToolsDownedAbbadon
		{
        get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
		public bool SacredToolsDownedAraghur
		{
        get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
		public bool SacredToolsDownedLunarians
		{
        get { return SacredTools.ModdedWorld.downedLunarians; }
        }
		public bool SacredToolsDownedChallenger
		{
        get { return SacredTools.ModdedWorld.downedChallenger; }
        }
		
		public bool SpiritModDownedScarabeus
		{
        get { return SpiritMod.MyWorld.downedScarabeus; }
        }
		public bool SpiritModDownedBane
		{
        get { return SpiritMod.MyWorld.downedReachBoss; }
        }
		public bool SpiritModDownedFlier
		{
        get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
		public bool SpiritModDownedStarplateRaider
		{
        get { return SpiritMod.MyWorld.downedRaider; }
        }
		public bool SpiritModDownedInfernon
		{
        get { return SpiritMod.MyWorld.downedInfernon; }
        }
		public bool SpiritModDownedDusking
		{
        get { return SpiritMod.MyWorld.downedDusking; }
        }
		public bool SpiritModDownedEtherialUmbra
		{
        get { return SpiritMod.MyWorld.downedSpiritCore; }
        }
		public bool SpiritModDownedIlluminantMaster
		{
        get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }
		public bool SpiritModDownedAtlas
		{
        get { return SpiritMod.MyWorld.downedAtlas; }
        }
		public bool SpiritModDownedOverseer
		{
        get { return SpiritMod.MyWorld.downedOverseer; }
        }
		
		public bool EnigmaDownedSharkron
		{
        get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }
		public bool EnigmaDownedHypothema
		{
        get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }
		public bool EnigmaDownedRagnar
		{
        get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }
		public bool EnigmaDownedAnDio
		{
        get { return Laugicality.LaugicalityWorld.downedAnDio; }
        }
		public bool EnigmaDownedAnnihilator
		{
        get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }
		public bool EnigmaDownedSlybertron
		{
        get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }
		public bool EnigmaDownedSteamTrain
		{
        get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }
		public bool EnigmaDownedEtheria
		{
        get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }
		
		public bool PinkymodDownedST
		{
        get { return pinkymod.Global.Pinkyworld.downedSunlightTrader; }
        }
		public bool PinkymodDownedMS
		{
        get { return pinkymod.Global.Pinkyworld.downedMythrilSlime; }
        }
		public bool PinkymodDownedVD
		{
        get { return pinkymod.Global.Pinkyworld.downedValdaris; }
        }
		public bool PinkymodDownedAD
		{
        get { return pinkymod.Global.Pinkyworld.downedAbyssmalDuo; }
        }
		
		public bool AAModDownedMonarch
		{
        get { return AAMod.AAWorld.downedMonarch; }
        }
		public bool AAModDownedGrips
		{
        get { return AAMod.AAWorld.downedGrips; }
        }
		public bool AAModDownedTruffleToad
		{
        get { return AAMod.AAWorld.downedToad; }
        }
		public bool AAModDownedBrood
		{
        get { return AAMod.AAWorld.downedBrood; }
        }
		public bool AAModDownedHydra
		{
        get { return AAMod.AAWorld.downedHydra; }
        }
		public bool AAModDownedSerpent
		{
        get { return AAMod.AAWorld.downedSerpent; }
        }
		public bool AAModDownedDjinn
		{
        get { return AAMod.AAWorld.downedDjinn; }
        }
		public bool AAModDownedEquinox
		{
        get { return AAMod.AAWorld.downedEquinox; }
        }
		public bool AAModDownedSisters
		{
        get { return AAMod.AAWorld.downedSisters; }
        }
		public bool AAModDownedYamata
		{
        get { return AAMod.AAWorld.downedYamata; }
        }
		public bool AAModDownedAkuma
		{
        get { return AAMod.AAWorld.downedAkuma; }
        }
		public bool AAModDownedZero
		{
        get { return AAMod.AAWorld.downedZero; }
        }
		public bool AAModDownedShen
		{
        get { return AAMod.AAWorld.downedShen; }
        }
		
		public bool EADownedWasteland
		{
        get { return ElementsAwoken.MyWorld.downedWasteland; }
        }
		public bool EADownedWyrm
		{
        get { return ElementsAwoken.MyWorld.downedAncientWyrm;}
        }
		public bool EADownedInfernace
		{
        get { return ElementsAwoken.MyWorld.downedInfernace; }
        }
		public bool EADownedScourgeFighter
		{
        get { return ElementsAwoken.MyWorld.downedScourgeFighter; }
        }
		public bool EADownedRegaroth
		{
        get { return ElementsAwoken.MyWorld.downedRegaroth; }
        }
		public bool EADownedCelestials
		{
        get { return ElementsAwoken.MyWorld.downedCelestial; }
        }
		public bool EADownedObsidious
		{
        get { return ElementsAwoken.MyWorld.downedObsidious; }
        }
		public bool EADownedPermafrost
		{
        get { return ElementsAwoken.MyWorld.downedPermafrost; }
        }
		public bool EADownedAqueous
		{
        get { return ElementsAwoken.MyWorld.downedAqueous; }
        }
		public bool EADownedGuardian
		{
        get { return ElementsAwoken.MyWorld.downedGuardian; }
        }
		public bool EADownedVolcanox
		{
        get { return ElementsAwoken.MyWorld.downedVolcanox; }
        }
		public bool EADownedVoidLevi
		{
        get { return ElementsAwoken.MyWorld.downedVoidLeviathan; }
        }
		public bool EADownedAzana
		{
        get { return ElementsAwoken.MyWorld.downedAzana; }
        }
		public bool EADownedAncients
		{
        get { return ElementsAwoken.MyWorld.downedAncients; }
        }
		
		public bool ReDownedChicken
		{
        get { return Redemption.RedeWorld.downedKingChicken; }
        }
		public bool ReDownedThorn
		{
        get { return Redemption.RedeWorld.downedThorn; }
        }
		public bool ReDownedKeeper
		{
        get { return Redemption.RedeWorld.downedTheKeeper; }
        }
		public bool ReDownedCrystal
		{
        get { return Redemption.RedeWorld.downedXenomiteCrystal; }
        }
		public bool ReDownedIEye
		{
        get { return Redemption.RedeWorld.downedInfectedEye; }
        }
		public bool ReDownedKingSlayer
		{
        get { return Redemption.RedeWorld.downedSlayer; }
        }
		public bool ReDownedVCleaver
		{
        get { return Redemption.RedeWorld.downedVlitch1; }
        }
		public bool ReDownedVGigipede
		{
        get { return Redemption.RedeWorld.downedVlitch2; }
        }
		public bool ReDownedObliterator
		{
        get { return Redemption.RedeWorld.downedVlitch3; }
        }
		public bool ReDownedPZero
		{
        get { return Redemption.RedeWorld.downedPatientZero; }
        }
		public bool ReDownedThornRe
		{
        get { return Redemption.RedeWorld.downedThornPZ; }
        }
		public bool ReDownedGolemRe
		{
        get { return Redemption.RedeWorld.downedEaglecrestGolemPZ; }
        }
		public bool ReDownedNebuleus
		{
        get { return Redemption.RedeWorld.downedNebuleus; }
        }
		
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("APMC"));
		}
		
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			bool T1 = false;
			bool T2 = false;
			bool T3 = false;
			bool T4 = false;
			bool T5 = false;
			bool T6 = false;
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active && player == Main.LocalPlayer)
				{
					for (int index1 = 0; index1 < 40; ++index1)
					{
						if (player.bank3.item[index1].stack == 0 && !T1)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier1"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT1;
							T1 = true;
							continue;
						}
						if (player.bank3.item[index1].stack == 0 && !T2)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier2"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT2;
							T2 = true;
							continue;
						}
						if (player.bank3.item[index1].stack == 0 && !T3)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier3"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT3;
							T3 = true;
							continue;
						}
						if (player.bank3.item[index1].stack == 0 && !T4)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier4"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT4;
							T4 = true;
							continue;
						}
						if (player.bank3.item[index1].stack == 0 && !T5)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier5"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT5;
							T5 = true;
							continue;
						}
						if (player.bank3.item[index1].stack == 0 && !T6)
						{
							player.bank3.item[index1].SetDefaults(mod.ItemType("ReversivityCoinTier6"));
							player.bank3.item[index1].stack = player.GetModPlayer<AlchemistNPCPlayer>().RCT6;
							T6 = true;
							break;
						}
					}
				}
			}
			if (Shop == 1)
			{
				shop.item[nextSlot].SetDefaults (ItemID.Lens);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.DemoniteOre);
				shop.item[nextSlot].shopCustomPrice = 1500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.ShadowScale);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.RottenChunk);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.CrimtaneOre);
				shop.item[nextSlot].shopCustomPrice = 1500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.TissueSample);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults (ItemID.Vertebrae);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				if (NPC.downedQueenBee)
				{
					shop.item[nextSlot].SetDefaults (ItemID.BeeWax);
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Stinger);
					shop.item[nextSlot].shopCustomPrice = 75000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.JungleSpores);
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Vine);
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
				}
				if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults (ItemID.Feather);
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.Bone);
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
				}
				if (AlchemistNPCWorld.downedSandElemental)
				{
					shop.item[nextSlot].SetDefaults (3783);
					shop.item[nextSlot].shopCustomPrice = 200000;
					nextSlot++;
				}
				if (NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults (ItemID.SoulofLight);
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SoulofNight);
					shop.item[nextSlot].shopCustomPrice = 15000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SoulofFlight);
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
				}
				if (NPC.downedMechBoss3)
				{
					shop.item[nextSlot].SetDefaults (ItemID.SoulofFright);
					shop.item[nextSlot].shopCustomPrice = 30000;
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
					shop.item[nextSlot].SetDefaults (ItemID.BlackLens);
					shop.item[nextSlot].shopCustomPrice = 200000;
					nextSlot++;
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
				{
					shop.item[nextSlot].SetDefaults (ItemID.HallowedBar);
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
				}
				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults (ItemID.Ectoplasm);
					shop.item[nextSlot].shopCustomPrice = 35000;
					nextSlot++;
				}
				if (NPC.downedGolemBoss)
				{
					shop.item[nextSlot].SetDefaults (ItemID.BrokenHeroSword);
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
				}
				if (NPC.downedMoonlord)
				{
					shop.item[nextSlot].SetDefaults (ItemID.FragmentSolar);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.FragmentNebula);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.FragmentVortex);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.FragmentStardust);
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
				}
			}
			if (Shop == 11)
			{
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("Petal"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					if (NPC.downedGolemBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BrokenHeroFragment"));
						shop.item[nextSlot].shopCustomPrice = 250000;
						nextSlot++;
					}
					if (NPC.downedMoonlord)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("WhiteDwarfFragment"));
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CometFragment"));
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CelestialFragment"));
						shop.item[nextSlot].shopCustomPrice = 100000;
						nextSlot++;
					}
				}
				if (ModLoader.GetMod("SpiritMod") != null)
				{
					if (NPC.downedGolemBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BrokenParts"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BrokenStaff"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
					}
				}
				if (ModLoader.GetMod("LithosArmory") != null)
				{
					if (NPC.downedGolemBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroFlail"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroGreatbow"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroShotgun"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroSling"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroSpear"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("LithosArmory").ItemType("BrokenHeroWand"));
						shop.item[nextSlot].shopCustomPrice = 500000;
						nextSlot++;
					}
				}
				if (NPC.downedMechBossAny)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("DivineLava"));
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("CursedIce"));
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (CalamityModDownedHiveMind)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("TrueShadowScale"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					}
					if (CalamityModDownedPerforators)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodSample"));
					shop.item[nextSlot].shopCustomPrice = 20000;
					nextSlot++;
					}
					if (CalamityModDownedSlimeGod)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EbonianGel"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PurifiedGel"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					}
					if (NPC.downedMechBoss2)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BlightedLens"));
					shop.item[nextSlot].shopCustomPrice = 150000;
					nextSlot++;
					}
					if (CalamityModDownedCalamitas)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyCore"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					}
					if (NPC.downedPlantBoss || CalamityModDownedCryogen)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofEleum"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++; 
					}
					if (NPC.downedPlantBoss || CalamityModDownedAquaticScourge)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofCinder"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					}
					if (NPC.downedPlantBoss || CalamityModDownedBrimstoneElemental)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos"));
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
					}
					if (NPC.downedPlantBoss)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Tenebris"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Lumenite"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DepthCells"));
					shop.item[nextSlot].shopCustomPrice = 30000;
					nextSlot++;
					}
					if (CalamityModDownedAstrageldon)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstralJelly"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Stardust"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					}
					if (CalamityModDownedLeviathan)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LivingShard"));
						shop.item[nextSlot].shopCustomPrice = 30000;
						nextSlot++;
					}
					if (NPC.downedPlantBoss)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("SolarVeil"));
						shop.item[nextSlot].shopCustomPrice = 50000;
						nextSlot++;
					}
					if (CalamityModDownedRavager)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BarofLife"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					}
					if (CalamityModDownedAstrum)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("MeldBlob"));
					shop.item[nextSlot].shopCustomPrice = 10000;
					nextSlot++;
					}
					if (CalamityModDownedGuardian)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("UnholyEssence"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					}
					if (CalamityModDownedPolter)
					{
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BloodOrb"));
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm"));
					shop.item[nextSlot].shopCustomPrice = 100000;
					nextSlot++;
					}
					if (CalamityModDownedDOG && AlchemistNPCWorld.downedDOGPumpking)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel"));
						shop.item[nextSlot].shopCustomPrice = 120000;
						nextSlot++;			
					}
					if (CalamityModDownedDOG && AlchemistNPCWorld.downedDOGIceQueen)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy"));
						shop.item[nextSlot].shopCustomPrice = 120000;
						nextSlot++;
					}
					if (CalamityModDownedMothron)
					{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DarksunFragment"));
						shop.item[nextSlot].shopCustomPrice = 150000;
						nextSlot++;
					}
				}
			}
			if (Shop == 2)
			{
				if (AlchemistNPC.modConfiguration.CoinsDrop && Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("WorldControlUnit"));
					shop.item[nextSlot].shopCustomPrice = new int?(50);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
				}
				if (!AlchemistNPC.modConfiguration.CoinsDrop && NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("WorldControlUnit"));
					shop.item[nextSlot].shopCustomPrice = 2000000;
					nextSlot++;
				}
				if (NPC.downedMoonlord)
				{
					if (AlchemistNPC.modConfiguration.CoinsDrop)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("TerrainReformer"));
						shop.item[nextSlot].shopCustomPrice = new int?(30);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
						nextSlot++;
					}
					if (!AlchemistNPC.modConfiguration.CoinsDrop)
					{
						shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("TerrainReformer"));
						shop.item[nextSlot].shopCustomPrice = 5000000;
						nextSlot++;
					}
				}
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorSnow"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorDesert"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorJungle"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorCorruption"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorCrimson"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorSpace"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				if (NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorDungeon"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
				}
				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("HoloprojectorHallowed"));
					shop.item[nextSlot].shopCustomPrice = 330000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("GlobalTeleporter"));
					nextSlot++;
				}
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
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Laetitia"));
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
				}
				if (NPC.downedMechBossAny)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("FuneralofDeadButterflies"));
				shop.item[nextSlot].shopCustomPrice = 500000;
				nextSlot++;
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
					{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("LaetitiaGift"));
					shop.item[nextSlot].shopCustomPrice = 300000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationHead"));
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationBody"));
					shop.item[nextSlot].shopCustomPrice = 350000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("ReverberationLegs"));
					shop.item[nextSlot].shopCustomPrice = 300000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Reverberation"));
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					}
				if (NPC.downedPlantBoss)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("BigBirdLamp"));
				shop.item[nextSlot].shopCustomPrice = 750000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("GrinderMK4"));
				shop.item[nextSlot].shopCustomPrice = 750000;
				nextSlot++;
				}
				if (NPC.downedGolemBoss)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("Spore"));
				shop.item[nextSlot].shopCustomPrice = 1000000;
				nextSlot++;
				}
			}
			if (Shop == 3)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.KingSlimeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(5);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EyeOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EaterOfWorldsBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.BrainOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.QueenBeeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(20);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(30);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
					nextSlot++;
					}
					if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (DD2Event.DownedInvasionT1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
						}
					if (Main.hardMode && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.WallOfFleshBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
					nextSlot++;
					}
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.DestroyerBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.TwinsBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronPrimeBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					}
					if (NPC.downedPlantBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.PlanteraBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(15);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
					nextSlot++;
					}
					if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (DD2Event.DownedInvasionT2 && NPC.downedMechBossAny)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
							}
						}
					if (NPC.downedGolemBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.GolemBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(5);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (DD2Event.DownedInvasionT3 && NPC.downedGolemBoss)
					{
					shop.item[nextSlot].SetDefaults (ItemID.BossBagBetsy);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (NPC.downedFishron && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.FishronBossBag);
					shop.item[nextSlot].shopCustomPrice = new int?(10);
					shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
					nextSlot++;
					}
					if (NPC.downedMoonlord && Main.expertMode)
					{
						shop.item[nextSlot].SetDefaults (ItemID.MoonLordBossBag);
						shop.item[nextSlot].shopCustomPrice = new int?(20);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
						nextSlot++;
					}
				}
				if (!AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.KingSlimeBossBag);
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EyeOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = 350000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.EaterOfWorldsBossBag);
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.BrainOfCthulhuBossBag);
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.QueenBeeBossBag);
					shop.item[nextSlot].shopCustomPrice = 750000;
					nextSlot++;
					shop.item[nextSlot].SetDefaults (ItemID.SkeletronBossBag);
					shop.item[nextSlot].shopCustomPrice = 1000000;
					nextSlot++;
					}
					if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (DD2Event.DownedInvasionT1)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
							}
						}
					if (Main.hardMode && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.WallOfFleshBossBag);
					shop.item[nextSlot].shopCustomPrice = 1500000;
					nextSlot++;
					}
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
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
					}
					if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (DD2Event.DownedInvasionT2 && NPC.downedMechBossAny)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag"));
								shop.item[nextSlot].shopCustomPrice = 2500000;
								nextSlot++;
							}
						}
					if (NPC.downedPlantBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.PlanteraBossBag);
					shop.item[nextSlot].shopCustomPrice = 2500000;
					nextSlot++;
					}
					if (NPC.downedGolemBoss && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.GolemBossBag);
					shop.item[nextSlot].shopCustomPrice = 3000000;
					nextSlot++;
					}
					if (DD2Event.DownedInvasionT3 && NPC.downedGolemBoss)
					{
					shop.item[nextSlot].SetDefaults (ItemID.BossBagBetsy);
					shop.item[nextSlot].shopCustomPrice = 3500000;
					nextSlot++;
					}
					if (NPC.downedAncientCultist && Main.expertMode)
					{
					shop.item[nextSlot].SetDefaults (ItemID.FishronBossBag);
					shop.item[nextSlot].shopCustomPrice = 3500000;
					nextSlot++;
					}
					if (NPC.downedMoonlord && Main.expertMode)
					{
						shop.item[nextSlot].SetDefaults (ItemID.MoonLordBossBag);
						shop.item[nextSlot].shopCustomPrice = 4000000;
						nextSlot++;
					}
				}
			}
			if (Shop == 4)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedDesertScourge)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (CalamityModDownedCrabulon)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (CalamityModDownedHiveMind || CalamityModDownedPerforators)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
						}
					}
					if (Main.hardMode && Main.expertMode)
					{
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedSlimeGod)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
								nextSlot++;
							}
						}
					}
					if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedCryogen)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
								nextSlot++;
							}
							if (CalamityModDownedBrimstoneElemental)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
							}
							if (CalamityModDownedAquaticScourge)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
								nextSlot++;
							}
						}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						if (CalamityModDownedCalamitas)
						{
						shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
						shop.item[nextSlot].shopCustomPrice = new int?(25);
						shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
						nextSlot++;
						}
						if (CalamityModDownedLeviathan)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(25);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
						}
						if (CalamityModDownedPlaguebringer)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++; 
						}
						if (CalamityModDownedRavager)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++; 
						}
						if (CalamityModDownedAstrum)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
						}
					}
					if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedBirb)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if (CalamityModDownedProvidence)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(20);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if(CalamityModDownedPolter)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
							if (CalamityModDownedDOG)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
							if (CalamityModDownedYharon)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("YharonBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(20);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
						}
						if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (NPC.downedBoss3)	
							{
								if (ThoriumModDownedGTBird)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedQueenJelly)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedViscount)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CountBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(20);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedStorm)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedChampion)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (ThoriumModDownedStarScout)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(40);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
								}
								if (Main.hardMode)	
								{
									if (ThoriumModDownedBoreanStrider)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(5);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
									nextSlot++;
									}
									if (ThoriumModDownedFallenBeholder)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
									nextSlot++;
									}
									if (ThoriumModDownedLich)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LichBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
									nextSlot++;
									}
									if (ThoriumModDownedAbyssion)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								}
								if (NPC.downedMoonlord)	
								{
									if (ThoriumModDownedRagnarok)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("RagBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(50);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								}
							}
						}
						if (ModLoader.GetMod("SacredTools") != null)
						{
							if (NPC.downedBoss3)	
							{
								if (SacredToolsDownedDecree)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("DecreeBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(5);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
									nextSlot++;
									}
								if (SacredToolsDownedPumpkin)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyPreHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(15);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
									nextSlot++;
									}
								if (SacredToolsDownedAraneas)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("AraneasBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
									nextSlot++;
									}
								if (SacredToolsDownedPrimordia)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(6);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								if (SacredToolsDownedAbbadon)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("OblivionBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								if (SacredToolsDownedAraghur)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("SerpentBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(15);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
									nextSlot++;
									}
								if (SacredToolsDownedLunarians)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("LunarBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(5);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
									nextSlot++;
									}
								if (SacredToolsDownedChallenger)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag"));
									shop.item[nextSlot].shopCustomPrice = new int?(10);
									shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
									nextSlot++;
									}
							}
						}
				}
				if (!AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedDesertScourge)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag"));
								shop.item[nextSlot].shopCustomPrice = 350000;
								nextSlot++;
							}
							if (CalamityModDownedCrabulon)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag"));
								shop.item[nextSlot].shopCustomPrice = 650000;
								nextSlot++;
							}
							if (CalamityModDownedHiveMind || CalamityModDownedPerforators)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
							}
						}
					}
					if (Main.hardMode && Main.expertMode)
					{
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (CalamityModDownedSlimeGod)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag"));
								shop.item[nextSlot].shopCustomPrice = 1750000;
								nextSlot++;
							}
						}
					}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						if (CalamityModDownedCryogen)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
						}
						if (CalamityModDownedBrimstoneElemental)
						{
							if (!CalamityModDownedProvidence)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
								shop.item[nextSlot].shopCustomPrice = 2000000;
								nextSlot++;
							}
							if (CalamityModDownedProvidence)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag"));
							shop.item[nextSlot].shopCustomPrice = 5000000;
							nextSlot++;
							}
						}
						if (CalamityModDownedAquaticScourge)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
						}
					}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						if (CalamityModDownedCalamitas)
						{
							if (!CalamityModDownedProvidence)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
							}
							if (CalamityModDownedProvidence)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag"));
							shop.item[nextSlot].shopCustomPrice = 5000000;
							nextSlot++;
							}
						}
						if (CalamityModDownedLeviathan)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = 3500000;
							nextSlot++;
						}
						if (!CalamityModDownedProvidence && CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
						}
						if (CalamityModDownedProvidence && CalamityModDownedAstrageldon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag"));
							shop.item[nextSlot].shopCustomPrice = 5000000;
							nextSlot++;
						}
						if (CalamityModDownedAstrum)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag"));
							shop.item[nextSlot].shopCustomPrice = 3500000;
							nextSlot++;
						}
						if (CalamityModDownedPlaguebringer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++; 
							}
						if (CalamityModDownedRavager)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++; 
							}
					}
					if (ModLoader.GetMod("CalamityMod") != null)
					{
						if (CalamityModDownedBirb)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
						}
						if (CalamityModDownedProvidence)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag"));
							shop.item[nextSlot].shopCustomPrice = 6000000;
							nextSlot++;
						}
						if (CalamityModDownedPolter)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag"));
							shop.item[nextSlot].shopCustomPrice = 7500000;
							nextSlot++;
						}
						if (CalamityModDownedDOG)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag"));
							shop.item[nextSlot].shopCustomPrice = 10000000;
							nextSlot++;
						}
						if (CalamityModDownedYharon)
						{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("CalamityMod").ItemType("YharonBag"));
							shop.item[nextSlot].shopCustomPrice = 15000000;
							nextSlot++;
						}
					}
					if (ModLoader.GetMod("ThoriumMod") != null)
						{
							if (NPC.downedBoss3)	
							{
								if (ThoriumModDownedGTBird)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag"));
								shop.item[nextSlot].shopCustomPrice = 500000;
								nextSlot++;
								}
								if (ThoriumModDownedQueenJelly)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag"));
								shop.item[nextSlot].shopCustomPrice = 750000;
								nextSlot++;
								}
								if (ThoriumModDownedViscount)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("CountBag"));
								shop.item[nextSlot].shopCustomPrice = 850000;
								nextSlot++;
								}
								if (ThoriumModDownedStorm)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
								}
								if (ThoriumModDownedChampion)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
								}
								if (ThoriumModDownedStarScout)
								{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag"));
								shop.item[nextSlot].shopCustomPrice = 1250000;
								nextSlot++;
								}
								if (Main.hardMode)	
								{
									if (ThoriumModDownedBoreanStrider)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag"));
									shop.item[nextSlot].shopCustomPrice = 1500000;
									nextSlot++;
									}
									if (ThoriumModDownedFallenBeholder)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag"));
									shop.item[nextSlot].shopCustomPrice = 2000000;
									nextSlot++;
									}
									if (ThoriumModDownedLich)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("LichBag"));
									shop.item[nextSlot].shopCustomPrice = 3000000;
									nextSlot++;
									}
									if (ThoriumModDownedAbyssion)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag"));
									shop.item[nextSlot].shopCustomPrice = 3500000;
									nextSlot++;
									}
								}
								if (NPC.downedMoonlord)	
								{
									if (ThoriumModDownedRagnarok)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ThoriumMod").ItemType("RagBag"));
									shop.item[nextSlot].shopCustomPrice = 5000000;
									nextSlot++;
									}
								}
							}
						}
					if (ModLoader.GetMod("SacredTools") != null)
						{
							if (NPC.downedBoss3)	
							{
								if (SacredToolsDownedDecree)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("DecreeBag"));
									shop.item[nextSlot].shopCustomPrice = 330000;
									nextSlot++;
									}
								if (SacredToolsDownedPumpkin)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag"));
									shop.item[nextSlot].shopCustomPrice = 500000;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyPreHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag"));
									shop.item[nextSlot].shopCustomPrice = 1000000;
									nextSlot++;
									}
								if (SacredToolsDownedAraneas)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("AraneasBag"));
									shop.item[nextSlot].shopCustomPrice = 1500000;
									nextSlot++;
									}
								if (SacredToolsDownedHarpyHM)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2"));
									shop.item[nextSlot].shopCustomPrice = 2000000;
									nextSlot++;
									}
								if (SacredToolsDownedPrimordia)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag"));
									shop.item[nextSlot].shopCustomPrice = 3000000;
									nextSlot++;
									}
								if (SacredToolsDownedAbbadon)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("OblivionBag"));
									shop.item[nextSlot].shopCustomPrice = 5000000;
									nextSlot++;
									}
								if (SacredToolsDownedAraghur)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("SerpentBag"));
									shop.item[nextSlot].shopCustomPrice = 7500000;
									nextSlot++;
									}
								if (SacredToolsDownedLunarians)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("LunarBag"));
									shop.item[nextSlot].shopCustomPrice = 10000000;
									nextSlot++;
									}
								if (SacredToolsDownedChallenger)
									{
									shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag"));
									shop.item[nextSlot].shopCustomPrice = 15000000;
									nextSlot++;
									}
							}
						}
				}
			}
			if (Shop == 5)
			{
				if (!NPC.downedBoss3)
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
				nextSlot++;
				}
				if (AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("AAMod") != null)
						{
							if (AAModDownedMonarch)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("MonarchBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(3);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (AAModDownedGrips)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("GripsBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(6);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (AAModDownedTruffleToad)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("TruffleBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(10);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (AAModDownedBrood)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("BroodBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (AAModDownedHydra)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("HydraBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
								nextSlot++;
							}
							if (AAModDownedSerpent)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("SerpentBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(3);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
								nextSlot++;
							}
							if (AAModDownedDjinn)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("DjinnBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(3);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
								nextSlot++;
							}
							if (AAModDownedEquinox)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("DBBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("NCBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
								nextSlot++;
							}
							if (AAModDownedSisters)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("AHBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(5);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if (AAModDownedYamata)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("YamataBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(9);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if (AAModDownedAkuma)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("AkumaBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(9);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if (AAModDownedZero)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("ZeroBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
								nextSlot++;
							}
							if (AAModDownedShen)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("ShenCache"));
								shop.item[nextSlot].shopCustomPrice = new int?(30);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("GripsSBag"));
								shop.item[nextSlot].shopCustomPrice = new int?(15);
								shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier6ID;
								nextSlot++;
							}
						}
						if (ModLoader.GetMod("SpiritMod") != null)
						{
							if (SpiritModDownedScarabeus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedBane)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedFlier)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (SpiritModDownedStarplateRaider)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (SpiritModDownedInfernon)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (SpiritModDownedDusking)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedEtherialUmbra)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedIlluminantMaster)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (SpiritModDownedAtlas)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (SpiritModDownedOverseer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("Laugicality") != null)
						{
							if (EnigmaDownedSharkron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedHypothema)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedRagnar)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EnigmaDownedAnDio)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (EnigmaDownedAnnihilator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EnigmaDownedSlybertron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EnigmaDownedSteamTrain)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("pinkymod") != null)
						{
							if (PinkymodDownedST)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("STBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (PinkymodDownedMS)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(30);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("MythrilBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (PinkymodDownedVD)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("Valdabag"));
							shop.item[nextSlot].shopCustomPrice = new int?(25);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (PinkymodDownedAD)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
						}
					}
				}
				if (!AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("AAMod") != null)
						{
							if (AAModDownedMonarch)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("MonarchBag"));
								shop.item[nextSlot].shopCustomPrice = 150000;
								nextSlot++;
							}
							if (AAModDownedGrips)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("GripsBag"));
								shop.item[nextSlot].shopCustomPrice = 300000;
								nextSlot++;
							}
							if (AAModDownedTruffleToad)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("TruffleBag"));
								shop.item[nextSlot].shopCustomPrice = 350000;
								nextSlot++;
							}
							if (AAModDownedBrood)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("BroodBag"));
								shop.item[nextSlot].shopCustomPrice = 500000;
								nextSlot++;
							}
							if (AAModDownedHydra)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("HydraBag"));
								shop.item[nextSlot].shopCustomPrice = 750000;
								nextSlot++;
							}
							if (AAModDownedSerpent)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("SerpentBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
							}
							if (AAModDownedDjinn)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("DjinnBag"));
								shop.item[nextSlot].shopCustomPrice = 1000000;
								nextSlot++;
							}
							if (AAModDownedEquinox)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("DBBag"));
								shop.item[nextSlot].shopCustomPrice = 2500000;
								nextSlot++;
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("NCBag"));
								shop.item[nextSlot].shopCustomPrice = 2500000;
								nextSlot++;
							}
							if (AAModDownedSisters)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("AHBag"));
								shop.item[nextSlot].shopCustomPrice = 5000000;
								nextSlot++;
							}
							if (AAModDownedYamata)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("YamataBag"));
								shop.item[nextSlot].shopCustomPrice = 5000000;
								nextSlot++;
							}
							if (AAModDownedAkuma)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("AkumaBag"));
								shop.item[nextSlot].shopCustomPrice = 5000000;
								nextSlot++;
							}
							if (AAModDownedZero)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("ZeroBag"));
								shop.item[nextSlot].shopCustomPrice = 10000000;
								nextSlot++;
							}
							if (AAModDownedShen)
							{
								shop.item[nextSlot].SetDefaults (ModLoader.GetMod("AAMod").ItemType("ShenCache"));
								shop.item[nextSlot].shopCustomPrice = 15000000;
								nextSlot++;
							}
						}
						if (ModLoader.GetMod("SpiritMod") != null)
						{
							if (SpiritModDownedScarabeus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs"));
							shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
							}
							if (SpiritModDownedBane)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (SpiritModDownedFlier)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag"));
							shop.item[nextSlot].shopCustomPrice = 750000;
							nextSlot++;
							}
							if (SpiritModDownedStarplateRaider)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (SpiritModDownedInfernon)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (SpiritModDownedDusking)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
							if (SpiritModDownedEtherialUmbra)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
							if (SpiritModDownedIlluminantMaster)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
							}
							if (SpiritModDownedAtlas)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag"));
							shop.item[nextSlot].shopCustomPrice = 4000000;
							nextSlot++;
							}
							if (SpiritModDownedOverseer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag"));
							shop.item[nextSlot].shopCustomPrice = 8000000;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("Laugicality") != null)
						{
							if (EnigmaDownedSharkron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
							}
							if (EnigmaDownedHypothema)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (EnigmaDownedRagnar)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 750000;
							nextSlot++;
							}
							if (EnigmaDownedAnDio)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (EnigmaDownedAnnihilator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (EnigmaDownedSlybertron)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (EnigmaDownedSteamTrain)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("pinkymod") != null)
						{
							if (PinkymodDownedST)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("STBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (PinkymodDownedMS)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 750000;
							nextSlot++;
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("MythrilBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (PinkymodDownedVD)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("Valdabag"));
							shop.item[nextSlot].shopCustomPrice = 1500000;
							nextSlot++;
							}
							if (PinkymodDownedAD)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
						}
					}
				}
			}
			if (Shop == 6)
			{
				if (!NPC.downedBoss3)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("AlchemistNPC").ItemType("InformatingNote"));
					nextSlot++;
				}
				if (AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("ElementsAwoken") != null)
						{
							if (EADownedWasteland)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(6);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (EADownedInfernace)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (EADownedScourgeFighter)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(7);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EADownedRegaroth)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (EADownedCelestials)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(6);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedPermafrost)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(7);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedObsidious)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(8);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedAqueous)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(9);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedWyrm)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedGuardian)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (EADownedVolcanox)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (EADownedVoidLevi)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (EADownedAzana)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (EADownedAncients)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(25);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("Redemption") != null)
						{
							if (ReDownedChicken)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("KingChickenBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(4);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (ReDownedThorn)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("ThornBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(6);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (ReDownedKeeper)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(12);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (ReDownedCrystal)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(18);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier1ID;
							nextSlot++;
							}
							if (ReDownedIEye)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier2ID;
							nextSlot++;
							}
							if (ReDownedKingSlayer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("SlayerBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (ReDownedVCleaver)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(20);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier3ID;
							nextSlot++;
							}
							if (ReDownedVGigipede)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(12);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier4ID;
							nextSlot++;
							}
							if (ReDownedObliterator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(5);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (ReDownedPZero)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("PZBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(10);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (ReDownedThornRe && ReDownedGolemRe)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("ThornPZBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(15);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
							if (ReDownedNebuleus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("NebBag"));
							shop.item[nextSlot].shopCustomPrice = new int?(25);
							shop.item[nextSlot].shopSpecialCurrency = AlchemistNPC.ReversivityCoinTier5ID;
							nextSlot++;
							}
						}
					}
				}
				if (!AlchemistNPC.modConfiguration.CoinsDrop)
				{
					if (NPC.downedBoss3 && Main.expertMode)
					{
						if (ModLoader.GetMod("ElementsAwoken") != null)
						{
							if (EADownedWasteland)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag"));
							shop.item[nextSlot].shopCustomPrice = 300000;
							nextSlot++;
							}
							if (EADownedInfernace)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (EADownedScourgeFighter)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag"));
							shop.item[nextSlot].shopCustomPrice = 1500000;
							nextSlot++;
							}
							if (EADownedRegaroth)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag"));
							shop.item[nextSlot].shopCustomPrice = 1750000;
							nextSlot++;
							}
							if (EADownedCelestials)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (EADownedPermafrost)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag"));
							shop.item[nextSlot].shopCustomPrice = 2250000;
							nextSlot++;
							}
							if (EADownedObsidious)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag"));
							shop.item[nextSlot].shopCustomPrice = 2250000;
							nextSlot++;
							}
							if (EADownedAqueous)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag"));
							shop.item[nextSlot].shopCustomPrice = 2500000;
							nextSlot++;
							}
							if (EADownedWyrm)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag"));
							shop.item[nextSlot].shopCustomPrice = 2750000;
							nextSlot++;
							}
							if (EADownedGuardian)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
							}
							if (EADownedVolcanox)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag"));
							shop.item[nextSlot].shopCustomPrice = 5000000;
							nextSlot++;
							}
							if (EADownedVoidLevi)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag"));
							shop.item[nextSlot].shopCustomPrice = 6000000;
							nextSlot++;
							}
							if (EADownedAzana)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag"));
							shop.item[nextSlot].shopCustomPrice = 8000000;
							nextSlot++;
							}
							if (EADownedAncients)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag"));
							shop.item[nextSlot].shopCustomPrice = 10000000;
							nextSlot++;
							}
						}
						if (ModLoader.GetMod("Redemption") != null)
						{
							if (ReDownedChicken)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("KingChickenBag"));
							shop.item[nextSlot].shopCustomPrice = 150000;
							nextSlot++;
							}
							if (ReDownedThorn)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("ThornBag"));
							shop.item[nextSlot].shopCustomPrice = 250000;
							nextSlot++;
							}
							if (ReDownedKeeper)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag"));
							shop.item[nextSlot].shopCustomPrice = 350000;
							nextSlot++;
							}
							if (ReDownedCrystal)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag"));
							shop.item[nextSlot].shopCustomPrice = 500000;
							nextSlot++;
							}
							if (ReDownedIEye)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag"));
							shop.item[nextSlot].shopCustomPrice = 1000000;
							nextSlot++;
							}
							if (ReDownedKingSlayer)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("SlayerBag"));
							shop.item[nextSlot].shopCustomPrice = 1500000;
							nextSlot++;
							}
							if (ReDownedVCleaver)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag"));
							shop.item[nextSlot].shopCustomPrice = 2000000;
							nextSlot++;
							}
							if (ReDownedVGigipede)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag"));
							shop.item[nextSlot].shopCustomPrice = 3000000;
							nextSlot++;
							}
							if (ReDownedObliterator)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag"));
							shop.item[nextSlot].shopCustomPrice = 5000000;
							nextSlot++;
							}
							if (ReDownedPZero)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("PZBag"));
							shop.item[nextSlot].shopCustomPrice = 6000000;
							nextSlot++;
							}
							if (ReDownedThornRe && ReDownedGolemRe)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("ThornPZBag"));
							shop.item[nextSlot].shopCustomPrice = 7000000;
							nextSlot++;
							}
							if (ReDownedNebuleus)
							{
							shop.item[nextSlot].SetDefaults (ModLoader.GetMod("Redemption").ItemType("NebBag"));
							shop.item[nextSlot].shopCustomPrice = 10000000;
							nextSlot++;
							}
						}
					}
				}
			}
		}
	}
}
