using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Buffs
{
	public class Snatcher : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Snatcher, the Cursed Prince");
			Description.SetDefault("Uh... You don't seem to have a soul. What a shame. OK then, let's make a deal..."
			+"\nIn your journey, you are defeating an endless amounts of enemies..."
			+"\nBut you are not collecting their souls for yourself, right?"
			+"\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
			+"\nDoes that sound good enough? I hope so...");
            Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Хвататель, Проклятый Принц");
			Description.AddTranslation(GameCulture.Russian, "Давай-ка заключим сделку!");
		}

		public override void ModifyBuffTip (ref string tip, ref int rare)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			tip = "Uh... You don't seem to have a soul. What a shame. OK then, let's make a deal..."
			+"\nIn your journey, you are defeating an endless amounts of enemies..."
			+"\nBut you are not collecting their souls for yourself, right?"
			+"\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
			+"\nDoes that sound good enough? I hope so..."
			+"\n" + modPlayer.SnatcherCounter + " souls collected.";
			if (modPlayer.SnatcherCounter >= 500)
			{
				tip += "\nIncreases your movement speed by 25%";
			}
			if (modPlayer.SnatcherCounter >= 1000)
			{
				tip += "\nIncreases your defense by 10";
			}
			if (modPlayer.SnatcherCounter >= 1500)
			{
				tip += "\nIncreases your damage reduction by 10%";
			}
			if (modPlayer.SnatcherCounter >= 3000)
			{
				tip += "\nBoosts all damage types by 8%";
			}
			if (modPlayer.SnatcherCounter >= 5000)
			{
				tip += "\nBoosts all critical strike chances by 5%";
			}
			if (modPlayer.SnatcherCounter >= 6666)
			{
				tip += "\nBoosts your max life by 10%";
			}
			if (modPlayer.SnatcherCounter >= 9999)
			{
				tip += "\nIncreases your armor penetration by 25";
			}
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Snatcher")] > 0)
			{
				modPlayer.snatcher = true;
			}
			if (!modPlayer.snatcher)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("Snatcher")] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("Snatcher"), 0, 0f, player.whoAmI, 0f, 0f);
			}
			if (modPlayer.SnatcherCounter >= 500)
			{
				player.moveSpeed += 0.25f;
			}
			if (modPlayer.SnatcherCounter >= 1000)
			{
				player.statDefense += 10;
			}
			if (modPlayer.SnatcherCounter >= 1500)
			{
				player.endurance += 0.1f;
			}
			if (modPlayer.SnatcherCounter >= 3000)
			{
				player.thrownDamage += 0.08f;
				player.meleeDamage += 0.08f;
				player.rangedDamage += 0.08f;
				player.magicDamage += 0.08f;
				player.minionDamage += 0.08f;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					ThoriumDBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
					RedemptionDBoost(player);
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					CalamityDBoost(player);
				}
			}
			if (modPlayer.SnatcherCounter >= 5000)
			{
				player.meleeCrit += 10;
				player.rangedCrit += 10;
				player.magicCrit += 10;
				player.thrownCrit += 10;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
					ThoriumCBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
					RedemptionCBoost(player);
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
					CalamityCBoost(player);
				}
			}
			if (modPlayer.SnatcherCounter >= 6666)
			{
				player.statLifeMax2 += player.statLifeMax / 10;
			}
			if (modPlayer.SnatcherCounter >= 9999)
			{
				player.armorPenetration += 25;
			}
		}
		
		private void CalamityDBoost(Player player)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.08f;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionDBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.08f;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumDBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.08f;
			ThoriumPlayer.radiantBoost += 0.08f;
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
		
		private void CalamityCBoost(Player player)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
            CalamityPlayer.throwingCrit += 5;
        }
		
		private void RedemptionCBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
            RedemptionPlayer.druidCrit += 5;
        }
		
		private void ThoriumCBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicCrit += 5;
            ThoriumPlayer.radiantCrit += 5;
        }
	}
}