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
		public static bool MusicianSpawn = true;
		public static bool RevPrices = true;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Alchemistv8.json");
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
				Configuration.Get<bool>("StartMessage", ref Config.StartMessage);
				if(StartMessage != true && StartMessage != false)
				{
				StartMessage = true;
				}
				Configuration.Get<bool>("AlchemistSpawn", ref Config.AlchemistSpawn);
				if(AlchemistSpawn != true && AlchemistSpawn != false)
				{
				AlchemistSpawn = true;
				}
				Configuration.Get<bool>("BrewerSpawn", ref Config.BrewerSpawn);
				if(BrewerSpawn != true && BrewerSpawn != false)
				{
				BrewerSpawn = true;
				}
				Configuration.Get<bool>("JewelerSpawn", ref Config.JewelerSpawn);
				if(JewelerSpawn != true && JewelerSpawn != false)
				{
				JewelerSpawn = true;
				}
				Configuration.Get<bool>("ArchitectSpawn", ref Config.ArchitectSpawn);
				if(ArchitectSpawn != true && ArchitectSpawn != false)
				{
				ArchitectSpawn = true;
				}
				Configuration.Get<bool>("YoungBrewerSpawn", ref Config.YoungBrewerSpawn);
				if(YoungBrewerSpawn != true && YoungBrewerSpawn != false)
				{
				YoungBrewerSpawn = true;
				}
				Configuration.Get<bool>("OperatorSpawn", ref Config.OperatorSpawn);
				if(OperatorSpawn != true && OperatorSpawn != false)
				{
				OperatorSpawn = true;
				}
				Configuration.Get<bool>("ExplorerSpawn", ref Config.ExplorerSpawn);
				if(ExplorerSpawn != true && ExplorerSpawn != false)
				{
				ExplorerSpawn = true;
				}
				Configuration.Get<bool>("MusicianSpawn", ref Config.MusicianSpawn);
				if(MusicianSpawn != true && MusicianSpawn != false)
				{
				MusicianSpawn = true;
				}
				Configuration.Get<bool>("RevPrices", ref Config.RevPrices);
				if(RevPrices != true && RevPrices != false)
				{
				RevPrices = true;
				}
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
			Configuration.Put("MusicianSpawn", MusicianSpawn);
			Configuration.Put("RevPrices", RevPrices);
            Configuration.Save(true);
        }
    }
}