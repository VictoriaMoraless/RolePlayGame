using Library;

class Program
{
    static void Main(string[] args)
    {
        // items disponibles
        Items espada = new Items("Espada", 30, 20);
        Items incienso = new Items("Incienso", 0, 10); //elemento de curación
        Items gorro = new Items("Gorro", 0, 5);
        Items capa = new Items("Capa", 0, 30);

        List<Items> items = new List<Items> { espada, incienso, gorro, capa };

        // personajes
        List<Dwarf> dwarves = new List<Dwarf> { new Dwarf("Gimli"), new Dwarf("Thorin") };
        List<Elf> elves = new List<Elf> { new Elf("Angrod") };
        List<Wizard> wizards = new List<Wizard> { new Wizard("Dumbledore") };

        // seleccionar personajes
        object character1 = SelectCharacter(dwarves, elves, wizards);
        object character2 = SelectCharacter(dwarves, elves, wizards);

        // asignar items
        if (character1 is Dwarf d1)
        {
            d1.AddItem(espada);
            d1.AddItem(incienso);
        }
        else if (character1 is Elf e1)
        {
            e1.AddItem(gorro);
            e1.AddItem(capa);
        }
        else if (character1 is Wizard w1)
        {
            w1.AddItem(incienso);
            w1.AddItem(capa);
        }

        if (character2 is Dwarf d2)
        {
            d2.AddItem(espada);
            d2.AddItem(incienso);
        }
        else if (character2 is Elf e2)
        {
            e2.AddItem(gorro);
            e2.AddItem(capa);
        }
        else if (character2 is Wizard w2)
        {
            w2.AddItem(incienso);
            w2.AddItem(capa);
        }

        //crear hechizos
        Spells bolaDeFuego = new Spells("Bola de fuego", 50);

        //asignar hechizo
        if (wizards.Count > 0)
        {
            Wizard wizard = wizards[0]; 
            wizard.AddSpell(bolaDeFuego);
        }

        static object SelectCharacter(List<Dwarf> dwarves, List<Elf> elves, List<Wizard> wizards)
        {
            Console.WriteLine("Elegi el personaje:");
            Console.WriteLine("1. Enano");
            Console.WriteLine("2. Elfo");
            Console.WriteLine("3. Mago");

            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                for (int i = 0; i < dwarves.Count; i++)
                {
                    Console.WriteLine($"{i}: {dwarves[i].GetName()}");
                }

                int selection = int.Parse(Console.ReadLine());
                return dwarves[selection];
            }
            else if (type == 2)
            {
                for (int i = 0; i < elves.Count; i++)
                {
                    Console.WriteLine($"{i}: {elves[i].GetName()}");
                }

                int selection = int.Parse(Console.ReadLine());
                return elves[selection];
            }
            else if (type == 3)
            {
                for (int i = 0; i < wizards.Count; i++)
                {
                    Console.WriteLine($"{i}: {wizards[i].GetName()}");
                }

                int selection = int.Parse(Console.ReadLine());
                return wizards[selection];
            }
            else
            {
                throw new ArgumentException("Seleccion invalida.");
            }
        }

        static bool IsDead(object character)
        {
            if (character is Dwarf d) return d.IsDead();
            if (character is Elf e) return e.IsDead();
            if (character is Wizard w) return w.IsDead();
            return true;
        }

        while (!IsDead(character1) && !IsDead(character2))
        {
            Console.WriteLine("\nQuien juega? (1 o 2)");
            string input = Console.ReadLine();

            Console.WriteLine("Que deseas hacer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Curar");
            string action = Console.ReadLine();

            if (input == "1" && action == "1")
            {
                Attack(character1, character2);
            }
            else if (input == "2" && action == "1")
            {
                Attack(character2, character1);
            }
            else if (input == "1" && action == "2")
            {
                HealCharacter(character1); // El personaje 1 se cura
            }
            else if (input == "2" && action == "2")
            {
                HealCharacter(character2); // El personaje 2 se cura
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }

            ShowHealth(character1);
            ShowHealth(character2);
        }

        Console.WriteLine($"\nfin del combate");
        Console.WriteLine(IsDead(character1)
            ? $"{GetName(character1)} murio"
            : $"{GetName(character2)} murio");
    }

    static string GetName(object character)
    {
        if (character is Dwarf d) return d.GetName();
        if (character is Elf e) return e.GetName();
        if (character is Wizard w) return w.GetName();
        return "Desconocido";
    }

    static void Attack(object attacker, object target)
    {
        if (attacker is Dwarf aD && target is Dwarf tD) aD.Attack(tD);
        else if (attacker is Dwarf d1 && target is Elf tE) d1.Attack(tE);
        else if (attacker is Dwarf AD && target is Wizard w1) AD.Attack(w1);
        else if (attacker is Elf aE && target is Dwarf d2) aE.Attack(d2);
        else if (attacker is Elf e1 && target is Elf e3) e1.Attack(e3);
        else if (attacker is Elf e2 && target is Wizard w2) e2.Attack(w2);
        else if (attacker is Wizard aW && target is Dwarf d3) aW.Attack(d3);
        else if (attacker is Wizard w3 && target is Elf e4) w3.Attack(e4);
        else if (attacker is Wizard AW && target is Wizard w4) AW.Attack(w4);
    }

    static void ShowHealth(object character)
    {
        if (character is Dwarf d)
            Console.WriteLine($"Salud de {d.GetName()}: {d.GetHealth()}");
        else if (character is Elf e)
            Console.WriteLine($"Salud de {e.GetName()}: {e.GetHealth()}");
        else if (character is Wizard w)
            Console.WriteLine($"Salud de {w.GetName()}: {w.GetHealth()}");
    }
    
    static void HealCharacter(object character)
    {
        List<Items> items = new List<Items>();
        int currentHealth = 0;
        string name = GetName(character);

        if (character is Dwarf d)
        {
            items = d.GetItems();
            currentHealth = d.GetHealth();
        }
        else if (character is Elf e)
        {
            items = e.GetItems();
            currentHealth = e.GetHealth();
        }
        else if (character is Wizard w)
        {
            items = w.GetItems();  
            currentHealth = w.GetHealth();
        }
        
        Items incienso = items.FirstOrDefault(i => i.GetName() == "Incienso");

        if (incienso != null)
        {
            int healAmount = 100 - currentHealth;
            if (healAmount <= 0)
            {
                Console.WriteLine($"{name} ya tiene salud completa. No necesita curarse.");
                return;
            }

            // Cura el personaje
            if (character is Dwarf d1) d1.Heal(healAmount);
            else if (character is Elf e1) e1.Heal(healAmount);
            else if (character is Wizard w1) w1.Heal(healAmount);
            
            Console.WriteLine($"{name} usó el Incienso y se curó {healAmount} puntos.");
        }
        else
        {
            Console.WriteLine($"{name} no tiene Incienso entonces no puede curarse.");
        }
    }
}
