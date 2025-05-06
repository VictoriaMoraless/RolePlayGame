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
    
    
    
    
    
    
    //No se permite agregar el mismo item dos veces
    public void NoDuplicidadItem()
    {

   
    //Ataque reduce salud correctamente
    public void Test1()
    {
        

        
        
        Assert.Pass();
    }
    
    
    
    
    

    //Se puede eliminar un ítem existente
    public void Test3()
    {



        Assert.Pass();


        //No se permite agregar el mismo item dos veces
        public void NoDuplicidadItem()
        {


            Assert.Pass();
        }





        //Se puede eliminar un ítem existente
        public void TestRmItem()
        {
            Elf elf = new Elf("Angrod");

            Items Gorro = new Items("Gorro", 0, 5);
            elf.AddItem(Gorro);
            elf.RmItem(Gorro);

            Assert.IsFalse(elf.GetItems().Contains(Gorro));

        }





        //Ataque no hace daño si ataque <= defensa
        public void Test4()
        {



            Assert.Pass();
        }
    }
