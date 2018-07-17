using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC
{
	public class AlchemistNPCPlayer : ModPlayer
	{
		public bool Yui = false;
		public bool ModPlayer = true;
		public bool lf = false;
		public int lamp = 0;
		public bool ParadiseLost = false;
		public bool Rampage = false;
		public bool LilithEmblem = false;
		public bool trigger = true;
		public bool watchercrystal = false;
		public bool grimreaper = false;
		public bool rainbowdust = false;
		public bool sscope = false;
		public bool lwm = false;
		public bool jr = false;
		public bool DB = false;
		
		private const int maxLifeElixir = 2;
		public int LifeElixir = 0;
		private const int maxFuaran = 1;
		public int Fuaran = 0;
		private const int maxKeepBuffs = 1;
		public int KeepBuffs = 0;
		
		public override void ResetEffects()
		{
			AlchemistNPC.EyeOfJudgement = false;
			AlchemistNPC.MemersRiposte = false;
			AlchemistNPC.PGSWear = false;
			AlchemistNPC.scroll = false;
			AlchemistNPC.RevSet = false;
			AlchemistNPC.SF = false;
			AlchemistNPC.LaetitiaSet = false;
			AlchemistNPC.Extractor = false;
			AlchemistNPC.XtraT = false;
			ParadiseLost = false;
			Rampage = false;
			LilithEmblem = false;
			watchercrystal = false;
			grimreaper = false;
			rainbowdust = false;
			sscope = false;
			lwm = false;
			jr = false;
			Yui = false;
			
			player.statLifeMax2 += LifeElixir * 50;
			player.statManaMax2 += Fuaran * 100;
			
			if (KeepBuffs == 1)
			{
			AlchemistNPC.KeepBuffs = true;
			}
			if (KeepBuffs == 0)
			{
			AlchemistNPC.KeepBuffs = false;
			}
		}
	
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
		}
	
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.LifeAndManaSync);
			packet.Write((byte)player.whoAmI);
			packet.Write(LifeElixir);
			packet.Write(Fuaran);
			packet.Write(KeepBuffs);
			packet.Send(toWho, fromWho);
		}

        //SBMW:You may forget this(from Decompile)
        //SBMW:Sorry for unauthorized decomcompiling
        public override void OnEnterWorld(Player player)
        {
            string enterText = Language.GetTextValue("Mods.AlchemistNPC.enterText");
            Main.NewText(enterText, 0, byte.MaxValue, byte.MaxValue, false);
        }

        //SBMW:And this one
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (player.FindBuffIndex(mod.BuffType("Uganda")) > -1)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " DIDN NO DE WEI!");
            }
            return true;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
		{
		}
	
		public override TagCompound Save()
		{
			return new TagCompound {
				{"LifeElixir", LifeElixir},
				{"Fuaran", Fuaran},
				{"KeepBuffs", KeepBuffs},
			};
		}
	
		public override void Load(TagCompound tag)
		{
			LifeElixir = tag.GetInt("LifeElixir");
			Fuaran = tag.GetInt("Fuaran");
			KeepBuffs = tag.GetInt("KeepBuffs");
		}
	
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{	
			if (target.friendly == false)
			{
			if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.buffImmune[BuffID.Daybreak] = false;
				target.AddBuff(mod.BuffType("Corrosion"), 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.Daybreak, 600);
				}
			if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				}
			if (AlchemistNPC.scroll)
				{
				target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
				target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
				target.defense = 0;
				}
			if (player.FindBuffIndex(mod.BuffType("ExplorersBrew")) > -1)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
			
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (target.friendly == false)
			{
			if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.buffImmune[BuffID.Daybreak] = false;
				target.AddBuff(mod.BuffType("Corrosion"), 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.Daybreak, 600);
				}
			if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
				{
				target.buffImmune[BuffID.BetsysCurse] = false;
				target.buffImmune[BuffID.Ichor] = false;
				target.AddBuff(BuffID.Ichor, 600);
				target.AddBuff(BuffID.BetsysCurse, 600);
				}
			if (AlchemistNPC.scroll)
				{
				target.buffImmune[mod.BuffType("ArmorDestruction")] = false;
				target.AddBuff(mod.BuffType("ArmorDestruction"), 600);
				target.defense = 0;
				}
			if ((proj.type == ProjectileID.Electrosphere) && AlchemistNPC.XtraT)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			if (player.FindBuffIndex(mod.BuffType("ExplorersBrew")) > -1)
				{
				target.AddBuff(mod.BuffType("Electrocute"), 600);
				}
			}
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
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
		}

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (AlchemistNPC.MemersRiposte && crit)
            {
                damage *= 2;
            }
        }
		
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (AlchemistNPC.MemersRiposte && crit)
            {
                damage *= 2;
            }
		}
		
		public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) 		
        {
            if (AlchemistNPC.MemersRiposte)
            {
				for (int h = 0; h < 1; h++) 
					{
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
					}
			}
			if (player.FindBuffIndex(mod.BuffType("Judgement")) > -1)
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				if (damage < 150)
				damage = 1;
				}
        }
		
		public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) 	
        {
			if (AlchemistNPC.MemersRiposte)
            {
				for (int h = 0; h < 1; h++) 
					{
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("Returner"), damage*5, 0, player.whoAmI);
					}
			}
			if (player.FindBuffIndex(mod.BuffType("Judgement")) > -1)
				{
					if (Main.rand.Next(3) == 0)
					{
					damage = 2;
					}
				}
			if (ParadiseLost)
				{
				if (damage < 150)
				damage = 1;
				}
        }
	}
}