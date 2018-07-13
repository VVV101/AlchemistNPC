using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public static bool on = false;
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Rampage == true && type == 14)
			{
				type = mod.ProjectileType("Chloroshard");
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		
		public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
			{
				type = mod.ProjectileType("Chloroshard");
			}
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (item.type == ItemID.KingSlimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "KingSlime", "King Slime Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EyeOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EyeofCthulhu", "Eye of Cthulhu Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EaterOfWorldsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EaterOfWorlds", "Eater Of Worlds Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BrainOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "BrainOfCthulhu", "Brain Of Cthulhu Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.QueenBeeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "QueenBeeBossBag", "Queen Bee Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Skeletron", "Skeletron Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.WallOfFleshBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "WallOfFleshBoss", "Wall Of Flesh Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.DestroyerBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Destroyer", "Destroyer Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.TwinsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Twins", "Twins Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronPrimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "SkeletronPrime", "Skeletron Prime Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.PlanteraBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Plantera", "Plantera Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.GolemBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Golem", "Golem Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.FishronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "DukeFishron", "Duke Fishron Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.MoonLordBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "MoonLord", "Moon Lord Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DesertScourge", "Desert Scourge Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Crabulon", "Crabulon Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
				{
				TooltipLine line = new TooltipLine(mod, "HiveMind", "The Hive Mind Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Perforator", "The Perforators Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SlimeGod", "The Slime God Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Cryogen", "Cryogen Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BrimstoneElemental", "Brimstone Elemental Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AquaticScourge", "Aquatic Scourge Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Calamitas", "Calamitas Doppelganger Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrageldonSlime", "Astrageldon Slime Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrumDeus", "Astrum Deus Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Leviathan", "The Leviathan Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
				{
				TooltipLine line = new TooltipLine(mod, "PlaguebringerGoliath", "The Plaguebringer Goliath Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ravager", "Ravager Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Providence", "Providence Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Polterghast", "Polterghast Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DevourerofGods", "The Devourer of Gods Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bumblebirb", "Bumblebirb Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yharon", "Yharon Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThunderBird", "The Great Thunder Bird Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "QueenJellyfish", "The Queen Jellyfish Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
				{
				TooltipLine line = new TooltipLine(mod, "GraniteEnergyStorm", "Granite Energy Storm Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheBuriedChampion", "The Buried Champion Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheStarScouter", "The Star Scouter Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BoreanStrider", "Borean Strider Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CoznixTheFallenBeholder", "Coznix, The Fallen Beholder Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheLich", "The Lich Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AbyssionTheForgottenOne", "Abyssion, The Forgotten One Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheRagnarok", "The Ragnarok Treasure Bag");
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
		}
		
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SuspiciousLookingScythe"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HeartofYui"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BanHammer"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PinkGuyHead"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyBody"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BlackCatHead"));
				player.QuickSpawnItem(mod.ItemType("BlackCatBody"));
				player.QuickSpawnItem(mod.ItemType("BlackCatLegs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Skyline222Hair"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Body"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Legs"));
			}
			if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("somebody0214Hood"));
				player.QuickSpawnItem(mod.ItemType("somebody0214Robe"));
			}
		}
	}
}
