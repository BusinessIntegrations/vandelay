#region Using
using System.Data;
using Orchard.Data.Migration;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries {
    public class Migrations : DataMigrationImpl {
        private const string ColumnName = nameof(FaviconSettingsPartRecord.FaviconUrl);
        private const string FaviconSettingsPartRecordName = nameof(FaviconSettingsPartRecord);

        #region Methods
        public int Create() {
            SchemaBuilder.CreateTable(FaviconSettingsPartRecordName,
                table => table.ContentPartRecord()
                    .Column<string>(ColumnName));
            return 1;
        }

        public int UpdateFrom1() {
            SchemaBuilder.AlterTable(FaviconSettingsPartRecordName,
                command => command.AlterColumn(ColumnName,
                    columnCommand => columnCommand.WithType(DbType.String)
                        .Unlimited()));
            return 2;
        }
        #endregion
    }
}
