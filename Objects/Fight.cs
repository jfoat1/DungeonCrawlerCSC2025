using Unity.VisualScripting.FullSerializer;
using UnityEditor.Build.Content;
using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour 
{
    private Inhabitant attacker;
    private Inhabitant defender;
    Monster theMonster = new Monster("Goblin");
    Player thePlayer = Core.thePlayer;
    public Fight()
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log(this.theMonster.getName() + " goes first.");
            attacker = theMonster;

            defender = this.thePlayer;
        }
        else
        {
            Debug.Log(this.thePlayer.getName() + " goes first.");
            attacker = this.thePlayer;
            defender = theMonster;
        }
    }
    public IEnumerator startFight()
    {
        Debug.Log("Tim's health: " + this.thePlayer.getCurrHP());
        Debug.Log("Goblin's health: " + this.theMonster.getCurrHP());
        while (defender.isAlive() && attacker.isAlive())
        {
            if (theMonster.getCurrHP() > 0 && thePlayer.getCurrHP() > 0)
            {
                yield return new WaitForSeconds(1);
            }
            int hit = attacker.rollHit();
            if (hit >= defender.getAC())
            {
                defender.takeDamage();
                Debug.Log(defender.getName() + " gets hit!");
                if(defender.isAlive())
                {
                    Debug.Log(defender.getName() + " now has " + defender.getCurrHP() + " health.");
                }
                else
                {
                    Debug.Log(defender.getName() + " has died!");
                }
            }
            else
            {
                Debug.Log(attacker.getName() + " misses!");
            }
            Inhabitant t = attacker;
            attacker = defender;
            defender = t;
            //should have the attacker and defender fight each until one of them dies.
            //the attacker and defender should alternate between each fight round and
            //the one who goes first was determined in the constructor.
        }
        Debug.Log(defender.getName() + " has won!"); 
    }


}