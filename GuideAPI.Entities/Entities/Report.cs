using GuideAPI.Domain.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Entities.Entities
{
    public class Report: BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
}
