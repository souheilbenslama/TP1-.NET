using System;
using System.Collections.Generic;

namespace TP1
{


    class Test
    {

        public static void Main (String [] args)
        {

            CompteCourant c1 = new CompteCourant(0, "Nicolas", 2000);
            CompteEpargne c2 = new CompteEpargne(0, "Nicolas", 0.02);
            CompteCourant c3 = new CompteCourant(0, "Jérémie", 500);


            c1.debiter(100);
            c1.crediter(50);
            c2.debiter( c1, 20);
            c2.debiter(100);
            c1.debiter(c2, 20);
            c3.crediter(500);
            c3.crediter(c1, 200);

            c2.verserAbondemant();



            System.Console.WriteLine("Solde compte courant de Nicolas : " + (double)c1.getSolde());
            System.Console.WriteLine("Solde compte epargne de Nicolas : " + (double)c2.getSolde());
            System.Console.WriteLine("Solde compte courant de Jérémie : " + (double)c3.getSolde());

            System.Console.WriteLine();
            System.Console.WriteLine();


            c1.afficheInfo();
            c2.afficheInfo(); 




        }


    }



    class Compte
    {
        protected double solde;
        protected string proprietaire;
        protected List<Operation> operations;

        public Compte(double solde, string proprietaire)
        {
            this.solde = solde;
            this.proprietaire = proprietaire;
            this.operations = new List<Operation>();
        }

        public void crediter(double somme)
        {
            this.solde -= somme;
            this.operations.Add(new Operation(somme, "credit")); 
        }

        public void crediter(Compte c, double somme)
        {
            this.crediter(somme);
            c.debiter(somme);


        }

        public void debiter(double somme)
        {

            this.solde += somme;
            this.operations.Add(new Operation(somme, "debit"));

        }
        public void debiter(Compte c, double somme)
        {
            this.debiter(somme);
            c.crediter(somme);

        }

        public double getSolde()
        {
            return this.solde;
        }

        public string getProprietaire()
        {
            return this.proprietaire;
        }



        public void afficheInfo()
        {
            System.Console.WriteLine("Resumé de compte de " + this.getProprietaire());
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("Compte  de " + this.getProprietaire());
            System.Console.WriteLine("Solde : " + this.getSolde());
            this.afficheOp();
            System.Console.WriteLine("*****************************");
        }



        public void   afficheOp()
        {
            System.Console.WriteLine("Operations  :   " );

            foreach(Operation e in this.operations)
            {
                if (e.getType().Equals("debit"))
                {
                    System.Console.WriteLine("+ " + e.getMontant());
                }
                else {

                    System.Console.WriteLine("- " + e.getMontant());

                }

            }; 

        }

    }


    class CompteCourant : Compte
    {

        private readonly double decouvert;

        public CompteCourant(double solde, string proprietaire, double decouvert) : base(solde, proprietaire)
        { 
            this.decouvert = decouvert;

        }


        public double getDecouvet()
        {
            return this.decouvert;
        }


         new  public void afficheInfo()
        {
            System.Console.WriteLine("   Resumé de compte   de " + this.getProprietaire());
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("   Compte Courant   de " + this.getProprietaire());
            System.Console.WriteLine("   Solde : " + this.getSolde());
            System.Console.WriteLine("   découvert autorisé   : " + this.getDecouvet());
            base.afficheOp();
            System.Console.WriteLine("*****************************");
        }

    }

    class CompteEpargne : Compte
    {
        private double taux;
        public CompteEpargne(double solde, string proprietaire, double taux) : base(solde, proprietaire)
        {
            this.taux = taux;

        }

        public double getTaux()
        {
            return this.taux; 
        }


        public void verserAbondemant()
        {
            this.solde += this.getSolde() * this.getTaux(); 
        }

         new public void afficheInfo()
        {
            System.Console.WriteLine("   Resumé de compte épargne  de " + this.getProprietaire());
            System.Console.WriteLine("########################################");
            System.Console.WriteLine("   Compte Epargne  entreprise  de " + this.getProprietaire());
            System.Console.WriteLine("   Solde : " + this.getSolde());
            System.Console.WriteLine("   taux  :" + this.getTaux());

            this.afficheOp();

            System.Console.WriteLine("########################################");
        }
    }

    class Operation{

        private double montant;
        private String type ;  

        public Operation(double m,string s)
        {
            this.montant = m;
            this.type = s ;
       
        }

        public String getType()
        {
            return this.type; 
        }

        public double getMontant()
        {

            return this.montant; 
        }

}

}
