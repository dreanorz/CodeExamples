using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Enemy
    {
        public int level { get; private set; }

        public int vitality { get; private set; }
        public int health { get; private set; }
        public int damage { get; private set; }
        public int effect { get; private set; }
        public int dur { get; private set; }

        public bool takeDamage(int dt)
        {
            health -= dt;

            if (effect == 1)
            {
                health -= (health / 5);
                dur--;
            }

            else if (effect == 2)
            {
                dur--;
            }

            else if (effect == 3)
            {
                health -= (vitality / 20);
                dur--;
            }

            else if (effect == 4)
            {
                dur--;
            }

            if (dur == 0)
                effect = 0;

            if (health <= 0)
                return false;

            else
                return true;
        }

        public bool takeDamage(int dmg, int ef)
        {
            if (ef == 1)
            {
                effect = ef;
                dur = 1;
            }

            else if (ef == 2)
            {
                effect = ef;
                dur = 4;
            }

            else if (ef == 3)
            {
                effect = ef;
                dur = 10;
            }

            else if (ef == 4)
            {
                effect = ef;
                dur = 1;
            }

            return takeDamage(dmg);
        }

        public Enemy generateEnemy(int pLevel)
        {
            Enemy enemy = new();

            Random rand = new();

            int randomlevel = rand.Next(0, 101);

            if (randomlevel >= 0 && randomlevel < 5)
                enemy.level = pLevel - 3;

            else if (randomlevel >= 5 && randomlevel < 15)
                enemy.level = pLevel - 2;

            else if (randomlevel >= 15 && randomlevel < 35)
                enemy.level = pLevel - 1;

            else if (randomlevel >= 35 && randomlevel < 65)
                enemy.level = pLevel;

            else if (randomlevel >= 65 && randomlevel < 85)
                enemy.level = pLevel + 1;

            else if (randomlevel >= 85 && randomlevel < 95)
                enemy.level = pLevel + 2;

            else if (randomlevel >= 95 && randomlevel <= 100)
                enemy.level = pLevel + 3;

            if (enemy.level < 1)
                enemy.level = 1;

            enemy.vitality = 6;
            enemy.vitality += enemy.level * 4;

            enemy.health = enemy.vitality;
            enemy.damage = enemy.level;

            int randomDmg = rand.Next(0, 101);

            if (randomDmg >= 0 && randomDmg < 25)
                enemy.damage -= 1;

            else if (randomDmg >= 75 && randomDmg <= 100)
                enemy.damage += 1;

            if (enemy.damage < 1)
                enemy.damage = 1;

            enemy.effect = 0;

            return enemy;
        }
    }
}