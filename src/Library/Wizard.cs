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

    public List<Items> GetItems()
    {
        return items;
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
    public void AddSpell(Spells spells)
    {
        Console.WriteLine("\nAdquirir hechizo:");
        if (spells != null && !this.book.Contains(spells))
        {
            this.book.AddSpell(spells);
            Console.WriteLine($"{this.name} ha adquirido el hechizo ¨{spells.GetName()}¨.");
        }
        else
        {
            Console.WriteLine($"No fue posible adquirir. {this.name} ya posee el hechizo ¨{spells.GetName()}¨.");
        }
    }

    public void RmSpell(Spells spells)
    {
        Console.WriteLine("\nRemover hechizo:");
        if (spells != null && this.book.Contains(spells))
        {
            this.book.RmSpell(spells);
            Console.WriteLine($"{this.name} removió el hechizo ¨{spells.GetName()}¨.");
        }
        else
        {
            Console.WriteLine($"No fue posible remover. {this.name} no posee el hechizo ¨{spells.GetName()}¨.");
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > 100)
        {
            health = 100;
        }
    }
    public void AddItem(Items item)
    {
        items.Add(item);
    }


}