using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;
using AlchemistNPC.NPCs;
using AlchemistNPC.Interface;
using AlchemistNPC.Items;
using AlchemistNPC.Mounts;

namespace AlchemistNPC
{
	public class AlchemistNPCPlayer : ModPlayer
	{
		public int Shield = 0;
		public int fc = 0;
		public bool HPJ = false;
		public bool DeltaRune = false;
		public bool PB4K = false;
		public bool PH = false;
		public bool DistantPotionsUse = false;
		public bool Voodoo = false;
		public bool CursedMirror = false;
		public bool ShieldBelt = false;
		public bool MysticAmuletMount = false;
		public bool TerrarianBlock = false;
		public bool Luck = false;
		public bool Illuminati = false;
		public bool AutoinjectorMK2 = false;
		public bool AlchemistCharmTier1 = false;
		public bool AlchemistCharmTier2 = false;
		public bool AlchemistCharmTier3 = false;
		public bool AlchemistCharmTier4 = false;
		public bool BeeHeal = false;
		public bool Pandora = false;
		public bool TS = false;
		public bool Symbiote = false;
		public bool Akumu = false;
		public bool DriedFish = false;
		public bool SolarFish = false;
		public bool NebulaFish = false;
		public bool VortexFish = false;
		public bool StardustFish = false;
		public bool MiniShark = false;
		public bool Manna = false;
		public bool Traps = false;
		public bool Yui = false;
		public bool YuiS = false;
		public bool Extractor = false;
		public bool Scroll = false;
		public bool EyeOfJudgement = false;
		public bool LaetitiaSet = false;
		public bool LaetitiaGift = false;
		public bool SFU = false;
		public bool SF = false;
		public bool PGSWear = false;
		public bool RevSet = false;
		public bool XtraT = false;
		public bool BuffsKeep = false;
		public bool MemersRiposte = false;
		public bool ModPlayer = true;
		public bool lf = false;
		public bool GC = false;
		public int lamp = 0;
		public bool ParadiseLost = false;
		public bool Rampage = false;
		public bool LilithEmblem = false;
		public bool trigger = true;
		public bool turret = false;
		public bool watchercrystal = false;
		public bool devilsknife = false;
		public bool uw = false;
		public bool grimreaper = false;
		public bool snatcher = false;
		public bool rainbowdust = false;
		public bool sscope = false;
		public bool lwm = false;
		public bool DB = false;
		public bool GlobalTeleporter = false;
		public bool GlobalTeleporterUp = false;
		public bool MeatGrinderOnUse = false;
		public int DisasterGauge = 0;
		public int chargetime = 0;
		public int MeatGrinderUsetime = 0;
		
		private const int maxBBP = -1;
		public int BBP = 0;
		private const int maxSnatcherCounter = -1;
		public int SnatcherCounter = 0;
		private const int maxLifeElixir = 2;
		public int LifeElixir = 0;
		private const int maxFuaran = 1;
		public int Fuaran = 0;
		private const int maxKeepBuffs = 1;
		public int KeepBuffs = 0;
		private const int maxWellFed = 1;
		public int WellFed = 0;
		private const int maxBillIsDowned = 1;
		public int BillIsDowned = 0;
		
		private const int maxKingSlimeBooster = 1;
		public int KingSlimeBooster = 0;
		private const int maxEyeOfCthulhuBooster = 1;
		public int EyeOfCthulhuBooster = 0;
		private const int maxEaterOfWorldsBooster = 1;
		public int EaterOfWorldsBooster = 0;
		private const int maxBrainOfCthulhuBooster = 1;
		public int BrainOfCthulhuBooster = 0;
		private const int maxQueenBeeBooster = 1;
		public int QueenBeeBooster = 0;
		private const int maxSkeletronBooster = 1;
		public int SkeletronBooster = 0;
		private const int maxWoFBooster = 1;
		public int WoFBooster = 0;
		private const int maxDarkMageBooster = 1;
		public int DarkMageBooster = 0;
		private const int maxDestroyerBooster = 1;
		public int DestroyerBooster = 0;
		private const int maxCustomBooster1 = 1;
		public int CustomBooster1 = 0;
		private const int maxCustomBooster2 = 1;
		public int CustomBooster2 = 0;
		private const int maxPrimeBooster = 1;
		public int PrimeBooster = 0;
		private const int maxTwinsBooster = 1;
		public int TwinsBooster = 0;
		private const int maxPlanteraBooster = 1;
		public int PlanteraBooster = 0;
		private const int maxIceGolemBooster = 1;
		public int IceGolemBooster = 0;
		private const int maxPigronBooster = 1;
		public int PigronBooster = 0;
		private const int maxOgreBooster = 1;
		public int OgreBooster = 0;
		private const int maxGolemBooster = 1;
		public int GolemBooster = 0;
		private const int maxBetsyBooster = 1;
		public int BetsyBooster = 0;
		private const int maxGSummonerBooster = 1;
		public int GSummonerBooster = 0;
		private const int maxFishronBooster = 1;
		public int FishronBooster = 0;
		private const int maxMartianSaucerBooster = 1;
		public int MartianSaucerBooster = 0;
		private const int maxCultistBooster = 1;
		public int CultistBooster = 0;
		private const int maxMoonLordBooster = 1;
		public int MoonLordBooster = 0;
		
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.World.CalamityWorld.downedSCal; }
		}
		
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		
		public override void ResetEffects()
		{
			if (AlchemistNPCWorld.foundAntiBuffMode)
			{
				player.AddBuff(mod.BuffType("AntiBuff"), 2);
			}
			if (Shield < 0)
			{
				Shield = 0;
			}
			Item.potionDelay = 3600;
			HPJ = false;
			DeltaRune = false;
			PH = false;
			PB4K = false;
			DistantPotionsUse = false;
			CursedMirror = false;
			Voodoo = false;
			ShieldBelt = false;
			MysticAmuletMount = false;
			Luck = false;
			TerrarianBlock = false;
			AlchemistGlobalItem.Luck = false;
			AlchemistGlobalItem.Luck2 = false;
			AlchemistGlobalItem.PerfectionToken = false;
			AlchemistGlobalItem.Menacing = false;
			AlchemistGlobalItem.Lucky = false;
			AlchemistGlobalItem.Violent = false;
			AlchemistGlobalItem.Warding = false;
			AlchemistGlobalItem.Stopper = false;
			AlchemistNPC.BastScroll = false;
			AlchemistNPC.Stormbreaker = false;
			MeatGrinderOnUse = false;
			AlchemistCharmTier1 = false;
			AlchemistCharmTier2 = false;
			AlchemistCharmTier3 = false;
			AlchemistCharmTier4 = false;
			Illuminati = false;
			BeeHeal = false;
			Pandora = false;
			TS = false;
			Symbiote = false;
			DriedFish = false;
			SolarFish = false;
			NebulaFish = false;
			VortexFish = false;
			StardustFish = false;
			MiniShark = false;
			Manna = false;
			Akumu = false;
			AutoinjectorMK2 = false;
			EyeOfJudgement = false;
			LaetitiaSet = false;
			LaetitiaGift = false;
			Scroll = false;
			SFU = false;
			SF = false;
			XtraT = false;
			RevSet = false;
			MemersRiposte = false;
			PGSWear = false;
			Extractor = false;
			ParadiseLost = false;
			Rampage = false;
			LilithEmblem = false;
			turret = false;
			watchercrystal = false;
			devilsknife = false;
			uw = false;
			grimreaper = false;
			snatcher = false;
			rainbowdust = false;
			sscope = false;
			lwm = false;
			Yui = false;
			YuiS = false;
			Traps = false;
			GlobalTeleporter = false;
			GlobalTeleporterUp = false;
			
			player.statLifeMax2 += LifeElixir * 50;
			player.statManaMax2 += Fuaran * 100;
			
			if (KeepBuffs == 1)
			{
			BuffsKeep = true;
			player.pStone = true;
			}
			if (KeepBuffs == 0)
			{
			BuffsKeep = false;
			}
			if (WellFed == 1)
			{
			player.AddBuff(BuffID.WellFed, 2);
			}
			if (BillIsDowned == 1)
			{
			player.AddBuff(mod.BuffType("DemonSlayer"), 2);
			}
			if (Main.netMode == 0)
			{
				if (player.talkNPC == -1)
				{
					ShopChangeUI.visible = false;
					ShopChangeUIA.visible = false;
					ShopChangeUIO.visible = false;
					ShopChangeUIM.visible = false;
					ShopChangeUIT.visible = false;
				}
			}
		}
		
		public override bool CanBeHitByProjectile(Projectile projectile)
		{
			if (player.HasBuff(mod.BuffType("Akumu")) || player.HasBuff(mod.BuffType("TrueAkumu")))
			{
				return false;
			}
			return true;
		}
		
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
			clone.BBP = BBP;
			clone.SnatcherCounter = SnatcherCounter;
		}
	
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.LifeAndManaSync);
			packet.Write((byte)player.whoAmI);
			packet.Write(LifeElixir);
			packet.Write(Fuaran);
			packet.Write(KeepBuffs);
			packet.Write(WellFed);
			packet.Write(BillIsDowned);
			packet.Write(BBP);
			packet.Write(SnatcherCounter);
			
			packet.Write(KingSlimeBooster);
			packet.Write(EyeOfCthulhuBooster);
			packet.Write(EaterOfWorldsBooster);
			packet.Write(BrainOfCthulhuBooster);
			packet.Write(QueenBeeBooster);
			packet.Write(SkeletronBooster);
			packet.Write(WoFBooster);
			packet.Write(DarkMageBooster);
			packet.Write(CustomBooster1);
			packet.Write(CustomBooster2);
			packet.Write(DestroyerBooster);
			packet.Write(PrimeBooster);
			packet.Write(TwinsBooster);
			packet.Write(IceGolemBooster);
			packet.Write(PigronBooster);
			packet.Write(OgreBooster);
			packet.Write(PlanteraBooster);
			packet.Write(GolemBooster);
			packet.Write(BetsyBooster);
			packet.Write(GSummonerBooster);
			packet.Write(FishronBooster);
			packet.Write(MartianSaucerBooster);
			packet.Write(CultistBooster);
			packet.Write(MoonLordBooster);
			packet.Send(toWho, fromWho);
		}
	
		public override void OnEnterWorld(Player player)
		{
            string enterText = Language.GetTextValue("Mods.AlchemistNPC.enterText");
			if (AlchemistNPC.modConfiguration.StartMessage)
			{
				Main.NewText(enterText, 0, 255, 255);
			}
		}
	
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			AlchemistNPCPlayer clone = clientPlayer as AlchemistNPCPlayer;
			if (clone.BBP != BBP || clone.SnatcherCounter != SnatcherCounter) {
				var packet = mod.GetPacket();
				packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.SyncPlayerVariables);
				packet.Write((byte)player.whoAmI);
				packet.Write(BBP);
				packet.Write(SnatcherCounter);
				packet.Send();
			}
		}
	
		public override TagCompound Save()
		{
			return new TagCompound {
				{"LifeElixir", LifeElixir},
				{"Fuaran", Fuaran},
				{"KeepBuffs", KeepBuffs},
				{"WellFed", WellFed},
				{"BillIsDowned", BillIsDowned},
				{"BBP", BBP},
				{"SnatcherCounter", SnatcherCounter},
				
				{"KingSlimeBooster", KingSlimeBooster},
				{"EyeOfCthulhuBooster", EyeOfCthulhuBooster},
				{"EaterOfWorldsBooster", EaterOfWorldsBooster},
				{"BrainOfCthulhuBooster", BrainOfCthulhuBooster},
				{"QueenBeeBooster", QueenBeeBooster},
				{"SkeletronBooster", SkeletronBooster},
				{"WoFBooster", WoFBooster},
				{"DarkMageBooster", DarkMageBooster},
				{"CustomBooster1", CustomBooster1},
				{"CustomBooster2", CustomBooster2},
				{"DestroyerBooster", DestroyerBooster},
				{"PrimeBooster", PrimeBooster},
				{"TwinsBooster", TwinsBooster},
				{"IceGolemBooster", IceGolemBooster},
				{"PigronBooster", PigronBooster},
				{"OgreBooster", OgreBooster},
				{"PlanteraBooster", PlanteraBooster},
				{"GolemBooster", GolemBooster},
				{"BetsyBooster", BetsyBooster},
				{"GSummonerBooster", GSummonerBooster},
				{"FishronBooster", FishronBooster},
				{"MartianSaucerBooster", MartianSaucerBooster},
				{"CultistBooster", CultistBooster},
				{"MoonLordBooster", MoonLordBooster},
			};
		}
		
		public override void Load(TagCompound tag)
		{
			LifeElixir = tag.GetInt("LifeElixir");
			Fuaran = tag.GetInt("Fuaran");
			KeepBuffs = tag.GetInt("KeepBuffs");
			WellFed = tag.GetInt("WellFed");
			BillIsDowned = tag.GetInt("BillIsDowned");
			BBP = tag.GetInt("BBP");
			SnatcherCounter = tag.GetInt("SnatcherCounter");
			
			KingSlimeBooster = tag.GetInt("KingSlimeBooster");
			EyeOfCthulhuBooster = tag.GetInt("EyeOfCthulhuBooster");
			EaterOfWorldsBooster = tag.GetInt("EaterOfWorldsBooster");
			BrainOfCthulhuBooster = tag.GetInt("BrainOfCthulhuBooster");
			QueenBeeBooster = tag.GetInt("QueenBeeBooster");
			SkeletronBooster = tag.GetInt("SkeletronBooster");
			WoFBooster = tag.GetInt("WoFBooster");
			DarkMageBooster = tag.GetInt("DarkMageBooster");
			CustomBooster1 = tag.GetInt("CustomBooster1");
			CustomBooster2 = tag.GetInt("CustomBooster2");
			DestroyerBooster = tag.GetInt("DestroyerBooster");
			PrimeBooster = tag.GetInt("PrimeBooster");
			TwinsBooster = tag.GetInt("TwinsBooster");
			IceGolemBooster = tag.GetInt("IceGolemBooster");
			PigronBooster = tag.GetInt("PigronBooster");
			OgreBooster = tag.GetInt("OgreBooster");
			PlanteraBooster = tag.GetInt("PlanteraBooster");
			GolemBooster = tag.GetInt("GolemBooster");
			BetsyBooster = tag.GetInt("BetsyBooster");
			GSummonerBooster = tag.GetInt("GSummonerBooster");
			FishronBooster = tag.GetInt("FishronBooster");
			MartianSaucerBooster = tag.GetInt("MartianSaucerBooster");
			CultistBooster = tag.GetInt("CultistBooster");
			MoonLordBooster = tag.GetInt("MoonLordBooster");
		}
	
		public override void AnglerQuestReward(float quality, List<Item> rewardItems)
		{
			if (DriedFish)
			{
				Item vobla = new Item();
				vobla.SetDefaults(mod.ItemType("DriedFish"));
				vobla.stack = 1;
				rewardItems.Add(vobla);
			}
			if (SolarFish)
			{
				Item solar = new Item();
				solar.SetDefaults(ItemID.FragmentSolar);
				solar.stack = 25;
				rewardItems.Add(solar);
			}
			if (NebulaFish)
			{
				Item nebula = new Item();
				nebula.SetDefaults(ItemID.FragmentNebula);
				nebula.stack = 25;
				rewardItems.Add(nebula);
			}
			if (VortexFish)
			{
				Item vortex = new Item();
				vortex.SetDefaults(ItemID.FragmentVortex);
				vortex.stack = 25;
				rewardItems.Add(vortex);
			}
			if (StardustFish)
			{
				Item stardust = new Item();
				stardust.SetDefaults(ItemID.FragmentStardust);
				stardust.stack = 25;
				rewardItems.Add(stardust);
			}
			if (MiniShark)
			{
				Item minishark = new Item();
				minishark.SetDefaults(ItemID.Minishark);
				minishark.stack = 1;
				rewardItems.Add(minishark);
			}
			if (Manna)
			{
				Item manna = new Item();
				manna.SetDefaults(mod.ItemType("MannafromHeaven"));
				manna.stack = 1;
				rewardItems.Add(manna);
			}
		}

		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
			{
				return;
			}
			if (questFish == mod.ItemType("MutantFish") && Main.rand.Next(8) == 0)
			{
				caughtType = mod.ItemType("MutantFish");
			}
			if (player.ZoneTowerSolar && questFish == mod.ItemType("SolarFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("SolarFish");
			}
			if (player.ZoneTowerNebula && questFish == mod.ItemType("NebulaFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("NebulaFish");
			}
			if (player.ZoneTowerVortex && questFish == mod.ItemType("VortexFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("VortexFish");
			}
			if (player.ZoneTowerStardust && questFish == mod.ItemType("StardustFish") && Main.rand.Next(5) == 0)
			{
				caughtType = mod.ItemType("StardustFish");
			}
			if (player.ZoneBeach && questFish == mod.ItemType("MiniShark") && Main.rand.Next(8) == 0)
			{
				caughtType = mod.ItemType("MiniShark");
			}
			if (player.ZoneDesert && questFish == mod.ItemType("MosesFish") && Main.rand.Next(20) == 0 && power < 55)
			{
				caughtType = mod.ItemType("MosesFish");
			}
			if (player.ZoneDesert && questFish == mod.ItemType("MosesFish") && Main.rand.Next(10) == 0 && power >= 55)
			{
				caughtType = mod.ItemType("MosesFish");
			}
		}
	
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{	
			if (target.friendly == false)
			{
				if (GSummonerBooster == 1)
				{
					target.buffImmune[153] = false;
					target.AddBuff(153, 300);
				}
				if (BetsyBooster == 1)
				{
					target.buffImmune[189] = false;
					target.AddBuff(189, 300);
				}
				if (Illuminati)
				{
					target.buffImmune[BuffID.Midas] = false;
					target.AddBuff(BuffID.Midas, 600);
				}
				if (player.HasBuff(mod.BuffType("RainbowFlaskBuff")))
				{
					target.buffImmune[BuffID.BetsysCurse] = false;
					target.buffImmune[BuffID.Ichor] = false;
					target.buffImmune[BuffID.Daybreak] = false;
					target.AddBuff(mod.BuffType("Corrosion"), 600);
					target.AddBuff(BuffID.BetsysCurse, 600);
					target.AddBuff(BuffID.Ichor, 600);
					target.AddBuff(BuffID.Daybreak, 600);
				}
				if (player.HasBuff(mod.BuffType("BigBirdLamp")))
				{
					target.buffImmune[BuffID.BetsysCurse] = false;
					target.buffImmune[BuffID.Ichor] = false;
					target.AddBuff(BuffID.Ichor, 600);
					target.AddBuff(BuffID.BetsysCurse, 600);
				}
				if (Scroll)
				{
					if (target.type != mod.NPCType("Knuckles"))
					{
						target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
						target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
						target.defense = 0;
					}
				}
				if (player.HasBuff(mod.BuffType("ExplorersBrew")))
				{
					target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (target.friendly == false)
			{
				if (GSummonerBooster == 1)
				{
					target.buffImmune[153] = false;
					target.AddBuff(153, 300);
				}
				if (BetsyBooster == 1)
				{
					target.buffImmune[189] = false;
					target.AddBuff(189, 300);
				}
				if (Illuminati)
				{
					target.buffImmune[BuffID.Midas] = false;
					target.AddBuff(BuffID.Midas, 600);
				}
				if (player.HasBuff(mod.BuffType("RainbowFlaskBuff")))
				{
					target.buffImmune[BuffID.BetsysCurse] = false;
					target.buffImmune[BuffID.Ichor] = false;
					target.buffImmune[BuffID.Daybreak] = false;
					target.AddBuff(mod.BuffType("Corrosion"), 600);
					target.AddBuff(BuffID.BetsysCurse, 600);
					target.AddBuff(BuffID.Ichor, 600);
					target.AddBuff(BuffID.Daybreak, 600);
				}
				if (player.HasBuff(mod.BuffType("BigBirdLamp")))
				{
					target.buffImmune[BuffID.BetsysCurse] = false;
					target.buffImmune[BuffID.Ichor] = false;
					target.AddBuff(BuffID.Ichor, 600);
					target.AddBuff(BuffID.BetsysCurse, 600);
				}
				if (proj.thrown && Scroll)
				{
					if (target.type != mod.NPCType("Knuckles"))
					{
						target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
						target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
					}
				}
				if ((proj.type == ProjectileID.Electrosphere) && XtraT)
				{
					target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
				if (player.HasBuff(mod.BuffType("ExplorersBrew")))
				{
					target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
		
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (player.HasBuff(mod.BuffType("TrueUganda")))
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + " DIDN NO DE WEI!");
			}
			if (NPC.AnyNPCs(mod.NPCType("Knuckles")))
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + " DIDN NO DE WEI!");
			}
			if (NPC.AnyNPCs(mod.NPCType("BillCipher")))
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + " was evaporated by the new master of this world.");
			}
			if (Illuminati && !player.HasBuff(mod.BuffType("IlluminatiCooldown")) && !player.HasBuff(mod.BuffType("MindBurn")) && !player.HasBuff(mod.BuffType("TrueUganda")))
			{
				player.statLife = 1;
				return false;
			}
			return true;
		}
		
		public override void OnRespawn(Player player)
		{
			if (NPC.AnyNPCs(NPCID.Nurse) && AlchemistNPCWorld.foundPHD && (player == Main.player[Main.myPlayer]))
			{
				int num1 = player.statLifeMax2 - player.statLife;
				int num2 = (int)((double)num1 * 0.75);
				if (num2 < 1)
				{
					num2 = 1;
				}
				HealingUI.visible = true;
				if(Language.ActiveCulture == GameCulture.Chinese)
				{
					Main.NewText("[c/00FF00:护士]: 您需要支付" + Math.Truncate((double)num2/100) + "银" + (num2-(Math.Truncate((double)num2/100)*100)) + "铜作为医疗费.", 0, 0, 0);
				}
				else
				{
					Main.NewText("[c/00FF00:Nurse]: You need " + Math.Truncate((double)num2/100) + " silver coins and " + (num2-(Math.Truncate((double)num2/100)*100)) + " copper coins to pay the doctor's fee.", 0, 0, 0);
				}
			}
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (GlobalTeleporter || GlobalTeleporterUp)
			{
				bool allow = true;
				for (int v = 0; v < 200; ++v)
				{
					NPC npc = Main.npc[v];
					if (npc.active && npc.boss)
					{
						allow = false;
						break;
					}
				}
				if (GlobalTeleporterUp && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
				{
					int mapWidth = Main.maxTilesX * 16;
					int mapHeight = Main.maxTilesY * 16;
					Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

					cursorPosition.X -= Main.screenWidth / 2;
					cursorPosition.Y -= Main.screenHeight / 2;

					Vector2 mapPosition = Main.mapFullscreenPos;
					Vector2 cursorWorldPosition = mapPosition;

					cursorPosition /= 16;
					cursorPosition *= 16 / Main.mapFullscreenScale;
					cursorWorldPosition += cursorPosition;
					cursorWorldPosition *= 16;

					cursorWorldPosition.Y -= player.height;
					if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
					else if (cursorWorldPosition.X + player.width > mapWidth) cursorWorldPosition.X = mapWidth - player.width;
					if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
					else if (cursorWorldPosition.Y + player.height > mapHeight) cursorWorldPosition.Y = mapHeight - player.height;
					
					player.Teleport(cursorWorldPosition, 0, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) cursorWorldPosition.X, (float) cursorWorldPosition.Y, 1, 0, 0);
					Main.mapFullscreen = false;
					
					for (int index = 0; index < 120; ++index)
					Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, Main.rand.NextFloat(-10f,10f), Main.rand.NextFloat(-10f,10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
				}
				if (GlobalTeleporter && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
				{
					int mapWidth = Main.maxTilesX * 16;
					int mapHeight = Main.maxTilesY * 16;
					Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

					cursorPosition.X -= Main.screenWidth / 2;
					cursorPosition.Y -= Main.screenHeight / 2;

					Vector2 mapPosition = Main.mapFullscreenPos;
					Vector2 cursorWorldPosition = mapPosition;

					cursorPosition /= 16;
					cursorPosition *= 16 / Main.mapFullscreenScale;
					cursorWorldPosition += cursorPosition;
					cursorWorldPosition *= 16;

					cursorWorldPosition.Y -= player.height;
					if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
					else if (cursorWorldPosition.X + player.width > mapWidth) cursorWorldPosition.X = mapWidth - player.width;
					if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
					else if (cursorWorldPosition.Y + player.height > mapHeight) cursorWorldPosition.Y = mapHeight - player.height;
					
					player.Teleport(cursorWorldPosition, 0, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) cursorWorldPosition.X, (float) cursorWorldPosition.Y, 1, 0, 0);
					Main.mapFullscreen = false;
					Item[] inventory = player.inventory;
					for (int k = 0; k < inventory.Length; k++)
					{
						if (inventory[k].type == mod.ItemType("GlobalTeleporter"))
						{
							inventory[k].stack--;
							break;
						}
					}
					for (int index = 0; index < 120; ++index)
					Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, Main.rand.NextFloat(-10f,10f), Main.rand.NextFloat(-10f,10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
				}
			}
			if (AlchemistNPC.LampLight.JustPressed)
			{
				if (lamp == 0 && trigger)
				{
				trigger = false;
				lamp++;
				lf = true;
				}
				if (lamp == 1 && !trigger && !lf)
				{
				trigger = true;
				lamp = 0;
				}
				lf = false;
			}
			if (AlchemistNPC.PipBoyTP.JustPressed && PB4K)
			{
				PipBoyTPMenu.visible = true;
			}
			if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
			{
				LegacySoundStyle type1 = (LegacySoundStyle) null;
				for (int index1 = 0; index1 < 40; ++index1)
				  {
					if (player.CountBuffs() == 22)
					  return;
					if (player.bank.item[index1].stack > 0 && player.bank.item[index1].type > 0 && (player.bank.item[index1].buffType > 0 && !player.bank.item[index1].summon) && player.bank.item[index1].buffType != 90)
					{
					  int type2 = player.bank.item[index1].buffType;
					  bool flag = true;
					  for (int index2 = 0; index2 < 22; ++index2)
					  {
						if (type2 == 27 && (player.buffType[index2] == type2 || player.buffType[index2] == 101 || player.buffType[index2] == 102))
						{
						  flag = false;
						  break;
						}
						if (player.buffType[index2] == type2)
						{
						  flag = false;
						  break;
						}
						if (Main.meleeBuff[type2] && Main.meleeBuff[player.buffType[index2]])
						{
						  flag = false;
						  break;
						}
					  }
					  if (Main.lightPet[player.bank.item[index1].buffType] || Main.vanityPet[player.bank.item[index1].buffType])
					  {
						for (int index2 = 0; index2 < 22; ++index2)
						{
						  if (Main.lightPet[player.buffType[index2]] && Main.lightPet[player.bank.item[index1].buffType])
							flag = false;
						  if (Main.vanityPet[player.buffType[index2]] && Main.vanityPet[player.bank.item[index1].buffType])
							flag = false;
						}
					  }
					  if (player.bank.item[index1].mana > 0 & flag)
					  {
						if (player.statMana >= (int) ((double) player.bank.item[index1].mana * (double) player.manaCost))
						{
						  player.manaRegenDelay = (int) player.maxRegenDelay;
						  player.statMana = player.statMana - (int) ((double) player.bank.item[index1].mana * (double) player.manaCost);
						}
						else
						  flag = false;
					  }
					  if (player.whoAmI == Main.myPlayer && player.bank.item[index1].type == 603 && !Main.cEd)
						flag = false;
					  if (type2 == 27)
					  {
						type2 = Main.rand.Next(3);
						if (type2 == 0)
						  type2 = 27;
						if (type2 == 1)
						  type2 = 101;
						if (type2 == 2)
						  type2 = 102;
					  }
					  if (flag)
					  {
						type1 = player.bank.item[index1].UseSound;
						int time1 = player.bank.item[index1].buffTime;
						if (time1 == 0)
						  time1 = 3600;
					  if (KeepBuffs == 1)
					  {
						player.AddBuff(type2, time1*2, true);
					  }
					  if (KeepBuffs == 0)
					  {
						player.AddBuff(type2, time1, true);
					  }
						if (player.bank.item[index1].consumable)
						{
							if (AlchemistCharmTier4 == true)
							{
								if (ModLoader.GetMod("CalamityMod") != null)
								{
									if (CalamityModDownedSCal)
									{
									}
								}
								if (Main.rand.NextFloat() >= .25f)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier3 == true)
							{
								if (Main.rand.Next(2) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier2 == true)
							{
								if (Main.rand.Next(4) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier1 == true)
							{
								if (Main.rand.Next(10) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							else
							{
								--player.bank.item[index1].stack;
							}
						  if (player.bank.item[index1].stack <= 0)
							player.bank.item[index1].TurnToAir();
						}
					  }
					}
				  }
				if (type1 == null)
				return;
				Main.PlaySound(type1, player.position);
				Recipe.FindRecipes();
			}
			if (AlchemistNPC.DiscordBuff.JustPressed)
			{
				if (Main.myPlayer == player.whoAmI && player.HasBuff(mod.BuffType("DiscordBuff")))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
					if (!Collision.SolidCollision(vector2, player.width, player.height))
					{
						player.Teleport(vector2, 1, 0);
						NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (player.chaosState)
						{
							player.statLife = player.statLife - player.statLifeMax2 / 3;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
							if (player.statLife <= 0)
							player.KillMe(damageSource, 1.0, 0, false);
							player.lifeRegenCount = 0;
							player.lifeRegenTime = 0;
						}
						player.AddBuff(88, 600, true);
						player.AddBuff(164, 60, true);
					}
				}
				if (Main.myPlayer == player.whoAmI && player.HasBuff(mod.BuffType("TrueDiscordBuff")))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				if (!Collision.SolidCollision(vector2, player.width, player.height))
				{
					player.Teleport(vector2, 1, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (player.chaosState)
						{
							player.statLife = player.statLife - player.statLifeMax2 / 7;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
							if (player.statLife <= 0)
							player.KillMe(damageSource, 1.0, 0, false);
							player.lifeRegenCount = 0;
							player.lifeRegenTime = 0;
						}
					player.AddBuff(88, 360, true);
					}
				}
			}
		}
		
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
			Item item = new Item();
			item.SetDefaults(mod.ItemType("AntiBuffItem"));
			item.stack = 1;
			items.Add(item);
		}
		
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
			if (player.HasBuff(mod.BuffType("GuarantCrit")) && crit)
			{
				damage *= 2;
				GC = false;
			}
			if (player.HasBuff(mod.BuffType("ExecutionersEyes")) && crit && Main.rand.Next(20) == 0)
            {
                damage *= 2;
            }
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
        }
		
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			if (player.HeldItem.type == mod.ItemType("Penetrator") && crit)
			{
				switch (Main.rand.Next(3))
				{
					case 0:
					damage += damage*2;
					break;
					case 1:
					damage += damage*3;	
					break;
					case 2:
					damage += damage*4;	
					break;
				}
			}
			if (player.HasBuff(mod.BuffType("GuarantCrit")) && crit)
			{
				damage *= 2;
				GC = false;
			}
			if (player.HasBuff(mod.BuffType("ExecutionersEyes")) && crit && Main.rand.Next(20) == 0)
            {
                damage *= 2;
            }
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
			if (proj.type == mod.ProjectileType("DemonicBullet") && crit && Main.rand.Next(200) == 0)
            {
                damage = 33333;
            }
		}
		
		public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) 		
        {
			if (QueenBeeBooster == 1)
			{
				var hornet = new List<int>();
				for (int k = -65; k < -56; k++)
				{
					hornet.Add(k);
				}
				for (int j = -21; j < -18; j++)
				{
					hornet.Add(j);
				}
				hornet.Add(42);
				hornet.Add(176);
				for (int l = 231; l < 235; l++)
				{
					hornet.Add(l);
				}
				hornet.Add(210);
				hornet.Add(211);
				for (int choose = 0; choose < hornet.Count; choose++)
				{
					if (npc.type == hornet[choose])
					{
						damage /= 2;
					}
				}
			}
			if (SkeletronBooster == 1)
			{
				var skeleton = new List<int>();
				for (int a = -53; a < -46; a++)
				{
					skeleton.Add(a);
				}
				for (int b = 201; b < 203; b++)
				{
					skeleton.Add(b);
				}
				for (int c = 291; c < 293; c++)
				{
					skeleton.Add(c);
				}
				for (int d = 322; d < 324; d++)
				{
					skeleton.Add(d);
				}
				for (int e = 449; e < 452; e++)
				{
					skeleton.Add(e);
				}
				skeleton.Add(-15);
				skeleton.Add(21);
				skeleton.Add(77);
				skeleton.Add(110);
				skeleton.Add(481);
				skeleton.Add(566);
				skeleton.Add(567);
				for (int choose1 = 0; choose1 < skeleton.Count; choose1++)
				{
					if (npc.type == skeleton[choose1])
					{
						damage /= 2;
					}
				}
			}
			if (CultistBooster == 1)
			{
				var pillare = new List<int>();
				for (int a1 = 402; a1 < 429; a1++)
				{
					pillare.Add(a1);
				}
				for (int choose2 = 0; choose2 < pillare.Count; choose2++)
				{
					if (npc.type == pillare[choose2])
					{
						damage -= damage/3;
					}
				}
			}
			if (MoonLordBooster == 1)
			{
				damage -= damage/10;
			}
			if (npc.type == mod.NPCType("BillCipher"))
            {
				player.AddBuff(mod.BuffType("MindBurn"), 1200);
			}
			if (TerrarianBlock && Main.dayTime)
            {
				damage -= damage/3;
			}
			if (Illuminati)
            {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("IlluminatiFreeze"), 0, 0, player.whoAmI);
			}
			if (MemersRiposte)
            {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
			}
			if (Shield > 0)
            {
				int damage2 = damage;
				damage -= Shield;
				Shield -= damage2;
			}
			if (player.HasBuff(mod.BuffType("Judgement")))
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				damage -= 100;
				}
        }
		
		public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) 	
        {
			if (QueenBeeBooster == 1)
			{
				if (proj.type == 55)
				{
					damage /= 2;
				}
			}
			if (CultistBooster == 1)
			{
				var pillarp = new List<int>();
				pillarp.Add(537);
				pillarp.Add(538);
				pillarp.Add(539);
				for (int a1 = 573; a1 < 581; a1++)
				{
					pillarp.Add(a1);
				}
				pillarp.Add(607);
				pillarp.Add(629);
				for (int choose = 0; choose < pillarp.Count; choose++)
				{
					if (proj.type == pillarp[choose])
					{
						damage -= damage/3;
					}
				}
			}
			if (MoonLordBooster == 1)
			{
				damage -= damage/10;
			}
			if (TerrarianBlock && !Main.dayTime)
            {
				damage -= damage/3;
			}
			if (Illuminati)
            {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("IlluminatiFreeze"), 0, 0, player.whoAmI);
			}
			if (MemersRiposte)
            {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
			}
			if (Shield > 0)
            {
				int damage2 = damage;
				damage -= Shield;
				Shield -= damage2;
			}
			if (player.HasBuff(mod.BuffType("Judgement")))
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				damage -= 100;
				}
        }
		
		public override void PostUpdate()
		{
			if (MysticAmuletMount)
			{
				player.hairFrame.Y = 5 * player.hairFrame.Height;
				player.headFrame.Y = 5 * player.headFrame.Height;
				player.legFrame.Y = 5 * player.legFrame.Height;
			}
		}
		
		public static readonly PlayerLayer MiscEffects = new PlayerLayer("AlchemistNPC", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate(PlayerDrawInfo drawInfo)
			{
				if (drawInfo.shadow != 0f)
				{
					return;
				}
				Player drawPlayer = drawInfo.drawPlayer;
				if (drawPlayer.dead)
				{
					return;
				}
				Mod mod = ModLoader.GetMod("AlchemistNPC");
				AlchemistNPCPlayer modPlayer = drawPlayer.GetModPlayer<AlchemistNPCPlayer>();
				if (modPlayer.MysticAmuletMount && modPlayer.fc <= 10)
				{
					Texture2D texture = mod.GetTexture("Mounts/MysticAmulet");
					int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
					int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
					float strength = 1f;
					if (strength > 1f)
					{
						strength = 2f - strength;
					}
					strength = 0.4f + strength * 0.2f;
					DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
					data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
					Main.playerDrawData.Add(data);
				}
				if (modPlayer.MysticAmuletMount && modPlayer.fc > 10 && modPlayer.fc <= 20)
				{
					Texture2D texture = mod.GetTexture("Mounts/MysticAmulet2");
					int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
					int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
					float strength = 1f;
					if (strength > 1f)
					{
						strength = 2f - strength;
					}
					strength = 0.4f + strength * 0.2f;
					DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
					data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
					Main.playerDrawData.Add(data);
				}
				if (modPlayer.MysticAmuletMount && modPlayer.fc > 20 &&  modPlayer.fc <= 30)
				{
					Texture2D texture = mod.GetTexture("Mounts/MysticAmulet3");
					int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
					int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
					float strength = 1f;
					if (strength > 1f)
					{
						strength = 2f - strength;
					}
					strength = 0.4f + strength * 0.2f;
					DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
					data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
					Main.playerDrawData.Add(data);
				}
				if (modPlayer.MysticAmuletMount && modPlayer.fc > 30 &&  modPlayer.fc <= 40)
				{
					Texture2D texture = mod.GetTexture("Mounts/MysticAmulet4");
					int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
					int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
					float strength = 1f;
					if (strength > 1f)
					{
						strength = 2f - strength;
					}
					strength = 0.4f + strength * 0.2f;
					DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
					data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
					Main.playerDrawData.Add(data);
				}
			});

			public override void ModifyDrawLayers(List<PlayerLayer> layers)
			{
				MiscEffects.visible = true;
				layers.Add(MiscEffects);
			}
	}
}