using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
	public class JewelerHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jeweler Horcrux");
			Tooltip.SetDefault("The piece of Jeweler's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Ювелира");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Ювелира находится внутри");

            DisplayName.AddTranslation(GameCulture.Chinese, "珠宝师魂器");
            Tooltip.AddTranslation(GameCulture.Chinese, "里面有珠宝师的一片灵魂");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.maxStack = 30;
			item.value = 15000;
			item.rare = ItemRarityID.LightPurple;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
			item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Jeweler");
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(mod.NPCType("Jeweler")) && !Collision.SolidCollision(vector2, player.width, player.height));
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Jeweler is spawned.", 255, 255, 255);
		}
	}
}