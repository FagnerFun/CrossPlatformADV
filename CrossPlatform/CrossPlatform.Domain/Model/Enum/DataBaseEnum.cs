using System.ComponentModel;

namespace CrossPlatform.Domain.Model.Enum
{
    public enum DataBaseEnum
    {
        [Description("Use SQLite for relational data base")]
        SQLite,
        [Description("Use Lite DB for database not relational (NoSQL)")]
        LiteDB
    }
}
