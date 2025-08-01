using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class PackingAssortmentDetail
    {
        public int Id { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public int? NoOfGarments { get; set; }
        public int? PackingAssortmentId { get; set; }
    }
}
