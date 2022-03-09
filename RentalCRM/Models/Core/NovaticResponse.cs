using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCRM.Models
{
    public class NovaticResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public IList<Object> data { get; set; }


        public NovaticResponse(string status, string message, IList<Object> data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }

        public NovaticResponse(string status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public static NovaticResponse SUCCESS(IList<Object> data)
        {
            return new NovaticResponse("200", "SUCCESS", data);
        }

        public static NovaticResponse SUCCESS()
        {
            return new NovaticResponse("200", "SUCCESS");
        }

        public static NovaticResponse BAD_REQUEST()
        {
            return new NovaticResponse("200", "BAD_REQUEST");
        }

        public static NovaticResponse SUCCESS(Object data)
        {
            List<Object> returnData = new List<Object>();
            returnData.Add(data);
            return new NovaticResponse("200", "SUCCESS", returnData);
        }

        public static NovaticResponse CREATED(Object data)
        {
            List<Object> returnData = new List<Object>();
            returnData.Add(data);
            return new NovaticResponse("201", "CREATED", returnData);
        }

        public static NovaticResponse Faild()
        {
            return new NovaticResponse("099", "FAILD");
        }

        public static NovaticResponse EmailExist(Object data)
        {
            List<Object> returnData = new List<Object>();
            returnData.Add(data);
            return new NovaticResponse("202", "EMAILEXIST", returnData);
        }

        public static NovaticResponse UsernameExist(Object data)
        {
            List<Object> returnData = new List<Object>();
            returnData.Add(data);
            return new NovaticResponse("203", "USENAMEEXIST", returnData);
        }
    }
}
