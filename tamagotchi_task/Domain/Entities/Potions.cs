﻿namespace tamagotchi_task.Domain.Entities
{
    public class Potions : DomainEntity
    {
        public string Image { get; set; }
        public int Buff_XP { get; set; }
        public PotionCharacter PoutionCharacter { get; set; }
        public Showcase Showcase { get; set; }
    }
}