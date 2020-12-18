using Cars.Common;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cars.Repository.Test
{
    public class VehicleModelRepositoryTests
    {
        public readonly IVehicleModelRepository _mockModelRepository;

        public VehicleModelRepositoryTests()
        {
            Mock<IVehicleModelRepository> mockModelRepository = new Mock<IVehicleModelRepository>();

            IEnumerable<IVehicleModelEntity> models = new List<VehicleModelEntity> {
                new VehicleModelEntity { ModelId = 1, MakeId = 1, Name = "A3", Abrv = "A3" },
                new VehicleModelEntity { ModelId = 2, MakeId = 1, Name = "A6", Abrv = "A6" },
                new VehicleModelEntity { ModelId = 3, MakeId = 2, Name = "3", Abrv = "3" },
                new VehicleModelEntity { ModelId = 4, MakeId = 2, Name = "5", Abrv = "5" }};

            var updateList = models.ToList();

            // return all makes
            mockModelRepository.Setup(mr => mr.FindAllModelsPaged(It.IsAny<SortingParameters>(), It.IsAny<FilteringParameters>(), It.IsAny<PagingParameters>()))
                .ReturnsAsync(new PaginationList<IVehicleModelEntity>(updateList, updateList.Count(), It.IsAny<int>(), It.IsAny<int>()));

            // return a make by Id
            mockModelRepository.Setup(mr => mr.FindById(It.IsAny<int>())).ReturnsAsync((int i) => updateList.Where(x => x.ModelId == i).FirstOrDefault());


            // Allows us to test saving a product
            mockModelRepository.Setup(mr => mr.Create(It.IsAny<IVehicleModelEntity>())).Returns(
                (IVehicleModelEntity target) =>
                {
                    if (target.ModelId.Equals(default))
                    {
                        target.ModelId = models.Count() + 1;
                        updateList.Add(target);
                    }

                    else
                    {
                        var original = models.Where(q => q.ModelId == target.ModelId).Single();
                        if (original == null)
                        {
                            return Task.FromResult(false);
                        }

                        original.ModelId = target.ModelId;
                        original.MakeId = target.MakeId;
                        original.Name = target.Name;
                        original.Abrv = target.Abrv;
                    }

                    return Task.FromResult(true);
                });

            mockModelRepository.Setup(mr => mr.Update(It.IsAny<IVehicleModelEntity>()));

            mockModelRepository.Setup(mr => mr.Delete(It.IsAny<int>())).Callback<IVehicleModelEntity>((entity) => updateList.Remove(entity));

            _mockModelRepository = mockModelRepository.Object;
        }

        [Fact]
        public void GetAll()
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

            PaginationList<IVehicleModelEntity> testMakes = _mockModelRepository.FindAllModelsPaged(sortingParams, filteringParams, pagingParams).Result;

            testMakes.Should().NotBeNull();

            testMakes.Count.Should().Be(3);
        }

        [Fact]
        public void GetById()
        {
            IVehicleModelEntity testModel = _mockModelRepository.FindById(2).Result;

            testModel.Should().NotBeNull();
            testModel.ModelId.Should().Be(2);
        }

        [Fact]
        public void Add()
        {
            IVehicleModelEntity newModel = new VehicleModelEntity
            {
                MakeId = 3,
                Name = "E Class",
                Abrv = "E"
            };

            _mockModelRepository.Create(newModel);

            int modelCount = _mockModelRepository.FindAllWithMake(3).Count();

            modelCount.Should().Be(1);

            IVehicleModelEntity testModel = _mockModelRepository.FindById(5).Result;

            testModel.Name.Should().BeEquivalentTo("E Class");
        }
        [Fact]
        public void Update()
        {
            IVehicleModelEntity testModel = _mockModelRepository.FindById(3).Result;

            testModel.Abrv = "7";

            _mockModelRepository.Update(testModel);

            IVehicleModelEntity getModel = _mockModelRepository.FindById(3).Result;

            getModel.Abrv.Should().BeEquivalentTo("7");
        }

        [Fact]
        public void Remove()
        {
            IVehicleModelEntity testModel = _mockModelRepository.FindById(3).Result;

            _mockModelRepository.Delete(testModel.ModelId);

            testModel = _mockModelRepository.FindById(3).Result;

            testModel.Should().BeNull();
        }
    }
}

