using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Common.Domain
{
    public abstract class BasicEntity : BaseEntity
    {
        [ColumnAttribute(Name = "CREATE_USER")]
        public string CreateUser { get; set; }

        [ColumnAttribute(Name = "CREATE_DATETIME")]
        public DateTime? CreateDateTime { get; set; }

        [ColumnAttribute(Name = "MODIFY_USER")]
        public string ModifyUser { get; set; }

        [ColumnAttribute(Name = "MODIFY_DATETIME")]
        public DateTime? ModifyDateTime { get; set; }
    }
}
