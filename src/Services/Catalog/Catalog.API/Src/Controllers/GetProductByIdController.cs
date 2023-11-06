﻿using System.Net;
using Catalog.API.Src.Entities;
using Catalog.API.Src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
	[ApiController]
	[Route("api/v1/catalog/[controller]")]
	[Produces("application/json")]
	public class GetProductByIdController : ControllerBase
	{
		private readonly IProductRepository _repository;
		private readonly ILogger<GetProductByIdController> _logger;

		public GetProductByIdController(IProductRepository repository, ILogger<GetProductByIdController> logger)
		{
			this._repository = repository;
			this._logger = logger;
		}

		[HttpGet("{id:length(24)}")]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<ActionResult<Product>> GetProductById(string id)
		{
			Product product = await this._repository.GetProductById(id);

			if (product == null)
			{
				string message = $"Product with id: {id} not found";
				this._logger.LogError(message: message);

				return NotFound();
			}

			return Ok(product);
		}

	}
}
