using ServicePro.Core.DTOs.Inbound;
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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateSchedule(ScheduleRequestDto request)
        {
            var schedule = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                ClientId = request.ClientId,
                LocationId = request.LocationId,
                CarePlanId = request.FhirCarePlanId,
                TimeZone = request.TimeZone,

                RecurrenceType = request.Recurrence.Type,
                Interval = request.Recurrence.Interval,
                MonthlyDayOfMonth = request.Recurrence.MonthlyDayOfMonth,
                RepeatUntil = request.Recurrence.RepeatUntil,

                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsArchived = false
            };

            _context.Schedules.Add(schedule);

            foreach (var item in request.Series)
            {
                var series = new ScheduleSeries
                {
                    SeriesId = Guid.NewGuid(),
                    ScheduleId = schedule.ScheduleId,

                    StartDate = item.StartDate,
                    EndDate = item.EndDate,

                    PractitionerId = item.PractitionerId,
                    Status = item.Status,
                    ServiceTypeId = item.ServiceTypeId,

                    BillRate = item.BillRate,
                    PayRate = item.PayRate,

                    BillTypeId = item.BillTypeId,
                    PayTypeId = item.PayTypeId,

                    TimeZone = item.TimeZone,
                    WallClockStart = item.WallClockStart,
                    WallClockEnd = item.WallClockEnd,

                    Notes = item.Notes,

                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsArchived = false
                };

                _context.ScheduleSeries.Add(series);
            }

            await _context.SaveChangesAsync();

            return schedule.ScheduleId;
        }
    }
}
