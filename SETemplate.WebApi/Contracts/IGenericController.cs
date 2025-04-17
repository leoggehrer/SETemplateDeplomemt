//@BaseCode
using Microsoft.AspNetCore.Mvc;

namespace SETemplate.WebApi.Contracts
{
    /// <summary>
    /// Defines a generic controller interface for handling CRUD operations.
    /// </summary>
    /// <typeparam name="TModel">The type of the model object.</typeparam>
    /// <typeparam name="TContract">The type of the contract object.</typeparam>
    public partial interface IGenericController<TModel, TContract>
        where TModel : CommonModels.ModelObject, TContract, new()
        where TContract : CommonContracts.IIdentifiable
    {
        /// <summary>
        /// Retrieves the count of all entities.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> representing the count of entities.</returns>
        Task<ActionResult> CountAsync();

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> containing an enumerable of <typeparamref name="TModel"/>.</returns>
        Task<ActionResult<IEnumerable<TModel>>> GetAsync();

        /// <summary>
        /// Queries entities based on a specified predicate.
        /// </summary>
        /// <param name="predicate">The query predicate as a string.</param>
        /// <returns>An <see cref="ActionResult"/> containing an enumerable of <typeparamref name="TModel"/> that match the predicate.</returns>
        Task<ActionResult<IEnumerable<TModel>>> QueryAsync(string predicate);

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="model">The model object to create.</param>
        /// <returns>An <see cref="ActionResult"/> containing the created <typeparamref name="TModel"/>.</returns>
        Task<ActionResult<TModel>> PostAsync([FromBody] TModel model);
    }
}