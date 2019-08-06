using NDC.Model;
using NDC.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDC.UI.Wrapper
{
    public class EmployeesWrapper : ModelWrapper<Employee>
    {
        public EmployeesWrapper(Employee model) : base(model)
        {
            
        }

        public Guid Id {
            get { return GetValue<Guid>(); }
        }

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

        public bool IsActive
        {
            get { return GetValue<bool>(); }
            set
            {
                SetValue(value);
            }
        }

        //public decimal Treshold { get; set; }
        public decimal Treshold
        {
            get { return GetValue<decimal>(); }
            set
            {
                SetValue(value);
            }
        }

        public Guid? DepartmentId
        {
            get { return GetValue<Guid?>(); }
            set
            {
                SetValue(value);
            }
        }

        public Department DepartmentOfEmployee
        {
            get { return GetValue<Department>(); }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            
            switch (propertyName)
            {
                case nameof(Name):
                    
                    if (!Regex.IsMatch(Name, @"^[a-zA-Z âãäåçèéêìíîðñòóôõùúûü]+$"))
                    {
                        yield return "Letters only";
                    }
                    break;
                case nameof(Code):
                    
                    if (!Regex.IsMatch(Code, @"^[a-zA-Z ]+$"))
                    {
                        yield return "Letters only";
                    }
                    break;
            }
        }
    }

}

