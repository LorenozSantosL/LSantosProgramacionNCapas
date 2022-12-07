using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Departamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Departamento.svc or Departamento.svc.cs at the Solution Explorer and start debugging.
    public class Departamento : IDepartamento
    {
        public SL_WCF.Result Add(ML.Departamento departamento)
        {
            ML.Result  result = BL.Departamento.AddEF(departamento);
            return new SL_WCF.Result { Correct = result.Correct, EX = result.EX, Message = result.Message };
        }

        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Departamento.GetAll();

            return new SL_WCF.Result { Correct = result.Correct, EX = result.EX, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Update(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateEF(departamento);

            return new SL_WCF.Result { Correct = result.Correct, EX = result.EX, Message = result.Message };
        }

        public SL_WCF.Result GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetById(IdDepartamento);

            return new SL_WCF.Result { Correct = result.Correct, EX = result.EX, Message = result.Message, Object = result.Object };
        }

        public SL_WCF.Result Delete(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.Delete(IdDepartamento);

            return new SL_WCF.Result { Correct = result.Correct, Message = result.Message, EX = result.EX };
        }
    }
}
