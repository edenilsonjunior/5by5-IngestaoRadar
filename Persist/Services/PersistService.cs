﻿using Models;
using Repositories;

namespace Services
{
    public class PersistService
    {
        private PersistRepository _repository;

        public PersistService()
        {
            _repository = new();
        }

        public List<Radar> LoadData() => _repository.LoadData();

        public bool Insert(List<Radar> list) => _repository.Insert(list);

    }
}
