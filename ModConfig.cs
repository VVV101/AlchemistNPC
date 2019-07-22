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
		[Label(ModConfigurationLang.ModConfigLabel("AlchemistSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("AlchemistSpawntoggleTooltip"))]
		public bool AlchemistSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("BrewerSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("BrewerSpawntoggleTooltip"))]
		public bool BrewerSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("JewelerSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("JewelerSpawntoggleTooltip"))]
		public bool JewelerSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("YoungBrewerSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("YoungBrewerSpawntoggleTooltip"))]
		public bool YoungBrewerSpawn;
			
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("TinkererSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("TinkererSpawntoggleTooltip"))]
		public bool TinkererSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("ArchitectSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("ArchitectSpawntoggleTooltip"))]
		public bool ArchitectSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("OperatorSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("OperatorSpawntoggleTooltip"))]
		public bool OperatorSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("MusicianSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("MusicianSpawntoggleTooltip"))]
		public bool MusicianSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("ExplorerSpawntoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("ExplorerSpawntoggleTooltip"))]
		public bool ExplorerSpawn;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("TreasureBagsShopstoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("TreasureBagsShopstoggleTooltip"))]
		public bool TS;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("TornNotesdroptoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("TornNotesdroptoggleTooltip"))]
		public bool TornNotesDrop;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("ReversityCoinsdroptoggle"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("ReversityCoinsdroptoggleTooltip"))]
		public bool CoinsDrop;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("AlchemistNPCLite"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("AlchemistNPCLiteTooltip"))]
		public bool StartMessage;
		
		[DefaultValue(true)]
		[Label(ModConfigurationLang.ModConfigLabel("Revengeancemode"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("RevengeancemodeTooltip"))]
		public bool RevPrices;
		
		[Range(1, 1000)]
		[DefaultValue(1)]
		[Label(ModConfigurationLang.ModConfigLabel("Potionspricemultiplier"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("PotionspricemultiplierTooltip"))]
		public int PotsPriceMulti;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label(ModConfigurationLang.ModConfigLabel("FallenStarsPrice"))]
		[Tooltip(ModConfigurationLang.ModConfigLabel("FallenStarsPriceTooltip"))]
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
				message = ModConfigurationLang.ModConfigLabel("messageTure");
				return true;
			}
			else
			{
				message = ModConfigurationLang.ModConfigLabel("messageFalse");
				return false;
			}
			return false;
		}
	}

	public class ModConfigurationLang
	{
		public static string ModConfigLabel(String Label)
        {
            if(Language.ActiveCulture == GameCulture.Chinese)
                {
					switch(Label)
                    {
                        case "AlchemistSpawntoggle":
                        return "炼金师生成切换";
						case "AlchemistSpawntoggleTooltip":
                        return "是, 以激活炼金师NPC生成, 否, 以取消. 默认为是";
						case "BrewerSpawntoggle":
                        return "药剂师生成切换";
						case "BrewerSpawntoggleTooltip":
                        return "是, 以激活药剂师NPC生成, 否, 以取消. 默认为是";
						case "JewelerSpawntoggle":
                        return "珠宝师生成切换";
						case "JewelerSpawntoggleTooltip":
                        return "是, 以激活珠宝师NPC生成, 否, 以取消. 默认为是";
						case "YoungBrewerSpawntoggle":
                        return "年轻药剂师生成切换";
						case "YoungBrewerSpawntoggleTooltip":
                        return "是, 以激活年轻药剂师NPC生成, 否, 以取消. 默认为是";
						case "TinkererSpawntoggle":
                        return "工匠生成切换";
						case "TinkererSpawntoggleTooltip":
                        return "是, 以激活工匠NPC生成, 否, 以取消. 默认为是";
						case "ArchitectSpawntoggle":
                        return "建筑师生成切换";
						case "ArchitectSpawntoggleTooltip":
                        return "是, 以激活建筑师NPC生成, 否, 以取消. 默认为是";
						case "OperatorSpawntoggle":
                        return "操作员生成切换";
						case "OperatorSpawntoggleTooltip":
                        return "是, 以激活操作员NPC生成, 否, 以取消. 默认为是";
						case "MusicianSpawntoggle":
                        return "音乐家生成切换";
						case "MusicianSpawntoggleTooltip":
                        return "是, 以激活音乐家NPC生成, 否, 以取消. 默认为是";
						case "ExplorerSpawntoggle":
                        return "探险家生成切换";
						case "ExplorerSpawntoggleTooltip":
                        return "是, 以激活探险家NPC生成, 否, 以取消. 默认为是";
						case "TreasureBagsShopstoggle":
                        return "宝藏袋商店切换";
						case "TreasureBagsShopstoggleTooltip":
                        return "是, 以启用操作员NPC的宝藏袋商店, 否, 以取消. 默认为是";
						case "TornNotesdroptoggle":
                        return "破损笔记掉落切换";
						case "TornNotesdroptoggleTooltip":
                        return "是, 以启用破损笔记掉落, 否, 以取消. 默认为是";
						case "ReversityCoinsdroptoggle":
                        return "逆转硬币掉落切换";
						case "ReversityCoinsdroptoggleTooltip":
                        return "是, 以启用逆转硬币掉落, 否, 以取消. 默认为是";
						case "AlchemistNPCLite":
                        return "启动时提及AlchemistNPC简化版";
						case "AlchemistNPCLiteTooltip":
                        return "是, 以推送消息. 默认为是";
						case "Revengeancemode":
                        return "灾厄复仇模式价格调整";
						case "RevengeancemodeTooltip":
                        return "是, 灾厄复仇模式下药水的价格将更高. 默认为是";
						case "Potionspricemultiplier":
                        return "多人药水价格加倍";
						case "PotionspricemultiplierTooltip":
                        return "提升价格倍率. 默认为1";
						case "FallenStarsPrice":
                        return "落星价格";
						case "FallenStarsPriceTooltip":
                        return "默认1000个价值10银";
						case "messageTure":
                        return "设置改动成功!";
						case "messageFalse":
                        return "你没有设置改动权限.";
                    }
                }
            else
                {
					switch(Label)
                    {
                        case "AlchemistSpawntoggle":
                        return "Alchemist Spawn toggle";
						case "AlchemistSpawntoggleTooltip":
                        return "True to enable Alchemist NPC spawn, false to disable. True by default";
						case "BrewerSpawntoggle":
                        return "Brewer Spawn toggle";
						case "BrewerSpawntoggleTooltip":
                        return "True to enable Brewer NPC spawn, false to disable. True by default";
						case "JewelerSpawntoggle":
                        return "Jeweler Spawn toggle";
						case "JewelerSpawntoggleTooltip":
                        return "True to enable Jeweler NPC spawn, false to disable. True by default";
						case "YoungBrewerSpawntoggle":
                        return "Young Brewer Spawn toggle";
						case "YoungBrewerSpawntoggleTooltip":
                        return "True to enable Young Brewer NPC spawn, false to disable. True by default";
						case "TinkererSpawntoggle":
                        return "Tinkerer Spawn toggle";
						case "TinkererSpawntoggleTooltip":
                        return "True to enable Tinkerer NPC spawn, false to disable. True by default";
						case "ArchitectSpawntoggle":
                        return "Architect Spawn toggle";
						case "ArchitectSpawntoggleTooltip":
                        return "True to enable Architect NPC spawn, false to disable. True by default";
						case "OperatorSpawntoggle":
                        return "Operator Spawn toggle";
						case "OperatorSpawntoggleTooltip":
                        return "True to enable Operator NPC spawn, false to disable. True by default";
						case "MusicianSpawntoggle":
                        return "Musician Spawn toggle";
						case "MusicianSpawntoggleTooltip":
                        return "True to enable Musician NPC spawn, false to disable. True by default";
						case "ExplorerSpawntoggle":
                        return "Explorer Spawn toggle";
						case "ExplorerSpawntoggleTooltip":
                        return "True to enable Explorer NPC spawn, false to disable. True by default";
						case "TreasureBagsShopstoggle":
                        return "Treasure Bags Shops toggle";
						case "TreasureBagsShopstoggleTooltip":
                        return "True to enable Treasure Bags Shops of Operator NPC. True by default";
						case "TornNotesdroptoggle":
                        return "Torn Notes drop toggle";
						case "TornNotesdroptoggleTooltip":
                        return "True to enable Torn Notes drop. True by default";
						case "ReversityCoinsdroptoggle":
                        return "Reversity Coins drop toggle";
						case "ReversityCoinsdroptoggleTooltip":
                        return "True to enable Reversity Coins drop. True by default";
						case "AlchemistNPCLite":
                        return "Starting message referring to AlchemistNPC Lite";
						case "AlchemistNPCLiteTooltip":
                        return "True to enable starting message. True by default";
						case "Revengeancemode":
                        return "Revengeance mode prices scaling";
						case "RevengeancemodeTooltip":
                        return "True to make potions prices bigger. True by default";
						case "Potionspricemultiplier":
                        return "Potions price multiplier";
						case "PotionspricemultiplierTooltip":
                        return "Multiplies potions price by X. 1 by default";
						case "FallenStarsPrice":
                        return "Fallen Stars Price";
						case "FallenStarsPriceTooltip":
                        return "1000 is 10 silver price by default";
						case "messageTure":
                        return "Changes accepted!";
						case "messageFalse":
                        return "You have no rights to change config.";
                    }
                }
            return"";
        }
	}
}
