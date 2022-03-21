using BILTIFUL.Core.Entidades.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BILTIFUL.Application.Repository.Base
{
    public class RepositoryDAT<TEntity> where TEntity : IEntidadeDAT<TEntity>, new()
    {
        public List<TEntity> entities;
        public string Path { get; set; }

        public RepositoryDAT()
        {
            entities = GetAll();
        }
        public RepositoryDAT(string path) : this()
        {
            Path = path;
        }

        public virtual List<TEntity> GetAll()
        {
            return ReadFile();
        }

        public virtual List<TEntity> GetAllByWhere(Func<TEntity, bool> where)
        {
            return GetAll().Where(where).ToList();
        }

        public virtual TEntity GetByWhere(Func<TEntity, bool> where)
        {
            return GetAll().FirstOrDefault(where);
        }

        public virtual TEntity Add(TEntity entity)
        {
            entities.Add(entity);
            WriteFile(entities);
            return entity;
        }

        public virtual List<TEntity> AddRange(List<TEntity> entity)
        {
            entity.ForEach(c => Add(c));
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            entities.Remove(entity);
            WriteFile(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            entities.Remove(entity);
            WriteFile(entities);
        }

        public virtual void WriteFile(List<TEntity> entities)
        {
            if (entities != null)
            {
                StreamWriter sw = new StreamWriter(Path);

                foreach (TEntity entity in entities)
                {
                    sw.WriteLine(entity.ConverterParaDAT());
                }

                sw.Close();
            }
        }

        public virtual List<TEntity> ReadFile()
        {
            List<TEntity> entitiesFile = new List<TEntity>();
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path);

                string line = sr.ReadLine();
                while (line != null && line != "")
                {
                    entitiesFile.Add(new TEntity().ExtrairDAT(line));
                    line = sr.ReadLine();
                }
                sr.Close();
            }

            return entities = entitiesFile;
        }

    }
}
