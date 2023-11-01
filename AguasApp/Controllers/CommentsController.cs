using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using AguasApp.Data;
using System.Linq;

namespace AguasApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly DataContext _context;

        public CommentsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comments = _context.Comments.ToList();
            return View(comments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            //comment.Message = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
