using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyException
{
    class EmailErrorException : ApplicationException
    {
        public string _message;

        public EmailErrorException()
            : base()
        {
            _message = null;
        }
        public EmailErrorException(string message)
            : base()
        {
            _message = message.ToString();
        }
        public EmailErrorException(string message, Exception myNew)
            : base(message, myNew)
        {
            _message = message.ToString();
        }

        public override string Message
        {
            get
            {
                return "Email格式错误。";
            }
        }
    }
}
