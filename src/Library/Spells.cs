namespace Library;

public class Spells
{
    private string name;
    private int attack;

    public string GetName()
    {
        return this.name;
    }

    public int GetAttack()
    {
        return this.attack; 
    }

    public Spells(string name, int attack)
    {
        this.name = name;
        this.attack = attack;
    }
}