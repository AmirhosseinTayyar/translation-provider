using Core.Domain.Cultures.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace Core.Contracts.Cultures.Commands;

public interface ICultureCommandRepository : ICommandRepository<Culture, int>
{
}