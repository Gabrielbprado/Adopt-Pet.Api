using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopt.Domain.Interfaces
{
    public interface IVisionIA
    {
        bool Response(byte[] image);
        public  Task<string> MakeRequest(byte[] bytes);


    }
}
