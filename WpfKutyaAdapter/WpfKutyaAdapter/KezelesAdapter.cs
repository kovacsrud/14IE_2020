using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKutyaAdapter
{
    public class KezelesAdapter
    {
        string connString;
        DataTable kutyakezelesadatok;

        public DataView Kutyakezelesadatok { get { return kutyakezelesadatok.DefaultView; } }

        SQLiteDataAdapter adapter;
        SQLiteConnection conn;

        public KezelesAdapter(string connstring)
        {
            connString = connstring;
            kutyakezelesadatok = new DataTable();
            conn = new SQLiteConnection(connString);
            adapter = new SQLiteDataAdapter("", conn);

            adapter.SelectCommand = new SQLiteCommand(conn);
            adapter.SelectCommand.CommandText = "select * from kutyak";

            adapter.InsertCommand = new SQLiteCommand(conn);
            adapter.InsertCommand.CommandText = "insert into kutyak " +
                "(fajtaid,nevid,eletkor,utolsoellenorzes) " +
                "values(@fajtaid,@nevid,@eletkor,@utolsoellenorzes)";
            adapter.InsertCommand.Parameters.Add("@fajtaid", DbType.Int32, 0, "fajtaid");
            adapter.InsertCommand.Parameters.Add("@nevid",DbType.Int32,0,"nevid");
            adapter.InsertCommand.Parameters.Add("@eletkor",DbType.Int32,0,"eletkor");
            adapter.InsertCommand.Parameters.Add("@utolsoellenorzes",DbType.String,0,"utolsoellenorzes");



        }

    }
}