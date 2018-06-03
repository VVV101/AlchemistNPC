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
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Alchemistv7.json");
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
            Configuration.Save(true);
        }
    }
}