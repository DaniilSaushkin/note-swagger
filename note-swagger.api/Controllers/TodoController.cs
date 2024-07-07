using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using note_swagger.api.DTO;
using note_swagger.api.Repository;

namespace note_swagger.api.Controllers
{
    /// <summary>
    /// Todo controller for working with TodoItems
    /// </summary>
    public class TodoController : Controller
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor TodoController with initialization InMemory database.
        /// </summary>
        public TodoController()
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase("ToDoDB");
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        /// <summary>
        /// Create item
        /// </summary>
        /// <param name="item">Model of item</param>
        /// <returns>Return created item</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /todo
        ///     {
        ///        "ID": 1,
        ///        "Name": "First task",
        ///        "Description": "Just description"
        ///     }
        /// </remarks>
        /// <response code="201">Return created item</response>
        /// <response code="400">Return not found message</response>
        [HttpPost("/todo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateItem(TodoItem item)
        {
            try
            {
                _context.TodoItems.Add(item);
                _context.SaveChanges();

                return CreatedAtAction("POST", item);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get one item by id
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Return one item by id</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /todo?id=1
        /// </remarks>
        /// <response code="200">Return one item by id</response>
        /// <response code="400">Return exception message</response>
        /// <response code="404">Return not found message</response>
        [HttpGet("/todo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetItemById(int id)
        {
            try
            {
                var item = _context.TodoItems.FirstOrDefault(todo => todo.ID == id);

                if (item == null)
                    return NotFound($"Item with ID: {id} is not found.");

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal error: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete one item by ID
        /// </summary>
        /// <param name="id">Item ID.</param>
        /// <returns>Return deleted item</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /todo?id=1
        /// </remarks>
        /// <response code="200">Return deleted item</response>
        /// <response code="400">Return exception message</response>
        /// <response code="404">Return not found message</response> 
        [HttpDelete("/todo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteItemById(int id)
        {
            try
            {
                var item = _context.TodoItems.FirstOrDefault(todo => todo.ID == id);

                if (item == null)
                    return NotFound($"Item with ID: {id} is not found.");

                _context.TodoItems.Remove(item);
                _context.SaveChanges();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal error: " + ex.Message);
            }
        }

        /// <summary>
        /// Update one item
        /// </summary>
        /// <param name="newItem">Item with current ID but with new data</param>
        /// <returns>Return updated item</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /todo
        ///     {
        ///         "id": 1,
        ///         "name": "New name",
        ///         "description": "New description"
        ///     }
        /// </remarks>
        /// <response code="200">Return updated item</response>
        /// <response code="400">Return exception message</response>
        /// <response code="404">Return not found message</response>
        [HttpPut("/todo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateItemById(TodoItem newItem)
        {
            try
            {
                var item = _context.TodoItems.FirstOrDefault(todo => todo.ID == newItem.ID);

                if (item == null)
                    return NotFound($"Item with ID: {newItem.ID} is not found.");

                item.Name = newItem.Name;
                item.Description = newItem.Description;
                
                _context.SaveChanges();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal error: " + ex.Message);
            }
        }
    }
}
