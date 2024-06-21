using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateTask.DBTask;
using StateTask.Model;


namespace StateTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerTask : Controller
    {
        private readonly DbContextTask _context;
        public ControllerTask(DbContextTask context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TasksModel>> PostTask(TasksModel tasksmodel)
        {
            tasksmodel.State = TaskState.Created;
            _context.TasksModel.Add(tasksmodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = tasksmodel.Id }, tasksmodel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TasksModel>> GetTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // altera se haver uma tarefa criada
            if (tasks.State == TaskState.Created)
            {
                tasks.State = TaskState.InProgress;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser iniciada!");
            }

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // altera se haver uma tarefa em progresso
            if (tasks.State == TaskState.InProgress)
            {
                tasks.State = TaskState.Completed;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser completada!");
            }

            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            // Cancela se haver uma tarefa criada ou em progresso
            if (tasks.State == TaskState.Created || tasks.State == TaskState.InProgress)
            {
                tasks.State = TaskState.Canceled;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser cancelada!");
            }

            return NoContent();
        }
    }
}
