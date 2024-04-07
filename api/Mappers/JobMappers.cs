using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Job;
using api.Models;

namespace api.Mappers
{
    public static class JobMappers 
    {
           public static JobDto ToJobDto(this Job jobModel){
            return new JobDto {

                 JobId=jobModel.JobId,
                UserId=jobModel.UserId,
                JobTitle=jobModel.JobTitle,
                Type=jobModel.Type,
                JobBudget=jobModel.JobBudget,
                JobDescription=jobModel.JobDescription,



            };
        }
    }
}