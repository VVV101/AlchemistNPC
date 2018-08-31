using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace AlchemistNPC
{
    public static class Config
    {
        public static int StarPrice = 1000;
		public static bool TS = true;
		public static bool TornNotesDrop = true;
		public static bool CoinsDrop = true;
		public static bool StartMessage = true;
		public static bool AlchemistSpawn = true;
		public static bool BrewerSpawn = true;
		public static bool JewelerSpawn = true;
		public static bool ArchitectSpawn = true;
		public static bool YoungBrewerSpawn = true;
		public static bool OperatorSpawn = true;
		public static bool ExplorerSpawn = true;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Alchemistv741.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            bool success = ReadConfig();

            if(!success)
            {
                ErrorLogger.Log("Failed to read AlchemistNPC's config file! Recreating config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
		if(Configuration.Load())
			{
            Configuration.Get("StarPrice", ref StarPrice);
            if(StarPrice <= 0)
			{
            StarPrice = 1000;
			}
			Configuration.Get<bool>("TreasureBagsShop", ref Config.TS);
			if(TS != true && TS != false)
			{
            TS = true;
			}
			Configuration.Get<bool>("TornNotesDrop", ref Config.TornNotesDrop);
			if(TornNotesDrop != true && TornNotesDrop != false)
			{
            TornNotesDrop = true;
			}
			Configuration.Get<bool>("CoinsDrop", ref Config.CoinsDrop);
			if(CoinsDrop != true && CoinsDrop != false)
			{
            CoinsDrop = true;
			}
			if(StartMessage != true && StartMessage != false)
			{
            StartMessage = true;
			}
			if(AlchemistSpawn != true && AlchemistSpawn != false)
			{
            AlchemistSpawn = true;
			}
			if(BrewerSpawn != true && BrewerSpawn != false)
			{
            BrewerSpawn = true;
			}
			if(JewelerSpawn != true && JewelerSpawn != false)
			{
            JewelerSpawn = true;
			}
			if(ArchitectSpawn != true && ArchitectSpawn != false)
			{
            ArchitectSpawn = true;
			}
			if(YoungBrewerSpawn != true && YoungBrewerSpawn != false)
			{
            YoungBrewerSpawn = true;
			}
			if(OperatorSpawn != true && OperatorSpawn != false)
			{
            OperatorSpawn = true;
			}
			if(ExplorerSpawn != true && ExplorerSpawn != false)
			{
            ExplorerSpawn = true;
			}
			Configuration.Get<bool>("StartMessage", ref Config.StartMessage);
			return true;
			}
		else
			{
			return false;
			}
		}
            
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("StarPrice", StarPrice);
			Configuration.Put("TreasureBagsShop", TS);
			Configuration.Put("TornNotesDrop", TornNotesDrop);
			Configuration.Put("CoinsDrop", CoinsDrop);
			Configuration.Put("StartMessage", StartMessage);
			Configuration.Put("AlchemistSpawn", AlchemistSpawn);
			Configuration.Put("BrewerSpawn", BrewerSpawn);
			Configuration.Put("JewelerSpawn", JewelerSpawn);
			Configuration.Put("ArchitectSpawn", ArchitectSpawn);
			Configuration.Put("YoungBrewerSpawn", YoungBrewerSpawn);
			Configuration.Put("OperatorSpawn", OperatorSpawn);
			Configuration.Put("ExplorerSpawn", ExplorerSpawn);
            Configuration.Save(true);
        }
    }
}