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
using AlchemistNPC.Interface;

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

		public static Mod Instance;
		internal static AlchemistNPC instance;
		internal TeleportClass TeleportClass;
		public static ModHotKey LampLight;
		public static ModHotKey DiscordBuff;
		public static ModHotKey PipBoyTP;
		public static bool SF = false;
		public static bool GreaterDangersense = false;
		public static bool BastScroll = false;
		public static bool Stormbreaker = false;
		public static int DTH = 0;
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
		private UserInterface alchemistUserInterface;
		internal ShopChangeUI alchemistUI;
		private UserInterface alchemistUserInterfaceA;
		internal ShopChangeUIA alchemistUIA;
		private UserInterface alchemistUserInterfaceO;
		internal ShopChangeUIO alchemistUIO;
		private UserInterface alchemistUserInterfaceM;
		internal ShopChangeUIM alchemistUIM;
		private UserInterface alchemistUserInterfaceH;
		internal HealingUI alchemistUIH;
		private UserInterface alchemistUserInterfaceDC;
		internal DimensionalCasketUI alchemistUIDC;
		private UserInterface alchemistUserInterfaceT;
		internal ShopChangeUIT alchemistUIT;
		private UserInterface alchemistUserInterfaceP;
		internal PipBoyTPMenu pipboyUI;
		
		public override void Load()
		{
			Instance = this;
			Config.Load();
            //ZY:Try to add translation for hotkey, seems worked, but requires to reload mod if change game language 
			string LampLightToggle, DiscordBuffTeleportation, PipBoy;
            if (Language.ActiveCulture == GameCulture.Chinese)
			{
				LampLightToggle = "大鸟灯开关";
				DiscordBuffTeleportation = "混乱Buff传送";
				PipBoy = "哔哔小子传送菜单";
			}
			else
			{
				LampLightToggle = "Lamp Light Toggle";
				DiscordBuffTeleportation = "Discord Buff Teleportation";
				PipBoy = "Pip-Boy Teleportation Menu";
			}
            LampLight = RegisterHotKey(LampLightToggle, "L");
            DiscordBuff = RegisterHotKey(DiscordBuffTeleportation, "Q");
			PipBoyTP = RegisterHotKey(PipBoy, "P");
			if (!Main.dedServ)
			{
				AddEquipTexture(null, EquipType.Legs, "somebody0214Robe_Legs", "AlchemistNPC/Items/Armor/somebody0214Robe_Legs");
			}
			ReversivityCoinTier1ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier1Data(ItemType<Items.Misc.ReversivityCoinTier1>(), 999L));
			ReversivityCoinTier2ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier2Data(ItemType<Items.Misc.ReversivityCoinTier2>(), 999L));
			ReversivityCoinTier3ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier3Data(ItemType<Items.Misc.ReversivityCoinTier3>(), 999L));
			ReversivityCoinTier4ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier4Data(ItemType<Items.Misc.ReversivityCoinTier4>(), 999L));
			ReversivityCoinTier5ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier5Data(ItemType<Items.Misc.ReversivityCoinTier5>(), 999L));
			ReversivityCoinTier6ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier6Data(ItemType<Items.Misc.ReversivityCoinTier6>(), 999L));
			instance = this;

            SetTranslation();
			
			if (!Main.dedServ)
			{				
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Deltarune OST - Chaos King"), ItemType("ChaosKingMusicBox"), TileType("ChaosKingMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Deltarune OST - Field of Hopes And Dreams"), ItemType("FieldsMusicBox"), TileType("FieldsMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Deltarune OST - Lantern"), ItemType("SheamMusicBox"), TileType("SheamMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Deltarune OST - The World Revolving"), ItemType("TheWorldRevolvingMusicBox"), TileType("TheWorldRevolvingMusicBox"));
				
				alchemistUI = new ShopChangeUI();
				alchemistUI.Activate();
				alchemistUserInterface = new UserInterface();
				alchemistUserInterface.SetState(alchemistUI);
				
				alchemistUIA = new ShopChangeUIA();
				alchemistUIA.Activate();
				alchemistUserInterfaceA = new UserInterface();
				alchemistUserInterfaceA.SetState(alchemistUIA);
				
				alchemistUIO = new ShopChangeUIO();
				alchemistUIO.Activate();
				alchemistUserInterfaceO = new UserInterface();
				alchemistUserInterfaceO.SetState(alchemistUIO);
				
				alchemistUIM = new ShopChangeUIM();
				alchemistUIM.Activate();
				alchemistUserInterfaceM = new UserInterface();
				alchemistUserInterfaceM.SetState(alchemistUIM);
				
				alchemistUIH = new HealingUI();
				alchemistUIH.Activate();
				alchemistUserInterfaceH = new UserInterface();
				alchemistUserInterfaceH.SetState(alchemistUIH);
				
				alchemistUIDC = new DimensionalCasketUI();
				alchemistUIDC.Activate();
				alchemistUserInterfaceDC = new UserInterface();
				alchemistUserInterfaceDC.SetState(alchemistUIDC);
				
				alchemistUIT = new ShopChangeUIT();
				alchemistUIT.Activate();
				alchemistUserInterfaceT = new UserInterface();
				alchemistUserInterfaceT.SetState(alchemistUIT);
				
				pipboyUI = new PipBoyTPMenu();
				pipboyUI.Activate();
				alchemistUserInterfaceP = new UserInterface();
				alchemistUserInterfaceP.SetState(pipboyUI);
			}
		}

		public override void PostSetupContent()
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("Alchemist"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Brewer"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Jeweler"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Tinkerer"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Architect"), "Defeat Eater of Worlds/Brain of Cthulhu and have at least 5 NPCs alive");
				censusMod.Call("TownNPCCondition", NPCType("Operator"), "Defeat Eater of Worlds/Brain of Cthulhu and place [c/00FF00:Wing of the World] (craftable furniture) inside free housing");
				censusMod.Call("TownNPCCondition", NPCType("Musician"), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType("Young Brewer"), "World state is Hardmode and both Alchemist and Operator are alive");
				censusMod.Call("TownNPCCondition", NPCType("OtherworldlyPortal"), "Not exactly a Town NPC, one of the steps for saving the Explorer");
				censusMod.Call("TownNPCCondition", NPCType("Explorer"), "Defeat Moon Lord and find the way to use all 9 Torn Notes for saving her");
			}
		}
		
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			InterfaceHelper.ModifyInterfaceLayers(layers);
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector",
					delegate
					{
						if (ShopChangeUI.visible)
						{
							alchemistUI.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexA != -1)
			{
				layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector A",
					delegate
					{
						if (ShopChangeUIA.visible)
						{
							alchemistUIA.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexO != -1)
			{
				layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector O",
					delegate
					{
						if (ShopChangeUIO.visible)
						{
							alchemistUIO.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexM != -1)
			{
				layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector M",
					delegate
					{
						if (ShopChangeUIM.visible)
						{
							alchemistUIM.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexH = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexH != -1)
			{
				layers.Insert(MouseTextIndexH, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Healing UI",
					delegate
					{
						if (HealingUI.visible)
						{
							alchemistUIH.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexDC = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexDC != -1)
			{
				layers.Insert(MouseTextIndexDC, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Dimensional Casket UI",
					delegate
					{
						if (DimensionalCasketUI.visible)
						{
							alchemistUIDC.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexT = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexT != -1)
			{
				layers.Insert(MouseTextIndexT, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector T",
					delegate
					{
						if (ShopChangeUIT.visible)
						{
							alchemistUIT.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexP = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexP != -1)
			{
				layers.Insert(MouseTextIndexP, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Pip-Boy Menu",
					delegate
					{
						if (PipBoyTPMenu.visible)
						{
							pipboyUI.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
		
		public override void Unload()
		{
			instance = null;
		}
		
		public static string ConfigFileRelativePath 
		{
		get { return "Mod Configs/Alchemistv84.json"; }
		}

		public static void ReloadConfigFromFile() 
		{
		Config.Load();
		}
		
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
		AlchemistNPCMessageType msgType = (AlchemistNPCMessageType)reader.ReadByte();
			switch (msgType)
			{
				case AlchemistNPCMessageType.LifeAndManaSync:
					byte playernumber = reader.ReadByte();
					Player lifeFruitsPlayer = Main.player[playernumber];
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().LifeElixir = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().Fuaran = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().KeepBuffs = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().WellFed = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BillIsDowned = reader.ReadInt32();
					lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BBP = reader.ReadInt32();
					break;
				case AlchemistNPCMessageType.TeleportPlayer:
					TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
					break;
				case AlchemistNPCMessageType.BBPChanged:
					playernumber = reader.ReadByte();
					AlchemistNPCPlayer alchemistPlayer = Main.player[playernumber].GetModPlayer<AlchemistNPCPlayer>();
					alchemistPlayer = Main.player[playernumber].GetModPlayer<AlchemistNPCPlayer>();
					alchemistPlayer.BBP = reader.ReadInt32();
					if (Main.netMode == NetmodeID.Server) {
						var packet = GetPacket();
						packet.Write((byte)AlchemistNPCMessageType.BBPChanged);
						packet.Write(playernumber);
						packet.Write(alchemistPlayer.BBP);
						packet.Send(-1, playernumber);
					}
					break;
				case AlchemistNPCMessageType.Snatcher:
					playernumber = reader.ReadByte();
					alchemistPlayer = Main.player[playernumber].GetModPlayer<AlchemistNPCPlayer>();
					alchemistPlayer.SnatcherCounter = reader.ReadInt32();
					if (Main.netMode == NetmodeID.Server) {
						var packet = GetPacket();
						packet.Write((byte)AlchemistNPCMessageType.Snatcher);
						packet.Write(playernumber);
						packet.Write(alchemistPlayer.SnatcherCounter);
						packet.Send(-1, playernumber);
					}
					break;
				default:
					ErrorLogger.Log("AlchemistNPC: Unknown Message type: " + msgType);
					break;
			}
		}
		
		public enum AlchemistNPCMessageType : byte
		{
		LifeAndManaSync,
		TeleportPlayer,
		BBPChanged,
		Snatcher
		}
		
		public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPC.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPC.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPC.tier3HardmodeBar");
			string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPC.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPC.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPC.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPC.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPC.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPC.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPC.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPC.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPC.CelestialWings");
			string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPC.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPC.tier3Watch");

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMask", group);
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:CultistMask", group);
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:Tier3Bar", group);
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:HardmodeComponent", group);
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilBar", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
         {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMush", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
         {
                 ItemID.ShadowScale, ItemID.TissueSample
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilComponent", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
         {
                 ItemID.RottenChunk, ItemID.Vertebrae
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilDrop", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
         {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyAnvil", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
         {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyForge", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
         {
                 ItemID.IronAnvil, ItemID.LeadAnvil
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyPreHMAnvil", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
         {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyCelestialWings", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
         {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyLunarHamaxe", group);
		group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
         {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyWatch", group);
			
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
			recipe.AddRecipeGroup("AlchemistNPC:AnyWatch");
			recipe.AddIngredient(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.Wire, 15);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.Stopwatch);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("AlchemistNPC:EvilBar", 10);
			recipe.AddRecipeGroup("AlchemistNPC:AnyWatch");
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.DPSMeter);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TallyCounter);
			recipe.AddIngredient(ItemID.BlackLens);
			recipe.AddIngredient(ItemID.AntlionMandible);
			recipe.AddRecipeGroup("AlchemistNPC:EvilDrop");
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent");
			recipe.AddIngredient(ItemID.Feather);
			recipe.AddIngredient(ItemID.TatteredCloth);
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.LifeformAnalyzer);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Mushroom);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.PurificationPowder, 5);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CorruptSeeds);
			recipe.AddIngredient(ItemID.PurificationPowder);
			recipe.AddIngredient(ItemID.PixieDust);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.HallowedSeeds);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimsonSeeds);
			recipe.AddIngredient(ItemID.PurificationPowder);
			recipe.AddIngredient(ItemID.PixieDust);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.HallowedSeeds);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "EmagledFragmentation", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentStardust, 2);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "EmagledFragmentation", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentNebula, 2);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "EmagledFragmentation", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentVortex, 2);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "EmagledFragmentation", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentSolar, 2);
			recipe.AddRecipe();
		}
		
        //SBMW:Transtation method
        public void SetTranslation()
        {
            //SBMW:Hotkey
            ModTranslation text = CreateTranslation("LampLightToggle");
            text.SetDefault("Lamp Light Toggle");
            text.AddTranslation(GameCulture.Chinese, "大鸟灯开关");
            AddTranslation(text);

            text = CreateTranslation("DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.Chinese, "混乱药剂传送");
            AddTranslation(text);

            //SBMW:Reversivity Coin
            //SBMW:Russian comes from Items.ReversivityCoin
            text = CreateTranslation("ReversivityCoinTier1");
            text.SetDefault("Reversivity Coin Tier 1");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Первого Уровня");
            text.AddTranslation(GameCulture.Chinese, "个1级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier2");
            text.SetDefault("Reversivity Coin Tier 2");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Второго Уровня");
            text.AddTranslation(GameCulture.Chinese, "个2级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier3");
            text.SetDefault("Reversivity Coin Tier 3");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Третьего Уровня");
            text.AddTranslation(GameCulture.Chinese, "个3级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier4");
            text.SetDefault("Reversivity Coin Tier 4");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Четвертого Уровня");
            text.AddTranslation(GameCulture.Chinese, "个4级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier5");
            text.SetDefault("Reversivity Coin Tier 5");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Пятого Уровня");
            text.AddTranslation(GameCulture.Chinese, "个5级逆转硬币");
            AddTranslation(text);

            text = CreateTranslation("ReversivityCoinTier6");
            text.SetDefault("Reversivity Coin Tier 6");
            text.AddTranslation(GameCulture.Russian, "Монета Реверсии Шестого Уровня");
            text.AddTranslation(GameCulture.Chinese, "个6级逆转硬币");
            AddTranslation(text);

            //SBMW:RecipeGroups
            text = CreateTranslation("evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.Chinese, "腐化/血腥Boss面具");
            AddTranslation(text);

            text = CreateTranslation("cultist");
            text.SetDefault("Cultist Mask/Hood");
            text.AddTranslation(GameCulture.Chinese, "邪教徒面具/兜帽");
            AddTranslation(text);

            text = CreateTranslation("tier3HardmodeBar");
            text.SetDefault("Tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.Chinese, "三级肉后锭(精金/钛金)");
            AddTranslation(text);
			
			text = CreateTranslation("hardmodeComponent");
            text.SetDefault("Hardmode Component");
            AddTranslation(text);

            text = CreateTranslation("evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.Chinese, "魔金/血腥锭");
            AddTranslation(text);

            text = CreateTranslation("evilMushroom");
            text.SetDefault("Evil Mushroom");
            text.AddTranslation(GameCulture.Chinese, "邪恶蘑菇");
            AddTranslation(text);

            text = CreateTranslation("evilComponent");
            text.SetDefault("Evil Component");
            text.AddTranslation(GameCulture.Chinese, "邪恶材料(暗影鳞片/组织样本)");
            AddTranslation(text);

            text = CreateTranslation("evilDrop");
            text.SetDefault("Evil Drop");
            text.AddTranslation(GameCulture.Chinese, "邪恶掉落物(腐肉/椎骨)");
            AddTranslation(text);

            text = CreateTranslation("tier2anvil");
            text.SetDefault("Tier 2 Anvil");
            text.AddTranslation(GameCulture.Chinese, "二级砧(秘银/山铜砧)");
            AddTranslation(text);

            text = CreateTranslation("tier2forge");
            text.SetDefault("Tier 2 Forge");
            text.AddTranslation(GameCulture.Chinese, "二级熔炉(精金/钛金熔炉)");
            AddTranslation(text);

            text = CreateTranslation("tier1anvil");
            text.SetDefault("Tier 1 Anvil");
            text.AddTranslation(GameCulture.Chinese, "一级砧(铁/铅砧)");
            AddTranslation(text);

            text = CreateTranslation("CelestialWings");
            text.SetDefault("Celestial Wings");
	    text.AddTranslation(GameCulture.Russian, "Небесные Крылья");
            text.AddTranslation(GameCulture.Chinese, "四柱翅膀");
            AddTranslation(text);
			
			text = CreateTranslation("LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            AddTranslation(text);

            text = CreateTranslation("tier3Watch");
            text.SetDefault("Tier 3 Watch");
            text.AddTranslation(GameCulture.Chinese, "三级表(金表/铂金表)");
            AddTranslation(text);


            text = CreateTranslation("enterText");
            text.SetDefault("If you don't like additional content or drops from the mod you could install AlchemistNPC Lite mod instead.");
	    text.AddTranslation(GameCulture.Russian, "Если вам не нравится дополнительный контент - существует облегченная версия (AlchemistNPC Lite).");
            text.AddTranslation(GameCulture.Chinese, "如果你不喜欢AlchemistNPC中的附加物品或掉落物, 你可以安装 AlchemistNPC Lite 取消他们");
            AddTranslation(text);

            //SBMW:Treasure Bag
			text = CreateTranslation("Knuckles");
            text.SetDefault("Ugandan Knuckles Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Угандского Наклза");
            AddTranslation(text);
			text = CreateTranslation("BillCipher");
            text.SetDefault("Bill Cipher Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Билла");
            AddTranslation(text);
            //SBMW:Vanilla
            text = CreateTranslation("KingSlime");
            text.SetDefault("King Slime Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Короля Слизней");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Глаза Ктулху");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Пожирателя Миров");
            text.AddTranslation(GameCulture.Chinese, "世界吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Мозга Ктулху");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之脑宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Королевы Пчел");
            text.AddTranslation(GameCulture.Chinese, "蜂后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Скелетрона");
            text.AddTranslation(GameCulture.Chinese, "骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Стены Плоти");
            text.AddTranslation(GameCulture.Chinese, "血肉之墙宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Уничтожителя");
            text.AddTranslation(GameCulture.Chinese, "机械蠕虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Twins");
            text.SetDefault("Twins Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Близнецов");
            text.AddTranslation(GameCulture.Chinese, "双子魔眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Скелетрона Прайм");
            text.AddTranslation(GameCulture.Chinese, "机械骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Plantera");
            text.SetDefault("Plantera Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Плантеры");
            text.AddTranslation(GameCulture.Chinese, "世纪之花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Golem");
            text.SetDefault("Golem Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Голема");
            text.AddTranslation(GameCulture.Chinese, "石巨人宝藏袋");
            AddTranslation(text);

			text = CreateTranslation("Betsy");
            text.SetDefault("Betsy Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Бетси");
            AddTranslation(text);
			
            text = CreateTranslation("DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Герцога Рыброна");
            text.AddTranslation(GameCulture.Chinese, "猪鲨公爵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Лунного Лорда");
            text.AddTranslation(GameCulture.Chinese, "月亮领主宝藏袋");
            AddTranslation(text);

            //SBMW:CalamityMod
            text = CreateTranslation("DesertScourge");
	    text.AddTranslation(GameCulture.Russian, "Сумка Пустынного Бича");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "荒漠灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Крабулона");
            text.AddTranslation(GameCulture.Chinese, "蘑菇螃蟹宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Коллективного Разума");
            text.AddTranslation(GameCulture.Chinese, "腐巢意志宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Perforator");
            text.SetDefault("The Perforators Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Бурителей");
            text.AddTranslation(GameCulture.Chinese, "血肉宿主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Бога Слизней");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Криогена");
            text.AddTranslation(GameCulture.Chinese, "极地之灵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Серного Элементаля");
            text.AddTranslation(GameCulture.Chinese, "硫磺火元素宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Водного Бича");
            text.AddTranslation(GameCulture.Chinese, "渊海灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Двойника Каламитас");
            text.AddTranslation(GameCulture.Chinese, "灾厄之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrageldonSlime");
            text.SetDefault("Astrum Aureus Treasure Bag");
			text.AddTranslation(GameCulture.Russian, "Сумка Звёздного Заразителя");
            text.AddTranslation(GameCulture.Chinese, "大彗星史莱姆宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Звёздного Бога");
            text.AddTranslation(GameCulture.Chinese, "星神吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Левиафана");
            text.AddTranslation(GameCulture.Chinese, "利维坦宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Голиафа-чумоносца");
            text.AddTranslation(GameCulture.Chinese, "瘟疫使者歌莉娅宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Ravager");
            text.SetDefault("Ravager Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Опустошителя");
            text.AddTranslation(GameCulture.Chinese, "毁灭魔像宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Providence");
            text.SetDefault("Providence Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Провидения");
            text.AddTranslation(GameCulture.Chinese, "亵渎天神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Полтергаста");
            text.AddTranslation(GameCulture.Chinese, "噬魂幽花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Пожирателя Богов");
            text.AddTranslation(GameCulture.Chinese, "神明吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Bumblebirb");
            text.SetDefault("Bumblebirb Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Шмелептицы");
            text.AddTranslation(GameCulture.Chinese, "癫痫鸟宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Yharon");
            text.SetDefault("Jungle Dragon, Yharon Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Дракона Джунглей, Ярона");
            text.AddTranslation(GameCulture.Chinese, "犽戎宝藏袋");
            AddTranslation(text);

            //SBMW:ThoriumMod
			text = CreateTranslation("DarkMage");
            text.SetDefault("Dark Mage Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Темного Мага");
            AddTranslation(text);
			
			text = CreateTranslation("Ogre");
            text.SetDefault("Ogre Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Огра");
            AddTranslation(text);
			
            text = CreateTranslation("ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Великой Птицы-Гром");
            text.AddTranslation(GameCulture.Chinese, "惊雷王鹰宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Королевы Медуз");
            text.AddTranslation(GameCulture.Chinese, "水母皇后宝藏袋");
            AddTranslation(text);
			
			text = CreateTranslation("CountEcho");
            text.SetDefault("Count Echo Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "水母皇后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Гранитного Энергошторма");
            text.AddTranslation(GameCulture.Chinese, "花岗岩流能风暴宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Похороненного Чемпиона");
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
	    text.AddTranslation(GameCulture.Russian, "Сумка Козникса, Падшего Наблюдателя");
            text.AddTranslation(GameCulture.Chinese, "堕落注视者·克兹尼格斯宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheLich");
            text.SetDefault("The Lich Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Лича");
            text.AddTranslation(GameCulture.Chinese, "巫妖宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Абиссиона, Забытого");
            text.AddTranslation(GameCulture.Chinese, "被遗忘者-深渊之主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Рагнарёка");
            text.AddTranslation(GameCulture.Chinese, "灾难之灵宝藏袋");
            AddTranslation(text);

			 //SacredTools
            text = CreateTranslation("FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Горящей Тыквы");
            AddTranslation(text);
			
			text = CreateTranslation("Jensen");
            text.SetDefault("Jensen, the Grand Harpy Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Дженсен, Великой Гарпии");
            AddTranslation(text);
			
			text = CreateTranslation("Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Рейнейр, Королевы Гарпий");
            AddTranslation(text);
			
			text = CreateTranslation("Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Абаддона, Эмиссара Кошмаров");
            AddTranslation(text);
			
			text = CreateTranslation("Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Арагура, Огненного Змия");
            AddTranslation(text);
			
			text = CreateTranslation("Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Лунарианов");
            AddTranslation(text);
			
			text = CreateTranslation("Challenger");
            text.SetDefault("The Challenger Treasure Bag");
            AddTranslation(text);
			
			//SpiritMod
            text = CreateTranslation("Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Infernon");
            text.SetDefault("Infernon Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Dusking");
            text.SetDefault("Dusking Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Atlas");
            text.SetDefault("Atlas Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Overseer");
            text.SetDefault("Overseer Treasure Bag");
            AddTranslation(text);
			
			//Enigma
            text = CreateTranslation("Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Дюнного Акулрона");
            AddTranslation(text);
			
			text = CreateTranslation("Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Рагнара");
            AddTranslation(text);
			
			text = CreateTranslation("AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Андезии и Диоритуса");
            AddTranslation(text);
			
			text = CreateTranslation("Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Аннигилятора");
            AddTranslation(text);
			
			text = CreateTranslation("Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
	    text.AddTranslation(GameCulture.Russian, "Сумка Паровоза");
            AddTranslation(text);
			
			//Pinky
            text = CreateTranslation("SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            AddTranslation(text);
			
			//AAMod
            text = CreateTranslation("Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            AddTranslation(text);

			text = CreateTranslation("Hydra");
            text.SetDefault("Hydra Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Retriever");
            text.SetDefault("Retriever Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Yamata");
            text.SetDefault("Yamata Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Akuma");
            text.SetDefault("Akuma Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Zero");
            text.SetDefault("Zero Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            AddTranslation(text);
			
			text = CreateTranslation("ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            AddTranslation(text);
			
            //SBMW:Some other translation
            text = CreateTranslation("Portal");
            text.SetDefault("An Otherworldly Portal was opened.");
			text.AddTranslation(GameCulture.Russian, "Междумировой портал был открыт.");
            text.AddTranslation(GameCulture.Chinese, "连接另一个世界的传送门已开启");
            AddTranslation(text);

            text = CreateTranslation("barrierWeek");
            text.SetDefault("The Barrier between worlds was weakened.");
			text.AddTranslation(GameCulture.Russian, "Барьер между мирами был ослаблен.");
            text.AddTranslation(GameCulture.Chinese, "世界间的屏障已变得脆弱不堪");
            AddTranslation(text);

            text = CreateTranslation("barrierStabilized");
            text.SetDefault("The Barrier between world is stabilized.");
			text.AddTranslation(GameCulture.Russian, "Барьер между мирами стабилизировался.");
            text.AddTranslation(GameCulture.Chinese, "世界间的屏障重新归于稳定");
            AddTranslation(text);

            text = CreateTranslation("Eclipse");
            text.SetDefault("Eclipse creatures become anxious.");
            text.AddTranslation(GameCulture.Chinese, "日食生物变得焦虑不堪");
            AddTranslation(text);

            text = CreateTranslation("portalOpen");
            text.SetDefault("I am alive...? I cannot believe this! Thank you!");
			text.AddTranslation(GameCulture.Russian, "Я жива...? Не верю своим глазам! Спасибо!");
            text.AddTranslation(GameCulture.Chinese, "我...我还活着?! 我简直无法相信! 谢谢你!");
            AddTranslation(text);

			text = CreateTranslation("pale");
			text.SetDefault("pale");
			text.AddTranslation(GameCulture.Russian, "бледный");
			text.AddTranslation(GameCulture.Chinese, "失色");
			AddTranslation(text);
			
			//QQ
			text = CreateTranslation("D1");
            text.SetDefault("To think, she's just here to collect the horrors of Terraria...what is she thinking?");
			text.AddTranslation(GameCulture.Russian, "Просто подумай, она здесь лишь для того, чтобы собрать ужасы Террарии... О чём она думает?");
            AddTranslation(text);
			
			text = CreateTranslation("D2");
            text.SetDefault("I still remember the day she landed. If it weren't for the help of everyone here, I swore I would never fix her up.");
			text.AddTranslation(GameCulture.Russian, "Я всё ещё помню день, когда она прибыла. Если бы это не было полезным для всех тут, то я клянусь, что никогда бы не помогла ей.");
            AddTranslation(text);
			
			text = CreateTranslation("D3");
            text.SetDefault("You may not have fully defeated the gate, but it seems Angela has what's left of it.");
			text.AddTranslation(GameCulture.Russian, "Ты мог победить врата не полностью, но похоже, что у Анджелы уже есть всё то, что от них осталось.");
            AddTranslation(text);
			
			text = CreateTranslation("D4");
            text.SetDefault("I can understand trying to understand a Dungeon Slime, but going out of your way to harvest the Wall of Flesh? What was Angela thinking!?");
			text.AddTranslation(GameCulture.Russian, "Я могу понять попытки понять Слизня Данжа, но сойти с пути чтобы собрать остатки Стены Плоти? О чём Анджела думает!?");
            AddTranslation(text);
			
			text = CreateTranslation("AD1");
            text.SetDefault("Shame. Would had wanted Angela, but she's lured by ");
			text.AddTranslation(GameCulture.Russian, "Как жаль. Хотел бы потолковать с Анджелой, но она привлечена ");
            AddTranslation(text);
			
			text = CreateTranslation("AD2");
            text.SetDefault("Man, how much gun is that AI packing?");
			text.AddTranslation(GameCulture.Russian, "Чувак, сколько же пушек у этого ИИ с собой?");
            AddTranslation(text);
			
			text = CreateTranslation("RCTT");
            text.SetDefault("Right-click to teleport here");
            AddTranslation(text);
        }
		
		public override void UpdateUI(GameTime gameTime)
		{
			if (alchemistUserInterface != null && ShopChangeUI.visible)
			{
				alchemistUserInterface.Update(gameTime);
			}
			
			if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
			{
				alchemistUserInterfaceA.Update(gameTime);
			}
			
			if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
			{
				alchemistUserInterfaceO.Update(gameTime);
			}
			
			if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
			{
				alchemistUserInterfaceM.Update(gameTime);
			}
			
			if (alchemistUserInterfaceP != null && PipBoyTPMenu.visible)
			{
				alchemistUserInterfaceP.Update(gameTime);
			}
			
			if (alchemistUserInterfaceH != null && HealingUI.visible)
			{
				alchemistUserInterfaceH.Update(gameTime);
			}
			
			if (alchemistUserInterfaceDC != null && DimensionalCasketUI.visible)
			{
				alchemistUserInterfaceDC.Update(gameTime);
			}
			
			if (alchemistUserInterfaceT != null && ShopChangeUIT.visible)
			{
				alchemistUserInterfaceT.Update(gameTime);
			}
		}
    }
	
}

