using System.Text;
class Poly
{
    public int[] Polinomio { get; set; }
    public int Grado { get; set; }
    public Poly(int[] polinomio)
    {
        ReducirPolinomio(polinomio);

        Grado = Polinomio.Length - 1;
    }
    private void ReducirPolinomio(int[] polinomio)
    {
        int count = 0;

        for (int i = polinomio.Length - 1; i >= 0; i--)
        {
            if (polinomio[i] == 0)
            {
                count++;
            }

            else break;
        }

        Polinomio = new int[polinomio.Length - count];
        Array.Copy(polinomio, Polinomio, Polinomio.Length);
    }
    // Verificar lo que hice dentro de array . copy no estoy muy seguro de lo que hice
    public int Coeficiente(int argumento)
    {
        return (argumento > Grado) ? 0 : Polinomio[argumento];
    }
    public override string ToString()
    {
        if (Polinomio.Length == 0 || (Polinomio.Length == 1 && Polinomio[0] == 0))
            return "0";

        StringBuilder cadenaPolinomio = new StringBuilder();

        for (int i = Polinomio.Length - 1; i >= 0; i--)
        {
            if (Polinomio[i] == 0) continue;

            if (cadenaPolinomio.Length > 0)
            {
                if (Polinomio[i] > 0)
                    cadenaPolinomio.Append("+");
            }

            if (i == 0)
                cadenaPolinomio.Append($"{Polinomio[i]}");

            else if (i == 1)
            {
                if (Polinomio[i] == 1)
                    cadenaPolinomio.Append("x");

                else if (Polinomio[i] == -1)
                    cadenaPolinomio.Append("-x");

                else
                    cadenaPolinomio.Append($"{Polinomio[i]}x");
            }

            else
            {
                if (Polinomio[i] == 1)
                    cadenaPolinomio.Append($"x^{i}");
 
                else if (Polinomio[i] == -1)
                    cadenaPolinomio.Append($"-x^{i}");
 
                else
                    cadenaPolinomio.Append($"{Polinomio[i]}x^{i}");
            }
        }

        return cadenaPolinomio.ToString();
    }
    public static bool operator >(Poly p1, Poly p2)
    {
        if (p1.Grado > p2.Grado) return true;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] > p2.Polinomio[i])
                    return true;

        return false;
    }
    public static bool operator >=(Poly p1, Poly p2)
    {
        if (p1.Grado >= p2.Grado) return true;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] >= p2.Polinomio[i])
                    return true;

        return false;
    }
    public static bool operator <(Poly p1, Poly p2)
    {
        if (p1.Grado < p2.Grado) return true;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] < p2.Polinomio[i])
                    return true;

        return false;
    }
    public static bool operator <=(Poly p1, Poly p2)
    {
        if (p1.Grado <= p2.Grado) return true;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] <= p2.Polinomio[i])
                    return true;

        return false;
    }
    public static bool operator ==(Poly p1, Poly p2)
    {
        if (p1.Grado != p2.Grado) return false;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] != p2.Polinomio[i])
                    return false;

        return true;
    }
    public static bool operator !=(Poly p1, Poly p2)
    {
        if (p1.Grado != p2.Grado) return true;

        if (p1.Grado == p2.Grado)
            for (int i = p1.Grado; i >= 0; i++)
                if (p1.Polinomio[i] != p2.Polinomio[i])
                    return true;

        return false;
    }

    public static Poly operator +(Poly p1, Poly p2)
    {
        int maxLength = Math.Max(p1.Polinomio.Length, p2.Polinomio.Length);
        int[] polinomioSuma = new int[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            polinomioSuma[i] = p1.Coeficiente(i) + p2.Coeficiente(i);
        }

        return new Poly(polinomioSuma);
    }
    public static Poly operator -(Poly p1, Poly p2)
    {
        int maxLength = Math.Max(p1.Polinomio.Length, p2.Polinomio.Length);
        int[] polinomioSuma = new int[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            polinomioSuma[i] = p1.Coeficiente(i) - p2.Coeficiente(i);
        }

        return new Poly(polinomioSuma);
    }
    public static Poly operator *(Poly p1, Poly p2)
    {
        int[] polinomioProducto = new int[p1.Grado + p2.Grado + 1];

        for (int i = 0; i < p1.Polinomio.Length; i++)
        {
            for (int j = 0; j < p2.Polinomio.Length; j++)
            {
                polinomioProducto[i + j] += p1.Polinomio[i] * p2.Polinomio[j];
            }
        }

        return new Poly(polinomioProducto);
    }
    public static Poly operator *(Poly p1, int escalar)
    {
        int[] polinomioProducto = new int[p1.Polinomio.Length];

        for (int i = 0; i < p1.Polinomio.Length; i++)
        {
            polinomioProducto[i] = escalar * p1.Polinomio[i];
        }

        return new Poly(polinomioProducto);
    }
    public static Poly operator /(Poly p1, Poly p2)
    {
        if (p2.Grado < 0)
            throw new ArgumentException("el grado del segundo polinomio debe ser mayor o igual que el del primero");

        if (p1.Grado < p2.Grado)
            return new Poly(new int[] { 0 });

        int[] polinomioDividido = new int[p1.Grado - p2.Grado + 1];
        Poly resto = new(p1.Polinomio);

        while (resto.Grado >= p2.Grado)
        {
            int coeficiente = resto.Polinomio[resto.Grado] / p2.Polinomio[p2.Grado];
            int gradoDiferencia = resto.Grado - p2.Grado;

            polinomioDividido[gradoDiferencia] = coeficiente;

            int[] polinomioTemporal = new int[gradoDiferencia + p2.Grado];

            for (int i = 0; i < p2.Polinomio.Length; i++)
            {
                polinomioTemporal[i + gradoDiferencia] = p2.Polinomio[i] * coeficiente;
            }

            resto = resto - new Poly(polinomioTemporal);
        }

        return new Poly(polinomioDividido);
    }
    public static Poly operator %(Poly p1, Poly p2)
    {
        if (p2.Grado < 0)
            throw new ArgumentException("Argumento incorrecto ");

        if (p1.Grado < p2.Grado)
            return p1;

        int[] polinomioDividido = new int[p1.Grado - p2.Grado];
        Poly resto = new Poly(p1.Polinomio);

        while (resto.Grado >= p2.Grado)
        {
            int coeficiente = resto.Polinomio[resto.Grado] / p2.Polinomio[p2.Grado];
            int gradoDiferencia = resto.Grado - p2.Grado;

            polinomioDividido[gradoDiferencia] = coeficiente;

            int[] polinomioTemporal = new int[gradoDiferencia + p2.Grado];

            for (int i = 0; i < p2.Polinomio.Length; i++)
            {
                polinomioTemporal[i + gradoDiferencia] = p2.Polinomio[i] * coeficiente;
            }

            resto = resto - new Poly(polinomioTemporal);
        }

        return resto;
    }
    public int EvaluarX(int x)
    {
        if (x == 0)
            return Polinomio[0];

        int raiz = 0;

        for (int i = 0; i < Polinomio.Length; i++)
        {
            raiz += Polinomio[i] * (int)Math.Pow(x, i);
        }

        return raiz;
    }
    public Poly Derivar()
    {
        int[] derivado = new int[Polinomio.Length - 1];

        for (int i = 0; i < Polinomio.Length - 1; i++)
        {
            derivado[i] = (i + 1) * Polinomio[i + 1];
        }

        return new Poly(derivado);
    }
}