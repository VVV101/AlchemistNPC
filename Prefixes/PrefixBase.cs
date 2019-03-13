using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.Items;

namespace AlchemistNPC.Prefixes
{
	public class AncientPrefix : ModPrefix
	{
		public override float RollChance(Item item)
		{
			return 0f;
		} 

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
		{
			return false;
		}

		// change your category this way, defaults to Custom
		public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
		
		public AncientPrefix()
		{
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Ancient", new AncientPrefix());
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult,
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult += 0.2f;
			critBonus += 10;
		}
		
		public override void Apply(Item item)
		{
		}

		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1.5f;
			valueMult *= multiplier;
		}
	}
	
	public class ArcanaPrefix : ModPrefix
	{
		public override float RollChance(Item item)
		{
			return 0f;
		} 

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
		{
			return false;
		}

		// change your category this way, defaults to Custom
		public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
		
		public ArcanaPrefix()
		{
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Arcana", new ArcanaPrefix());
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult,
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult += 0.2f;
			critBonus += 8;
			useTimeMult -= 0.1f;
			manaMult -= 0.2f;
		}
		
		public override void Apply(Item item)
		{
		}

		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1.5f;
			valueMult *= multiplier;
		}
	}
	
	public class DemiurgicPrefix : ModPrefix
	{
		public override float RollChance(Item item)
		{
			return 0f;
		} 

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
		{
			return false;
		}

		// change your category this way, defaults to Custom
		public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
		
		public DemiurgicPrefix()
		{
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Demiurgic", new DemiurgicPrefix());
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult,
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult += 0.22f;
			useTimeMult -= 0.1f;
			manaMult -= 0.2f;
		}
		
		public override void Apply(Item item)
		{
		}

		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1.5f;
			valueMult *= multiplier;
		}
	}
	
	public class ImmortalPrefix : ModPrefix
	{
		public override float RollChance(Item item)
		{
			return 0f;
		} 

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
		{
			return false;
		}

		// change your category this way, defaults to Custom
		public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
		
		public ImmortalPrefix()
		{
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Immortal", new ImmortalPrefix());
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult,
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult += 0.2f;
			critBonus += 8;
			shootSpeedMult += 0.1f;
			useTimeMult -= 0.1f;
		}
		
		public override void Apply(Item item)
		{
		}

		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1.5f;
			valueMult *= multiplier;
		}
	}
	
	public class PrimalPrefix : ModPrefix
	{
		public override float RollChance(Item item)
		{
			return 0f;
		} 

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
		{
			return false;
		}

		// change your category this way, defaults to Custom
		public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
		
		public PrimalPrefix()
		{
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Primal", new PrimalPrefix());
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult,
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult += 0.2f;
			critBonus += 8;
			useTimeMult -= 0.1f;
			scaleMult += 0.1f;
		}
		
		public override void Apply(Item item)
		{
		}

		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1.3f;
			valueMult *= multiplier;
		}
	}
}