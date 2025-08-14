using Core.Contracts.Translations.Commands.Create;
using Core.Contracts.Translations.Commands.Delete;
using Core.Contracts.Translations.Commands.Update;
using Core.Contracts.Translations.Queries.GetById;
using Core.Contracts.Translations.Queries.GetFilterablePaged;
using Core.Contracts.Translations.Queries.GetLocalizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace Endpoints.API.Features.Translations;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class TranslationController : BaseController
{
    #region Commands
    [HttpPost]
    [EndpointName("CreateTranslation")]
    [EndpointSummary("Creates a new translation record.")]
    [EndpointDescription("Creates a new translation with the provided details.")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(
        [FromBody, Description("The payload containing all required fields to create a new translation.")] TranslationCreateCommand command)
        => await Create<TranslationCreateCommand, Guid>(command);

    [HttpPut]
    [EndpointName("UpdateTranslation")]
    [EndpointSummary("Updates an existing translation record.")]
    [EndpointDescription("Updates the details of an existing translation.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Update(
        [FromBody, Description("The payload containing all required fields to update an existing translation.")] TranslationUpdateCommand command)
        => await Edit(command);

    [HttpDelete]
    [EndpointName("DeleteTranslation")]
    [EndpointSummary("Deletes a translation record.")]
    [EndpointDescription("Deletes the specified translation by its identifier.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(
        [FromQuery, Description("The payload containing the identifier of the translation to delete.")] TranslationDeleteCommand command)
        => await base.Delete(command);
    #endregion

    #region Queries
    [HttpGet]
    [EndpointName("GetTranslationById")]
    [EndpointSummary("Gets a translation by its identifier.")]
    [EndpointDescription("Retrieves the details of a translation by its identifier.")]
    [ProducesResponseType(typeof(TranslationQr), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(
        [FromQuery, Description("The payload containing the identifier of the translation to retrieve.")] TranslationGetByIdQuery query)
        => await Query<TranslationGetByIdQuery, TranslationQr?>(query);

    [HttpGet]
    [EndpointName("GetFilterablePagedTranslations")]
    [EndpointSummary("Gets a paged list of translations with filtering.")]
    [EndpointDescription("Retrieves a paged and filterable list of translations.")]
    [ProducesResponseType(typeof(PagedData<TranslationListItemQr>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterablePaged(
        [FromQuery, Description("The payload containing paging and filtering options for translations.")] TranslationGetFilterablePagedQuery query)
        => await Query<TranslationGetFilterablePagedQuery, PagedData<TranslationListItemQr>>(query);

    [HttpGet]
    [AllowAnonymous]
    [EndpointName("GetLocalizationRecords")]
    [EndpointSummary("Gets localization records for translations.")]
    [EndpointDescription("Retrieves a list of localization records for translations.")]
    [ProducesResponseType(typeof(List<TranslationLocalizationItemQr>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetLocalizationRecords(
        [FromQuery, Description("The payload containing options for retrieving localization records.")] TranslationGetLocalizationsQuery query)
        => await Query<TranslationGetLocalizationsQuery, List<TranslationLocalizationItemQr>>(query);
    #endregion
}