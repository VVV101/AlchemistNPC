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

namespace AlchemistNPC
{
	public class AlchemistNPCPlayer : ModPlayer
	{
		public bool ModPlayer = true;
		public bool Rampage = false;
		public bool watchercrystal = false;
		public bool grimreaper = false;
		public bool rainbowdust = false;
		public bool sscope = false;
		public bool lwm = false;
		public bool jr = false;
		
		public override void ResetEffects()
		{
			Rampage = false;
			watchercrystal = false;
			grimreaper = false;
			rainbowdust = false;
			sscope = false;
			lwm = false;
			jr = false;
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
		}
	}
}