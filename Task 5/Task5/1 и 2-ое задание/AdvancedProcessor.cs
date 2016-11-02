using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class AdvancedProcessor<TObject, TRequest>
    {
        private readonly Func<TRequest, bool> check;
        private readonly Func<TRequest, TObject> register;
        private readonly Action<TObject> save;

        public AdvancedProcessor(Func<TRequest, bool> check,
            Func<TRequest, TObject> register,
            Action<TObject> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }

        public TObject Process(TRequest request)
        {
            if (!this.check(request))
            {
                throw new ArgumentException();
            }

            var result = this.register(request);

            this.save(result);

            return result;
        }
    }
}
