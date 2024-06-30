﻿namespace Fire_Emblem {
    public class BrazenAtkRes : Skill {
        private int Bonus { get; set; }
        private double Threshold { get; set; }
        public BrazenAtkRes(string name, string description) : base(name, description) {
            Bonus = 10;
            Threshold = 0.8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            if (owner.CurrentHP <= owner.MaxHP * Threshold) {
                owner.AddTemporaryBonus("Atk", Bonus);
                owner.AddTemporaryBonus("Res", Bonus);
            }
        }
    }
}