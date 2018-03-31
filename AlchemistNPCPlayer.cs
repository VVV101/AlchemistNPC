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
using AlchemistNPC;

namespace AlchemistNPC
{
	public class AlchemistNPCPlayer : ModPlayer
	{
		public bool ModPlayer = true;
		public bool lf = false;
		public int lamp = 0;
		public bool Rampage = false;
		public bool lilithemblem = false;
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
		
		public override void ResetEffects()
		{
			AlchemistNPC.scroll = false;
			AlchemistNPC.RevSet = false;
			AlchemistNPC.LE = false;
			AlchemistNPC.SF = false;
			AlchemistNPC.LaetitiaSet = false;
			AlchemistNPC.Extractor = false;
			Rampage = false;
			lilithemblem = false;
			watchercrystal = false;
			grimreaper = false;
			rainbowdust = false;
			sscope = false;
			lwm = false;
			jr = false;
			
			player.statLifeMax2 += LifeElixir * 50;
			player.statManaMax2 += Fuaran * 100;
		}
	
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
		}
	
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.LifeElixir);
			packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.Fuaran);
			packet.Write((byte)player.whoAmI);
			packet.Write(LifeElixir);
			packet.Write(Fuaran);
			packet.Send(toWho, fromWho);
		}
	
		public override TagCompound Save()
		{
			return new TagCompound {
				{"LifeElixir", LifeElixir},
				{"Fuaran", Fuaran},
			};
		}
	
		public override void Load(TagCompound tag)
		{
			LifeElixir = tag.GetInt("LifeElixir");
			Fuaran = tag.GetInt("Fuaran");
		}
	
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{	
		if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
			{
			target.AddBuff(mod.BuffType("Corrosion"), 600);
			target.AddBuff(BuffID.BetsysCurse, 600);
			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.Daybreak, 600);
			target.AddBuff(BuffID.ShadowFlame, 600);
			}
		if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
			{
			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.BetsysCurse, 600);
			}
		if (player.FindBuffIndex(mod.BuffType("BastScroll")) > -1)
			{
			target.defense -= 100;
			}
		}
			
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{	
		if (player.FindBuffIndex(mod.BuffType("RainbowFlaskBuff")) > -1)
			{
			target.AddBuff(mod.BuffType("Corrosion"), 600);
			target.AddBuff(BuffID.BetsysCurse, 600);
			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.Daybreak, 600);
			target.AddBuff(BuffID.ShadowFlame, 600);
			}
		if (player.FindBuffIndex(mod.BuffType("BigBirdLamp")) > -1)
			{
			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.BetsysCurse, 600);
			}
		if (player.FindBuffIndex(mod.BuffType("BastScroll")) > -1)
			{
			target.defense -= 100;
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
	}
}