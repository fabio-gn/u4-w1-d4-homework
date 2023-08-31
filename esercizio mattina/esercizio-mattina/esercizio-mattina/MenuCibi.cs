using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_mattina
{
    internal class MenuCibi
    {
        static public void Start()
        {
            PopulateMenuItems();
            CreaMenu();
            Scegli();
        }
        static private List<IMenuItem> menuItems = new List<IMenuItem>();
        static private void PopulateMenuItems()
        {
            IMenuItem cocacola = new Prodotto("Coca Cola 150 ml", 2.50);
            menuItems.Add(cocacola);
            IMenuItem insalataDiPollo = new Prodotto("Insalata di pollo", 5.20);
            menuItems.Add(insalataDiPollo);
            IMenuItem pizzaMargherita = new Prodotto("Pizza Margherita", 10.00);
            menuItems.Add(pizzaMargherita);
            IMenuItem pizza4Formaggi = new Prodotto("Pizza 4 Formaggi", 12.50);
            menuItems.Add(pizza4Formaggi);
            IMenuItem pizzaPatatineFritte = new Prodotto("Pizza patatine fritte", 3.50);
            menuItems.Add(pizzaPatatineFritte);
            IMenuItem insalataDiRiso = new Prodotto("Insalata di riso", 8.00);
            menuItems.Add(insalataDiRiso);
            IMenuItem fruttaDiStagione = new Prodotto("Frutta di stagione", 5.00);
            menuItems.Add(fruttaDiStagione);
            IMenuItem pizzaFritta = new Prodotto("Pizza fritta", 5.00);
            menuItems.Add(pizzaFritta);
            IMenuItem piadinaVeg = new Prodotto("Piadina vegetariana", 6.00);
            menuItems.Add(piadinaVeg);
            IMenuItem paninoHamburger = new Prodotto("Panino hamburger", 7.90);
            menuItems.Add(paninoHamburger);

        }
        static private List<IMenuItem> PiattiScelti = new List<IMenuItem>();
        static private void CreaMenu()
        {
            Console.WriteLine("===========MENU============");
            for(int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i+1}:  {menuItems[i].nomeArticolo} (€ {menuItems[i].prezzo})");
            }
            Console.WriteLine("11:  Stampa conto finale e conferma");
            Console.WriteLine("===========MENU============");
        }

        static private void Scegli()
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }
            
            if( num < 1 || num > menuItems.Count + 1)
            {
                Console.WriteLine("scelta non valida, riprova");
                Scegli();
            }
            
            else if (num == menuItems.Count + 1)
            {
                Console.WriteLine(  "----------------------- \r\n ------------------------");
                Console.WriteLine("Hai ordinato:");
                double total = 0;
                for(int i = 0; i < PiattiScelti.Count; i++ )
                {
                    Console.WriteLine($"{i + 1}:  {PiattiScelti[i].nomeArticolo} (€ {PiattiScelti[i].prezzo})");
                    total += PiattiScelti[i].prezzo;
                }
                Console.WriteLine(  $"il totale è: {total + 3} euro \r\n desideri altro? digita nuovamente");

                Scegli();
            }
            else
            {
                PiattiScelti.Add(menuItems[num - 1]);
                Console.WriteLine("desideri altro? digita nuovamente");
                Scegli();
            }
        }
        
    }
}
