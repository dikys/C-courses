using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public static class ProcessorBuilder
    {
        public static ProcessorBuilderWithEngine<TEngine> CreateEngine<TEngine>()
        {
            return new ProcessorBuilderWithEngine<TEngine>();
        }
    }
    public class ProcessorBuilderWithEngine<TEngine>
    {
        public ProcessorBuilderWithEngineAndEntity<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorBuilderWithEngineAndEntity<TEngine,TEntity>();
        }
    }
    public class ProcessorBuilderWithEngineAndEntity<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
    public class Processor<TEngine, TEntity, TLogger>
    { }
}
