using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Control;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services;
using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Contracts;

namespace AddressServiceTesting
{
    internal class ServiceTesting
    {
        public IAddressService Service { get; set; }

        [SetUp]
        public void SetUp(AddressService service)
        {
            Service = service;
        }

        [Test]
        public async Task Test1()
        {
            var res = await Service.GetZIPCoordinatesThroughPostalCodeAsync("7005");
            Assert.IsNotNull(res);
        }
    }
}
