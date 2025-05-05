using Library;

namespace LibraryTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
   
    //Ataque reduce salud correctamente
    public void Test1()
    {
        
        
        
        Assert.Pass();
    }
    
    
    
    
    
    
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
