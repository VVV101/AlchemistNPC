using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using AlchemistNPC.Items;

namespace AlchemistNPC
{
    public class AlchemistNPC : Mod
    {
		public AlchemistNPC()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
			};
		}

		internal static AlchemistNPC instance;
		internal TeleportClass TeleportClass;
		public static ModHotKey LampLight;
		public static bool EyeOfJudgement = false;
		public static bool KeepBuffs = false;
		public static bool MemersRiposte = false;
		public static bool PGSWear = false;
		public static bool scroll = false;
		public static bool RevSet = false;
		public static bool SF = false;
		public static int DTH = 0;
		public static bool LaetitiaSet = false;
		public static bool Extractor = false;
		public static bool XtraT = false;
		public static float ppx = 0f;
		public static float ppy = 0f;
		public static string GithubUserName { get { return "VVV101"; } }
		public static string GithubProjectName { get { return "AlchemistNPC"; } }
		public static int ReversivityCoinTier1ID;
		public static int ReversivityCoinTier2ID;
		public static int ReversivityCoinTier3ID;
		public static int ReversivityCoinTier4ID;
		public static int ReversivityCoinTier5ID;
		public static int ReversivityCoinTier6ID;
		
		public override void Load()
		{
            Config.Load();

            //SBMW:Try to add translation for hotkey, seems worked, but requires to reload mod if change game language
            string HotkeyLamp = Language.GetTextValue("Mods.AlchemistNPC.LampLightToggle");
            LampLight = RegisterHotKey(HotkeyLamp, "L");

            if (!Main.dedServ)
            {
                AddEquipTexture(null, EquipType.Legs, "somebody0214Robe_Legs", "AlchemistNPC/Items/Armor/somebody0214Robe_Legs");
            }
            ReversivityCoinTier1ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier1Data(ItemType<Items.ReversivityCoinTier1>(), 999L));
            ReversivityCoinTier2ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier2Data(ItemType<Items.ReversivityCoinTier2>(), 999L));
            ReversivityCoinTier3ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier3Data(ItemType<Items.ReversivityCoinTier3>(), 999L));
            ReversivityCoinTier4ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier4Data(ItemType<Items.ReversivityCoinTier4>(), 999L));
            ReversivityCoinTier5ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier5Data(ItemType<Items.ReversivityCoinTier5>(), 999L));
            ReversivityCoinTier6ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier6Data(ItemType<Items.ReversivityCoinTier6>(), 999L));
            instance = this;

            //SBMW:Move transtation to this method
            SetTranslation();
        }

        public override void Unload()
		{
			instance = null;
		}
		
		public static string ConfigFileRelativePath 
		{
		get { return "Mod Configs/Alchemist.json"; }
		}

		public static void ReloadConfigFromFile() 
		{
		Config.Load();
		}
		
		public static bool CalamityLoaded = ModLoader.GetMod("CalamityMod") != null;
		public static bool ThoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
		public static bool SacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;
		
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
		AlchemistNPCMessageType msgType = (AlchemistNPCMessageType)reader.ReadByte();
			switch (msgType)
			{
				case AlchemistNPCMessageType.LifeAndManaSync:
					Player lifeFruitsPlayer = Main.player[reader.ReadByte()];
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().LifeElixir = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().Fuaran = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().KeepBuffs = reader.ReadInt32();
					break;
				case AlchemistNPCMessageType.TeleportPlayer:
					TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
					break;
				default:
					ErrorLogger.Log("AlchemistNPC: Unknown Message type: " + msgType);
					break;
			}
		}
		
		public enum AlchemistNPCMessageType : byte
		{
		LifeAndManaSync,
		TeleportPlayer
		}
		
		public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPC.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPC.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPC.tier3HardmodeBar");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPC.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPC.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPC.evilComponent");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPC.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPC.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPC.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPC.CelestialWings");

            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMask", group);
			group = new RecipeGroup(() => Lang.misc[37] + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:CultistMask", group);
			group = new RecipeGroup(() => Lang.misc[37] + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:Tier3Bar", group);
			group = new RecipeGroup(() => Lang.misc[37] + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilBar", group);
		group = new RecipeGroup(() => Lang.misc[37] + " " + evilMushroom, new int[]
         {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMush", group);
		group = new RecipeGroup(() => Lang.misc[37] + " " + evilComponent, new int[]
         {
                 ItemID.ShadowScale, ItemID.TissueSample
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilComponent", group);	
		group = new RecipeGroup(() => Lang.misc[37] + " " + tier2anvil, new int[]
         {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyAnvil", group);
		group = new RecipeGroup(() => Lang.misc[37] + " " + tier2forge, new int[]
         {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyForge", group);
		group = new RecipeGroup(() => Lang.misc[37] + " " + tier1anvil, new int[]
         {
                 ItemID.IronAnvil, ItemID.LeadAnvil
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyPreHMAnvil", group);
		group = new RecipeGroup(() => Lang.misc[37] + " " + celestialWings, new int[]
         {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyCelestialWings", group);
			
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CelestialStone);
			recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Sundial);
            recipe.AddRecipe();
			recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "EmagledFragmentation", 25);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ItemID.FragmentStardust, 2);
            recipe.AddRecipe();
			recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "EmagledFragmentation", 25);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ItemID.FragmentNebula, 2);
            recipe.AddRecipe();
			recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "EmagledFragmentation", 25);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ItemID.FragmentVortex, 2);
            recipe.AddRecipe();
			recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "EmagledFragmentation", 25);
			recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(ItemID.FragmentSolar, 2);
            recipe.AddRecipe();
			
		}

        //SBMW:Transtation method
        public void SetTranslation()
        {
            ModTranslation text = CreateTranslation("DC1");
            text.SetDefault("Damage type changed to Magic");
            text.AddTranslation(GameCulture.Russian, "Тип урона изменён на Магический");
            text.AddTranslation(GameCulture.Chinese, "伤害类型变更为魔法");
            AddTranslation(text);

            text = CreateTranslation("DC2");
            text.SetDefault("Damage type changed to Melee");
            text.AddTranslation(GameCulture.Russian, "Тип урона изменён на Ближний");
            text.AddTranslation(GameCulture.Chinese, "伤害类型变更为近战");
            AddTranslation(text);

            //SBMW:Hotkey
            text = CreateTranslation("LampLightToggle");
            text.SetDefault("Lamp Light Toggle");
            text.AddTranslation(GameCulture.Chinese, "大鸟灯开关");
            AddTranslation(text);

            //SBMW:Reversivity Coin
            //SBMW:Russian comes from Items.ReversivityCoin
            text = CreateTranslation("ReversivityCoinTier1");
            text.SetDefault("Reversivity Coin Tier 1");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Тир Первый");
            text.AddTranslation(GameCulture.Chinese, "个1级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier2");
            text.SetDefault("Reversivity Coin Tier 2");
            text.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Второй");
            text.AddTranslation(GameCulture.Chinese, "个2级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier3");
            text.SetDefault("Reversivity Coin Tier 3");
            text.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Третий");
            text.AddTranslation(GameCulture.Chinese, "个3级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier4");
            text.SetDefault("Reversivity Coin Tier 4");
            text.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Четвертый");
            text.AddTranslation(GameCulture.Chinese, "个4级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier5");
            text.SetDefault("Reversivity Coin Tier 5");
            text.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Пятый");
            text.AddTranslation(GameCulture.Chinese, "个5级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier6");
            text.SetDefault("Reversivity Coin Tier 6");
            text.AddTranslation(GameCulture.Russian, "Монета реверсии Тир Шестой");
            text.AddTranslation(GameCulture.Chinese, "个6级逆转硬币");
            AddTranslation(text);

            //SBMW:RecipeGroups
            text = CreateTranslation("evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.Chinese, "腐化/血腥Boss面具");
            AddTranslation(text);

            text = CreateTranslation("cultist");
            text.SetDefault("Cultist mask/hood");
            text.AddTranslation(GameCulture.Chinese, "邪教徒面具/兜帽");
            AddTranslation(text);

            text = CreateTranslation("tier3HardmodeBar");
            text.SetDefault("tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.Chinese, "三级肉后锭(精金/钛金)");
            AddTranslation(text);

            text = CreateTranslation("evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.Chinese, "魔金/血腥锭");
            AddTranslation(text);

            text = CreateTranslation("evilMushroom");
            text.SetDefault("evil mushroom");
            text.AddTranslation(GameCulture.Chinese, "邪恶蘑菇");
            AddTranslation(text);

            text = CreateTranslation("evilComponent");
            text.SetDefault("evil component");
            text.AddTranslation(GameCulture.Chinese, "邪恶材料(暗影鳞片/组织样本)");
            AddTranslation(text);

            text = CreateTranslation("tier2anvil");
            text.SetDefault("tier 2 anvil");
            text.AddTranslation(GameCulture.Chinese, "二级砧(秘银/山铜砧)");
            AddTranslation(text);

            text = CreateTranslation("tier2forge");
            text.SetDefault("tier 2 forge");
            text.AddTranslation(GameCulture.Chinese, "二级熔炉(精金/钛金熔炉)");
            AddTranslation(text);

            text = CreateTranslation("tier1anvil");
            text.SetDefault("tier 1 anvil");
            text.AddTranslation(GameCulture.Chinese, "一级砧(铁/铅砧)");
            AddTranslation(text);

            text = CreateTranslation("CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.Chinese, "四柱翅膀");
            AddTranslation(text);

            //SBMW:Some forgotten code from AlchenostNPCPlayer.cs
            text = CreateTranslation("enterText");
            text.SetDefault("If you don't like additional content or drops from the mod you could install AlchemistNPC Content Disabler mod");
            text.AddTranslation(GameCulture.Chinese, "如果你不喜欢AlchemistNPC中的附加物品或掉落物, 你可以安装 AlchemistNPC Content Disabler 取消他们");
            AddTranslation(text);


            //SBMW:Treasure Bag
            //SBMW:Vanilla
            text = CreateTranslation("KingSlime");
            text.SetDefault("King Slime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "世界吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之脑宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "蜂后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "血肉之墙宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "机械蠕虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Twins");
            text.SetDefault("Twins Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "双子魔眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "机械骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Plantera");
            text.SetDefault("Plantera Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "世纪之花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Golem");
            text.SetDefault("Golem Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "石巨人宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "猪鲨公爵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "月亮领主宝藏袋");
            AddTranslation(text);

            //SBMW:CalamityMod
            text = CreateTranslation("DesertScourge");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "荒漠灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "蘑菇螃蟹宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "腐巢意志宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Perforator");
            text.SetDefault("The Perforators Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "血肉宿主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "极地之灵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "硫磺火元素宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "渊海灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "灾厄之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrageldonSlime");
            text.SetDefault("Astrageldon Slime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "大彗星史莱姆宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "星神吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "利维坦宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "瘟疫使者歌莉娅宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Ravager");
            text.SetDefault("Ravager Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "毁灭魔像宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Providence");
            text.SetDefault("Providence Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "亵渎天神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "噬魂幽花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "神明吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Bumblebirb");
            text.SetDefault("Bumblebirb Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "癫痫鸟宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Yharon");
            text.SetDefault("Yharon Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "犽戎宝藏袋");
            AddTranslation(text);

            //SBMW:ThoriumMod
            text = CreateTranslation("ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "惊雷王鹰宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "水母皇后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "花岗岩流能风暴宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "英灵遗骸宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheStarScouter");
            text.SetDefault("The Star Scouter Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "星际监察者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BoreanStrider");
            text.SetDefault("Borean Strider Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "极地遁蛛宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("CoznixTheFallenBeholder");
            text.SetDefault("Coznix, The Fallen Beholder Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "堕落注视者·克兹尼格斯宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheLich");
            text.SetDefault("The Lich Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "巫妖宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "被遗忘者-深渊之主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "灾难之灵宝藏袋");
            AddTranslation(text);

            //SBMW:Some other translation
            text = CreateTranslation("Portal");
            text.SetDefault("Otherworldly Portal was opened.");
            text.AddTranslation(GameCulture.Chinese, "连接另一个世界的传送门已开启");
            AddTranslation(text);

            text = CreateTranslation("barrierWeek");
            text.SetDefault("Barrier between worlds was weakened.");
            text.AddTranslation(GameCulture.Chinese, "世界间的屏障已变得脆弱不堪");
            AddTranslation(text);

            text = CreateTranslation("barrierStabilized");
            text.SetDefault("Barrier between world is stabilized.");
            text.AddTranslation(GameCulture.Chinese, "世界间的屏障重新归于稳定");
            AddTranslation(text);

            text = CreateTranslation("Eclipse");
            text.SetDefault("Eclipse creatures become anxious.");
            text.AddTranslation(GameCulture.Chinese, "日食生物变得焦虑不堪");
            AddTranslation(text);

            text = CreateTranslation("portalOpen");
            text.SetDefault("I am alive...? I cannot believe this! Thank you!");
            text.AddTranslation(GameCulture.Chinese, "我...我还活着?! 我简直无法相信! 谢谢你!");
            AddTranslation(text);
        }
    }
}