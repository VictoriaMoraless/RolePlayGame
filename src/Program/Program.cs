using Library;
class Program
{
    static void Main(string[] args)
    {
        // creando 2 enanos
        Dwarf dwarf1 = new Dwarf("Gimli");
        
        // agregar cosas
        dwarf1.AddItem("Espada");
        dwarf1.AddItem("Incienso");
    }
}