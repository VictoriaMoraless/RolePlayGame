using Library;
namespace Library;

public class Wizard
{
    private string name;
    private int health;
    private List<Items> items;
    private SpellsBook book;

    public Wizard(string name)
    {
        this.name = name;
        this.health = 100;
        this.items = new List<Items>();
        this.book = new SpellsBook(new List<Spells>());
    }

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
        return IsDead() ? $"{name} está muerto." : $"{name} está vivo.";
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public void AddItem(Items item)
    {
        items.Add(item);
    }

    public int GetAttack()
    {
        int itemsAttack = items.Sum(i => i.GetAttack());
        int spellsAttack = book.PoderTotal();
        return itemsAttack + spellsAttack;
    }

    public int GetDefense()
    {
        return items.Sum(i => i.GetDefense());
    }

    public void Attack(Wizard target)
    {
        int damage = this.GetAttack() - target.GetDefense();
        if (damage < 0) damage = 0;
        target.ReceiveDamage(damage);
    }

    public void Attack(Dwarf target)
    {
        int damage = this.GetAttack() - target.GetDefense();
        if (damage < 0) damage = 0;
        target.SetHealth(target.GetHealth() - damage);
    }

    public void Attack(Elf target)
    {
        int damage = this.GetAttack() - target.GetDefense();
        if (damage < 0) damage = 0;
        target.SetHealth(target.GetHealth() - damage);
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }
}