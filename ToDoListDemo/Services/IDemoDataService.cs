using System.Collections.Generic;
using DanDemoCrud1.Models;

namespace DanDemoCrud1.Services
{
    public interface IDemoDataService
    {
        List<DemoMessage> GetAllMessages();
        int InsertMessages(InsertMessages model);
        void UpdateMessages(UpdateMessages model);
        void Delete(int Id);
    }
}