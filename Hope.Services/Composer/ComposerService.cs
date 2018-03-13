using System;
using System.Collections.Generic;
using Hope.Core;

namespace Hope.Services
{
    public class ComposerService : IComposerService
    {
        private readonly IRepository<Composer> _composerRepo;
        public ComposerService(IRepository<Composer> composerRepo)
        {
            _composerRepo = composerRepo;
        }

        public void Add(Composer composer)
        {
            this._composerRepo.Insert(composer);
        }

        public bool Delete(int id)
        {
            var entity = this._composerRepo.GetById(id);
            this._composerRepo.Delete(entity);
            return true;
        }

        public void Edit(Composer composer)
        {
            this._composerRepo.Update(composer);
        }

        public IEnumerable<Composer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Composer GetById(int id)
        {
            return this._composerRepo.GetById(id);
        }
    }
}
