using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Common.Domain
{
    public abstract class BaseEntity
    {
        [ColumnAttribute(Name = "PK_ID")]
        public int? Id { get; set; }

        [ColumnAttribute(Name = "SYSTEM_INSERT_DATETIME")]
        public DateTime? SystemInsertDateTime { get; set; }

        [ColumnAttribute(Name = "SYSTEM_UPDATE_DATETIME")]
        public DateTime? SystemUpdateDateTime { get; set; }

        [ColumnAttribute(Name = "SYSTEM_STATUS")]
        public int? SystemSatus { get; set; }
    }
}
