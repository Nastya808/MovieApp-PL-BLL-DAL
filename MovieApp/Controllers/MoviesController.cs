using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.BLL.Interfaces;
using MovieApp.BLL.DTO;
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Entities;


public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return View(movies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieDto movieDto)
    {
        if (ModelState.IsValid)
        {
            await _movieService.AddMovieAsync(movieDto);
            return RedirectToAction(nameof(Index));
        }
        return View(movieDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(MovieDto movieDto)
    {
        if (ModelState.IsValid)
        {
            await _movieService.UpdateMovieAsync(movieDto);
            return RedirectToAction(nameof(Index));
        }
        return View(movieDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _movieService.DeleteMovieAsync(id);
        return RedirectToAction(nameof(Index));
    }



}