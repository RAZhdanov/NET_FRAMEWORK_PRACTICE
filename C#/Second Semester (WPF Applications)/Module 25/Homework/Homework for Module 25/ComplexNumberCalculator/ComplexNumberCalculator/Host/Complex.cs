using System;
using System.Runtime.Serialization;
using System.ServiceModel;

[DataContract]
public class Complex
{
    private double a;   // вещественная часть
    private double b;   // мнимая часть

   
   
    public Complex(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

   

    public Complex(double a) : this(a, 0) { }

    [DataMember]
    public double Re
    {
        get { return a; }
        set { a = value; }
    }

    [DataMember]
    public double Im
    {
        get { return b; }
        set { b = value; }
    }

   
    public double Module
    { 
        get {  return Math.Sqrt(a * a + b * b); }
    }

    
    public double Argument
    {
        get { return Math.Atan2(b, a); }
    }

    
    public static Complex GetComplex(double module, double argument) // создание комплексного числа по модулю и аргументу
    {
        return new Complex(module * Math.Cos(argument), module * Math.Sin(argument));
    }

    
    public static implicit operator Complex(double a)
    {
        return new Complex(a);
    }


    // Арифметические операции

    public static Complex operator +(Complex x, Complex y)
    {
        if (x is null | y is null) return null;

        double re = x.a + y.a;
        double im = x.b + y.b;
        return new Complex(re, im);    
        
    }

    public static Complex operator -(Complex x, Complex y)
    {
        if (x is null | y is null) return null;

        double re = x.a - y.a;
        double im = x.b - y.b;
        return new Complex(re, im);
    }

    public static Complex operator *(Complex x, Complex y)
    {
        if (x is null | y is null) return null;

        double re = x.a * y.a - x.b * y.b;
        double im = x.b * y.a + x.a * y.b;
        return new Complex(re, im);
    }

    public static Complex operator /(Complex x, Complex y)
    {
        if (x is null | y is null) return null;

        double re = (x.a * y.a + x.b * y.b) / (y.a * y.a + y.b * y.b);
        double im = (x.b * y.a - x.a * y.b) / (y.a * y.a + y.b * y.b);

        if (double.IsNaN(re) | double.IsNaN(im))
        {
            throw new DivideByZeroException();
        }
        return new Complex(re, im);
    }



    // Сравнение


    public static bool operator ==(Complex x, Complex y)
    {
        if (x is null && y is null) return true;
        if (x is null | y is null) return false;
        return x.Equals(y);
    }

    public static bool operator !=(Complex x, Complex y)
    {
        if (x is null && y is null) return false;
        if (x is null | y is null) return true;
        return !x.Equals(y);
    }


    public bool Equals(Complex x)
    {
        if (ReferenceEquals(this, x)) return true;

        if (x is null) return false;

        return a == x.a && b == x.b;
    }

   

    public override bool Equals(object obj)
    {
        return Equals(obj as Complex);
    }


    public override int GetHashCode()
    {
        return a.GetHashCode() ^ b.GetHashCode();
    }





    public override string ToString()
    {
        string str = "";

        double A = Math.Round(a, 4);
        double B = Math.Round(b, 4);

        if (A != 0 | B == 0)
        {
            str += A.ToString();
        }

        if (B > 0)
        {
            if (A == 0)
            {
                if (B == 1) str += "i";
                else str += B.ToString() + "i";
            }
            else
            {
                if (B == 1) str += " + i";
                else str += " + " + B.ToString() + "i";
            }
            
        }

        if (B < 0)
        {
            if (B == -1) str += " - i";
            else str += " - " + (-B).ToString() + "i";
        }
        

        return str;
    }


}

