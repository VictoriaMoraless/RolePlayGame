using Library;
class Program
{
    static object SelectCharacter(List<Dwarf> dwarves, List<Elf> elves, List<Wizard> wizards)
    {
        Console.WriteLine("Elegi el personaje:");
        Console.WriteLine("1. Enano");
        Console.WriteLine("2. Elfo");
        Console.WriteLine("3. Mago");

        int type = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            Console.WriteLine("Elegí un enano:");
            for (int i = 0; i < dwarves.Count; i++)
            {
                Console.WriteLine($"{i}: {dwarves[i].GetName()}");
            }

            int selection = int.Parse(Console.ReadLine());
            return dwarves[selection];
        }
        else if (type == 2)
        {
            Console.WriteLine("Elegí un elfo:");
            for (int i = 0; i < elves.Count; i++)
            {
                Console.WriteLine($"{i}: {elves[i].GetName()}");
            }
            int selection = int.Parse(Console.ReadLine());
            return elves[selection];
        }
        else if (type == 3)
        {
            Console.WriteLine("Elegí un mago:");
            for (int i = 0; i < wizards.Count; i++)
            {
                Console.WriteLine($"{i}: {wizards[i].GetName()}");
            }
            int selection = int.Parse(Console.ReadLine());
            return wizards[selection];
        }
        else
        {
            Console.WriteLine("Selección inválida. Intentá de nuevo.");
            return SelectCharacter(dwarves, elves, wizards);
        }
    }
    
    static void Main(string[] args)
    {
        // items disponibles
        List<Items> items = new List<Items>
        {
            new Items("Espada", 30, 20),
            new Items("Incienso", 0, 10),
            new Items("Gorro", 0, 5),
            new Items("Capa", 0, 30)
        };
        
        // Hechizos y libro de hechizos para el mago
        List<Spells> hechizos = new List<Spells>
        {
            new Spells("Fuego", 40),
            new Spells("Hielo", 25)
        };
        SpellsBook libro = new SpellsBook(hechizos);
        
        // personajes
        List<Dwarf> dwarves = new List<Dwarf> { new Dwarf("Gimli"), new Dwarf("Thorin") };
        List<Elf> elves = new List<Elf> { new Elf("Angrod")};
        List<Wizard> wizards = new List<Wizard> { new Wizard("Dumbledore", libro) };
        
        // seleccionar personajes
        var personaje1 = SelectCharacter(dwarves, elves, wizards);
        var personaje2 = SelectCharacter(dwarves, elves, wizards);
        
        // agregando elementos a los personajes
        if (personaje1 is Dwarf dwarf1)
        {
            dwarf1.AddItem(items[0]);
            dwarf1.AddItem(items[1]);
        }
        else if (personaje1 is Elf elf1)
        {
            elf1.AddItem("Gorro");
            elf1.AddItem("Capa");
        }
        else if (personaje1 is Wizard wizard1)
        {
            wizard1.AddItem(items[2]);
            wizard1.AddItem(items[3]);
        }

        if (personaje2 is Dwarf dwarf2)
        {
            dwarf2.AddItem(items[0]);
            dwarf2.AddItem(items[1]);
        }
        else if (personaje2 is Elf elf2)
        {
            elf2.AddItem("Gorro");
            elf2.AddItem("Capa");
        }
        else if (personaje2 is Wizard wizard2)
        {
            wizard2.AddItem(items[2]);
            wizard2.AddItem(items[3]);
        }

        while (!(personaje1 is Dwarf p1DwarfLoop && p1DwarfLoop.IsDead()) && 
               !(personaje1 is Elf p1ElfLoop && p1ElfLoop.IsDead()) && 
               !(personaje1 is Wizard p1WizardLoop && p1WizardLoop.IsDead()) &&
               !(personaje2 is Dwarf p2DwarfLoop && p2DwarfLoop.IsDead()) && 
               !(personaje2 is Elf p2ElfLoop && p2ElfLoop.IsDead()) && 
               !(personaje2 is Wizard p2WizardLoop && p2WizardLoop.IsDead()))
        {
            Console.WriteLine("\n¿Quién juega? (1 = Gimli, 2 = Angrod, 3= Dumbledore)");
            string input = Console.ReadLine();

            if (input == "1")
            {
                if (personaje1 is Dwarf d1)
                {
                    if (personaje2 is Dwarf d2)
                        d1.Attack(d2);
                    else if (personaje2 is Elf e2)
                        d1.Attack(e2);
                    else if (personaje2 is Wizard w2)
                        d1.Attack(w2);
                }
            }
            else if (input == "2")
            {
                if (personaje1 is Elf e1)
                {
                    if (personaje2 is Dwarf d2)
                        e1.Attack(d2);
                    else if (personaje2 is Elf e2)
                        e1.Attack(e2);
                    else if (personaje2 is Wizard w2)
                        e1.Attack(w2);
                }
            }
            else if (input == "3")
            {
                if (personaje1 is Wizard w1)
                {
                    if (personaje2 is Dwarf d2)
                        w1.Attack(d2);
                    else if (personaje2 is Elf e2)
                        w1.Attack(e2);
                    else if (personaje2 is Wizard w2)
                        w1.Attack(w2);
                }
            }
            else
            {
                Console.WriteLine("Opción inválida");
            }

            // Mostrar la salud de los personajes
            if (personaje1 is Dwarf d1) Console.WriteLine($"Salud de {d1.GetName()}: {d1.GetHealth()}");
            if (personaje1 is Elf e1) Console.WriteLine($"Salud de {e1.GetName()}: {e1.GetHealth()}");
            if (personaje1 is Wizard w1) Console.WriteLine($"Salud de {w1.GetName()}: {w1.GetHealth()}");

            if (personaje2 is Dwarf d2) Console.WriteLine($"Salud de {d2.GetName()}: {d2.GetHealth()}");
            if (personaje2 is Elf e2) Console.WriteLine($"Salud de {e2.GetName()}: {e2.GetHealth()}");
            if (personaje2 is Wizard w2) Console.WriteLine($"Salud de {w2.GetName()}: {w2.GetHealth()}");
        }
    }
}