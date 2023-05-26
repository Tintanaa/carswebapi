using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Cars.Application.Cars.Queries.GetCarList;
using Cars.Application.Cars.Queries.GetCarDetails;
using Cars.Application.Cars.Commands.CreateCar;
using Cars.Application.Cars.Commands.UpdateCar;
using Cars.Application.Cars.Commands.DeleteCar;
using Cars.WebApi.Models;

namespace Cars.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CarController : BaseController
    {
        private readonly IMapper _mapper;

        public CarController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of cars
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns CarsListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CarListVm>> GetAll()
        {
            var query = new GetCarListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the car by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Car id (guid)</param>
        /// <returns>Returns CarDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CarDetailsVm>> Get(Guid id)
        {
            var query = new GetCarDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the car
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /note
        /// {
        ///     title: "car title",
        ///     details: "car details"
        ///     country: "car country"
        ///     usagebenzin: "car usagebenzin"
        ///     serialnumber: "car serialnumber"
        /// }
        /// </remarks>
        /// <param name="createCarDto">CreateCarDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCarDto createCarDto)
        {
            var command = _mapper.Map<CreateCarCommand>(createCarDto);
            command.UserId = UserId;
            var carId = await Mediator.Send(command);
            return Ok(carId);
        }

        /// <summary>
        /// Updates the car
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /note
        /// {
        ///     title: "updated car title"
        ///     details: "updated car details"
        ///     country: "updated car country"
        ///     usagebenzin: "updated car usagebenzin"
        ///     serialnumber: "updated serial number"
        /// }
        /// </remarks>
        /// <param name="updateCarDto">UpdateCarDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateCarDto updateCarDto)
        {
            var command = _mapper.Map<UpdateCarCommand>(updateCarDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the car by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /car/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the note (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCarCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
