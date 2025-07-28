using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoMvcApp.Data;
using TodoMvcApp.Models;

namespace TodoMvcApp.Controllers
{
    public class TodosController : Controller
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context)
        {
            _context = context;
        }

        // GET: /Todos
        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.ToListAsync();
            return View(todos);
        }

        // GET: /Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IsCompleted")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.CreatedAt = DateTime.Now; // ✅ Automatically set timestamp
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }


        // GET: /Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            return View(todo);
        }

        // POST: /Todos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Todo todo)
        {
            if (id != todo.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }


        // GET: /Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null) return NotFound();

            return View(todo);
        }

        // POST: /Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
