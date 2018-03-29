using Hope.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hope.Services
{
    public interface IComposerService
    {
        IList<Composer> GetAll();
        Composer GetById(int id);
        void Add(Composer composer);
        void Edit(Composer composer);
        bool Delete(int id);
    }
}
