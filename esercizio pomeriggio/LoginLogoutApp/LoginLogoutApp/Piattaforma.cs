using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LoginLogoutApp
{
    static class Utente
    {
        static public void Start() 
        {
            populateMenu();
            Scegli();

        }
        static private void populateMenu()
        {
            Console.WriteLine(
                "===============OPERAZIONI==============\r\n" +
                "Scegli l’operazione da effettuare:\r\n" +
                "1.: Login\r\n" +
                "2.: Logout\r\n" +
                "3.: Verifica ora e data di login\r\n" +
                "4.: Lista degli accessi\r\n" +
                "5.: Esci\r\n" +
                "=================================="
                );
        }
        static private void Scegli()
        {   
            string scelta = Console.ReadLine();
            int choice = 0;
            try
            {
               choice = Convert.ToInt32(scelta);
            }
            catch( Exception ex ) 
            {
                Console.WriteLine(ex.Message);
                Scegli();
            }
            if (choice < 1 || choice > 5)
            {
                Console.WriteLine("Scelta non valida, prova di nuovo");
                Scegli();
            }
            else if (choice == 1)
            {
                Login();
            }
            else if (choice == 2)
            {
                Logout();
            }
            else if (choice == 3)
            {
                LoginTime();
            }

        }
        static private bool IsLoggedIn { get; set; }
        
        static private void Login() 
        {
            Console.WriteLine("Username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Password");
            string password = Console.ReadLine();
            Console.WriteLine("conferma password:");
            string passwordConfirm = Console.ReadLine();
            if(password.Equals(passwordConfirm)) 
            {
                Console.WriteLine("Sei stato autenticato.");
                IsLoggedIn = true;
                DataOraAccesso = DateTime.Now;
                Scegli();
            }
            else
            {
                Console.WriteLine("Autenticazione fallita.");
                Scegli();
            }

        }
        static private void Logout()
        {
            if (IsLoggedIn)
            {
                Console.WriteLine("sei sicuro di voler uscire? (y/n)");
                string ans = Console.ReadLine();
                //Console.WriteLine(ans);
                //char ans = ' ';
                //try
                //{
                //    ans = Convert.ToChar(risp);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Scegli();
                //}

                
                if (ans == "y")
                {
                    IsLoggedIn = false;
                     
                    Console.WriteLine("sei stato sloggato correttamente");
                    Scegli();
                }
                else if (ans == "n")
                {
                    Console.WriteLine("come non detto");
                    Scegli();
                }
                else
                {
                    Console.WriteLine("invalid character, try again");
                    Scegli();
                }


            }
            else
            {
                Console.WriteLine("Non sei ancora loggato!");
                Scegli();
            }

        }
        static private DateTime DataOraAccesso { get; set; }
        static private void LoginTime()
        {
            Console.WriteLine($"hai eseguito l'ultimo accesso il {DataOraAccesso.Day} {DataOraAccesso.Month} {DataOraAccesso.Year} alle {DataOraAccesso.Hour}");
            Scegli();
        }

    }
}
