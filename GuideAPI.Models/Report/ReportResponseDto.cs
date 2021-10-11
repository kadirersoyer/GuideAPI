using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Models.Report
{
    public class ReportResponseDto
    {
        /// <summary>
        ///  Get Total Person Count Of Requested Location
        /// </summary>
        public int TotalPersonCount { get; set; }

        /// <summary>
        ///  Get total Phone Number Count of Requested Location
        /// </summary>
        public int TotalPhoneNumberCount { get; set; }
    }
}
