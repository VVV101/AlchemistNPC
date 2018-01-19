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
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "AlchemistNPC.json");
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
                   StarPrice = 1;
                return true;
            }
            return false;
        }

        //Creates a config file. This will only be called if the config file doesn't exist yet or it's invalid. 
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("StarPrice", StarPrice);
            Configuration.Save();
        }
    }
}