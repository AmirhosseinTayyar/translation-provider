using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using TranslationProvider.Core.Contracts.Cultures.Commands.Create;
using TranslationProvider.Core.Contracts.Cultures.Commands.Delete;
using TranslationProvider.Core.Contracts.Cultures.Commands.Disable;
using TranslationProvider.Core.Contracts.Cultures.Commands.Enable;
using TranslationProvider.Core.Contracts.Cultures.Commands.Update;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetById;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetFilterablePaged;
using TranslationProvider.Core.Contracts.Cultures.Queries.GetSelectList;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace TranslationProvider.Endpoints.API.Features.Cultures;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class CultureController : BaseController
{
    #region Commands
    [HttpPost]
    [EndpointName("CreateCulture")]
    [EndpointSummary("Creates a new culture.")]
    [EndpointDescription("Creates a new culture with the provided key and title.")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(
        [FromBody, Description("The payload containing all required fields to create a new culture.")] CultureCreateCommand command)
        => await Create<CultureCreateCommand, Guid>(command);

    [HttpPut]
    [EndpointName("UpdateCulture")]
    [EndpointSummary("Updates an existing culture.")]
    [EndpointDescription("Updates the details of an existing culture by BusinessId.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Update(
        [FromBody, Description("The payload containing all required fields to update an existing culture.")] CultureUpdateCommand command)
        => await Edit(command);

    [HttpPut]
    [EndpointName("EnableCulture")]
    [EndpointSummary("Enables a culture.")]
    [EndpointDescription("Enables the specified culture by BusinessId.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Enable(
        [FromBody, Description("The payload containing the BusinessId of the culture to enable.")] CultureEnableCommand command)
        => await Edit(command);

    [HttpPut]
    [EndpointName("DisableCulture")]
    [EndpointSummary("Disables a culture.")]
    [EndpointDescription("Disables the specified culture by BusinessId.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Disable(
        [FromBody, Description("The payload containing the BusinessId of the culture to disable.")] CultureDisableCommand command)
        => await Edit(command);

    [HttpDelete]
    [EndpointName("DeleteCulture")]
    [EndpointSummary("Deletes a culture.")]
    [EndpointDescription("Deletes the specified culture by BusinessId.")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(
        [FromQuery, Description("The payload containing the BusinessId of the culture to delete.")] CultureDeleteCommand command)
        => await base.Delete(command);
    #endregion

    #region Queries
    [HttpGet]
    [EndpointName("GetCultureById")]
    [EndpointSummary("Gets a culture by its BusinessId.")]
    [EndpointDescription("Retrieves the details of a culture by its BusinessId.")]
    [ProducesResponseType(typeof(CultureQr), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(
        [FromQuery, Description("The payload containing the BusinessId of the culture to retrieve.")] CultureGetByIdQuery query)
        => await Query<CultureGetByIdQuery, CultureQr?>(query);

    [HttpGet]
    [EndpointName("GetCultureSelectList")]
    [EndpointSummary("Gets a select list of cultures.")]
    [EndpointDescription("Retrieves a list of cultures for selection purposes.")]
    [ProducesResponseType(typeof(List<CultureSelectItemQr>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSelectList(
        [FromQuery, Description("The payload containing filter options for the select list of cultures.")] CultureGetSelectListQuery query)
        => await Query<CultureGetSelectListQuery, List<CultureSelectItemQr>>(query);

    [HttpGet]
    [EndpointName("GetFilterablePagedCultures")]
    [EndpointSummary("Gets a paged list of cultures with filtering.")]
    [EndpointDescription("Retrieves a paged and filterable list of cultures.")]
    [ProducesResponseType(typeof(PagedData<CulturePageItemQr>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterablePaged(
        [FromQuery, Description("The payload containing paging and filtering options for cultures.")] CultureGetFilterablePagedQuery query)
        => await Query<CultureGetFilterablePagedQuery, PagedData<CulturePageItemQr>>(query);
    #endregion
}