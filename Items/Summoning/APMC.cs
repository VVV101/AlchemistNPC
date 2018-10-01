using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Summoning
{
	public class APMC : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AI Programming and Memory Chip");
			Tooltip.SetDefault("It is Angela's backup.");
			DisplayName.AddTranslation(GameCulture.Russian, "Модуль данных ИИ");
			Tooltip.AddTranslation(GameCulture.Russian, "Это резервная копия Анджелы.");

            DisplayName.AddTranslation(GameCulture.Chinese, "AI程序与记忆芯片");
            Tooltip.AddTranslation(GameCulture.Chinese, "这是Angela的备份.");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.maxStack = 30;
			item.value = 15000;
			item.rare = 6;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Operator");
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Operator"));
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Operator is spawned.", 255, 255, 255);
		}
	}
}