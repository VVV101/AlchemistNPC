using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class SecretNote2 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret Note #2");
			Tooltip.SetDefault("''Few times, I saw one pretty strange creature."
			+ "\nShe looked like Fairy, but at the same time..."
			+ "\nThere were something strange in her appearance."
			+ "\nShe was... way too perfect for an ordinary Fairy."
			+ "\nSadly, that was the last time I saw her..."
			+ "\nShe was beaten by unknown creature and transformed into a Crystal."
			+ "\nIt was nearby the places of Plantera.''"
			+ "\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Тайная записка 2");
            Tooltip.AddTranslation(GameCulture.Russian, "Несколько раз я видела одно довольно странное создание.\nОна выглядела как Фея, но в то же время...\nБыло что-то странное в её облике.\nОна выглядела... слишком совершенной для обычной Феи.\nК сожелению, это был последний раз, когда я её видела.\nЕё победило неизвестное существо и утащило с собой, превратив в Кристалл.\nЭто произошло неподалёку от мест обитания Плантеры.''\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 1000000;
			item.rare = 5;
		}	
	}
}