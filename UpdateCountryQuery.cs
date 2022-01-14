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

namespace IRIExcelWEBAPI.Query.UpdateCountry
{
    public class UpdateCountryQuery:IRequest<List<Country>>
    {
        public List<CountryUpSetRequest> countries { get; set; }
    }

    public class UpdateCountryQueryHandler : IRequestHandler<UpdateCountryQuery, List<Country>>
    {
        private static CountryContext countryContext = new CountryContext();
        private readonly AppSettings _configuration;
        public UpdateCountryQueryHandler(AppSettings appSettings, IMediator mediator)
        {
            _configuration = appSettings;
        }
        public async Task<List<Country>> Handle(UpdateCountryQuery request, CancellationToken cancellationToken)
        {
            var countries = countryContext.Countries.ToList();
            foreach (var country in countries)
                countryContext.Entry(country).Reload();

            foreach (var countryUpset in request.countries)
            {
                if(countryUpset.CountryId == 0)
                {
                    Country newCountry = new Country();
                    newCountry.Code = countryUpset.Code.Trim();
                    newCountry.Description = countryUpset.Description.Trim();
                    countryContext.Countries.Add(newCountry);
                }
                var dbCountry = countries.Where(c => c.CountryId == countryUpset.CountryId).FirstOrDefault();
                if(dbCountry != null)
                {
                    dbCountry.Code = countryUpset.Code.Trim();
                    dbCountry.Description = countryUpset.Description.Trim();
                }
            }
            countryContext.SaveChanges();
            var response = countryContext.Countries.ToList();
            return await Task.FromResult(response);
        }
    }
}
