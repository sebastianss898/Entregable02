public interface ICombate
{
    int Ataque();
    double Defen();
}

public abstract class Pokemon : ICombate
{
    private string nombre;
    public string tipo;
    private int[] ataques = new int[3];
    public double defensa;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public int[] Ataques
    {
        get { return ataques; }
        set { ataques = value; }
    }
    public double Defensa
    {
        get { return defensa; }
        set { defensa = value; }
    }
    public Pokemon(string nombre, string tipo, int[] ataques, double defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataques = ataques;
        this.defensa = defensa;
    }
    public abstract int Ataque();
    public abstract double Defen();
}


public class DatosPokemon : Pokemon
{
    public DatosPokemon(string nombre, string tipo, int[] ataques, double defensa) : base(nombre, tipo, ataques, defensa) {}
    public override int Ataque()
    {
        Random rnd = new Random();
        int seleccionataque = Ataques[rnd.Next(Ataques.Length)];
        int multiplier = rnd.Next(2); // 0 or 1
        return seleccionataque * multiplier;
    }
    public override double Defen()
    {
        Random rnd = new Random();
        double multiplicar = rnd.Next(2) == 0 ? 1 : 0.5;
        return Defensa * multiplicar;
    }
}


public class Program
{
    public static void Main()
    {

        Pokemon pokemon1 = new DatosPokemon("pikachu", "electrico", new int[] { 30, 25, 40 }, 20);
        Pokemon pokemon2 = new DatosPokemon("charmander", "fuego", new int[] { 30, 30, 10 }, 15);


        int puntosPK1 = 0, puntosPK2 = 0;

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Turno {i + 1}:");

            int ataque1 = pokemon1.Ataque();
            double defensa2 = pokemon2.Defen();
            Console.WriteLine($"{pokemon1.Nombre} ataca con {ataque1} puntos, {pokemon2.Nombre} defiende con {defensa2} puntos.");

            if (ataque1 > defensa2)

                puntosPK1++;
            else if (ataque1 < defensa2)
                puntosPK2++;


            int ataque2 = pokemon1.Ataque();
            double defensa1 = pokemon2.Defen();
            Console.WriteLine($"{pokemon1.Nombre} ataca con {ataque2} puntos, {pokemon2.Nombre} defiende con {defensa1} puntos.");

            if (ataque2 > defensa1)

                puntosPK1++;
            else if (ataque2 < defensa1)
                puntosPK2++;

        }

        if (puntosPK1 > puntosPK2)
            Console.WriteLine($"{pokemon1.Nombre} es el ganador");
        else if (puntosPK1 < puntosPK2)
            Console.WriteLine($"{pokemon2.Nombre} es el ganador");
        else
            Console.WriteLine($"es un empate");

    }

}