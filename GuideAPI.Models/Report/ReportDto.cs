using GuideAPI.Domain.Person;
using GuideAPI.Domain.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Models.Report
{
    public class ReportDto : BaseDto
    {
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
}
