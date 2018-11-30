using Semesterprojekt.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semesterprojekt.UI.Services
{
    public interface IAuthApiClient
    {
        void Login(LoginViewModel user);
    }
}
