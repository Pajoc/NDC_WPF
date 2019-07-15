using Gest.Model;
using Purchase.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDC.UI.Wrapper
{
    public class EmployeesWrapper : ModelWrapper<Employee>
    {
        public EmployeesWrapper(Employee model) : base(model)
        {

        }

        public Guid Id { get { return GetValue<Guid>(); } }

        public string Name
        {
            //1º get { return Model.Name; }
            //2º get { return GetValue<string>(nameof(Name)); }
            get { return GetValue<string>(); }

            set
            {
                //Model.Name = value;
                SetValue(value);
                //ValidateProperty(nameof(Name));
            }
        }
        public string Code
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public string MainEmail
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
    }

}

