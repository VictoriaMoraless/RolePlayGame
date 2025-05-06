using Library;

namespace LibraryTests
{
    public class Tests1
    {
        [SetUp]
        public void Setup()
        {
        }
        
        //Que se termine el juego cuando muere un personaje
        [Test]
        public void GameEnds_WhenCharacterDies()
        {
            //crea un dwarf y un wizard para jugar
            Dwarf attacker = new Dwarf("Thorin");
            Wizard target = new Wizard("Dumbledore");

            //le ponemos cualquier salud baja (20) y que lo ataquen
            attacker.AddItem(new Items("Espada", 30, 20));  // Agregamos una espada con daño suficiente
            attacker.Attack(target);
            
            //verificamos que el personaje haya muerto
            Assert.IsTrue(target.IsDead(), "El personaje murió, el juego debería haber terminado");
        }
    }
}