using System;
using System.IO;
using System.Collections.Generic;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            int exp = 0;
            int lvlup = 2;
            int vitality = 20;
            int maxHP = vitality;
            int health = maxHP;
            int strength = 2;
            int damage;
            int gold = 0;
            bool defeated;
            bool dead = false;

            int intelligence = 1;
            int Mmana = 10;
            int Cmana = Mmana;

            int weapon = 0;
            int armor = 0;
            int wpbought = 1;
            int arbought = 1;

            int armormult = 2;

            List<Spell> spells = new();

            bool learnedspells = false;

            string[] liners = File.ReadAllLines("data.txt");

            while (!dead)
            {
                //testing
                Spell spell = new Spell().generate("Fireblast", 1);

                spells.Add(spell);

                learnedspells = true;

                damage = strength + weapon;
                maxHP = vitality + (armor * armormult);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("What do you want to do today?");
                Console.WriteLine("Your current health is: " + health + "/" + maxHP);
                
                //if (!learnedspells)
                    Console.WriteLine("Your current mana is: " + Cmana + "/" + Mmana);

                Console.WriteLine("Your gold is: " + gold);
                Console.WriteLine("1. Explore the woods");
                Console.WriteLine("2. Go to town");
                Console.WriteLine("3. See your stats");
                Console.WriteLine("4. Sleep until tomorrow");
                Console.WriteLine("5. Exit the game");


                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.Clear();
                    
                    Random rand = new();

                    int result = rand.Next(101);
                    result = 10;
                    if (result < 10 && result >= 0)
                    {
                        Console.WriteLine(" ^   ^   ^   ^");
                        Console.WriteLine("/|\\ /|\\ /|\\ /|\\");
                        Console.WriteLine("/|\\ /|\\ /|\\ /|\\");
                        Console.WriteLine(" |   |   |   |\n");
                        Console.WriteLine("You found nothing of interest in the woods today.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }

                    else if (result >= 25 && result < 50)
                    {
                        int loot = rand.Next(2, 11);
                        Console.WriteLine("    _.---_");
                        Console.WriteLine("   `---..-'");
                        Console.WriteLine("    }====={");
                        Console.WriteLine("  .'       '.");
                        Console.WriteLine(" /::         \\");
                        Console.WriteLine("|::           |");
                        Console.WriteLine("\\::.          /");
                        Console.WriteLine(" '::_      _.'");
                        Console.WriteLine("     ``````\n");
                        Console.WriteLine("You've stumbled upon a small leather pouch of gold.");
                        Console.WriteLine("You gained " + loot + " pieces of gold!");

                        gold += loot;

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }

                    else if (result >= 50 && result < 60)
                    {
                        Console.WindowHeight += 6;
                        int healing = rand.Next(1, maxHP/2);
                        Console.WriteLine("                 __");
                        Console.WriteLine("               .'/\'.");
                        Console.WriteLine("             .'-/__\\-'.");
                        Console.WriteLine("           .'--/____\\--'.");
                        Console.WriteLine("         .'--./______\\.--'.");
                        Console.WriteLine("       .'--../________\\..--'.");
                        Console.WriteLine("     .'--.._/__________\\_..--'.");
                        Console.WriteLine("   .'--..__/____________\\__..--'.");
                        Console.WriteLine(" .'--..___/______________\\___..--'.");
                        Console.WriteLine("'========'================'========'");
                        Console.WriteLine("      [_|__]            [_|__]");
                        Console.WriteLine("     =[__|_]=====\"\"=====[__|_]==.");
                        Console.WriteLine("      [_|__]     '|     [_|__]  |");
                        Console.WriteLine("      [__|_]     |'     [__|_]  |");
                        Console.WriteLine("      [_|__]  .--JL--.  [_|__]  '===O");
                        Console.WriteLine("      [__|_]   \\====/   [__|_]");
                        Console.WriteLine("      [_|__]_.-| .; |-._[_|__]");
                        Console.WriteLine("      [__|_]'._ \\__/(_.'[__|_]");
                        Console.WriteLine("      [.-._]            [_.-.]");
                        Console.WriteLine("      [_.-.'--..____..--'.-._]");
                        Console.WriteLine("      [(_.'   .-.     .-.'._)\\");
                        Console.WriteLine("      [  .-. (_.'.-. (_.' .-.]");
                        Console.WriteLine("      [ (_.'.-. (_.' .-. (_.'|");
                        Console.WriteLine("      [ .-. '._) .-. '._).-. ]");
                        Console.WriteLine("      [(_.'  .-. '._) .-.'._)]");
                        Console.WriteLine("      /.-.  (_.'.-.  (_.' .-.]");
                        Console.WriteLine("      ['._).-. (_.'   .-.(_.']");
                        Console.WriteLine("      [   (_.'.-.  .-.'._)   \\");
                        Console.WriteLine("      '-._    '._) '._)   _.-'");
                        Console.WriteLine("          `---..____..---'\n");
                        Console.WriteLine("You've found a well. You take a sip and feel refreshed");
                        Console.WriteLine("You've healed for " + healing + " points of health!");

                        health += healing;

                        if (health >= maxHP)
                        {
                            health = maxHP;
                        }

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.WindowHeight -= 6;
                    }

                    else
                    {
                        defeated = false;
                        Enemy enemy = new Enemy().generateEnemy(level);
                        while (!defeated)
                        {
                            Console.Clear();
                            Console.WriteLine("You've encoutered an enemy, what action do you wish to perform?");
                            Console.WriteLine("1. Attack the enemy");
                            Console.WriteLine("2. Inspect the enemy");
                            Console.WriteLine("3. Run away");

                            answer = Console.ReadLine();

                            if (answer == "1")
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You've decided to attack the creature!");
                                    Console.WriteLine("1. Attack with your weapon");
                                    if (learnedspells)
                                    {
                                        Console.WriteLine("2. Cast one of your spells");
                                        Console.WriteLine("3. Flee from the creature");
                                    }

                                    else
                                    {
                                        Console.WriteLine("2. Flee from the creature");
                                    }

                                    answer = Console.ReadLine();

                                    if (answer == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You attack the creature dealing " + damage + " points of damage.");

                                        if (enemy.takeDamage(damage))
                                        {
                                            if (enemy.effect == 2)
                                            {
                                                result = rand.Next(101);

                                                if (result >= 0 && result < 50)
                                                {
                                                    Console.WriteLine("The creature tries to attack but are unable to move due to being paralyzed.");
                                                }

                                                else
                                                {
                                                    Console.WriteLine("\nThe creature deals " + enemy.damage + " damage to you.");
                                                    health -= enemy.damage;
                                                }
                                            }

                                            else if (enemy.effect == 4)
                                            {
                                                Console.WriteLine("The creates tries to attack but it's feet/paws are frozen to the ground so they're unable to attack.");
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nThe creature deals " + enemy.damage + " damage to you.");
                                                health -= enemy.damage;
                                            }

                                            if (health <= 0)
                                            {
                                                dead = true;
                                                defeated = true;
                                                break;
                                            }

                                            Console.WriteLine("You have " + health + " remaining hit points.");
                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey();
                                        }

                                        else
                                        {
                                            int loot = rand.Next(enemy.level, enemy.level * 3);

                                            Console.WriteLine("You've slain the creature and gained " + enemy.level + " points of experience!");
                                            Console.WriteLine("You also find " + loot + " pieces of gold on the creature!");

                                            exp += enemy.level;
                                            gold += loot;

                                            if (exp >= lvlup)
                                            {
                                                exp -= lvlup;
                                                lvlup = lvlup * 2;
                                                level++;
                                                strength++;
                                                intelligence++;
                                                vitality += rand.Next(1, 6);
                                                maxHP = vitality + (armor * armormult);
                                                health = maxHP;
                                                Mmana += rand.Next(1, 6);
                                                Cmana = Mmana;
                                            }

                                            defeated = true;

                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }

                                    else if ((answer == "2" && !learnedspells) || (answer == "3" && learnedspells))
                                    {
                                        Console.Clear();
                                        if (rand.Next(101) > enemy.level * 10)
                                        {
                                            Console.WriteLine("You successfully ran away from the creature!");
                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey();
                                            defeated = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You did not manage to flee from the creature.");
                                            Console.WriteLine("The battle continues\n\n");

                                            Console.WriteLine("The creature deals " + enemy.damage + " damage to you.");
                                            health -= enemy.damage;

                                            if (health <= 0)
                                            {
                                                dead = true;
                                                defeated = true;
                                                break;
                                            }

                                            Console.WriteLine("You have " + health + " remaining hit points.");

                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey();
                                        }
                                    }

                                    else if (answer == "2" && learnedspells)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You've decided to cast a spell!");
                                        Console.WriteLine("Your mana is currently at " + Cmana + "/" + Mmana);
                                        Console.WriteLine("Which spell do you which to cast?");
                                        for (int i = 0; i < spells.Count; i++)
                                        {
                                            Console.WriteLine((i + 1) + ". " + spells[i].name + ", this spell will cost you " + spells[i].cost + " points of mana.");
                                        }
                                        Console.WriteLine((spells.Count + 1) + ". You don't want to cast any spells.");

                                        answer = Console.ReadLine();

                                        if (Int32.Parse(answer) <= spells.Count && Int32.Parse(answer) > 0)
                                        {
                                            Spell Cspell = spells[(Int32.Parse(answer) - 1)];
                                            (int dmg, int co, int ef) = Cspell.Cast(Cmana);
                                            if (dmg == 0 && co == 0 && ef == 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You do not have the required amount of mana for this spell.");
                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey();
                                            }

                                            else
                                            {
                                                Cmana -= co;
                                                int ed = 0;

                                                if (ef == 1)
                                                {
                                                    ed = (enemy.health / 5);
                                                }

                                                else if (ef == 3)
                                                {
                                                    ed = (enemy.vitality / 20);
                                                }

                                                Console.Clear();
                                                if (enemy.takeDamage(dmg, ef))
                                                {
                                                    Console.WriteLine("Your spell deals " + dmg + " points of damage to the creature.");
                                                    
                                                    if (ef == 1)
                                                    {
                                                        Console.WriteLine("The creature is set on fire and takes an additional " + ed + " points of damage before extinguishing the flames.");
                                                    }

                                                    else if (ef == 3)
                                                    {
                                                        Console.WriteLine("The creature whrithes from the poison your spell has affected it with dealing + " + ed + " points of damage.");
                                                    }

                                                    Console.WriteLine("\nThe creature deals " + enemy.damage + " damage to you.");
                                                    health -= enemy.damage;
                                                    Console.WriteLine("You have " + health + " remaining hit points.");
                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey();
                                                }

                                                else
                                                {
                                                    int loot = rand.Next(enemy.level, enemy.level * 3);

                                                    Console.WriteLine("You've slain the creature and gained " + enemy.level + " points of experience!");
                                                    Console.WriteLine("You also find " + loot + " pieces of gold on the creature!");

                                                    exp += enemy.level;
                                                    gold += loot;

                                                    if (exp >= lvlup)
                                                    {
                                                        exp -= lvlup;
                                                        lvlup = lvlup * 2;
                                                        level++;
                                                        strength++;
                                                        intelligence++;
                                                        vitality += rand.Next(1, 6);
                                                        maxHP = vitality + (armor * armormult);
                                                        health = maxHP;
                                                        Mmana += rand.Next(1, 6);
                                                        Cmana = Mmana;
                                                    }

                                                    defeated = true;

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                        }

                                        else if (Int32.Parse(answer) == (spells.Count + 1))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You decide that you don't want to cast any spell after all.");
                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey();
                                        }

                                        else
                                        {
                                            
                                        }
                                    }

                                    else
                                    {

                                    }
                                }
                            }

                            else if (answer == "2")
                            {
                                Console.Clear();
                                Console.WriteLine("You carefully inspect the creature from a distance and learn the following:");

                                if (enemy.level == level)
                                {
                                    Console.WriteLine("This creature seems to be a fair fight.");
                                }

                                else if (enemy.level < level)
                                {
                                    Console.WriteLine("This creature seems to be an easy fight.");
                                }

                                else
                                {
                                    Console.WriteLine("This creature seems to be a tough fight.");
                                }

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                            }

                            else if (answer == "3")
                            {
                                Console.Clear();
                                Console.WriteLine("You successfully ran away from the creature!");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }

                            else
                            {

                            }
                        }
                    }
                }

                else if (answer == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Where do you want to go?");
                        Console.WriteLine("1. Blacksmith's workshop");
                        Console.WriteLine("2. Priest's hut");
                        Console.WriteLine("3. The singing leprechaun Inn");
                        Console.WriteLine("4. The mage tower");
                        Console.WriteLine("5. Back to your house");

                        answer = Console.ReadLine();

                        if (answer == "1")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("What would you like to have forged today?");
                                Console.WriteLine("Your current gold is: " + gold);
                                Console.WriteLine("1. Upgrade weapon, this will cost " + 10 * wpbought + " gold");
                                Console.WriteLine("2. Upgrade armor, this will cost " + 10 * arbought + " gold");
                                Console.WriteLine("3. Leave the workshop");

                                answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    Console.Clear();
                                    if (gold >= wpbought * 10)
                                    {
                                        gold -= wpbought * 10;

                                        wpbought++;
                                        weapon++;

                                        Console.WriteLine("You've upgraded you're weapon to level " + (wpbought - 1) + ".");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You lack the required gold to upgrade your weapon.");
                                        Console.WriteLine("Try to explore the woods to find some gold.");
                                    }
                                }

                                else if (answer == "2")
                                {
                                    Console.Clear();
                                    if (gold >= arbought * 10)
                                    {
                                        gold -= arbought * 10;

                                        arbought++;
                                        armor++;

                                        health += armormult;

                                        Console.WriteLine("You've upgraded you're armor to level " + (arbought - 1) + ".");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You lack the required gold to upgrade your armor.");
                                        Console.WriteLine("Try to explore the woods to find some gold.");
                                    }
                                }

                                else if (answer == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You didn't feel like buying any services today so you left.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                else
                                {

                                }

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                            }
                        }

                        else if (answer == "2")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Do you wish to be healed?");
                                Console.WriteLine("Your gold is: " + gold);
                                Console.WriteLine("1. Heal, this will cost 20 gold");
                                Console.WriteLine("2. Leave the hut");

                                answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    Console.Clear();
                                    if (gold > 20)
                                    {
                                        gold -= 20;
                                        health = maxHP;

                                        Console.WriteLine("You've been healed to full.");
                                    }

                                    else
                                    {
                                        Console.WriteLine("You lack the required gold for the healing.");
                                        Console.WriteLine("Try to explore the woods to find some gold.");
                                    }
                                }

                                else if (answer == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You decide that you don't need any healing this time.");
                                    break;
                                }

                                else
                                {

                                }

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                            }
                        }

                        else if (answer == "3")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Welcome to the Inn, what will it be today?");
                                Console.WriteLine("1. Give me some tips");
                                Console.WriteLine("2. Ask around for any news");
                                Console.WriteLine("3. Leave the Inn");

                                answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    Random rand = new();
                                    Console.Clear();
                                    Console.WriteLine("\"" + liners[rand.Next(liners.Length)] + "\"");
                                    Console.WriteLine("\nYou bask in the wisdom of this tip.");
                                }

                                else if (answer == "2")
                                {

                                }

                                else if (answer == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You decide that you've had enough of the festivties in the Inn for today.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                else
                                {

                                }

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                            }
                        }

                        else if (answer == "4")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Welcome to the mage tower, what piques your interest today?");
                                Console.WriteLine("1. Read up on magical spells");
                                Console.WriteLine("2. Leave the tower");

                                answer = Console.ReadLine();

                                if (answer == "1")
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("What kind of tome would you like to read?");
                                        Console.WriteLine("1. Introductory course to thermodynamics");
                                        Console.WriteLine("2. Yellow streaks from the air, what are those?");
                                        Console.WriteLine("3. Flora and fauna but without the fauna");
                                        Console.WriteLine("4. The three different types of matter: not wet, wet, wet air");
                                        Console.WriteLine("5. Elements and their effects");
                                        Console.WriteLine("6. You change your mind and does not want to read today.");

                                        answer = Console.ReadLine();

                                        if (answer == "1")
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("You've chosen to study the practice of ");
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Fire");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spells.");

                                                Console.Write("\nWhich ");
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Fire");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spell do you which to study today?\n");

                                                Console.WriteLine("1. Fireblast, a good place to start");
                                                Console.WriteLine("2. Fireball, a bigger and better Fireblast");
                                                Console.WriteLine("3. Magmaball, Fireball but with magma");
                                                Console.WriteLine("4. Inferno, Let's just say that your enemies will not be freezing after this");
                                                Console.WriteLine("5. You don't want to heat people up from the outside");

                                                answer = Console.ReadLine();

                                                string spellname = "";

                                                if (answer == "1")
                                                {
                                                    spellname = "Fireblast";
                                                }

                                                else if (answer == "2")
                                                {
                                                    spellname = "Fireball";
                                                }

                                                else if (answer == "3")
                                                {
                                                    spellname = "Magmaball";
                                                }

                                                else if (answer == "4")
                                                {
                                                    spellname = "Inferno";
                                                }

                                                if (answer == "1" || answer == "2" || answer == "3" || answer == "4")
                                                {
                                                    if (spells.Count > 1)
                                                    {
                                                        foreach (Spell _ in spells)
                                                        {
                                                            if (_.name == spellname)
                                                            {
                                                                Console.Clear();
                                                                if (_.learned)
                                                                {
                                                                    Console.WriteLine("You've already learned the " + spellname + " spell.");
                                                                    Console.WriteLine("You should try and learn some other spell.");
                                                                }

                                                                else
                                                                {
                                                                    _.Progress();

                                                                    if (_.learned)
                                                                    {
                                                                        Console.WriteLine("Congratulations! You've learned the " + spellname + " spell and are now able to use it.");
                                                                        learnedspells = true;
                                                                    }

                                                                    else
                                                                    {
                                                                        Console.WriteLine("Your understanding of the " + spellname + " spell has been incrased.");
                                                                    }

                                                                    Console.WriteLine("\nPress any key to continue...");
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        spell = new Spell().generate(spellname, 1);

                                                        spells.Add(spell);
                                                    }
                                                }

                                                else if (answer == "5")
                                                {
                                                    break;
                                                }

                                                else
                                                {

                                                }
                                            }
                                        }

                                        else if (answer == "2")
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("You've chosen to study the practice of ");
                                                Console.BackgroundColor = ConsoleColor.Yellow;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Lightning");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spells.");

                                                Console.Write("\nWhich ");
                                                Console.BackgroundColor = ConsoleColor.Yellow;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Lightning");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spell do you which to study today?\n");

                                                Console.WriteLine("1. Fizzle, a little bit bigger of a zap than static electricity but not a lot");
                                                Console.WriteLine("2. Spark, ");
                                                Console.WriteLine("3. Lightning ball, ");
                                                Console.WriteLine("4. Thunder, ");
                                                Console.WriteLine("5. ");

                                                answer = Console.ReadLine();

                                                string spellname = "";

                                                if (answer == "1")
                                                {
                                                    spellname = "Fizzle";
                                                }

                                                else if (answer == "2")
                                                {
                                                    spellname = "Spark";
                                                }

                                                else if (answer == "3")
                                                {
                                                    spellname = "Lightning ball";
                                                }

                                                else if (answer == "4")
                                                {
                                                    spellname = "Thunder";
                                                }

                                                if (answer == "1" || answer == "2" || answer == "3" || answer == "4")
                                                {
                                                    if (spells.Count > 1)
                                                    {
                                                        foreach (Spell _ in spells)
                                                        {
                                                            if (_.name == spellname)
                                                            {
                                                                Console.Clear();
                                                                if (_.learned)
                                                                {
                                                                    Console.WriteLine("You've already learned the " + spellname + " spell.");
                                                                    Console.WriteLine("You should try and learn some other spell.");
                                                                }

                                                                else
                                                                {
                                                                    _.Progress();

                                                                    if (_.learned)
                                                                    {
                                                                        Console.WriteLine("Congratulations! You've learned the " + spellname + " spell and are now able to use it.");
                                                                        learnedspells = true;
                                                                    }

                                                                    else
                                                                    {
                                                                        Console.WriteLine("Your understanding of the " + spellname + " spell has been incrased.");
                                                                    }

                                                                    Console.WriteLine("\nPress any key to continue...");
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        spell = new Spell().generate(spellname, 2);

                                                        spells.Add(spell);
                                                    }
                                                }

                                                else if (answer == "5")
                                                {
                                                    break;
                                                }

                                                else
                                                {

                                                }
                                            }
                                        }

                                        else if (answer == "3")
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("You've chosen to study the practice of ");
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Nature");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spells.");

                                                Console.Write("\nWhich ");
                                                Console.BackgroundColor = ConsoleColor.Green;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Nature");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spell do you which to study today?\n");

                                                Console.WriteLine("1. Healing salve, ");
                                                Console.WriteLine("2. Poison dart, ");
                                                Console.WriteLine("3. Poison lance, ");
                                                Console.WriteLine("4. Contagion, ");
                                                Console.WriteLine("5. ");

                                                answer = Console.ReadLine();

                                                string spellname = "";

                                                if (answer == "1")
                                                {
                                                    spellname = "Healing salve";
                                                }

                                                else if (answer == "2")
                                                {
                                                    spellname = "Poison dart";
                                                }

                                                else if (answer == "3")
                                                {
                                                    spellname = "Poison lance";
                                                }

                                                else if (answer == "4")
                                                {
                                                    spellname = "Contagion";
                                                }

                                                if (answer == "1" || answer == "2" || answer == "3" || answer == "4")
                                                {
                                                    if (spells.Count > 1)
                                                    {
                                                        foreach (Spell _ in spells)
                                                        {
                                                            if (_.name == spellname)
                                                            {
                                                                Console.Clear();
                                                                if (_.learned)
                                                                {
                                                                    Console.WriteLine("You've already learned the " + spellname + " spell.");
                                                                    Console.WriteLine("You should try and learn some other spell.");
                                                                }

                                                                else
                                                                {
                                                                    _.Progress();

                                                                    if (_.learned)
                                                                    {
                                                                        Console.WriteLine("Congratulations! You've learned the " + spellname + " spell and are now able to use it.");
                                                                        learnedspells = true;
                                                                    }

                                                                    else
                                                                    {
                                                                        Console.WriteLine("Your understanding of the " + spellname + " spell has been incrased.");
                                                                    }

                                                                    Console.WriteLine("\nPress any key to continue...");
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        if (spellname == "Healing salve")
                                                            spell = new Spell().generate(spellname, 0);

                                                        else
                                                            spell = new Spell().generate(spellname, 3);

                                                        spells.Add(spell);
                                                    }
                                                }

                                                else if (answer == "5")
                                                {
                                                    break;
                                                }

                                                else
                                                {

                                                }
                                            }
                                        }

                                        else if (answer == "4")
                                        {
                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.Write("You've chosen to study the practice of ");
                                                Console.BackgroundColor = ConsoleColor.Blue;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Water");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spells.");

                                                Console.Write("\nWhich ");
                                                Console.BackgroundColor = ConsoleColor.Blue;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("Water");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(" spell do you which to study today?\n");

                                                Console.WriteLine("1. Rejuvenating water, ");
                                                Console.WriteLine("2. Ice ball, ");
                                                Console.WriteLine("3. Ice spike, ");
                                                Console.WriteLine("4. Tsunami, ");
                                                Console.WriteLine("5. You don't want to heat people up from the outside");

                                                answer = Console.ReadLine();

                                                string spellname = "";

                                                if (answer == "1")
                                                {
                                                    spellname = "Rejuvenating water";
                                                }

                                                else if (answer == "2")
                                                {
                                                    spellname = "Ice ball";
                                                }

                                                else if (answer == "3")
                                                {
                                                    spellname = "Ice spike";
                                                }

                                                else if (answer == "4")
                                                {
                                                    spellname = "Tsunami";
                                                }

                                                if (answer == "1" || answer == "2" || answer == "3" || answer == "4")
                                                {
                                                    if (spells.Count > 1)
                                                    {
                                                        foreach (Spell _ in spells)
                                                        {
                                                            if (_.name == spellname)
                                                            {
                                                                Console.Clear();
                                                                if (_.learned)
                                                                {
                                                                    Console.WriteLine("You've already learned the " + spellname + " spell.");
                                                                    Console.WriteLine("You should try and learn some other spell.");
                                                                }

                                                                else
                                                                {
                                                                    _.Progress();

                                                                    if (_.learned)
                                                                    {
                                                                        Console.WriteLine("Congratulations! You've learned the " + spellname + " spell and are now able to use it.");
                                                                        learnedspells = true;
                                                                    }

                                                                    else
                                                                    {
                                                                        Console.WriteLine("Your understanding of the " + spellname + " spell has been incrased.");
                                                                    }

                                                                    Console.WriteLine("\nPress any key to continue...");
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        if (spellname == "Rejuvenating water")
                                                            spell = new Spell().generate(spellname, 0);
                                                        
                                                        else
                                                            spell = new Spell().generate(spellname, 4);

                                                        spells.Add(spell);
                                                    }
                                                }

                                                else if (answer == "5")
                                                {
                                                    break;
                                                }

                                                else
                                                {

                                                }
                                            }
                                        }

                                        else if (answer == "5")
                                        {
                                            Console.Clear();

                                        }

                                        else if (answer == "6")
                                        {
                                            break;
                                        }

                                        else
                                        {

                                        }
                                    }
                                }

                                else if (answer == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("You go back to the town square.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                else
                                {

                                }
                            }
                        }

                        else if (answer == "5")
                        {
                            Console.Clear();
                            Console.WriteLine("You decide that it is time to head home.");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }

                        else
                        {

                        }
                    }
                }

                else if (answer == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Your current level is: " + level);
                    Console.WriteLine("Your current experience points are: " + exp);
                    Console.WriteLine("Experience needed for next level: " + lvlup);
                    Console.WriteLine();
                    Console.WriteLine("Your vitality is: " + vitality);
                    Console.WriteLine("Your strength is: " + strength);
                    Console.WriteLine("Your maximum health is: " + maxHP);
                    Console.WriteLine("Your current health is: " + health);
                    Console.WriteLine("Your current damage is: " + damage);
                    Console.WriteLine();
                    Console.WriteLine("Your gold is: " + gold);
                    Console.WriteLine("Your weapon damage increase is: " + weapon);
                    Console.WriteLine("Your armor health increase is: " + armor);

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (answer == "4")
                {
                    Random rand = new();
                    int healing = rand.Next(1, maxHP / 3);
                    Console.Clear();
                    Console.WriteLine("You slept through the whole day and recovered " + healing + " amounts of hit points.");

                    if (learnedspells)
                    {
                        int manag = rand.Next(1, Mmana / 3);
                        Cmana += manag;

                        if (Cmana > Mmana)
                            Cmana = Mmana;

                        Console.WriteLine("You also regain " + manag + " points of mana.");
                    }

                    health += healing;

                    if (health > maxHP)
                    {
                        health = maxHP;
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (answer == "5")
                {
                    Environment.Exit(0);
                }

                else
                {

                }
            }

            Console.WriteLine("\nYou've sadly died. The game is now over but you can always play again.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}