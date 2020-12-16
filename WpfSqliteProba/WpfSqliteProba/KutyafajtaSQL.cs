using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSqliteProba
{
    public class KutyafajtaSQL
    {
        public class Kutyafajta
        {
            public int Id { get; set; }
            public string Nev { get; set; }
            public string Eredetinev { get; set; }

        }

        string connString = "";

        private List<Kutyafajta> kutyafajtak;
        public List<Kutyafajta> Kutyafajtak { get { return kutyafajtak; } }

        public DataTable KutyafajtakDT;

        public KutyafajtaSQL(string connstring)
        {
            connString = connstring;
            kutyafajtak = new List<Kutyafajta>();
            KutyafajtakDT = new DataTable();
            //Lekerdezes();
            LekerdezesDt();
            //UjKutyafajta("komondor", "komondor");
            //ModositKutyafajta(423, "kuvasz", "kuvasz");
            //ModositKutyafajta(425, "vizsla", "vizsla");
            //TorolKutyafajta(425);


        }

        private void Lekerdezes()
        {
            using (SQLiteConnection conn=new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand command=new SQLiteCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select * from kutyafajtak";
                    using (SQLiteDataReader reader=command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                kutyafajtak.Add(
                                    new Kutyafajta
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        Nev = reader["nev"].ToString(),
                                        Eredetinev=reader["eredetinev"].ToString()
                                    }
                                    );  

                            }

                        } else
                        {
                            MessageBox.Show("Nincs a feltételnek megfelelő adat!");
                        }

                    }

                }

            }
        }

        private void LekerdezesDt()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select * from kutyafajtak";

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        KutyafajtakDT.Load(reader);              
                    }

                }


            }
        }

        public void UjKutyafajta(string nev,string eredetinev)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand command=new SQLiteCommand(conn))
                {
                    command.CommandText = "INSERT INTO kutyafajtak (nev,eredetinev) VALUES(@nev,@eredetinev)";
                    command.Parameters.Add("@nev", DbType.String).Value = nev;
                    command.Parameters.Add("@eredetinev", DbType.String).Value = eredetinev;
                    
                    var sor=command.ExecuteNonQuery();
                    Debug.WriteLine($"Beillesztve:{sor} rekord.");
                    LekerdezesDt();

                }
            }
        }

        public void ModositKutyafajta(int id,string nev,string eredetinev)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand command=new SQLiteCommand(conn))
                {
                    command.CommandText = "UPDATE kutyafajtak SET nev=@nev,eredetinev=@eredetinev WHERE id=@id";
                    command.Parameters.Add("@nev", DbType.String).Value = nev;
                    command.Parameters.Add("@eredetinev", DbType.String).Value = eredetinev;
                    command.Parameters.Add("@id", DbType.Int32).Value = id;
                    var sor = command.ExecuteNonQuery();
                    Debug.WriteLine($"Módosítva:{sor} sor.");
                    LekerdezesDt();

                }
            }
        }

        public void TorolKutyafajta(int id)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand command=new SQLiteCommand(conn))
                {
                    command.CommandText = "DELETE FROM kutyafajtak WHERE id=@id";
                    command.Parameters.Add("@id", DbType.Int32).Value = id;
                    var sor = command.ExecuteNonQuery();
                    Debug.WriteLine($"Törölve:{sor} sor.");
                    LekerdezesDt();
                }
            }
        }

    }
}
