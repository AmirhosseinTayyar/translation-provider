using Core.Domain.Translations.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace Core.Contracts.Translations.Commands;

public interface ITranslationCommandRepository : ICommandRepository<Translation, int>
{
}