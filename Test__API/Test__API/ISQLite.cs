using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test__API
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
