namespace ti4_calc
{
	internal class Unit
	{
		// Default: Cruiser I
		public bool IsActive { get; private set; } = true;
		public string Faction { get; private set; } = null;
		public bool Upgraded { get; private set; } = false;

		public double UnitCost { get; private set; } = 2;
		public int UnitMove { get; private set; } = 2;
		public int UnitCapacity { get; private set; } = 0;
		public int ReinforcementsPool { get; private set; } = 8;

		public int CombatToHit { get; private set; } = 7;
		public int CombatNumberOfDice { get; private set; } = 1;

		public bool CanSustainDamage { get; private set; } = false;
		public bool HasSustainedDamage { get; private set; } = false;

		public string SpecialText { get; private set; } = null;

		public string SpecialAttackType { get; private set; } = null;
		public int SpecialAttackToHit { get; private set; } = 0;
		public int SpecialAttackNumberOfDice { get; private set; } = 0;

		public string GetAllUnitStats()
		{
			return
				$"UnitMove: {UnitMove}, " +
				$"UnitCapacity: {UnitCapacity}, " +
				$"CombatToHit: {CombatToHit}, " +
				$"CombatNumberOfDice: {CombatNumberOfDice}, " +
				$"CanSustainDamage: {CanSustainDamage}, " +
				$"SpecialText: {SpecialText}, " +
				$"SpecialAttackType: {SpecialAttackType}, " +
				$"SpecialAttackToHit: {SpecialAttackToHit}, " +
				$"SpecialAttackNumberOfDice: {SpecialAttackNumberOfDice}";
		}
			

		// For later, can some of this get stored elsewhere? UnitStats.cs or something?
		public void SetUnitBaseStats(double unitCost, int reinforcementsPool)
		{
			UnitCost = unitCost;
			ReinforcementsPool = reinforcementsPool;
		}

		public void SetUnitMove(int unitMove) => UnitMove = unitMove;
		public void SetUnitCapacity(int unitCapacity) => UnitCapacity = unitCapacity;

		public void SetCombatToHit(int combatToHit) => CombatToHit = combatToHit;
		public void SetCombatNumberOfDice(int combatNumberOfDice) => CombatNumberOfDice = combatNumberOfDice;

		public void ActivateSustainDamage() => CanSustainDamage = true;

		public void SetSpecialText(string specialText) => SpecialText = specialText;
		public void AppendSpecialText(string specialText) => SpecialText += "; " + specialText;

		public void SetSpecialAttackType(string specialAttackType) => SpecialAttackType = specialAttackType;
		public void SetSpecialAttackToHit(int specialAttackToHit) => SpecialAttackToHit = specialAttackToHit;
		public void SetSpecialAttackNumberOfDice(int specialAttackNumberOfDice) => SpecialAttackNumberOfDice = specialAttackNumberOfDice;

		// Methods?
		public void DamageUnit()
		{
			if (CanSustainDamage == true && HasSustainedDamage == false) {
				HasSustainedDamage = true;
			} else {
				IsActive = false;
			}
		}
		
		// HaveMoreInReinforcements()
			// UseSustainDamage()
			// ResetSustainDamage()
	}
}
