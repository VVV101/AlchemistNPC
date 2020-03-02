using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Terraria.Localization;

namespace AlchemistNPC
{
	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.AlchemistSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.AlchemistSpawntoggleTooltip")]
		public bool AlchemistSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.BrewerSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.BrewerSpawntoggleTooltip")]
		public bool BrewerSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.JewelerSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.JewelerSpawntoggleTooltip")]
		public bool JewelerSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.YoungBrewerSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.YoungBrewerSpawntoggleTooltip")]
		public bool YoungBrewerSpawn;
			
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.TinkererSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.TinkererSpawntoggleTooltip")]
		public bool TinkererSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.ArchitectSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.ArchitectSpawntoggleTooltip")]
		public bool ArchitectSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.OperatorSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.OperatorSpawntoggleTooltip")]
		public bool OperatorSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.MusicianSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.MusicianSpawntoggleTooltip")]
		public bool MusicianSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.ExplorerSpawntoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.ExplorerSpawntoggleTooltip")]
		public bool ExplorerSpawn;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.TreasureBagsShopstoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.TreasureBagsShopstoggleTooltip")]
		public bool TS;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.TornNotesdroptoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.TornNotesdroptoggleTooltip")]
		public bool TornNotesDrop;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.ReversityCoinsdroptoggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.ReversityCoinsdroptoggleTooltip")]
		public bool CoinsDrop;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.AlchemistNPCLite")]
		[Tooltip("$Mods.AlchemistNPC.Common.AlchemistNPCLiteTooltip")]
		public bool StartMessage;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.LifeformAnalyzer")]
		[Tooltip("$Mods.AlchemistNPC.Common.LifeformAnalyzerTooltip")]
		public bool LifeformAnalyzer;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.Revengeancemode")]
		[Tooltip("$Mods.AlchemistNPC.Common.RevengeancemodeTooltip")]
		public bool RevPrices;
		
		[DefaultValue(true)]
		[Label("$Mods.AlchemistNPC.Common.CatcheableNPCToggle")]
		[Tooltip("$Mods.AlchemistNPC.Common.CatcheableNPCToggleTooltip")]
		public bool CatchNPC;
		
		[Range(1, 1000)]
		[DefaultValue(1)]
		[Label("$Mods.AlchemistNPC.Common.Potionspricemultiplier")]
		[Tooltip("$Mods.AlchemistNPC.Common.PotionspricemultiplierTooltip")]
		public int PotsPriceMulti;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("$Mods.AlchemistNPC.Common.FallenStarsPrice")]
		[Tooltip("$Mods.AlchemistNPC.Common.FallenStarsPriceTooltip")]
		public int StarPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("$Mods.AlchemistNPC.Common.RecallPrice")]
		[Tooltip("$Mods.AlchemistNPC.Common.RecallPriceTooltip")]
		public int RecallPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("$Mods.AlchemistNPC.Common.WormholePrice")]
		[Tooltip("$Mods.AlchemistNPC.Common.WormholePriceTooltip")]
		public int WormholePrice;

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPC.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string messageline) {
			string message = "";
			string messagech = "";
			
			if(Language.ActiveCulture == GameCulture.Chinese)
			{
				messageline = messagech;
			}
			else 
			{
				messageline = message;
			}
			
			if (whoAmI == 0) {
				message = "Changes accepted!";
				messagech = "设置改动成功!";
				return true;
			}
			if (whoAmI != 0)
			{
				message = "You have no rights to change config.";
				messagech = "你没有设置改动权限.";
				return false;
			}
			return false;
		}
	}
}