using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais"); 
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count(); ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count(); matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                         sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                         random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                        
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.Moyenne(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.Moyenne(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");
            Console.Read();
        }
    }
}
// Classes fournies par HNI Institut
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}

class Classe
{
    public string nomClasse { get; private set; }
    public List<Eleve> eleves = new List<Eleve> ();
    public List<string> matieres = new List<string> ();
    public int[] maxEleve = new int[30];
    public int[] maxMatiere = new int[10];
    public int compteEleve = 0;
    public int compteMatiere = 0;


    public Classe(string nom)
    {
        nomClasse = nom;
    }
    public void ajouterEleve(string prenom, string nom)
    {
        try
        {
            eleves.Add(new Eleve(prenom + " " + nom));
            maxEleve[compteEleve] = 1;
            compteEleve++;
        }

        catch (Exception)
        {
            Console.WriteLine("Erreur nombre élèves");
        }
        
        
            
        
        
    }
    public void ajouterMatiere(string matiere)
    {
        try
        {
            matieres.Add(matiere);
            maxMatiere[compteMatiere] = 1;
            compteMatiere++;
        }
        catch (Exception)
        {
            Console.WriteLine("Erreur nombre Matière");
        }
        


    }

    public string Moyenne(int matiere)
    {
        float sommeEleve = 0;
        float sommeClasse = 0;
        int nbNotes = 0;
        int nbEleves = 0;
        float moyenneEleve = 0;
        float moyenneClasse = 0;
        foreach (Eleve eleve in eleves)
        {
            sommeEleve = 0;
            nbNotes = 0;
            foreach (Note note in eleve.notes)
            {
                if (note.matiere == matiere)
                {
                        sommeEleve = sommeEleve + note.note;
                        nbNotes++;
                }
               
            }
            moyenneEleve = sommeEleve / nbNotes;
            sommeClasse = sommeClasse + moyenneEleve;
            nbEleves++;


        }
        moyenneClasse = sommeClasse / nbEleves;
        string strMoyenne = String.Format("{0:N2}", moyenneClasse);
        return strMoyenne;




    }
    public string Moyenne()
    {
        float sommeEleve = 0;
        float sommeClasse = 0;
        int nbNotes = 0;
        int nbEleves = 0;
        float moyenneEleve = 0;
        float moyenneClasse = 0;
        foreach (Eleve eleve in eleves)
        {
            sommeEleve = 0;
            nbNotes = 0;
            foreach (Note note in eleve.notes)
            {
                sommeEleve = sommeEleve + note.note;
                nbNotes++;

            }
            moyenneEleve = sommeEleve / nbNotes;
            sommeClasse = sommeClasse + moyenneEleve;
            nbEleves++;


        }
        moyenneClasse = sommeClasse / nbEleves;
        string strMoyenne = String.Format("{0:N2}", moyenneClasse);
        return strMoyenne;
    }
}
class Eleve
{
    public string prenom { get; private set; }
    public string nom { get; private set; }

    public List<Note> notes = new List<Note> ();

    public int[] maxNotes = new int[200];

    public int compteNote = 0;

    public Eleve(string nomEleve)
    {
        string[] nomSepare = nomEleve.Split(' ');
        prenom = nomSepare[0];
        nom = nomSepare[1];
    }
    public void ajouterNote(Note nvlNote)
    {
        try
        {
            notes.Add(nvlNote);
            maxNotes[compteNote] = 1; 
            compteNote++;

        }
        catch (Exception)
        {
            Console.WriteLine("Erreur nombre notes");
        }
        

    }

    public string Moyenne()
    {
        float somme = 0;
        int nbNotes = 0;
        float moyenne = 0;
        foreach (Note note in notes)
        {
            somme = somme + note.note;
            nbNotes++;
        }
        moyenne = somme / nbNotes;
        string strMoyenne = String.Format("{0:N2}", moyenne);
        return strMoyenne;
    }
    public string Moyenne(int matiere)
    {
        float somme = 0;
        int nbNotes = 0;
        float moyenne = 0;
        foreach (Note n in notes)
        {
            if (n.matiere == matiere)
            {
                somme = somme + n.note;
                nbNotes++;
            }
        }
        moyenne = somme / nbNotes;
        string strMoyenne = String.Format("{0:N2}", moyenne);
        return strMoyenne;
    }
}

