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
        this.ac = Random.Range(5, 12);
    }

    public string getName()
    {
        return this.name;
    }

    public int getCurrHp()
    {
        return this.currHp;
    }

    public int getMaxHp()
    {
        return this.maxHp;
    }

    public bool isDead()
    {
        return this.currHp <= 0;
    }

    public void takeDamage(int damage)
    {
        this.currHp -= damage;
    }
    public int getAC()
    {
        return this.ac;
    }
}