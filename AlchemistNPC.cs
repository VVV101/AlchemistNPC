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
            LampLight = RegisterHotKey("Lamp Light Toggle", "L");
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
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " " + "Corruption/Crimson boss mask", new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMask", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "Cultist mask/hood", new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:CultistMask", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "tier 3 Hardmode Bar", new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:Tier3Bar", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "Crimson/Corruption bar", new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilBar", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "evil mushroom", new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMush", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "evil component", new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilComponent", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "tier 2 anvil", new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyAnvil", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "tier 2 forge", new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyForge", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "tier 1 anvil", new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Lang.misc[37] + " " + "Celestial Wings", new int[]
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
    }

}

