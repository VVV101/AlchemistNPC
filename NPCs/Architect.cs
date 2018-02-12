using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC.NPCs;
 
namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class Architect : ModNPC
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
				return "AlchemistNPC/NPCs/Architect";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Architect";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Architect");
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
		text = mod.CreateTranslation("A1");
		text.SetDefault("If this dastardly ");
		text.AddTranslation(GameCulture.Russian, "Если эта трусливая ");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A2");
		text.SetDefault(" isn't going to shut up, I'm letting ");
		text.AddTranslation(GameCulture.Russian, " не замолчит, я позволю ");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A3");
		text.SetDefault(" bite her.");
		text.AddTranslation(GameCulture.Russian, " укусить её.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A4");
		text.SetDefault("KILL THE ZOMBIES! KILL THE BUNNIES! IN THE NAME OF THE BLOO- oh sorry I didn't notice you here.");
		text.AddTranslation(GameCulture.Russian, "УБИВАЙ ЗОМБИ! УБИВАЙ КРОЛИКОВ! ВО ИМЯ КРОВ-- Ой прости, я не заметил, что ты здесь.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A5");
		text.SetDefault("Why hello there I'm just getting some blood buckets for a lake I'm making pleasedontaskanymorequestions");
		text.AddTranslation(GameCulture.Russian, "Привет. Я просто собираю несколько вёдер крови для озера. Пожалуйста, большеничегонеспрашивай.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A6");
		text.SetDefault("I like it when there is a gigantic horde of zombies behind our doors. But I HATE WHEN THEY BREAK MY DOORS!");
		text.AddTranslation(GameCulture.Russian, "Я люблю, когда за нашими дверями огромная орда зомби. Но Я НЕНАВИЖУ КОГДА ОНИ ИХ ЛОМАЮТ!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A7");
		text.SetDefault("Ah, the feeling that I'm not safe, the paranoia is embraced the moment the bloodmoon rises in the sky.");
		text.AddTranslation(GameCulture.Russian, "Ах, это чувство небезопасности, паранойя, которая подчёркивается моментом, когда кровавая луна всходит на небосводе.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A8");
		text.SetDefault("Are you interested in my religion? It invloves sacrifices to the bloody moon.");
		text.AddTranslation(GameCulture.Russian, "Ты заинтересован в моей религии? Она вовлекает жертвы Кровавой Луне.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A9");
		text.SetDefault("Do you know why I hate these goblins? They are wildly annoying.");
		text.AddTranslation(GameCulture.Russian, "Знаешь, почему я ненавижу этих гоблинов? Они ужасно раздражающие.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A10");
		text.SetDefault("Hooray to pirates! They supply me with my golden furniture!");
		text.AddTranslation(GameCulture.Russian, "Ура пиратам! Они помогают мне с золотой мебелью!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A11");
		text.SetDefault("Ah! Finally some proper plating to have my roof done!");
		text.AddTranslation(GameCulture.Russian, "Ах! Наконец-то хорошое покрытие для моей крыши готово!");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A12");
		text.SetDefault("No explosives please, ");
		text.AddTranslation(GameCulture.Russian, "Никакой взрывчатки, пожалуйста, ");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A13");
		text.SetDefault(" is already annoying me enough.");
		text.AddTranslation(GameCulture.Russian, " и так достаточно раздражает меня.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A14");
		text.SetDefault("BUILDER POTIONS FREE FOR EVERYONE but you.");
		text.AddTranslation(GameCulture.Russian, "БЕСПЛАТНЫЕ ЗЕЛЬЯ СТРОИТЕЛЯ ДЛЯ ВСЕХ кроме тебя.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A15");
		text.SetDefault("What? Where I got my architect degree? There's an architect degree?");
		text.AddTranslation(GameCulture.Russian, "Что? Где я получил степень в архитектуре? Существуют архитектурные степени?");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A16");
		text.SetDefault("Did'ja know that wood somehow doesn't burn? Though under certain circumstances it does. Weird...");
		text.AddTranslation(GameCulture.Russian, "Ты знаешь, что дерево каким-то образом не горит? Хотя с помощью определённых манипуляций оно может. Странно...");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A17");
		text.SetDefault("No, I am not the guy. I'm the dude.");
		text.AddTranslation(GameCulture.Russian, "Нет, я не парень. Я чувак.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A18");
		text.SetDefault("Well, the one you recently made was ALMOST impressive. (not really)");
		text.AddTranslation(GameCulture.Russian, "Ну, то, что ты недавно постоил было почти впечетляющим. (на самом деле НЕТ)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A19");
		text.SetDefault("So, you say that chests are furniture too. I reply: Screw you.");
		text.AddTranslation(GameCulture.Russian, "Так ты утверждаешь, что сундуки - это тоже мебель. Я повторю: Пошёл ты.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("A20");
		text.SetDefault("I saw your buildings but I am still not impressed");
		text.AddTranslation(GameCulture.Russian, "Я видел твои постройки, но я всё ещё не впечатлён.");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("AS1");
		text.SetDefault("1st shop (Filler Blocks)");
		text.AddTranslation(GameCulture.Russian, "1-ый магазин (Заполняющие Блоки)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("AS2");
		text.SetDefault("2nd shop (Building Blocks)");
		text.AddTranslation(GameCulture.Russian, "2-ой магазин (Строительные Блоки)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("AS3");
		text.SetDefault("3rd shop (Basic Furniture)");
		text.AddTranslation(GameCulture.Russian, "3-ий магазин (Базовая мебель)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("AS4");
		text.SetDefault("4th shop (Advanced Furniture)");
		text.AddTranslation(GameCulture.Russian, "4-ый магазин (Продвинутая мебель)");
		mod.AddTranslation(text);
		text = mod.CreateTranslation("CycleAS");
		text.SetDefault("Cycle Shop");
		text.AddTranslation(GameCulture.Russian, "Смена магазина");
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
                    if (numTownNPCs >= 1)
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
			string Li = Language.GetTextValue("Mods.AlchemistNPC.Li");
			switch (WorldGen.genRand.Next(5))
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

		
				 int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
				  int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
				  int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
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
            switch (Main.rand.Next(5))
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
			string CycleAS = Language.GetTextValue("Mods.AlchemistNPC.CycleAS");
          if (Shop1)
			{
			button = AS1;
			S4A = false;
			S1A = true;
			}
			if (Shop2)
			{
			button = AS2;
			S1A = false;
			S2A = true;
			}
			if (Shop3)
			{
			button = AS3;
			S2A = false;
			S3A = true;
			}
			if (Shop4)
			{
			button = AS4;
			S3A = false;
			S4A = true;
			}
	  button2 = CycleAS;
        }
 
        public override void OnChatButtonClicked(bool firstButton, ref bool shop) 
		{
		if (firstButton)
            {
                shop = true;
            }
		else
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
						Shop4 = true;
						Shop3 = false;
						}
			if (Shop4 && S4A)
						{
						Shop1 = true;
						Shop4 = false;
						}
				}
		}

        Mod chadsfurniture = ModLoader.GetMod("chadsfurni");

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
		if (Shop1)
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
shop.item[nextSlot].SetDefaults (ItemID.Obsidian);
			shop.item[nextSlot].shopCustomPrice = 5;
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
			shop.item[nextSlot].shopCustomPrice = 2;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ItemID.Granite);
			shop.item[nextSlot].shopCustomPrice = 2;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ItemID.Cloud);
			shop.item[nextSlot].shopCustomPrice = 5;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ItemID.RainCloud);
			shop.item[nextSlot].shopCustomPrice = 5;
            nextSlot++;
if (Main.hardMode)
{		
shop.item[nextSlot].SetDefaults (ItemID.PearlstoneBlock);
			shop.item[nextSlot].shopCustomPrice = 5;
            nextSlot++;
shop.item[nextSlot].SetDefaults (ItemID.PearlsandBlock);
			shop.item[nextSlot].shopCustomPrice = 5;
            nextSlot++;
}
			}
				if (Shop2)
{
		shop.item[nextSlot].SetDefaults (ItemID.RedBrick);
			shop.item[nextSlot].shopCustomPrice = 2;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Ebonwood);
			shop.item[nextSlot].shopCustomPrice = 10;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Shadewood);
			shop.item[nextSlot].shopCustomPrice = 10;
			nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.DynastyWood);
			shop.item[nextSlot].shopCustomPrice = 100;
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
		if (Main.hardMode)
			{
		shop.item[nextSlot].SetDefaults (ItemID.CrystalBlock);
			shop.item[nextSlot].shopCustomPrice = 100;
            nextSlot++;
			}
		shop.item[nextSlot].SetDefaults (ItemID.SunplateBlock);
			shop.item[nextSlot].shopCustomPrice = 10;
            nextSlot++;
		shop.item[nextSlot].SetDefaults (ItemID.Pumpkin);
			shop.item[nextSlot].shopCustomPrice = 2;
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
			if (Shop3)
			{
			shop.item[nextSlot].SetDefaults (ItemID.Wood);
			shop.item[nextSlot].shopCustomPrice = 5;
            nextSlot++;
			shop.item[nextSlot].SetDefaults (ItemID.Torch);
			shop.item[nextSlot].shopCustomPrice = 25;
			nextSlot++;
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
            if (Shop4)
            {
                if (NPC.downedBoss3)
                {
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
		shop.item[nextSlot].SetDefaults (ItemID.HoneyDispenser);
		shop.item[nextSlot].shopCustomPrice = 20000;
		nextSlot++;
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
		}
	}
}
