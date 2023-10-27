namespace ti4_calc
{
	public abstract class Unit
	{
		public bool IsActive { get; private set; } = true;
		public string Faction { get; private set; } = null;
		public bool Upgraded { get; private set; } = false;

		public double UnitCost { get; private set; }
		public int UnitMove { get; private set; }
		public int UnitCapacity { get; private set; } = 0;
		public int ReinforcementsPool { get; private set; }

		public int CombatToHit { get; private set; }
		public int CombatNumberOfDice { get; private set; }

		public bool CanSustainDamage { get; private set; }
		public bool SustainedDamage { get; private set; }

		public bool HasPlanetaryShield { get; private set; }
		public bool CanBypassPlanetaryShield { get; private set; }

		public string SpecialText { get; private set; }

		public string SpecialAttackType { get; private set; } = null;
		public int SpecialAttackToHit { get; private set; }
		public int SpecialAttackNumberOfDice { get; private set; }

		private string GetSpecialAttack()
		{
			return (SpecialAttackType != null
				? $"{SpecialAttackType}: {SpecialAttackToHit}(x{SpecialAttackNumberOfDice}), "
				: "");
		}

		private string GetOtherStats()
		{
			return
				(CanSustainDamage ? "Sustain Damage, " : "") +
				(HasPlanetaryShield ? "Planetary Shield, " : "") +
				(CanBypassPlanetaryShield ? "Bypasses Planetary Shield, " : "");
		}

		public string GetAllUnitStats()
		{
			return
				$"Cost: {UnitCost}, Combat: {CombatToHit}(x{CombatNumberOfDice}), Move: {UnitMove}, Capacity: {UnitCapacity}, " +
				GetSpecialAttack() +
				GetOtherStats() +
				$"Others: {Faction}, " + (Upgraded ? "Upgraded, " : "") + $"Reinforcements: {ReinforcementsPool}";
				// + $"SpecialText: {SpecialText}";
		}

		// For later, can some of this get stored elsewhere? UnitStats.cs or something?
		public void SetUnitBaseStats(string faction, bool upgraded, double unitCost, int reinforcementsPool)
		{
			Faction = faction;
			Upgraded = upgraded;
			UnitCost = unitCost;
			ReinforcementsPool = reinforcementsPool;
		}

		public void SetUnitMove(int unitMove) => UnitMove = unitMove;
		public void SetUnitCapacity(int unitCapacity) => UnitCapacity = unitCapacity;

		public void SetCombatToHit(int combatToHit) => CombatToHit = combatToHit;
		public void SetCombatNumberOfDice(int combatNumberOfDice) => CombatNumberOfDice = combatNumberOfDice;

		public void ActivateSustainDamage() => CanSustainDamage = true;
		
		public void ActivatePlanetaryShield() => HasPlanetaryShield = true;
		public void ActivateBypassPlanetaryShield() => CanBypassPlanetaryShield = true;

		public void SetSpecialText(string specialText) => SpecialText = specialText;
		public void AppendSpecialText(string specialText) => SpecialText += " " + specialText;

		public void SetSpecialAttackType(string specialAttackType) => SpecialAttackType = specialAttackType;
		public void SetSpecialAttackToHit(int specialAttackToHit) => SpecialAttackToHit = specialAttackToHit;
		public void SetSpecialAttackNumberOfDice(int specialAttackNumberOfDice) => SpecialAttackNumberOfDice = specialAttackNumberOfDice;

		public abstract Unit Clone(string faction, bool upgraded = false);

		// Methods?
		public void DamageUnit()
		{
			if (CanSustainDamage == true && SustainedDamage == false) SustainedDamage = true;
			else IsActive = false;
		}
		
		// HaveMoreInReinforcements()
			// UseSustainDamage()
			// ResetSustainDamage()
	}
}
