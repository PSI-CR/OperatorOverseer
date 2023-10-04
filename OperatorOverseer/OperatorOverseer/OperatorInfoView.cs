using AuditLibrary.OperatorInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverseer
{
    public class OperatorInfoView
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Device { get; set; }
        public string Permissions { get; set; }
        public OperatorInfoView(OperatorInfo operatorInfo)
        {
            Number = operatorInfo.Number;
            Name = operatorInfo.Name;
            LastName = operatorInfo.LastName;
            Device = operatorInfo.Device;
            Permissions = String.Join(", ", operatorInfo.Permissions.Where(x => x.Value).Select(y => y.Key));
        }
    }
}
