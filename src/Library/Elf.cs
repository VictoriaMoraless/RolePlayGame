using Library;
namespace Library;

public class Elf
{
    private string name;
    private int health;
    private int magic;
    private List<Items> items;

    public Elf(string name)
    {
        this.name = name;
        this.health = 100;
        this.magic = 30;
        this.items = new List<Items>(); // es una lista vacia
    }
    
    
    public string GetName() // se obtiene el nombre
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
        return 10; // todos los ataques restan al menos 10 puntos de vida al oponente 
    }

    public int GetDefense()
    {
        return 5; // idem getattack, pero en vez de restar suma a si mismo (?
    }

    public void Attack(Dwarf dwarf)
    {
        if (dwarf.IsDead())
        {
            Console.WriteLine($"{dwarf.GetName()} esta muerto, no se le puede hacer mas daño.");
            return;
        }
        
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - dwarf.GetDefense()); // calcula el daño según la defensa
        dwarf.SetHealth(dwarf.GetHealth() - damage); // reduce la vida del enano atacado
        Console.WriteLine($"{GetName()} ataco a {dwarf.GetName()} y le hizo {damage} de daño.");
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
        if (this.health < 100)
        {
            health += qty;
            Console.WriteLine($"{name} se curo {qty} puntos de vida y su salud actual es {health}");
        }
        else
        {
            Console.WriteLine($"No fue posible curarse. {this.name} ya tiene todos los puntos de vida.");
        }
        
    }

    public void AddItem(Items item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Console.WriteLine($"{name} guardo {item.GetName()} en su bolsa encantada.");
        }
        else
        {
            Console.WriteLine($"{name} no pudo guardar {item.GetName()} en su bolsa porque ya lo posee."); 
        }
    }

    public void RmItem(Items item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{name} saco {item} de su bolsa encantada.");
        }
        else
        {
            Console.WriteLine($"{item} no esta en la bolsa encantada de {name}.");
        }
    }
}
