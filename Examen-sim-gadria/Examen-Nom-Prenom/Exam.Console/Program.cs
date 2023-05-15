// See https://aka.ms/new-console-template for more information
using Examen.ApplicationCore.Domain;
using Examen.Infrastructure;

Console.WriteLine("Hello, World!");
Banque banque1 = new Banque
{
    
    Email = "ogadria@gmail.com",
    Nom = "oussama",
    Rue = "djerba,tunisia,en face de casino",
    Ville = "Djerba",

};
Banque banque2 = new Banque
{
   
    Email = "o1gadria@gmail.com",
    Nom = "oussamaaaa",
    Rue = "djerbaaaa,tunisia,en face de casino",
    Ville = "Djerbaaa",

};
ExamContext ec = new ExamContext();
ec.Banque.Add(banque1);
ec.Banque.Add(banque2);
ec.SaveChanges();
