using IRIExcelWEBAPI.Application;
using IRIExcelWEBAPI.Infra;
using IRIExcelWEBAPI.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IRIExcelWEBAPI.Query
{
    public class GetCountryQuery:IRequest<List<Country>>
    {

    }

    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, List<Country>>
    {
        private readonly AppSettings _appSettings;
        private static CountryContext countryContext = new CountryContext();
        public GetCountryQueryHandler(AppSettings appSettings, IMediator mediator)
        {
            _appSettings = appSettings;
        }
        public async Task<List<Country>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var countries = countryContext.Countries.ToList();
            foreach (var country in countries)
            {
                countryContext.Entry(country).Reload();
            }
            return await Task.FromResult(countries);
         }
    }
}
