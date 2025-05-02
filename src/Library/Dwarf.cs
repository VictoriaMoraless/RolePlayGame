using Library;
namespace Library;

public class Dwarf
{
    private string name;
    private int health;
    private List<Items> items;

    public Dwarf(string name)
    {
        this.name = name;
        this.health = 100;
        this.items = new List<Items>(); // lista vacia
    }
    
// getters para acceder a nombre, vida, items, ataque, defensa, atacar, curar, agregar, borrar    
    
    public string GetName() // getter para nombre
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
    
    public List<Items> GetItems()
    {
        return items;
    }

    public int GetAttack()
    {
        int defaultAttack = 10; // default sin items
        int itemAttack = 0; // aca acumla el valor de ataque segun el item

        foreach (Items item in items)
        {
            itemAttack += item.GetAttack(); // asi suma alataque
        }

        return defaultAttack + itemAttack;
    }

    public int GetDefense() // esto es idem getattakc pero al reves!! cura ne vez de lastimar
    {
        int defaultDefense = 5;
        int itemDefense = 0;

        foreach (Items item in items)
        {
            itemDefense += item.GetDefense();
        }

        return defaultDefense + itemDefense;
    }

    public void Attack(Dwarf dwarf)
    {
        if (dwarf.IsDead())
        {
            Console.WriteLine($"{dwarf.GetName()} esta muerto, no se le puede hacer mas da;o.");
            return;
        }
        
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - dwarf.GetDefense()); // calcula el da;o segun la defensa
        dwarf.SetHealth(dwarf.GetHealth() - damage); // reduce la vida del enano atacado
        Console.WriteLine($"{GetName()} ataco a {dwarf.GetName} y le hizo {damage} de da;o.");
    }
    
    
    public void Attack(Wizard wizard)
    {
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - wizard.GetDefense()); // calcula el da;o segun la defensa
        wizard.SetHealth(wizard.GetHealth() - damage); // reduce la vida del enano atacado
    }
    
    
    public void Attack(Elf elf)
    {
        if (elf.IsDead())
        {
            Console.WriteLine($"{elf.GetName()} esta muerto, no se le puede hacer mas da;o.");
            return;
        }
        
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - elf.GetDefense()); // calcula el da;o segun la defensa
        elf.SetHealth(elf.GetHealth() - damage); // reduce la vida del enano atacado
        Console.WriteLine($"{GetName()} ataco a {elf.GetName()} y le hizo {damage} de da;o.");
    }


    public void Heal(int qty)
    {
        health = Math.Min(100, health + qty); // no se cura mas de 100 puntos de vida
        Console.WriteLine($"{name} se curo {qty} puntos de vida y su salud actual es {health}");
    }

    public void AddItem(Items item)
    {
        items.Add(item);
        Console.WriteLine($"{name} guardo {item.GetName()} en su bolsa encantada.");
    }

    public void RmItem(Items item)
    {
        if (items.Contains((item)))
        {
            items.Remove(item);
            Console.WriteLine($"{name} saco {item} de su bolsa encantada.");
        }
        else
        {
            Console.WriteLine($"{item.GetName()} no esta en la bolsa encantada de {name}.");
        }
    }
}