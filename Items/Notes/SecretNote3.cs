using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class SecretNote3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret Note #3");
			Tooltip.SetDefault("''In one ancient scroll I found quite... unpleasant information."
			+ "\nIt said something about... Pink Guy? I have no idea who is this."
			+ "\nSo, if you find his armor and equip it as actual armor in fight against Moon Lord..."
			+ "\nYou may get something very unique."
			+ "\nBut you need to be very careful with that thing..."
			+ "\nIt can attract attention of a VERY dangerous creature.''"
			+ "\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Тайная записка 3");
            Tooltip.AddTranslation(GameCulture.Russian, "''В одном древнем свитке я обнаружила довольно... неприятную информацию.\nТам говорилось о... Розовом Парне? Понятия не имею, кто это.\nВ общем, если ты экипируешь сет его брони в качестве основной во время битвы с Лунным Лордом...\nТо ты можешь получить нечто уникальное.\nНо будь осторожен с этой вещью!\nОна может привлечь внимание ОЧЕНЬ опасного существа.''\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");
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