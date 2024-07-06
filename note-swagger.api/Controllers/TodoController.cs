using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using note_swagger.api.DTO;
using note_swagger.api.Repository;

namespace note_swagger.api.Controllers
{
    /// <summary>
    /// Контроллер для Todo.
    /// </summary>
    public class TodoController : Controller
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Конструктор контроллера Todo с инициализацией InMemory базы данных.
        /// </summary>
        public TodoController()
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase("ToDoDB");
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        /// <summary>
        /// Создать пункт задачи.
        /// </summary>
        /// <param name="item">Модель пункта задачи.</param>
        /// <returns>Возвращает созданный пункт задачи.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     POST /todo
        ///     {
        ///        "ID": 1,
        ///        "Name": "Первая задача",
        ///        "Description": "Простое описание"
        ///     }
        /// </remarks>
        /// <response code="201">Возвращает созданный пункт задачи.</response>
        /// <response code="400">Возвращает сообщение об ошибке.</response>
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
        /// Получить один пункт задач по ID.
        /// </summary>
        /// <param name="id">Идентификатор пункта задачи.</param>
        /// <returns>Возвращает пункт задачи.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        /// GET /todo?id=1
        /// </remarks>
        /// <response code="200">Возвращает один пункт задачи.</response>
        /// <response code="400">Возвращает сообщение об ошибке.</response>
        /// <response code="404">Возвращает сообщение о не найденном пункте.</response>
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
                    return NotFound($"Пункт задачи с ID: {id} не найден.");

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Непредвиденная ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Удалить один пункт задачи по ID.
        /// </summary>
        /// <param name="id">Идентификатор пункта задачи.</param>
        /// <returns>Возвращает удаленный пункт задачи.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        /// DELETE /todo?id=1
        /// </remarks>
        /// <response code="200">Возвращает удаленный пункт задачи.</response>
        /// <response code="400">Возвращает сообщение об ошибке.</response>
        /// <response code="404">Возвращает сообщение о не найденном пункте.</response> 
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
                    return NotFound($"Пункт задачи с ID: {id} не найден.");

                _context.TodoItems.Remove(item);
                _context.SaveChanges();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Непредвиденная ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Редактировать один пункт задачи.
        /// </summary>
        /// <param name="newItem">Модель пункта задачи с действующим ID, но с новыми данными</param>
        /// <returns>Возвращает измененный пункт задачи.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     PUT /todo
        ///     {
        ///         "id": 1,
        ///         "name": "Новое имя",
        ///         "description": "Новое описание"
        ///     }
        /// </remarks>
        /// <response code="200">Возвращает измененный пункт задачи.</response>
        /// <response code="400">Возвращает сообщение об ошибке.</response>
        /// <response code="404">Возвращает сообщение о не найденном пункте.</response>
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
                    return NotFound($"Пункт задачи с ID: {newItem.ID} не найден.");

                item.Name = newItem.Name;
                item.Description = newItem.Description;
                
                _context.SaveChanges();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest("Непредвиденная ошибка: " + ex.Message);
            }
        }
    }
}
