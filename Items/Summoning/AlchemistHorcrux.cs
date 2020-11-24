using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
	public class AlchemistHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Horcrux");
			Tooltip.SetDefault("The piece of Alchemist's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Алхимика");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Алхимика находится внутри");

            DisplayName.AddTranslation(GameCulture.Chinese, "炼金师魂器");
            Tooltip.AddTranslation(GameCulture.Chinese, "里面有炼金师的一片灵魂");
        }

		public override void SetDefaults()
		{
			item.width = 46;
            item.height = 42;
            item.maxStack = 30;
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Alchemist");
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(mod.NPCType("Alchemist")) && !Collision.SolidCollision(vector2, player.width, player.height));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Alchemist is spawned.", 255, 255, 255);
		}
	}
}