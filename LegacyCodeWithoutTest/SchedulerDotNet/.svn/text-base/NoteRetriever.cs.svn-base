using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SchedulerDotNet
{
    public class NoteRetriever {

	    public static String GetNote(DateTime date) {
            SQLiteConnection cnn = new SQLiteConnection("Data Source=" + "C:\\ProductionSchedulerDotNet.db");  
                try {
                    cnn.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(cnn);
                    mycommand.CommandText = "Select note from event where date=?";
                    mycommand.Parameters.Add(new SQLiteParameter(System.Data.DbType.AnsiString, date.ToString("dd/MM/yyyy")));
                    object value = mycommand.ExecuteScalar();
                    return value as string;
                }
                finally {
                    if(cnn != null) {
                        cnn.Close();
                    }
                }
        }
    }
}
