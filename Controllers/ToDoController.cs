// File: ToDoController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }
        // Action method for displaying the to-do list
        public IActionResult Index()
        {
            List<ToDoItem> toDoItems = _context.ToDoItems.ToList();

            // Calculate time left for each task
            foreach (var item in toDoItems)
            {
                item.TimeLeft = item.DueDate - DateTime.Now;
            }

            return View(toDoItems);
        } 

        
        

        // Action method for adding a new to-do item
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Add(toDoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoItem);
        }

        // Action method for editing an existing to-do item
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ToDoItem toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(toDoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoItem);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ToDoItem toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        [HttpPost]
        public IActionResult Delete(ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(toDoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoItem);
        }

        // Action method for marking a to-do item as complete
        public IActionResult Complete(int id)
        {
            ToDoItem toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            toDoItem.IsComplete = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
