using System.Collections.Generic;
using DanDemoCrud1.Models;

namespace DanDemoCrud1.Services
{
    public interface IDemoDataService
    {
        List<DemoMessage> GetAllMessages();
    }
}