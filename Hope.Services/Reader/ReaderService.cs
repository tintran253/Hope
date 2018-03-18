using System;
using System.Collections.Generic;
using System.Text;
using Hope.Core;

namespace Hope.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IRepository<Reader> _readerRepository;
        public ReaderService(IRepository<Reader> readerRepository)
        {
            _readerRepository = readerRepository;
        }
        public void Add(Reader reader)
        {
            this._readerRepository.Insert(reader);
        }
    }
}
