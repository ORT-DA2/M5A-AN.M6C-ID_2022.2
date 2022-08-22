using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ej_filters.api.Logic;

namespace ej_filters.api.Filters
{
    public class ExampleResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            object result = (object)((ObjectResult)context.Result).Value;
            context.Result = new ObjectResult("Hola " + result);
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            ServiceLogic.EntryLog();
        }
    }
}