using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Spell
    {
        public string name { get; private set; }
        public bool learned { get; private set; }
        bool mastered = false;
        int progress = 0;
        int complete;

        int damage;
        int effect;
        public int cost { get; private set; }

        public Spell generate(string nam, int eff)
        {
            Spell spell = new();

            spell.learned = false;
            spell.name = nam;
            spell.effect = eff;

            if (name == "Fireblast")
            {
                spell.complete = 2;
                spell.damage = 3;
                spell.cost = 3;
            }

            else if (name == "Fireball")
            {
                spell.complete = 4;
                spell.damage = 9;
                spell.cost = 7;
            }

            else if (name == "Magmaball")
            {
                spell.complete = 6;
                spell.damage = 24;
                spell.cost = 12;
            }

            else if (name == "Inferno")
            {
                spell.complete = 8;
                spell.damage = 48;
                spell.cost = 24;
            }

            return spell;
        }

        public void Progress()
        {
            if (progress != complete && progress < complete)
                progress++;

            if (progress == complete && !learned)
            {
                progress = 0;
                learned = true;
            }

            else if (progress == complete && learned)
            {
                mastered = true;
            }
        }

        public (int Sdamage, int Scost, int Seffect) Cast(int Cmana)
        {
            if (cost <= Cmana)
            {
                Progress();
                if (mastered)
                    return ((damage + 5), cost, effect);
                else
                    return (damage, cost, effect);
            }

            else
            {
                return (0, 0, 0);
            }
        }
    }
}