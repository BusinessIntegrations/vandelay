#region Using
using System.Data;
using Orchard.Data.Migration;
#endregion

namespace Vandelay.Industries {
    public class Migrations : DataMigrationImpl {
        #region Methods
        public int Create() {
            SchemaBuilder.CreateTable(Constants.FaviconSettingsPartRecordName,
                table => table.ContentPartRecord()
                    .Column<string>(Constants.ColumnName));
            return 1;
        }

        public int UpdateFrom1() {
            SchemaBuilder.AlterTable(Constants.FaviconSettingsPartRecordName,
                command => command.AlterColumn(Constants.ColumnName,
                    columnCommand => columnCommand.WithType(DbType.String)
                        .Unlimited()));
            return 2;
        }
        #endregion
    }
}
