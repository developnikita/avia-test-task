using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Avia.Flight.Service.Entities;
using CsvHelper;

namespace Avia.Flight.Service.Repositories
{
    public class CsvRepository<CsvRecordType, TResult> : IReadOnlyRepository<TResult> where TResult : IEntity
    {
        public CsvRepository(string dataBasePath, Func<CsvRecordType, TResult> convertFromCsvToEntity)
        {
            using (var reader = new StreamReader(dataBasePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = Activator.CreateInstance<CsvRecordType>();
                _inMemoryDataBase = new BlockingCollection<TResult>(
                    new ConcurrentQueue<TResult>(csv.EnumerateRecords(record).Select(x => convertFromCsvToEntity(x)).ToList()));
            }
        }

        public TResult Get(int id)
        {
            return _inMemoryDataBase.Where(x => x.Id == id).FirstOrDefault();
        }

        public TResult Get(Expression<Func<TResult, bool>> filter)
        {
            return _inMemoryDataBase.Where(filter.Compile()).FirstOrDefault();
        }

        public IReadOnlyCollection<TResult> GetAll()
        {
            return _inMemoryDataBase;
        }

        public IReadOnlyCollection<TResult> GetAll(Expression<Func<TResult, bool>> filter)
        {
            return _inMemoryDataBase.Where(filter.Compile()).ToList();
        }

        private BlockingCollection<TResult> _inMemoryDataBase = new BlockingCollection<TResult>();
    }
}