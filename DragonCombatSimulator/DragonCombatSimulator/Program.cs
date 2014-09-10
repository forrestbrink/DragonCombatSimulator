using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 110;
            DragonCombatSimulator();
            Console.ReadKey();
        }

        static void DragonCombatSimulator()
        {
            //set hp equal to 100 for user
            int userHP = 100;
            //set hp equal to 200 for dragon
            int dragonHP = 200;
            //set number of attacks to zero
            int numAttacks = 0;

            //create random number generator
            Random rng = new Random();
 
           //welcome user to game and explain the game
            Console.WriteLine(@"Welcome to Dragon Combat Simulator!!  You will be going head-to-head against a real-life simulated Dragon....  During battle you will have three combat choices:  1) Sword:  Attacks with your sword will do between 20-35 damage to the dragon, but only have a 70% chance of hitting.  2) Magic:  Attacks with your magic fireball hit the dragon 100% of the time, but only cause the dragon between 10-15 damage.  3) Heal:  Choosing the heal combat will heal for 10-20 HP.  Each turn you have will then result in an attack by the dragon.  You will then keep alternating attacks with the dragon until only one opponent is left standing, THE VICTOR!!!!");

            
            bool userPlay = true;
            while (userPlay)
            {
                
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                
                if (userHP > 0 || dragonHP > 0)
                {
                    //if the user choose sword
                    if (choice == 1)
                    {
                        //add to number of attackss
                        numAttacks++;
                        //create rng for sword choice and damagae
                        int swordChoice = rng.Next(1, 101);
                        int swordDamage = rng.Next(20, 36);

                        
                        if (swordChoice <= 30)
                        {
                            //tell the user they missed
                            Console.WriteLine("You missed the dragon!  Try aiming your sword a little better next time.");
                        }
                        else
                        {
                            
                            dragonHP = dragonHP - swordDamage;
                            //tell user they hit dragon
                            Console.WriteLine("You hit the dragon!  Nice aiming, you did " + swordDamage + " to the dragon.");
                        }
                    }
                    //if user chooses magic
                    else if (choice == 2)
                    {
                        //rng for magic damage
                        int magicDamage = rng.Next(10, 16);
                        //take damage away from dragon hp
                        dragonHP -= magicDamage;
                        //add to number of attacks
                        numAttacks++;
                        //output to user
                        Console.WriteLine("Your magic fireball has caused " + magicDamage + " damage to the dragon, keep it up!");
                    }
                    //if userr chooses heal
                    else if (choice == 3)
                    {
                        //rng for healing hp
                        int healing = rng.Next(10, 21);
                        //add healing hp to the user's hp
                        userHP += healing;
                        //output to user
                        Console.WriteLine("You healed yourself for " + healing + " HP!");
                    }
                    //if user chooses a number that is not an option
                    else
                    {
                        //output to user
                        Console.WriteLine("We're sorry, that's not an option!");
                    }
                    //set dragon attack equal to random number between 5-15
                    int dragonHit = rng.Next(5, 16);
                    //set dragon attack percent equal to random number between 1-100
                    int dragonPercent = rng.Next(1, 101);
                    //if dragon percent is less than 20
                    if (dragonPercent < 20)
                    {
                        //output to user(miss)
                        Console.WriteLine("You got lucky this time, the dragon has missed you!");
                    }
                    //if greater than 20
                    else
                    {
                        //take attack damage away from the dragon's hp
                        userHP -= dragonHit;
                        //output to user(hit);
                        Console.WriteLine("The dragon's firey breath has struck you, causing " + dragonHit + " damage to you!");
                    }
                    //if the user's hp gets to zero
                    if (userHP <= 0)
                    {
                        //clear screen
                        Console.Clear();
                        //tell user they lost
                        Console.WriteLine("Uh-oh, you lose!  Maybe you shouldn't pick any more battles with dragons!");
                        userPlay = false;
                    }
                        //if the dragon's hp  gets to zero
                    else if (dragonHP <= 0)
                    {
                        Console.Clear();
                        //tell the user that they have won
                        Console.WriteLine("You have defeated the almighty dragon and you now rein VICTORIOUS!!!!!!");
                        userPlay = false;
                    }
                }
                //print the userr's remaining hp
                Console.WriteLine("You have: " + userHP + " HP left");
                //print the dragon's remaining hp
                Console.WriteLine("The dragon still has: " + dragonHP + " HP left");
                //print the total number of attacks
                Console.WriteLine("You have attempted: " + numAttacks + " attacks on the dragon");
            }
        }
    }
}
