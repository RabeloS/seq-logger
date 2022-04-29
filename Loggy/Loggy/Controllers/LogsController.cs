using Microsoft.AspNetCore.Mvc;

namespace Loggy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        public LogsController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var logs = new List<string>();
            var result = Directory.GetFiles(@"logs", "*.txt");

            foreach (var item in result)
            {
                try
                {
                    Stream stream = System.IO.File.Open(item, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader streamReader = new StreamReader(stream);

                    while (true)
                    {
                        var linha = streamReader.ReadLine();
                        if (linha == null)
                            break;
                        logs.Add(linha);
                    }

                    streamReader.Close();
                    stream.Close();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return Ok(Enumerable.Reverse(logs).ToList());
        }
    }
}
