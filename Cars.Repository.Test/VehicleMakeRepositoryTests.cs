using Cars.Common;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project.Repository.Tests
{
    public class VehicleMakeRepositoryTests
    {
        public readonly IVehicleMakeRepository _mockMakeRepository;

        public VehicleMakeRepositoryTests()
        {
            Mock<IVehicleMakeRepository> mockMakeRepository = new Mock<IVehicleMakeRepository>();

            IEnumerable<IVehicleMakeEntity> makes = new List<VehicleMakeEntity> {
                new VehicleMakeEntity { MakeId = 1, Name = "Audi", Abrv = "Germany" },
                new VehicleMakeEntity { MakeId = 2, Name = "BMW", Abrv = "BMW" },
                new VehicleMakeEntity { MakeId = 3, Name = "Honda", Abrv = "Japan" },
                new VehicleMakeEntity { MakeId = 4, Name = "Alfa Romeo", Abrv = "Italy" },
                new VehicleMakeEntity { MakeId = 5, Name = "Seat", Abrv = "Spain" }};

            var updateList = makes.ToList();

            // return all makes
            mockMakeRepository.Setup(mr => mr.FindAllMakesPaged(It.IsAny<SortingParameters>(), It.IsAny<FilteringParameters>(), It.IsAny<PagingParameters>()))
                .ReturnsAsync(new PaginationList<IVehicleMakeEntity>(updateList, updateList.Count(), It.IsAny<int>(), It.IsAny<int>()));

            // return a make by Id
            mockMakeRepository.Setup(mr => mr.FindById(It.IsAny<int>())).ReturnsAsync((int i) => updateList.Where(x => x.MakeId == i).FirstOrDefault());

            // Allows us to test saving a product
            mockMakeRepository.Setup(mr => mr.Create(It.IsAny<IVehicleMakeEntity>())).Returns(
                (IVehicleMakeEntity target) =>
                {
                    if (target.MakeId.Equals(default))
                    {
                        target.MakeId = makes.Count() + 1;
                        updateList.Add(target);
                    }

                    else
                    {
                        var original = makes.Where(q => q.MakeId == target.MakeId).Single();
                        if (original == null)
                        {
                            return Task.FromResult(false);
                        }

                        original.MakeId = target.MakeId;
                        original.Name = target.Name;
                        original.Abrv = target.Abrv;
                    }

                    return Task.FromResult(true);
                });

            mockMakeRepository.Setup(mr => mr.Update(It.IsAny<IVehicleMakeEntity>()));

            mockMakeRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback<IVehicleMakeEntity>((entity) => updateList.Remove(entity));

            _mockMakeRepository = mockMakeRepository.Object;
        }


        [Fact]
        public void FindAll()
        {

            ISortingParameters sortingParams = new SortingParameters
            {
                SortOrder = ""
            };

            IFilteringParameters filteringParams = new FilteringParameters
            {
                SearchString = ""
            };

            IPagingParameters pagingParams = new PagingParameters
            {
                PageNumber = 1,
                PageSize = 2
            };

            PaginationList<IVehicleMakeEntity> testMakes = _mockMakeRepository.FindAllMakesPaged(sortingParams, filteringParams, pagingParams).Result;

            testMakes.Should().NotBeNull();

            testMakes.Count.Should().Be(3);
        }

        [Fact]
        public void FindById()
        {
            var testMake = _mockMakeRepository.FindById(2).Result;

            testMake.Should().NotBeNull();
            testMake.MakeId.Should().Be(2);
        }

        [Fact]
        public void Create()
        {
            var newMake = new VehicleMakeEntity
            {
                Name = "Subaru",
                Abrv = "Japan"
            };

            _mockMakeRepository.Create(newMake);

            int makeCount = _mockMakeRepository.FindAllAsync().Count();

            makeCount.Should().Be(6);

            var testMake = _mockMakeRepository.FindById(6).Result;

            testMake.Name.Should().BeEquivalentTo("Subaru");
        }
        [Fact]
        public void Update()
        {
            var testMake = _mockMakeRepository.FindById(3).Result;

            testMake.Abrv = "Jap";

            _mockMakeRepository.Update(testMake);

            var getMake = _mockMakeRepository.FindById(3).Result;

            getMake.Abrv.Should().BeEquivalentTo("Jap");
        }

        [Fact]
        public void Delete()
        {
            var testMake = _mockMakeRepository.FindById(3).Result;

            _mockMakeRepository.Delete(testMake.MakeId);

            testMake = _mockMakeRepository.FindById(3).Result;

            testMake.Should().BeNull();
        }
    }
}
