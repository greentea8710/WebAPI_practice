using Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    /// <summary>
    /// 班級表
    /// </summary>
    public class TClass:CUD
    {

        public string Name { get; set; }

        //一對多:一個班級對到多個學生

        public virtual List<TStudent> Students { get; set; }
    }
}
