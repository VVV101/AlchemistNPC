using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
            + "\nIn your journey, you are defeating an endless amounts of enemies..."
            + "\nBut you are not collecting their souls for yourself, right?"
            + "\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
            + "\nDoes that sound good enough? I hope so...");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
            DisplayName.AddTranslation(GameCulture.Russian, "Хвататель, Проклятый Принц");
            Description.AddTranslation(GameCulture.Russian, "Давай-ка заключим сделку!");
            DisplayName.AddTranslation(GameCulture.Chinese, "掠夺者, 被诅咒的王子");
            Description.AddTranslation(GameCulture.Chinese, "我们来做个交易吧!");
        }

        public override void ModifyBuffTip(ref string tipline, ref int rare)
        {
            string tip;
            string tipch;

            Player player = Main.player[Main.myPlayer];
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            tip = "Uh... You don't seem to have a soul. What a shame. OK then, let's make a deal..."
            + "\nIn your journey, you are defeating an endless amounts of enemies..."
            + "\nBut you are not collecting their souls for yourself, right?"
            + "\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
            + "\nDoes that sound good enough? I hope so..."
            + "\n" + modPlayer.SnatcherCounter + " souls collected.";
            tipch = "嗯... 看起来你还没有灵魂啊. 真可惜. 好吧,让我们来做个交易..."
            + "\n在旅途中,你会击败无数的敌人..."
            + "\n你不是在为自己收集他们的灵魂,对吧?"
            + "\n为什么不把它们给我呢? 每到达固定数量, 我会给你一些奖励."
            + "\n听起来不错, 是吧? 希望如此..."
            + "\n" + modPlayer.SnatcherCounter + "已收集的灵魂.";

            if (Language.ActiveCulture == GameCulture.Chinese)
            {
                tipline = tipch;
            }
            else
            {
                tipline = tip;
            }

            if (modPlayer.SnatcherCounter >= 500)
            {
                tip += "\nIncreases your movement speed by 25%";
                tipch += "\n增加25%移动速度";
            }
            if (modPlayer.SnatcherCounter >= 1000)
            {
                tip += "\nIncreases your defense by 10";
                tipch += "\n提升10防御力";
            }
            if (modPlayer.SnatcherCounter >= 1500)
            {
                tip += "\nIncreases your damage reduction by 10%";
                tipch += "\n增加10%伤害减免";
            }
            if (modPlayer.SnatcherCounter >= 2500)
            {
                tip += "\nIncreases max amount of minions/sentries by 1";
                tipch += "\n增加1召唤物和哨兵炮台数量";
            }
            if (modPlayer.SnatcherCounter >= 3500)
            {
                tip += "\nBoosts all damage types by 8%";
                tipch += "\n增加8%所有伤害";
            }
            if (modPlayer.SnatcherCounter >= 5000)
            {
                tip += "\nBoosts all critical strike chances by 5%";
                tipch += "\n增加5%所有暴击率";
            }
            if (modPlayer.SnatcherCounter >= 6666)
            {
                tip += "\nIncreases your armor penetration by 20";
                tipch += "\n提升20点护甲穿透";
            }
            if (modPlayer.SnatcherCounter >= 9999)
            {
                tip += "\nBoosts your max life by 10%";
                tipch += "\n增加10%生命上限";
            }
            if (modPlayer.SnatcherCounter >= 12500)
            {
                tip += "\nReflects 1000% damage taken back to its owner";
                tipch += "\n反弹10倍伤害";
            }
            if (modPlayer.SnatcherCounter >= 15000)
            {
                tip += "\nSupports you by attacking nearby enemies with shadow bursts\nDamage is calculated depending from current weapon in hands";
                tipch += "\n让你可以通过暗影爆发攻击附近的敌人\n伤害由当前手持武器决定";
            }

            if (Language.ActiveCulture == GameCulture.Chinese)
            {
                tipline = tipch;
            }
            else
            {
                tipline = tip;
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
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
            if (modPlayer.SnatcherCounter >= 2500)
            {
                player.maxMinions += 1;
                player.maxTurrets += 1;
            }
            if (modPlayer.SnatcherCounter >= 3500)
            {
                player.allDamage += 0.08f;
            }
            if (modPlayer.SnatcherCounter >= 5000)
            {
                player.meleeCrit += 5;
                player.rangedCrit += 5;
                player.magicCrit += 5;
                player.thrownCrit += 5;
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    ThoriumCBoosts(player);
                }
                if (ModLoader.GetMod("Redemption") != null)
                {
                    RedemptionCBoost(player);
                }
                Mod Calamity = ModLoader.GetMod("CalamityMod");
                if (Calamity != null)
                {
                    Calamity.Call("AddRogueCrit", player, 5);
                }
            }
            if (modPlayer.SnatcherCounter >= 6666)
            {
                player.armorPenetration += 20;
            }
            if (modPlayer.SnatcherCounter >= 9999)
            {
                player.statLifeMax2 += player.statLifeMax / 10;
            }
        }

        private void RedemptionCBoost(Player player)
        {
            Redemption.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 5;
        }

        private void ThoriumCBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 5;
            ThoriumPlayer.radiantCrit += 5;
        }
    }
}