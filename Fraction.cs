class Fraction
{
    public int Numerador {get; private set;}
    public int Denominador {get; private set;}
    public Fraction(int numerador, int denominador)
    {
        if (denominador == 0)
            throw new ArgumentException("El denominador no puede ser cero ");

        if (numerador == 0)
        {
            Numerador = 0;
            Denominador = 1;
        }

        else
        {
            Numerador = numerador;
            Denominador = denominador;
            Simplificar();
        }

    }
    private void Simplificar()
    {
        int mcd = MCD(Math.Abs(Numerador), Math.Abs(Denominador));

        Numerador /= mcd;
        Denominador /= mcd;

        if (Denominador < 0)
        {
            Numerador *= -1;
            Denominador *= -1;
        }
    }
    private int MCD(int a, int b)
    {
        while (b != 0)
        {
            int temporal = b;
            b = a % b;
            a = temporal;
        }

        return a;
    }
    public override string ToString()
    {
        if (Denominador == 1) return $"{Numerador}";

        return $"{Numerador}/{Denominador}";
    }
    public override bool Equals(object obj)
    {
        if (obj is Fraction f)
        {
            return this == f;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return (Numerador, Denominador).GetHashCode();
    }
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerador * f2.Denominador + f2.Numerador * f1.Denominador, f1.Denominador * f2.Denominador);
    }
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerador * f2.Denominador - f2.Numerador * f1.Denominador, f1.Denominador * f2.Denominador);
    }
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerador * f2.Numerador, f1.Denominador * f2.Denominador);
    }
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.Numerador == 0) throw new ArgumentException("Parametro invalido");

        return new Fraction(f1.Numerador * f2.Denominador, f1.Denominador * f2.Numerador);
    }
    public static bool operator >(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador > f1.Denominador * f2.Numerador;
    }
    public static bool operator >=(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador >= f1.Denominador * f2.Numerador;
    }
    public static bool operator <(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador < f1.Denominador * f2.Numerador;
    }
    public static bool operator <=(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador <= f1.Denominador * f2.Numerador;
    }
    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador == f1.Denominador * f2.Numerador;
    }
    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return f1.Numerador * f2.Denominador != f1.Denominador * f2.Numerador;
    }
}

