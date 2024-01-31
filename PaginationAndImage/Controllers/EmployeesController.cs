using Microsoft.AspNetCore.Mvc;
using PaginationAndImage.Models;

namespace PaginationAndImage.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{

    public static string filess;

    [HttpPost]
    public IActionResult PostEmployee([FromForm] Employee employee)
    {
        if (employee.File != null)
        {
            try
            {
                var filePath = Path.Combine("Storage", employee.File.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    employee.File.CopyTo(fileStream);
                    filess = filePath;
                return Ok();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return Ok();
    }

    [HttpGet]
    public IActionResult Download()
    {
        var dataBytes = System.IO.File.ReadAllBytes(filess);
        return File(dataBytes, "image/jpeg");
    }
}