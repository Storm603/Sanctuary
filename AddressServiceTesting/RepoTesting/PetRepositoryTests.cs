using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressServiceTesting.RepoTesting
{
    [TestFixture]
    public class PetRepositoryTests
    {
        public IPetRepository<Pet> petRepository;

        public PetRepositoryTests(IPetRepository<Pet> _petRepository)
        {
            petRepository = _petRepository;
        }

        //public void 
    }
}
