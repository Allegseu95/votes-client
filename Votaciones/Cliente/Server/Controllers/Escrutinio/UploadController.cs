using Cliente.Server.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class UploadController : ApiControllerBase
{
    private readonly ILogger<UploadController> logger;
    private readonly IWebHostEnvironment environment;

    public UploadController(ILogger<UploadController> logger, IWebHostEnvironment environment)
    {
        this.logger = logger;
        this.environment = environment;
    }

    [HttpPost]
    public async Task<bool> Post()
    {
        try
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var path = Path.Combine(environment.ContentRootPath, "uploads", file.FileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
       
    }
}
