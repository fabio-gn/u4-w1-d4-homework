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
            //List<Accesso> CronologiaAccessi = new List<Accesso>();
            CronologiaAccessi = new List<Accesso> { };
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
            catch (Exception ex)
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
                Console.Clear();
                populateMenu();
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
            else if (choice == 4)
            {
                PrintAccessList();
            }
            else if(choice == 5)
            {
                Exit();
            }

        }
        static private bool IsLoggedIn { get; set; }

        static private void Login()
        {
            if (!IsLoggedIn)
            {
                Console.WriteLine("Username:");
                string userName = Console.ReadLine();
                Console.WriteLine("Password");
                string password = Console.ReadLine();
                Console.WriteLine("conferma password:");
                string passwordConfirm = Console.ReadLine();
                if (password.Equals(passwordConfirm))
                {   
                    //resetta schermata menù
                    Console.Clear();
                    populateMenu();

                    Console.WriteLine("Sei stato autenticato.");
                    IsLoggedIn = true;
                    DataOraAccesso = DateTime.Now;
                    Accesso newAccess = new Accesso(userName, $"{DataOraAccesso.Day}/{DataOraAccesso.Month}/{DataOraAccesso.Year}", $"{DataOraAccesso.Hour}");
                    
                    CronologiaAccessi.Add(newAccess);
                    

                    Scegli();
                }
                else
                {
                    //resetta schermata menù
                    Console.Clear();
                    populateMenu();

                    Console.WriteLine("Autenticazione fallita.");
                    Scegli();
                }
            }
            else
            {
                //resetta schermata menù
                Console.Clear();
                populateMenu();

                Console.WriteLine("Hai già effettuato il login");
                Scegli();
            }
            

        }
        static private void Logout()
        {
            if (IsLoggedIn)
            {
                //resetta schermata menù
                Console.Clear();
                populateMenu();

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

                    //resetta schermata menù
                    Console.Clear();
                    populateMenu();

                    Console.WriteLine("sei stato sloggato correttamente");
                    Scegli();
                }
                else if (ans == "n")
                {
                    //resetta schermata menù
                    Console.Clear();
                    populateMenu();

                    Console.WriteLine("come non detto");
                    Scegli();
                }
                else
                {
                    //resetta schermata menù
                    Console.Clear();
                    populateMenu();

                    Console.WriteLine("invalid character, try again");
                    Scegli();
                }


            }
            else
            {   //resetta schermata menù
                Console.Clear();
                populateMenu();

                Console.WriteLine("Non sei ancora loggato!");
                Scegli();
            }

        }
        static private DateTime DataOraAccesso { get; set; }
        static private void LoginTime()
        {
            if (IsLoggedIn)
            {
                //resetta schermata menù
                Console.Clear();
                populateMenu();

                Console.WriteLine($"hai eseguito l'ultimo accesso il {DataOraAccesso.Day}/{DataOraAccesso.Month}/{DataOraAccesso.Year} alle {DataOraAccesso.TimeOfDay}");
                Scegli();
            }
            else
            {
                Console.Clear();
                populateMenu();

                Console.WriteLine("non sei ancora loggato!");
                Scegli();
            }

        }
        static private List<Accesso> CronologiaAccessi { get; set; }
        static private void PrintAccessList()
        {
            if( CronologiaAccessi != null)
            {
                //resetta schermata menù
                Console.Clear();
                populateMenu();

                Console.WriteLine("--------------Lista Accessi--------------");
                for (int i = 0;i <  CronologiaAccessi.Count;i++)
                {
                    Console.WriteLine($"{CronologiaAccessi[i].NomeUtente} il {CronologiaAccessi[i].Data} alle {CronologiaAccessi[i].Ora}");
                }
                Console.WriteLine("-----------------------------------------");
                Scegli();
            }
            else
            {   //resetta schermata menù
                Console.Clear();
                populateMenu();

                Console.WriteLine("non è stato eseguito ancora nessun accesso.");
                Scegli();
            }
        }
        static private void Exit()
        {   
            Console.Clear();
            populateMenu();
            Console.WriteLine("Sei sicuro di voler uscire dall'applicazione? (y/n)");
            string choice = Console.ReadLine();
            if (choice == "y") { Console.Clear(); }
            else if (choice == "n") {
                Console.Clear();
                populateMenu();
                Console.WriteLine("come non detto");
                Scegli();
            }
            else {
                Console.Clear();
                populateMenu();
                Scegli();
            }
        }


    }

    public class Accesso
    {
        public string NomeUtente { get; set; }
        public string Data { get; set; }
        public string Ora { get; set; }
        public Accesso(string nome, string data, string ora)
            {
                this.NomeUtente = nome;
                this.Data = data;
                this.Ora = ora;
               
            }
    }
}
