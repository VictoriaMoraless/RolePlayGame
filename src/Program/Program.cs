using Library;
class Program
{
    static void Main(string[] args)
    {
        // creando personajes
        Dwarf dwarf1 = new Dwarf("Gimli");
        Elf elf1 = new Elf("Angrod");
        
        // creando elementos
        Items espada = new Items("Espada", 30, 20);
        Items incienso = new Items("Incienso", 0, 10);
        Items gorro = new Items("Gorro", 0, 5);
        Items capa = new Items("Capa", 0, 30);
        
        // agregando elementos
        dwarf1.AddItem(espada);
        dwarf1.AddItem(incienso);
        elf1.AddItem("Gorro");
        elf1.AddItem("Capa");
        
        // atacar
        dwarf1.Attack(elf1);
        Console.WriteLine(elf1.DeadOrAlive());

    }
}