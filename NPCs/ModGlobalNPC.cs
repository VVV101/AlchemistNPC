using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.NPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public bool rainbowdust = false;
		public bool electrocute = false;
		public bool corrosion = false;
		public bool twilight = false;
		public bool justitiapale = false;
		public bool N1 = false;
		public bool N2 = false;
		public bool N3 = false;
		public bool N4 = false;
		public bool N5 = false;
		public bool N6 = false;
		public bool N7 = false;
		public bool N8 = false;
		public bool N9 = false;
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (ModLoader.GetLoadedMods().Contains("Tremor"))
			{
			if (type == ModLoader.GetMod("Tremor").NPCType("Lady Moon"))
				{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DarkMass"));
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CarbonSteel"));
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Doomstone"));
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightmareBar"));
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("VoidBar"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AngryShard"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Phantaplasm"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ClusterShard"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DragonCapsule"));
				shop.item[nextSlot].shopCustomPrice = 50000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("HuskofDusk"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightCore"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GoldenClaw"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StoneDice"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ConcentratedEther"));
				shop.item[nextSlot].shopCustomPrice = 100000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Squorb"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ToothofAbraxas"));
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CosmicFuel"));
				shop.item[nextSlot].shopCustomPrice = 1000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("EyeofOblivion"));
				shop.item[nextSlot].shopCustomPrice = 3000000;
				nextSlot++;
				}
			}
		}
		
		public override void SetDefaults(NPC npc)
		{
			if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
				{
					if (NPC.downedMoonlord)
					{
					npc.lifeMax = 500;
					}
				}
			if (npc.type == mod.NPCType("Alchemist") || npc.type == mod.NPCType("Brewer") || npc.type == mod.NPCType("Young Brewer") || npc.type == mod.NPCType("Jeweler") || npc.type == mod.NPCType("Architect"))
				{
					if (NPC.downedMoonlord)
					{
					npc.lifeMax = 500;
					}
				}
		}
		
		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
				{
					if (Main.hardMode && !NPC.downedMoonlord)
					{
					damage = 40;	
					}
					if (NPC.downedMoonlord)
					{
					damage = 100;	
					}
				}
		}

		public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
		{
			if (npc.type == NPCID.Steampunker)
			{
				if (NPC.downedMoonlord)
				{
				cooldown = 3;
				randExtraCooldown = 3;
				}
			}
			if (npc.type == NPCID.Guide)
			{
				if (NPC.downedMoonlord)
				{
				cooldown = 3;
				}
			}
		}

		public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
		{
			if (npc.type == NPCID.Steampunker)
				{
					if (NPC.downedMoonlord)
					{
					attackDelay = 3;
					projType = ProjectileID.MoonlordBullet;		
					}
				}
			if (npc.type == NPCID.Cyborg)
				{
					if (NPC.downedMoonlord)
					{
					attackDelay = 3;
					projType = ProjectileID.RocketSnowmanI;		
					}
				}
			if (npc.type == NPCID.Wizard)
				{
					if (NPC.downedMoonlord)
					{
					projType = ProjectileID.CursedFlameFriendly;		
					}
				}
			if (npc.type == NPCID.Guide)
				{
					if (NPC.downedMoonlord)
					{
					projType = ProjectileID.MoonlordArrow;		
					}
				}
		}

		public override void DrawTownAttackGun(NPC npc, ref float scale, ref int item, ref int closeness)
		{
			if (npc.type == NPCID.Steampunker)
				{
					if (NPC.downedMoonlord)
					{
					scale = 1f;
					closeness = 4;
					item = ItemID.SDMG;
					}
				}
		}
		
		public override void BuffTownNPC(ref float damageMult, ref int defense)
		{
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			defense += 30;
			}
			if (NPC.downedMoonlord)
			{
			defense += 80;
			}
		}
		
		public override void ResetEffects(NPC npc)
        {
            corrosion = false;
			rainbowdust = false;
			electrocute = false;
			twilight = false;
			justitiapale = false;
			N1 = false;
			N2 = false;
			N3 = false;
			N4 = false;
			N5 = false;
			N6 = false;
			N7 = false;
			N8 = false;
			N9 = false;
        }
 
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (corrosion)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 1500;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 149)
                {
                    damage = 150;  // this is the damage dealt when the npc lose health
                }
            }
			if (justitiapale)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 2000;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 199)
                {
                    damage = 200;  // this is the damage dealt when the npc lose health
                }
            }
			if (electrocute)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 1500;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 149)
                {
                    damage = 150;  // this is the damage dealt when the npc lose health
                }
            }
			if (twilight)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 5000;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 499)
                {
                    damage = 500;  // this is the damage dealt when the npc lose health
                }
            }
        }
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (corrosion)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("RainbowDust"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			if (npc.FindBuffIndex(mod.BuffType("ArmorDestruction")) >= 0)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("BastScroll"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 1f, 1f, 1f);
			}
			if (justitiapale)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("JustitiaPale"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
			if (electrocute)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("Electrocute"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(8) == 0)
					{
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale *= 0.8f;
					}
				}
			}
			if (twilight)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("JustitiaPale"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
		}
		
		public override bool PreNPCLoot(NPC npc)
		{
			if (npc.type == NPCID.MoonLordCore)
			{
				if (!NPC.downedMoonlord)
				{
				Main.NewText("Barrier between worlds was weakened.", 255, 255, 255);
				Main.NewText("Eclipse creatures become anxious.", 255, 50, 50);
				}
			}
			return true;
		}
		
		public override void NPCLoot(NPC npc)
        {
            for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("TornNote1"))
						{
						N1 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote2"))
						{
						N2 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote3"))
						{
						N3 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote4"))
						{
						N4 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote5"))
						{
						N5 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote6"))
						{
						N6 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote7"))
						{
						N7 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote8"))
						{
						N8 = true;
						}
						if (player.inventory[j].type == mod.ItemType("TornNote9"))
						{
						N9 = true;
						}
					}
				}
			}
			if (AlchemistNPC.Extractor && npc.boss == true && npc.lifeMax >= 50000 && (Main.rand.Next(3) == 0))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulEssence"));
			}
			if (AlchemistNPC.Extractor && npc.boss == true && npc.lifeMax >= 55000 && (Main.rand.Next(10) == 0))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HateVial"));
			}
			if (npc.type == mod.NPCType("Operator"))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("APMC"));
			}
			if (npc.type == NPCID.MoonLordCore && AlchemistNPC.PGSWear)
			{
				if (Main.rand.Next(4) == 0)
                {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KnucklesUgandaDoll"));
				}
			}
			if (npc.type == NPCID.DungeonGuardian)
			{
				if (!Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmagledFragmentation"), Main.rand.Next(5, 10));
					if (Main.rand.Next(10) == 0)
					{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OtherworldlyAmulet"));
					}
				}
				if (Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmagledFragmentation"), Main.rand.Next(15, 20));
					if (Main.rand.Next(5) == 0)
					{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OtherworldlyAmulet"));
					}
				}
			}
			if (npc.type == NPCID.EyeofCthulhu && !N1 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote1"));
			}
			if (npc.type == NPCID.BrainofCthulhu && !N2 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsHead && !N2 && !NPC.AnyNPCs(NPCID.EaterofWorldsTail) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsTail && !N2 && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.SkeletronHead && !N3 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote3"));
			}
			if (npc.type == NPCID.SkeletronPrime && !N4 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote4"));
			}
			if (npc.type == NPCID.Spazmatism && !N5 && !NPC.AnyNPCs(NPCID.Retinazer) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.Retinazer && !N5 && !NPC.AnyNPCs(NPCID.Spazmatism) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.TheDestroyer && !N6 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote6"));
			}
			if (npc.type == NPCID.Plantera && !N7 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote7"));
			}
			if (npc.type == NPCID.Golem && !N8 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote8"));
			}
			if (npc.type == NPCID.Golem && Config.TornNotesDrop)
			{
				if (Main.rand.Next(10) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fuaran"));
				}
			}
			if (npc.type == NPCID.MoonLordCore && !N9 && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote9"));
			}
        }
	}
}
