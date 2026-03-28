using Microsoft.EntityFrameworkCore;
using ServicePro.Core.DTOs.Inbound;
using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Entities;
using ServicePro.Core.Interfaces;
using ServicePro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Repositories
{
    public class CareLogRepository : ICareLogRepository
    {
        private readonly AppDbContext _context;

        public CareLogRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CarePlanResponse>> GetCarePlanByClientId(Guid clientId)
        {
            var result = await _context.CarePlanSpResults
                .FromSqlRaw("EXEC sp_GetCarePlanByClientId @ClientId = {0}", clientId)
                .ToListAsync();

            var grouped = result
                .GroupBy(x => x.CareLogId)
                .Select(g => new CarePlanResponse
                {
                    CareLogId = g.Key,
                    ClientId = g.First().ClientId,
                    Title = g.First().Title,
                    Status = g.First().Status,
                    StartDate = g.First().StartDate,
                    EndDate = g.First().EndDate,

                    Activities = g.Select(a => new ActivityResponse
                    {
                        ActivityId = a.ActivityId,
                        Type = a.Type,
                        Description = a.Description,
                        StartDate = a.ActivityStartDate,
                        EndDate = a.ActivityEndDate,
                        Days = a.Days.Split(',').ToList()
                    }).ToList()
                })
                .ToList();

            return grouped;
        }
        public async Task AddCareLogAsync(CareLogRequest request)
        {
            var careLog = new CareLog
            {
                CareLogId = Guid.NewGuid(),
                ClientId = request.ClientId,
                Title = request.Title,
                Status = request.Status,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            _context.CareLogs.Add(careLog);

            foreach (var act in request.Activities)
            {
                var activity = new CareLogActivity
                {
                    ActivityId = Guid.NewGuid(),
                    CareLogId = careLog.CareLogId,
                    Type = act.Type,
                    Description = act.Description,
                    StartDate = act.StartDate,
                    EndDate = act.EndDate,
                    Days = string.Join(",", act.Days)
                };

                _context.CareLogActivities.Add(activity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
