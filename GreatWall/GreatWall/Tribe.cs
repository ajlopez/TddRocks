namespace GreatWall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tribe
    {
        private int day;
        private int nattacks;
        private int west;
        private int east;
        private int strength;
        private int ddays;
        private int ddistance;
        private int dstrength;
        private int nday;

        public Tribe(int day, int nattacks, int west, int east, int strength, int ddays, int ddistance, int dstrength)
        {
            this.day = day;
            this.nattacks = nattacks;
            this.west = west;
            this.east = east;
            this.strength = strength;
            this.ddays = ddays;
            this.ddistance = ddistance;
            this.dstrength = dstrength;
        }

        public int Day { get { return this.day; } }

        public int Strength { get { return this.strength; } }

        public int West { get { return this.west; } }

        public int East { get { return this.east; } }

        public bool CanAttack()
        {
            return this.nday < this.nattacks;
        }

        public void NewDay()
        {
            this.nday++;
            this.day += this.ddays;
            this.west += this.ddistance;
            this.east += this.ddistance;
            this.strength += this.dstrength;
        }
    }
}
