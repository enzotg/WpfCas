using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCas.ViewModels
{
    public class ErrorMessage
    {
        public string Message { get; set; }

        public ErrorMessage()
        {

        }
        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
