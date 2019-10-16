using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProectWindowsFormsApp1.Model;
using ProectWindowsFormsApp1.Repository;
namespace ProectWindowsFormsApp1.BLL
{
   public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomer(Customers customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        //public bool UpdateCustomer(Customer customer)
        //{
        //    return _customerRepository.UpdateCustomer(customer);
        //}

        //public List<District> ComboDistricts()
        //{
        //    return _customerRepository.ComboDistricts();
        //}

        public List<Customers> Display()
       {
            return _customerRepository.Display();
        }

        public bool IsCodeUniqe(String code)
        {
            return _customerRepository.IsCodeUniqe(code);
        }

        public bool IsContactUniqe(String contact)
        {
            return _customerRepository.IsContactUniqe(contact);
        }
        //public double GetLoyaltiPointById(Customers customers)
        //{
        //    return _customerRepository.GetLoyaltiPointById(customers);
        //}
        //public List<Customer> SearchCustomerByCode(Customer customer)
        //{
        //    return _customerRepository.SearchCustomerByCode(customer);
        //}
    }
}
