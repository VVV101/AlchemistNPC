using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

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
		public static ModHotKey LampLight;
		public static bool scroll = false;
		public static string GithubUserName { get { return "VVV101"; } }
		public static string GithubProjectName { get { return "AlchemistNPC"; } }
		
		public override void Load()
		{
		Config.Load();
		ModTranslation text = CreateTranslation("Change1");
		text.SetDefault("Sniper scope is disabled");
		text.AddTranslation(GameCulture.Russian, "Снайперский прицел выключен");
		AddTranslation(text);
		text = CreateTranslation("Change2");
		text.SetDefault("Sniper scope is enabled");
		text.AddTranslation(GameCulture.Russian, "Снайперский прицел включён");
		AddTranslation(text);
		text = CreateTranslation("DC1");
		text.SetDefault("Damage type changed to Magic");
		text.AddTranslation(GameCulture.Russian, "Тип урона изменён на Магический");
		AddTranslation(text);
		text = CreateTranslation("DC2");
		text.SetDefault("Damage type changed to Melee");
		text.AddTranslation(GameCulture.Russian, "Тип урона изменён на Ближний");
		AddTranslation(text);
		LampLight = RegisterHotKey("Lamp Light Toggle", "L");
		}

		public static string ConfigFileRelativePath {
		get { return "Mod Configs/Alchemist.json"; }
		}
		public static void ReloadConfigFromFile() 
		{
		Config.Load();
		}
		
		public static bool CalamityLoaded = ModLoader.GetMod("CalamityMod") != null;
		public static bool SacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;
		
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

