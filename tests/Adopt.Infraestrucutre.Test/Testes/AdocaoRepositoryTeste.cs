using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Moq;
using Xunit;

namespace Adopt.Infraestrucutre.Test.Testes;

public class AdocaoRepositoryTeste
{
    private readonly Mock<IMapper> _mapper;
    private readonly DataContext _context;
    private readonly Mock<IAbrigoRepository> _abrigoRepository;
    private readonly AdocaoRepository _adocaoRepository;
    public AdocaoRepositoryTeste()
    {
        _mapper = new Mock<IMapper>();
        var dbInMemory = new DataContextInMemory();
        _context = dbInMemory.GetContext();
        _abrigoRepository = new Mock<IAbrigoRepository>();
        _adocaoRepository = new AdocaoRepository(_context, _mapper.Object, _abrigoRepository.Object);

    }

    [Fact]
    public void AdoptTeste()
    {
        AdocaoModel adocao = new AdocaoModel
        {

        };
        _mapper.Setup(m => m.Map<AdocaoModel>(It.IsAny<AdocaoDto>())).Returns(new AdocaoModel());
    }

}
