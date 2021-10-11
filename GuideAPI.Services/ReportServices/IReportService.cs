using GuideAPI.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Services.ReportServices
{
    public interface IReportService
    {
        /// <summary>
        ///  Add Report Request
        /// </summary>
        /// <param name="reportDto"></param>
        void AddReportRequest(ReportDto reportDto);

        /// <summary>
        ///  Get Report Response
        /// </summary>
        /// <returns></returns>
        List<ReportResponseDto> GetReportResponses();
    }
}
