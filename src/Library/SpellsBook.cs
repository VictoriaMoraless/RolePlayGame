using System.Collections.Generic;
using System.Linq;

namespace Library;

public class SpellsBook
{
    private List<Spells> hechizos;

    public SpellsBook(List<Spells> hechizosIniciales)
    {
        if (hechizosIniciales == null || hechizosIniciales.Count == 0)
        {
            this.hechizos = new List<Spells>
            {
                new Spells("Hechizo Básico", 10)
            };
        }
        else
        {
            this.hechizos = new List<Spells>(hechizosIniciales);
        }
    }

    public void AddSpell(Spells spell)
    {
        if (!hechizos.Contains(spell))
        {
            hechizos.Add(spell);
        }
    }

    public bool Contains(Spells spell)
    {
        return hechizos.Contains(spell);
    }

    public void RmSpell(Spells spell)
    {
        if (hechizos.Contains(spell) && hechizos.Count > 1)
        {
            hechizos.Remove(spell);
        }
    }

    public int PoderTotal()
    {
        return hechizos.Sum(h => h.GetAttack());
    }

    public List<Spells> ObtenerHechizos()
    {
        return new List<Spells>(hechizos);
    }

    public override string ToString()
    {
        return $"SpellsBook con {hechizos.Count} hechizo(s), poder total: {PoderTotal()}";
    }
}