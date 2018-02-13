using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).lilithemblem == true && item.magic == true)
			{
			Projectile.NewProjectile(player.position.X+Main.rand.Next(-50,50), player.position.Y+Main.rand.Next(-50,50), speedX*1.1f, speedY, mod.ProjectileType("Bees"), damage/2, knockBack, player.whoAmI);
			Projectile.NewProjectile(player.position.X-Main.rand.Next(-50,50), player.position.Y+Main.rand.Next(-50,50), speedX*0.7f, speedY*0.8f, mod.ProjectileType("Bees"), damage/2, knockBack, player.whoAmI);
			Projectile.NewProjectile(player.position.X-Main.rand.Next(-50,50), player.position.Y+Main.rand.Next(-50,50), speedX*0.8f, speedY*1.1f, mod.ProjectileType("Bees"), damage/2, knockBack, player.whoAmI);
			Projectile.NewProjectile(player.position.X+Main.rand.Next(-50,50), player.position.Y-Main.rand.Next(-50,50), speedX*1.2f, speedY*0.7f, mod.ProjectileType("Bees"), damage/2, knockBack, player.whoAmI);
			Projectile.NewProjectile(player.position.X+Main.rand.Next(-50,50), player.position.Y-Main.rand.Next(-50,50), speedX, speedY*1.1f, mod.ProjectileType("Bees"), damage/2, knockBack, player.whoAmI);
			}
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
		
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(80) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SuspiciousLookingScythe"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(50) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PinkGuyHead"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyBody"));
				player.QuickSpawnItem(mod.ItemType("PinkGuyLegs"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(50) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Skyline222Hair"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Body"));
				player.QuickSpawnItem(mod.ItemType("Skyline222Legs"));
			}
			if (Main.hardMode && context == "bossBag" && Main.rand.Next(50) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("somebody0214Hood"));
				player.QuickSpawnItem(mod.ItemType("somebody0214Robe"));
			}
		}
	}
}
