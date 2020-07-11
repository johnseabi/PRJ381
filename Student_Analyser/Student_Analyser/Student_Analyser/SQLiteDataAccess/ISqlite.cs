using SQLite;

namespace Student_Analyser
{
   public  interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
