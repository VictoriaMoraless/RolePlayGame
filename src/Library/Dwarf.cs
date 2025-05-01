namespace Library;

public class Dwarf
{
    private string name;
    private int health;
    private List<string> items;

    public Dwarf(string name)
    {
        this.name = name;
        this.health = 100;
        this.items = new List<string>(); // lista vacia
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

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
    
    public List<string> GetItems()
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
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - dwarf.GetDefense()); // calcula el da;o segun la defensa
        dwarf.SetHealth(dwarf.GetHealth() - damage); // reduce la vida del enano atacado
    }
    
    
    public void Attack(Wizard wizard)
    {
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - wizard.GetDefense()); // calcula el da;o segun la defensa
        wizard.SetHealth(wizard.GetHealth() - damage); // reduce la vida del enano atacado
    }
    
    
    public void Attack(Elf elf)
    {
        int attackValue = GetAttack();
        int damage = Math.Max(0, attackValue - elf.GetDefense()); // calcula el da;o segun la defensa
        elf.SetHealth(elf.GetHealth() - damage); // reduce la vida del enano atacado
    }

    public void Heal(int qty)
    {
        health += qty;
        Console.WriteLine($"{name} se curo {qty} puntos de vida y su salud actual es {health}");
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"{name} guardo {item} en su bolsa encantada.");
    }

    public void RmItem(string item)
    {
        if (items.Contains((item)))
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