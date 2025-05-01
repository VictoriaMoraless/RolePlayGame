namespace Library;

public class Items
{
        private string name;
        private int attack;
        private int defense;
        public string GetNombre()
        {
            return this.name;
        }
        public int GetAttack()
        {
            return this.attack;
        }

        public int GetDefense()
        {
            return this.defense;
        }

        public Items(string name, int attack, int defense)
        {
            this.name = name;
            this.attack = attack;
            this.defense = defense;
        }
}