using System;

abstract class Personen
{
    protected string name;
    protected double gehalt;

    public abstract void Gehalt_Rueckgabe(double wert);
}

class Angestellter : Personen
{
    //Vorbereitung
    static int count;
    static Angestellter()
    {
        count = 1;
    }

    public Angestellter()
    {
        this.name = "Angestellter" + count;
        count++;
        this.gehalt = 0;
    }
    public override string ToString()
    {
      string _ausgabe_Angestellter;
      _ausgabe_Angestellter = this.name + " " + this.gehalt;
      return  _ausgabe_Angestellter;
    }

  public override void Gehalt_Rueckgabe(double wert)
  {  
       this.gehalt += wert;
  }
}

class Mitarbeiter : Personen
{
    //Vorbereitung
    static int count;
    static Mitarbeiter()
    {
        count = 1;
    }

    public Mitarbeiter()
    {
        this.name = "Mitarbeiter" + count;
        count++;
        this.gehalt = 0;
    }
 public override string ToString()
    {
      string _ausgabe_Mitarbeiter;
      _ausgabe_Mitarbeiter = this.name + " " + this.gehalt;
      return  _ausgabe_Mitarbeiter;
    }
public override void Gehalt_Rueckgabe(double wert)
  {  
   this.gehalt += wert;
  }
}

class Program
{
    static void Main()
    {
        //Angestellter a1 = new Angestellter();
        //Mitarbeiter m1 = new Mitarbeiter();

        //Array
        Personen[] p1 = new Personen[10];
        for(int i = 0; i < 10; i++)
        {
            if(i < 5)
            {
                p1[i] = new Angestellter();
                p1[i].Gehalt_Rueckgabe(50);
            }

            if(i >= 5)
            {
                p1[i] = new Mitarbeiter();
                p1[i].Gehalt_Rueckgabe(100);
            }
        }

        //Ausgaben
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(p1[i].ToString());
        }
    }
}