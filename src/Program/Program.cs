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
        Items incienso = new Items("Incienso", 20, 0);
        Items gorro = new Items("Gorro", 0, 40);
        Items capa = new Items("Capa", 0, 30);
        
        // agregando elementos
        dwarf1.AddItem("Espada");
        dwarf1.AddItem("Incienso");
        elf1.AddItem("Gorro");
        elf1.AddItem("Capa");

    }
}