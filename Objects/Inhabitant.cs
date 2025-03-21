using UnityEditor.Rendering;
using UnityEngine;

public abstract class Inhabitant
{
    protected int currHp;
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }

    public int rollHit()
    {
        int attack = Random.Range(10, 30) + 1;
        return attack;
    }

    public void takeDamage()
    {
        int damage = Random.Range(5, 10) + 1;
        this.currHp = this.currHp - damage; 
    }
    
    public int getAC()
    {
        return this.ac;
    }

    public string getName()
    {
        return this.name;
    }

    public int getCurrHP()
    {
        return this.currHp;
    }

    public bool isAlive()
    {
        if (this.currHp > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
