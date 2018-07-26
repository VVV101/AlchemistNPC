using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AlchemistNPC.Projectiles;
using System.IO;
using AlchemistNPC;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Projectiles
{
   public class AlchemistGlobalProjectile : GlobalProjectile
   {
		public bool firstTime = true;

		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public override void SetDefaults(Projectile projectile)
		{
			if (AlchemistNPC.BastScroll == true && projectile.thrown == true)
			{
				projectile.tileCollide = false;
			}
		}

		public void createBee(Projectile projectile) {
			Player player = Main.player[projectile.owner]; 
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 5f;
			Projectile.NewProjectile(
				player.position.X,
				player.position.Y,
				vel.X,
				vel.Y,
				mod.ProjectileType("Bees"),
				projectile.damage/2,
				0,
				projectile.owner
			);
		}
		
		public void createNAG(Projectile projectile) {
			Projectile.NewProjectile(
				projectile.Center.X,
				projectile.Center.Y,
				projectile.velocity.X,
				projectile.velocity.Y,
				mod.ProjectileType("NyctosythiaArrowGhost"),
				projectile.damage,
				0,
				Main.myPlayer
			);			
		}
		
		public void createNBG(Projectile projectile) {
			Projectile.NewProjectile(
				projectile.Center.X,
				projectile.Center.Y,
				projectile.velocity.X,
				projectile.velocity.Y,
				mod.ProjectileType("NyctosythiaBulletGhost"),
				projectile.damage,
				0,
				Main.myPlayer
			);			
		}
		
		public override void AI(Projectile projectile)
		{
			Player player = Main.player[projectile.owner];
			if (firstTime && !projectile.hostile && projectile.magic && (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem == true) && projectile.type != mod.ProjectileType("Bees"))
			{
				for (int g = 0; g < 2; g++)
				{
					createBee(projectile);
				}
				firstTime = false;
			}
			
			if (firstTime && !projectile.hostile && projectile.type == mod.ProjectileType("NyctosythiaArrow"))
			{
				createNAG(projectile);
				firstTime = false;
			}
			
			if (firstTime && !projectile.hostile && projectile.type == mod.ProjectileType("NyctosythiaBullet"))
			{
				createNBG(projectile);
				firstTime = false;
			}
			
			if (projectile.type == mod.ProjectileType("DTH"))
			{
				if (Main.rand.Next(45) == 0)
					{
						for (int g = 0; g < 3; g++)
						{
						Vector2 vel = new Vector2(0, -1);
						float rand = Main.rand.NextFloat() * 6.283f;
						vel = vel.RotatedBy(rand);
						vel *= 3f;
						Projectile.NewProjectile(
						projectile.Center.X,
						projectile.Center.Y,
						vel.X,
						vel.Y,
						mod.ProjectileType("DTHL"),
						projectile.damage,
						0,
						Main.myPlayer
						);	
					}
				}
			}
		}
		
		
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if (projectile.minion && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).SF == true)
			{
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 443) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).XtraT == true)
			{
				target.AddBuff(mod.BuffType("Electrocute"), 300);
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 98) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 184) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 185) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 3;
			}
			if ((projectile.type == 186) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 20;
				}
				else{
				projectile.damage += 10;	
				}
				target.immune[projectile.owner] = 1;
			}
			if ((projectile.type == 187) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 188) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 2;
			}
			if ((projectile.type == 654) && ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Traps == true)
			{
				if (Main.expertMode){
				projectile.damage += 40;
				}
				else{
				projectile.damage += 20;	
				}
				target.immune[projectile.owner] = 2;
			}
		}
	}
}