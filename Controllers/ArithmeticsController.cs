using Microsoft.AspNetCore.Mvc;
using WebApplicationHng.Models;

namespace WebApplicationHng.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ArithmeticsController : ControllerBase
    {
        Models.Results Arithmetic(string operation, int x, int y)
        {
            Models.Results result = new Models.Results()
            {
                slackUsername = "Sunday Mba",
                operation_type = "Not Defined",
                result = 0
            };
            switch (operation)
            {
                case "add":
                    result = new Models.Results()
                    {
                        slackUsername = "Sunday Mba",
                        operation_type = "addition",
                        result = (x + y)
                    };
                    break;
                case "subtract":
                    result = new Models.Results()
                    {
                        slackUsername = "Sunday Mba",
                        operation_type = "subtraction",
                        result = (x - y)
                    };
                    break;
                case "multiply":
                    result = new Models.Results()
                    {
                        slackUsername = "Sunday Mba",
                        operation_type = "multiplication",
                        result = (x * y)
                    };
                    break;
            }

            return result;
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok("Please make a post request to the url using json format");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Arithmetic cal)
        {
            Models.Results result = new Models.Results() 
            {
                slackUsername = "Sunday Mba",
                operation_type = "Not Defined",
                result = 0
            };
            switch(cal.operation_type)
            {
                case "Addition":
                case "addition":
                case "add":
                case "+":
                    result = new Models.Results() 
                    { 
                        slackUsername = "Sunday Mba",
                        operation_type = "addition",
                        result = (cal.x + cal.y) 
                    };
                break;

                case "Subtraction":
                case "subtraction":
                case "subtract":
                case "-":
                    result = new Models.Results()
                    {
                        slackUsername = "Sunday Mba",
                        operation_type = "subtraction",
                        result = (cal.x - cal.y)
                    };
                break;

                case "Multiplication":
                case "multiply":
                case "multiplication":
                case "*":
                case "x":
                    result = new Models.Results()
                    {
                        slackUsername = "Sunday Mba",
                        operation_type = "multiplication",
                        result = (cal.x * cal.y)
                    };
                break;
                default:
                    {
                        List<int> listInt = new List<int>();
                        int sum;
                        String temp = "";
                        String? randomData = cal.operation_type;
                        string[] strArray = randomData.Split(" ");

                        foreach (string str2 in strArray)
                        {
                            if (int.TryParse(str2, out sum))
                            {
                                listInt.Add(sum);
                            }

                            if (str2 == "add" || str2 == "addition" || str2 == "Addition" || str2 == "plus" || str2 == "+" || str2 == "join")
                            {
                                temp = "add";
                            }
                            else if (str2 == "subtract" || str2 == "Subtraction" || str2 == "subtraction" || str2 == "Subtract" || str2 == "-" || str2 == "minus" || str2 == "remove")
                            {
                                temp = "subtract";
                            }
                            else if (str2 == "multiply" || str2 == "Multiply" || str2 == "Multiplication" || str2 == "multiplication" || str2 == "*" || str2 == "x" || str2 == "times")
                            {
                                temp = "multiply";
                            }

                        }

                        switch (temp)
                        {
                            case "add":
                                result = Arithmetic("add", listInt[0], listInt[1]);
                                break;
                            case "subtract":
                                result = Arithmetic("subtract", listInt[1], listInt[0]);
                                break;
                            case "multiply":
                                result = Arithmetic("multiply", listInt[0], listInt[1]);
                                break;

                        }



                    }
                    
                    break;
                    

            }



                return Ok(result);
          
        }
    }
}
