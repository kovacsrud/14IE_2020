using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKutyaAdapter
{
    public class NevAdapter
    {
        string connString;
        DataTable kutyanevadatok;
        public DataView Kutyanevadatok { get { return kutyanevadatok.DefaultView; } }
        SQLiteDataAdapter adapter;
        SQLiteConnection conn;

        public NevAdapter(string connstring)
        {
            connString = connstring;
            conn =new SQLiteConnection(connString);
            adapter = new SQLiteDataAdapter("", conn);

            adapter.SelectCommand = new SQLiteCommand(conn);
            adapter.SelectCommand.CommandText = "select * from kutyanevek";

            adapter.InsertCommand = new SQLiteCommand(conn);
            adapter.InsertCommand.CommandText = "insert into kutyanevek " +
                "(kutyanev) " +
                "values(@kutyanev)";
            adapter.InsertCommand.Parameters.Add("@kutyanev", DbType.String, 0, "kutyanev");

            adapter.UpdateCommand = new SQLiteCommand(conn);
            adapter.UpdateCommand.CommandText = "update kutyanevek" +
                " set kutyanev=@kutyanev " +
                " where id=@id";

        }
    }
}