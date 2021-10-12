using GuideAPI.Entities.Entities;
using GuideAPI.Mapper;
using GuideAPI.Models.Report;
using GuideAPI.Repositories;
using GuideAPI.Repositories.UnitOfWork;
using GuideAPI.Services.PersonServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Services.ReportServices
{
    public class ReportService : IReportService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ReportService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public void AddReportRequest(ReportDto reportDto)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var unitOfWorkService = scope.ServiceProvider.GetRequiredService<IUnitofWork>();
                var autoMapperService = scope.ServiceProvider.GetRequiredService<IAutoMapper>();
                var reportRepository = unitOfWorkService.GetRepository<Report>();

                var entity = autoMapperService.Map<ReportDto, Report>(reportDto);
                reportRepository.Add(entity);
                unitOfWorkService.Save();
            }
        }

        public List<ReportResponseDto> GetReportResponses()
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var unitOfWorkService = scope.ServiceProvider.GetRequiredService<IUnitofWork>();
                var autoMapperService = scope.ServiceProvider.GetRequiredService<IAutoMapper>();
                var reportRepository = unitOfWorkService.GetRepository<Report>();

                var reports = reportRepository.GetList();
                var entities = autoMapperService.MapCollection<Report, ReportDto>(reports);

                return new List<ReportResponseDto>(); 
            }
        }
    }
}
