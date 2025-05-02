namespace Library;

public class Wizard
{
    private string name;
    private int health;
    private int magic;
    private List<string> items;
    private List<string> magicBook;

    public Wizard(string name)
    {
        this.name = name;
        this.health = 100;
        this.magic = 30;
        this.items = new List<string>();
        this.magicBook = new List<string>();
    }
    // getname

    public string GetName()
    {
        return name;
    }

    public int GetHealth()
    {
        return health;
    }
    
    public bool IsDead()
    {
        return health <= 0;
    }

    public string DeadOrAlive()
    {
        return health <= 0 ? $"{name} esta muerto." : $"{name} esta vivo.";
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
    //getitems
    //getattack
    public int GetDefense()
    {
        return 5;
    }
    

}