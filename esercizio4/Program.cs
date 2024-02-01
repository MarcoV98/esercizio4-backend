using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");

            Console.Write("Inserisci la tua scelta: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Logout();
                        break;
                    case 3:
                        VerificaOraDataLogin();
                        break;
                    case 4:
                        ListaAccessi();
                        break;
                    case 5:
                        Console.WriteLine("Grazie per aver utilizzato il programma. Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Inserisci un numero valido.");
            }

        } while (choice != 5);
    }

    static class Utente
    {
        public static string Username { get; private set; }
        public static DateTime OraDataLogin { get; private set; }
        public static List<DateTime> StoricoAccessi { get; } = new List<DateTime>();

        public static void Login()
        {
            Console.Write("Inserisci username: ");
            string username = Console.ReadLine();

            Console.Write("Inserisci password: ");
            string password = Console.ReadLine();

            Console.Write("Conferma password: ");
            string confermaPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(username) && password == confermaPassword)
            {
                Username = username;
                OraDataLogin = DateTime.Now;
                StoricoAccessi.Add(OraDataLogin);
                Console.WriteLine("Login effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Errore nel login. Riprova.");
            }
        }

        public static void Logout()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Username = null;
                OraDataLogin = DateTime.MinValue;
                Console.WriteLine("Logout effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile effettuare il logout.");
            }
        }

        public static void VerificaOraDataLogin()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Console.WriteLine($"Utente loggato: {Username}");
                Console.WriteLine($"Ora e data di login: {OraDataLogin}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile verificare ora e data di login.");
            }
        }

        public static void ListaAccessi()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Console.WriteLine($"Storico accessi di {Username}:");
                foreach (var accesso in StoricoAccessi)
                {
                    Console.WriteLine(accesso);
                }
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile visualizzare la lista degli accessi.");
            }
        }
    }
}
