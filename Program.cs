using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;userid=root;
            password=;database=klubb";

            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            MySqlCommand cmd = new MySqlCommand();
            

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                cmd.Connection = conn;
                Console.WriteLine("MySQL version : {0}", conn.ServerVersion);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MySQL version: " + conn.ServerVersion);
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine("[1]Skriv ut medlemarna.");
                    Console.WriteLine("[2]Lägg till Henrik i tabellen.");
                    Console.WriteLine("[3]Lägg till medlem.");
                    Console.WriteLine("[4]Ändra Henriks telefon nummer till 098765.");
                    Console.WriteLine("[5]Ändra en medlems telefon nummer.");
                    Console.WriteLine("[6]Ta bort Henrik från tabellen.");
                    Console.WriteLine("[7]Avsluta.");

                    string menySelection = Console.ReadLine();

                    if (menySelection == "1")
                    {
                        Console.Clear();
                        cmd.CommandText = "select * from medlem order by medlemsnummer;";
                        cmd.Prepare();

                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine("Medlemsnummer: " + rdr.GetInt32(0) + " Namn: " + rdr.GetString(1) + " Telefon: " + rdr.GetInt32(2));
                        }
                        rdr.Close();
                    }

                    else if (menySelection == "2")
                    {
                        Console.Clear();
                        cmd.CommandText = "insert into medlem(medlemsnummer, namn, telefon) values(20, 'Henrik', 0123456);";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Henrik är nu tillagd i tabellen medlem.");
                    }

                    else if (menySelection == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Mata in önskat medlemsnummer på den nya medlemmen.");
                        string nummer = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Mata in önskat namn på den nya medlemmen.");
                        string namn = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Mata in önskat telefonnummer på den nya medlemmen.");
                        string telefon = Console.ReadLine();
                        cmd.CommandText = "insert into medlem(medlemsnummer, namn, telefon) values(@nummer, @namn, @telefon);";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@nummer", nummer);
                        cmd.Parameters.AddWithValue("@namn", namn);
                        cmd.Parameters.AddWithValue("@telefon", telefon);
                        cmd.ExecuteNonQuery();

                    }

                    else if (menySelection == "4")
                    {
                        Console.Clear();
                        cmd.CommandText = "update medlem set telefon=098765 where namn='henrik';";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Henriks telefon nummer är nu 098765.");
                    }

                    else if (menySelection == "5")
                    {
                        Console.Clear();
                        Console.WriteLine("Mata in medlemsnummret på den medlem vars telefonnummer ska ändras.");
                        string nummer = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Mata in det nya telefonnummret.");
                        string telefon = Console.ReadLine();
                        cmd.CommandText = "update medlem set telefon=@telefon where medlemsnummer=@nummer;";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@telefon", telefon);
                        cmd.Parameters.AddWithValue("@nummer", nummer);
                    }

                    else if (menySelection == "6")
                    {
                        Console.Clear();
                        cmd.CommandText = "delete from medlem where namn='henrik';";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Nu är Henrik borttagen ur tabellen.");
                    }

                    else if (menySelection == "7")
                    {
                        Console.Clear();
                        break;
                    }

                    Console.ReadKey();
                }
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
