using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        public KutyafajtaSQL(string connstring)
        {
            connString = connstring;
            kutyafajtak = new List<Kutyafajta>();
            Lekerdezes();
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

    }
}
