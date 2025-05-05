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

    public void QuitarHechizo(Spells hechizo)
    {
        if (hechizos.Contains(hechizo) && hechizos.Count > 1)
        {
            hechizos.Remove(hechizo);
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