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
		}

		public static string ConfigFileRelativePath {
		get { return "Mod Configs/AlchemistNPC.json"; }
		}
		public static void ReloadConfigFromFile() {
		}
		
		public static bool CalamityUnloaded = ModLoader.GetMod("CalamityMod") != null;
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

