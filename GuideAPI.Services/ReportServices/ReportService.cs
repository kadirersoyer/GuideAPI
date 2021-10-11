using GuideAPI.Entities.Entities;
using GuideAPI.Mapper;
using GuideAPI.Models.Report;
using GuideAPI.Repositories;
using GuideAPI.Repositories.UnitOfWork;
using GuideAPI.Services.PersonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Services.ReportServices
{
    public class ReportService : IReportService
    {
        private readonly IAutoMapper autoMapper;
        private readonly IUnitofWork unitofWork;
        private readonly IPersonService personService;
        private readonly IRepository<Report> reportRepository;

        public ReportService(IUnitofWork unitofWork, IAutoMapper autoMapper)
        {
            this.autoMapper = autoMapper;
            this.unitofWork = unitofWork;
            this.reportRepository = this.unitofWork.GetRepository<Report>();

        }
        public void AddReportRequest(ReportDto reportDto)
        {
            var entity = autoMapper.Map<ReportDto, Report>(reportDto);
            reportRepository.Add(entity);
            unitofWork.Save();
        }

        public List<ReportResponseDto> GetReportResponses()
        {
            var reports = reportRepository.GetList();
            var entities = autoMapper.MapCollection<Report, ReportDto>(reports);

            return entities;
        }
    }
}
