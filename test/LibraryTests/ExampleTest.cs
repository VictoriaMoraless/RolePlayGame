using Library;
namespace LibraryTests;
using Library;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    //Ataque reduce salud correctamente
    [Test]
    public void DwarfAttack_AffectsHealth()
    {
        int defaultHealth = 100;
        Dwarf attacker = new Dwarf("Thorin");
        Elf target = new Elf("Angrod");

        Items espada = new Items("espada", 30, 20);
        attacker.AddItem(espada);
        attacker.Attack(target);
        
        Assert.Less(target.GetHealth(), defaultHealth);
        
    }

    //Ataque reduce salud correctamente
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }


    //No se permite agregar el mismo item dos veces
    [Test]
    public void NoDuplicidadItem()
    {


        Assert.Pass();
    }


    //Se puede eliminar un ítem existente
    [Test]
    public void TestRmItem()
    {
        Elf elf = new Elf("Angrod");

        Items Gorro = new Items("Gorro", 0, 5);
        elf.AddItem(Gorro);
        elf.RmItem(Gorro);

        Assert.IsFalse(elf.GetItems().Contains(Gorro));

    }

    //Ataque no hace daño si ataque <= defensa
    [Test]
    public void Test4()
    {
        Dwarf attacker = new Dwarf("Thorin");
        Elf target = new Elf("Angrod");

        Items palito = new Items("Palito", 5, 20); // 5 de ataque, 20 de defensa
        attacker.AddItem(palito); // daño total: 5
        target.AddItem(palito);   // suma defensa: 20

        int saludInicial = target.GetHealth();

        attacker.Attack(target);

        Assert.AreEqual(saludInicial, target.GetHealth(), "La salud no debería cambiar porque el ataque fue bloqueado.");
    }
}
