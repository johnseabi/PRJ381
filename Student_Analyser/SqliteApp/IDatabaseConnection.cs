using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqliteApp
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
