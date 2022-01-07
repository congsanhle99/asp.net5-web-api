using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Data.Services;
using MyBook.Data.ViewModels;
using MyBook.Exceptions;
using System;

namespace MyBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublisers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
            var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
            return Ok(_result);

            }
            catch (Exception)
            {

                return BadRequest("Error !!!");
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPubliserById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);               
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPubliserData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher Name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
