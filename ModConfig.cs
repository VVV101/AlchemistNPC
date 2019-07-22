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
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace AlchemistNPC
{
	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[DefaultValue(true)]
		[Label("Alchemist Spawn toggle")]
		[Tooltip("True to enable Alchemist NPC spawn, false to disable. True by default")]
		public bool AlchemistSpawn;
		
		[DefaultValue(true)]
		[Label("Brewer Spawn toggle")]
		[Tooltip("True to enable Brewer NPC spawn, false to disable. True by default")]
		public bool BrewerSpawn;
		
		[DefaultValue(true)]
		[Label("Jeweler Spawn toggle")]
		[Tooltip("True to enable Jeweler NPC spawn, false to disable. True by default")]
		public bool JewelerSpawn;
		
		[DefaultValue(true)]
		[Label("Young Brewer Spawn toggle")]
		[Tooltip("True to enable Young Brewer NPC spawn, false to disable. True by default")]
		public bool YoungBrewerSpawn;
			
		[DefaultValue(true)]
		[Label("Tinkerer Spawn toggle")]
		[Tooltip("True to enable Tinkerer NPC spawn, false to disable. True by default")]
		public bool TinkererSpawn;
		
		[DefaultValue(true)]
		[Label("Architect Spawn toggle")]
		[Tooltip("True to enable Architect NPC spawn, false to disable. True by default")]
		public bool ArchitectSpawn;
		
		[DefaultValue(true)]
		[Label("Operator Spawn toggle")]
		[Tooltip("True to enable Operator NPC spawn, false to disable. True by default")]
		public bool OperatorSpawn;
		
		[DefaultValue(true)]
		[Label("Musician Spawn toggle")]
		[Tooltip("True to enable Musician NPC spawn, false to disable. True by default")]
		public bool MusicianSpawn;
		
		[DefaultValue(true)]
		[Label("Explorer Spawn toggle")]
		[Tooltip("True to enable Explorer NPC spawn, false to disable. True by default")]
		public bool ExplorerSpawn;
		
		[DefaultValue(true)]
		[Label("Treasure Bags Shops toggle")]
		[Tooltip("True to enable Treasure Bags Shops of Operator NPC. True by default")]
		public bool TS;
		
		[DefaultValue(true)]
		[Label("Torn Notes drop toggle")]
		[Tooltip("True to enable Torn Notes drop. True by default")]
		public bool TornNotesDrop;
		
		[DefaultValue(true)]
		[Label("Reversity Coins drop toggle")]
		[Tooltip("True to enable Reversity Coins drop. True by default")]
		public bool CoinsDrop;
		
		[DefaultValue(true)]
		[Label("Starting message referring to AlchemistNPC Lite")]
		[Tooltip("True to enable starting message. True by default")]
		public bool StartMessage;
		
		[DefaultValue(true)]
		[Label("Revengeance mode prices scaling")]
		[Tooltip("True to make potions prices bigger. True by default")]
		public bool RevPrices;
		
		[Range(1, 1000)]
		[DefaultValue(1)]
		[Label("Potions price multiplier")]
		[Tooltip("Multiplies potions price by X. 1 by default")]
		public int PotsPriceMulti;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("Fallen Stars Price")]
		[Tooltip("1000 is 10 silver price by default")]
		public int StarPrice;

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPC.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (whoAmI == 0) {
				message = "Changes accepted!";
				return true;
			}
			else
			{
				message = "You have no rights to change config.";
				return false;
			}
			return false;
		}
	}
}
