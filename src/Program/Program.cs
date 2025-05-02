using Library;
class Program
{
    static void Main(string[] args)
    {
        // creando personajes
        Dwarf dwarf1 = new Dwarf("Gimli");
        Elf elf1 = new Elf("Angrod");

        List<Items> items = new List<Items>
        {
            new Items("Espada", 30, 20),
            new Items("Incienso", 0, 10),
            new Items("Gorro", 0, 5),
            new Items("Capa", 0, 30)
        };
        
        
        // agregando elementos
        dwarf1.AddItem(espada);
        dwarf1.AddItem(incienso);
        elf1.AddItem("Gorro");
        elf1.AddItem("Capa");

        while (!dwarf1.IsDead() && !elf1.IsDead())
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