using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDC03FinalProject.Services
{
    public interface IAlertService
    {
        Task ShowAlertAsync(string title, string message, string cancel);
    }
}