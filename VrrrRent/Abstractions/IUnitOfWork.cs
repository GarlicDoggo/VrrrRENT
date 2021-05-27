using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Abstractions
{
    public interface IUnitOfWork
    {
        void UploadImage(IFormFile file);
    }
}
