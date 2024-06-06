﻿namespace Fire_Emblem {
    public class WillToWin : Skill {
        private int Bonus { get; set; }

        public WillToWin(string name, string description) : base(name, description) {
            Bonus = 8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {

            if (owner.CurrentHP <= owner.MaxHP * 0.5) {
                owner.AddTemporaryBonus("Atk", Bonus);
            }
        }
    }
}