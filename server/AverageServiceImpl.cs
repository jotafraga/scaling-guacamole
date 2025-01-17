﻿using Average;
using Grpc.Core;
using System.Threading.Tasks;
using static Average.AverageService;

namespace server
{
    public class AverageServiceImpl : AverageServiceBase
    {
        public override async Task<AverageResponse> ComputeAverage(IAsyncStreamReader<AverageRequest> requestStream, ServerCallContext context)
        {
            int total = 0;
            double result = 0.0;

            while(await requestStream.MoveNext())
            {
                result += requestStream.Current.Number;
                total++;
            }

            return new AverageResponse() { Result = result / total };
        }
    }
}