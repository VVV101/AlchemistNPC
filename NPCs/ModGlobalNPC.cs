using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

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
		
		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (npc.FindBuffIndex(mod.BuffType("CurseOfLight")) > -1)
			{
				damage += damage/5;
			}
		}
		
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (npc.FindBuffIndex(mod.BuffType("CurseOfLight")) > -1)
			{
				damage += damage/5;
			}
		}
		
		public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
		{
			if (npc.FindBuffIndex(mod.BuffType("CurseOfLight")) > -1 && Main.rand.Next(4) == 0)
			{
				damage /= 2;
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
			if (ModLoader.GetLoadedMods().Contains("MaterialTraderNpc"))
				{
				if (npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Jungle Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cavern Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cool Guy")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Desert Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Dungeon Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Evil Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Hell Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Holy Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Ocean Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Sky Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Winter Trader")))
					{
						if (NPC.downedMoonlord)
						{
						npc.lifeMax = 500;
						}
					}
				}
		}
		
		public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
		{
			if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
				{
					if (Main.hardMode && !NPC.downedMoonlord)
					{
					damage += 20;	
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
				cooldown = 4;
				randExtraCooldown = 4;
				}
			}
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
			if (npc.type == NPCID.ArmsDealer)
				{
					if (NPC.downedMoonlord)
					{
					attackDelay = 4;
					projType = ProjectileID.MoonlordBullet;		
					}
				}
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
			if (npc.type == NPCID.ArmsDealer)
				{
					if (NPC.downedMoonlord)
					{
					item = ItemID.Megashark;
					}
				}
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
            if (corrosion)
            {
                npc.lifeRegen -= 1500;
                if (damage < 149)
                {
                    damage = 150;
                }
            }
			if (justitiapale)
            {
                npc.lifeRegen -= 2000;
                if (damage < 199)
                {
                    damage = 200;
                }
            }
			if (electrocute)
            {
                npc.lifeRegen -= 1500;
                if (damage < 149)
                {
                    damage = 150;
                }
            }
			if (twilight)
            {
                npc.lifeRegen -= 5000;
                if (damage < 499)
                {
                    damage = 500;
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
			if (npc.FindBuffIndex(mod.BuffType("CurseOfLight")) >= 0)
			{
				npc.color = new Color(255, 255, 255, 100);
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
            string barrierWeek = Language.GetTextValue("Mods.AlchemistNPC.barrierWeek");
            string Eclipse = Language.GetTextValue("Mods.AlchemistNPC.Eclipse");
            if (npc.type == NPCID.MoonLordCore)
			{
				if (!NPC.downedMoonlord)
				{
				Main.NewText(barrierWeek, 255, 255, 255);
				Main.NewText(Eclipse, 255, 50, 50);
				}
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (!NPC.downedBoss1)
				{
					if (Main.netMode == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AlchemistCharmTier1"));
                    }
                    if (Main.netMode == 1)
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            if(Main.player[i].active)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AlchemistCharmTier1"));
                            }
                        }

                    }
				}
			}
			if (Main.expertMode)
				{
					if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
					{
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Infernon")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(6, 9));
						}
					}
				}
			return true;
		}
		
		public override void NPCLoot(NPC npc)
        {
			if (Main.rand.Next(15000) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HolyAvenger"));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AlchemistNPCPlayer>(mod).Extractor && npc.boss == true && npc.lifeMax >= 50000 && (Main.rand.Next(3) == 0))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulEssence"));
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AlchemistNPCPlayer>(mod).Extractor && npc.boss == true && npc.lifeMax >= 55000 && (Main.rand.Next(10) == 0))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HateVial"));
			}
			if (npc.type == NPCID.MoonLordCore && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AlchemistNPCPlayer>(mod).PGSWear)
			{
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KnucklesUgandaDoll"));
				}
			}
			if (npc.type == mod.NPCType("Operator"))
			{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("APMC"));
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
			if (npc.type == NPCID.EyeofCthulhu && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote1"));
			}
			if (npc.type == NPCID.BrainofCthulhu && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote2"));
			}
			if (npc.type == NPCID.SkeletronHead && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote3"));
			}
			if (npc.type == NPCID.SkeletronPrime && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote4"));
			}
			if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote5"));
			}
			if (npc.type == NPCID.TheDestroyer && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote6"));
			}
			if (npc.type == NPCID.Plantera && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote7"));
			}
			if (npc.type == NPCID.Golem && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote8"));
			}
			if (npc.type == NPCID.Golem)
			{
				if (Main.rand.Next(10) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fuaran"));
				}
			}
			if (npc.type == NPCID.MoonLordCore && Config.TornNotesDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornNote9"));
			}
			if (Main.expertMode)
			{
				if (npc.type == NPCID.KingSlime && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.EyeofCthulhu && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(3, 6));
				}
				if (npc.type == NPCID.BrainofCthulhu && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
				}
				if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsTail) && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
				}
				if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
				}
				if (npc.type == NPCID.QueenBee && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(9, 12));
				}
				if (npc.type == NPCID.SkeletronHead && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(12, 15));
				}
				if (npc.type == NPCID.WallofFlesh && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.SkeletronPrime && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer) && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.TheDestroyer && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.Plantera && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
				}
				if (npc.type == NPCID.Golem && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(1, 3));
				}
				if (npc.type == NPCID.DukeFishron && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
				}
				if (npc.type == NPCID.CultistBoss && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
				}
				if (npc.type == NPCID.MoonLordCore && Config.CoinsDrop)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(6, 9));
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
					{
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("DesertScourgeHead")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(1, 3));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("CrabulonIdle")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("HiveMindP2")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PerforatorHive")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SlimeGodCore")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(1, 3));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Cryogen")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(6, 9));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("BrimstoneElemental")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("AquaticScourgeHead")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SoulSeeker")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(1, 2));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Leviathan")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Astrageldon")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ScavangerBody")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss2")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("ProfanedGuardianBoss3")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier5"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Providence")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier5"), Main.rand.Next(9, 12));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Polterghast")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier6"), Main.rand.Next(1, 3));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("DevourerofGodsHeadS")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier6"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Bumblefuck")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier6"), Main.rand.Next(3, 6));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("Yharon")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier6"), Main.rand.Next(12, 15));
						}
					if (npc.type == (ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier6"), 66);
						}
					}
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
					{
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheGrandThunderBirdv2")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(1, 2));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("QueenJelly")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("Viscount")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(5, 7));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("GraniteEnergyStorm")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("TheBuriedWarrior")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("ThePrimeScouter")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("BoreanStriderPopped")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(1, 3));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("FallenDeathBeholder2")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("LichHeadless")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("AbyssionReleased")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("ThoriumMod").NPCType("RealityBreaker")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), 33);
						}
					}
				if (ModLoader.GetLoadedMods().Contains("SacredTools"))
					{
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("FlamePump2")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(4, 6));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Jensen")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Raynare")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("Abaddon")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("AraghurHead")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("NovaLunarian")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier5"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SacredTools").NPCType("ChallengerBoss")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier5"), Main.rand.Next(6, 9));
						}
					}
				if (ModLoader.GetLoadedMods().Contains("SpiritMod"))
					{
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Scarabeus")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(2, 3));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("ReachBoss")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("AncientFlyer")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(9, 12));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SteamRaiderHead")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Dusking")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("SpiritCore")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(3, 6));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("IlluminantMaster")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Atlas")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("SpiritMod").NPCType("Overseer")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), 50);
						}
					}
				if (ModLoader.GetLoadedMods().Contains("Laugicality"))
					{
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("DuneSharkron")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(2, 3));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Hypothema")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Ragnar")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier1"), Main.rand.Next(9, 12));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("AnDio3")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier2"), Main.rand.Next(4, 6));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Slybertron")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("TheAnnihilator")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("SteamTrain")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier3"), Main.rand.Next(6, 9));
						}
						if (npc.type == (ModLoader.GetMod("Laugicality").NPCType("Etheria")) && Config.CoinsDrop)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReversivityCoinTier4"), 33);
						}
					}
			}
        }
	}
}
