using Library;
class Program
{
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

        // personajes
        List<Dwarf> dwarves = new List<Dwarf> { new Dwarf("Gimli"), new Dwarf("Thorin") };
        List<Elf> elves = new List<Elf> { new Elf("Angrod")};
        List<Wizard> wizards = new List<Wizard> { new Wizard("Dumbledore") };
        
        // seleccionar personajes
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

        object character1 = SelectCharacter(dwarves, elves, wizards);
        object character2 = SelectCharacter(dwarves, elves, wizards);

        while (true)
        {
            Console.WriteLine("\nQuien juega? (1 o 2)");
            string input = Console.ReadLine();

            if (input == "1")
            {
                if (character1 is Dwarf d && character2 is Dwarf d2) d.Attack(d2);
                
            }
        }
        while (!character1.IsDead() && !character2.IsDead())
        {
            Console.WriteLine("\nQuien juega? (1 = Gimli, 2 = Angrod)");
            string input = Console.ReadLine();

            if (input == "1")
            {
                dwarf1.Attack(elf1);
            }
            else if (input == "2")
            {
                elf1.Attack((dwarf1));
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }
            
            Console.WriteLine($"Salud de {dwarf1.GetName()}: {dwarf1.GetHealth()}");
            Console.WriteLine($"Salud de {elf1.GetName()}: {elf1.GetHealth()}");
        }
        
        Console.WriteLine($"\nfin del combate");
        Console.WriteLine(dwarf1.IsDead() ? $"{dwarf1.GetName()} murio" : $"{elf1.GetName()} murio");

    }
}